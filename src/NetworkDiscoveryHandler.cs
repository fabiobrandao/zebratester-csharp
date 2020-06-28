using System;
using System.Collections.Generic;
using Zebra.Sdk.Printer.Discovery;

namespace ZebraTester
{
    public class NetworkDiscoveryHandler : DiscoveryHandler
    {
        public bool DiscoveryComplete { get; private set; }
        List<DiscoveredPrinter> printers = new List<DiscoveredPrinter>();

        public void DiscoveryError(string message)
        {
            Console.WriteLine("An error occurred during dis  covery: {message}.");
            DiscoveryComplete = true;
        }

        public void DiscoveryFinished()
        {
            foreach (DiscoveredPrinter printer in printers)
            {
                Console.WriteLine(printer);
            }
            Console.WriteLine("Discovered {printers.Count} Link-OS™ printers.");
            DiscoveryComplete = true;
        }

        public void FoundPrinter(DiscoveredPrinter printer)
        {
            printers.Add(printer);
        }
    }
}
