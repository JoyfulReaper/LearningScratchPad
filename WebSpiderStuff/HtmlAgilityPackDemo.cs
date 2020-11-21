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
        private static readonly Random r = new Random();
        private static readonly List<Uri> allLinks = new List<Uri>(); // List of found URIs
        private static readonly List<Uri> followedLinks = new List<Uri>(); // TODO track followed links

        public static void DemoEntryPoint()
        {
            Uri seed = GetSeedUri(); // Get starting point
            AddLinks(GetLinks(seed)); // Add links found from starting point
            followedLinks.Add(seed);

            while (true)
            {
                int linkNumber = r.Next(0, allLinks.Count); // Get a random index

                ConsoleHelper.ColorWriteLine(ConsoleColor.Cyan, $"I have followed {followedLinks.Count} links!");
                ConsoleHelper.ColorWriteLine(ConsoleColor.Cyan, $"Next to follow: {allLinks[linkNumber]}");
                ConsoleHelper.ColorWrite(ConsoleColor.Cyan, $"{allLinks.Count} Links found. About to follow the random link! Ready? Y/n: ");
                var ready = Console.ReadLine();

                if(Char.ToUpper(ready[0]) != 'Y' )
                {
                    return;
                }

                var newLinks = GetLinks(allLinks[linkNumber]);
                followedLinks.Add(allLinks[linkNumber]);
                AddLinks(newLinks);
            }
        }

        private static void AddLinks(List<Uri> newLinks)
        {
            foreach (var l in newLinks)
            {
                if (!allLinks.Contains(l))
                {
                    allLinks.Add(l);
                }
                else
                {
                    ConsoleHelper.ColorWriteLine(ConsoleColor.Magenta, $"AddLinks(): We already know about {l}, ignoring");
                }
            }
        }

        private static Uri GetSeedUri()
        {
            Uri seed = null;

            try
            {
                Console.WriteLine("Enter seed URI: ");
                var input = Console.ReadLine();
                seed = new Uri(input);
            }
            catch (UriFormatException e)
            {
                // Note must be a valid URI, so the Scheme is required
                // https://docs.microsoft.com/en-us/dotnet/api/system.uri?view=net-5.0
                Console.WriteLine("\nPlease enter a valid seed URI!");
                DemoEntryPoint();
            }

            return seed;
        }

        public static List<Uri> GetLinks(Uri link)
        {
            if(link.Scheme != "http" && link.Scheme != "https")
            {
                ConsoleHelper.ColorWriteLine(ConsoleColor.Magenta, "Scheme must be http or https");
                return null;
            }

            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = web.Load(link);

            HtmlNode[] nodes = document.DocumentNode.SelectNodes("//a").ToArray();

            List<Uri> links = new List<Uri>();

            foreach (var item in nodes)
            {
                string foundLink = item.Attributes["href"]?.Value;

                if(foundLink == null)
                {
                    Console.WriteLine("GetLinks(): foundLink was null!");
                    continue;
                }

                try
                {
                    Uri uri = new Uri(foundLink);

                    if (!links.Contains(uri)) // Not sure this will do what I want with reference types
                    {
                        links.Add(new Uri(foundLink));
                    }
                    else
                    {
                        ConsoleHelper.ColorWriteLine(ConsoleColor.Magenta, "GetLinks(): We already know about this link, ignoring");
                    }
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
