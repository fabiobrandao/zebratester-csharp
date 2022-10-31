using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Zebra.Sdk.Comm;
using Zebra.Sdk.Printer;
using Zebra.Sdk.Printer.Discovery;

namespace ZebraTester
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string ip = txbIP.Text;
            string zplData = txbZplData.Text.Replace("\n", string.Empty);

            int quantity = int.Parse(txbQtd.Text);

            List<DataPrinter> dataPrint = new List<DataPrinter>();

            for (int i = 0; i < quantity; i++)
            {
                dataPrint.Add(new DataPrinter { Id = i + 1, ZplData = zplData, Send = false, Print = false });
            }

            Print(ip, dataPrint);
        }

        private void Print(string ipAddress, List<DataPrinter> dataPrint)
        {
            Connection connection = new TcpConnection(ipAddress, TcpConnection.DEFAULT_ZPL_TCP_PORT);
            ZebraPrinter printer = Connect(connection);

            if (printer == null)
            {
                MessageBox.Show("Printer not connected!");
                return;
            }

            var status = GetPrinterStatus(printer);

            if (status != Status.Ready)
            {
                MessageBox.Show("Printer status: " + status);
                return;
            }

            foreach (var data in dataPrint)
            {
                if (PrintOne(printer, data.ZplData))
                {
                    data.Send = true;

                    if (CheckPrintingStatus(printer))
                        data.Print = true;
                    else
                        break;
                }
            }

            var noPrinted = dataPrint.Where(x => x.Print == false).ToList();

            if (noPrinted != null && noPrinted.Count > 0)
            {
                MessageBox.Show("Press OK to Continue...");
                Print(ipAddress, noPrinted);
            }

            Disconnect(printer);

            MessageBox.Show("Done!");
        }

        private bool PrintOne(ZebraPrinter printer, string zplData)
        {
            try
            {
                if (GetPrinterStatus(printer) == Status.Ready)
                {
                    printer.Connection.Write(Encoding.UTF8.GetBytes(zplData));
                    return true;
                }

                return false;
            }
            catch (ConnectionException)
            {
                return false;
            }
        }

        private ZebraPrinter Connect(Connection printerConn)
        {
            ZebraPrinter printer = null;

            try
            {
                printerConn.Open();
                printer = ZebraPrinterFactory.GetInstance(printerConn);
            }
            catch (ConnectionException e)
            {
                Debug.WriteLine("Connection Exception: " + e.ToString());
            }
            catch (ZebraPrinterLanguageUnknownException e)
            {
                Debug.WriteLine("PrinterLanguage Exception: " + e.ToString());
            }

            return printer;
        }

        private ZebraPrinter Disconnect(ZebraPrinter printer)
        {
            try
            {
                printer.Connection.Close();
            }
            catch (ConnectionException e)
            {
                Debug.WriteLine("Connection Exception: " + e.ToString());
            }

            return printer;
        }

        private string GetPrinterStatus(ZebraPrinter printer)
        {
            try
            {
                PrinterStatus printerStatus = printer.GetCurrentStatus();

                if (printerStatus.isReadyToPrint)
                    return Status.Ready;
                else if (printerStatus.isPaused)
                    return Status.Paused;
                else if (printerStatus.isHeadOpen)
                    return Status.HeadOpen;
                else if (printerStatus.isPaperOut)
                    return Status.MediaOut;
                else if (printerStatus.isRibbonOut)
                    return Status.RibbonOut;
                else
                    return Status.CannotPrint;
            }
            catch (ConnectionException e)
            {
                return e.ToString();
            }
            catch (ZebraPrinterLanguageUnknownException e)
            {
                return e.ToString();
            }
        }

        private bool CheckPrintingStatus(ZebraPrinter printer)
        {
            PrinterStatus printerStatus = null;

            try
            {
                printerStatus = printer.GetCurrentStatus();

                while (printerStatus.numberOfFormatsInReceiveBuffer > 0 && printerStatus.isReadyToPrint)
                {
                    Thread.Sleep(100);
                    printerStatus = printer.GetCurrentStatus();
                }
            }
            catch (ConnectionException e)
            {
                Debug.WriteLine("Connection Exception: " + e.ToString());
            }

            return printerStatus.isReadyToPrint;
        }

        private void NetworkDiscovery()
        {
            try
            {
                NetworkDiscoveryHandler discoveryHandler = new NetworkDiscoveryHandler();
                NetworkDiscoverer.FindPrinters(discoveryHandler);

                while (!discoveryHandler.DiscoveryComplete)
                {
                    Thread.Sleep(10);
                }
            }
            catch (DiscoveryException e)
            {
                Debug.WriteLine("DiscoveryException Exception: " + e.ToString());
            }
        }

        private DiscoveredPrinter DiscoveryUSB()
        {
            DiscoveredPrinter discoveredPrinter = null;

            try
            {
                foreach (DiscoveredUsbPrinter usbPrinter in UsbDiscoverer.GetZebraUsbPrinters())
                {
                    discoveredPrinter = usbPrinter;
                }
            }
            catch (DiscoveryException e)
            {
                Debug.WriteLine("DiscoveryException Exception: " + e.ToString());
            }

            return discoveredPrinter;
        }

        public class Status
        {
            public static string Ready
            {
                get { return "Ready"; }
            }

            public static string Paused
            {
                get { return "Paused"; }
            }

            public static string HeadOpen
            {
                get { return "HeadOpen"; }
            }

            public static string MediaOut
            {
                get { return "MediaOut"; }
            }

            public static string RibbonOut
            {
                get { return "RibbonOut"; }
            }

            public static string CannotPrint
            {
                get { return "CannotPrint"; }
            }
        }
    }
}