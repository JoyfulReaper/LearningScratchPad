using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace WebSpiderStuff
{
    public class HtmlAgilityPackDemo
    {
        public static void DemoEntryPoint()
        {
            List<Uri> links = new List<Uri>(); // List of found URIs

            try
            {
                Console.WriteLine("Enter seed URI: ");
                var seed = Console.ReadLine();

                links = GetLinks(new Uri(seed)); // Get links for seed
            }
            catch(UriFormatException e)
            {
                // Note must be a valid URI, so the Scheme is required
                // https://docs.microsoft.com/en-us/dotnet/api/system.uri?view=net-5.0
                Console.WriteLine("\nPlease enter a valid seed URI!");
                DemoEntryPoint();
            }

            ConsoleHelper.ColorWriteLine(ConsoleColor.Cyan, "About to follow a link! Ready?");
            ConsoleHelper.ColorWriteLine(ConsoleColor.Cyan, $"Following: {links[0]}");
            Console.ReadLine();

            GetLinks(links[0]);
        }

        public static List<Uri> GetLinks(Uri link)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = web.Load(link);

            HtmlNode[] nodes = document.DocumentNode.SelectNodes("//a").ToArray();

            List<Uri> links = new List<Uri>();

            foreach (var item in nodes)
            {
                string foundLink = item.Attributes["href"]?.Value;

                try
                {
                    links.Add(new Uri(foundLink));
                }
                catch (UriFormatException e)
                {
                    // Note relative links need to be expanded to absoulute or they won't be valid here
                    ConsoleHelper.ColorWriteLine(ConsoleColor.Red, $"ERORR: {foundLink} is not a valid URI");
                }

                Console.WriteLine(item.Attributes["href"].Value);
            }

            return links;
        }
    }
}
