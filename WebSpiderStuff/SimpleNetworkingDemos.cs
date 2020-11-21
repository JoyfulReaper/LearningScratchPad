using System;
using System.Net;
using System.Collections.Generic;
using System.Text;

namespace WebSpiderStuff
{
    public static class SimpleNetworkingDemos
    {
        public static void DemoEntryPoint()
        {
            // IPEndPoint Demo - IP address port combination
            Console.WriteLine("IPEndPoint Class represents an ip and port combintation (127.0.0.1:222): ");
            IPAddress a = IPAddress.Parse("127.0.0.1");
            IPEndPoint ep = new IPEndPoint (a, 222);
            Console.WriteLine(ep.ToString());



            Console.WriteLine("\nEnd demo\n");
        }

        public static void UriDemo()
        {
            Console.Write("\nPlease enter a valid URI: ");
            string uri = Console.ReadLine();

            Uri u = null;

            try
            {
                u = new Uri(uri);
            } 
            catch(UriFormatException e)
            {
                Console.WriteLine("\nWhoa there! That wasn't a valid URI\n");
            }

            Console.WriteLine($"Scheme: {u.Scheme}");
            Console.WriteLine($"Host: {u.Host}");
            Console.WriteLine($"Port: {u.Port}");
            Console.WriteLine();
        }
    }
}
