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

                ConsoleHelper.ColorWriteLine(ConsoleColor.Cyan, $"I have followed {followedLinks.Count} links! I know about {allLinks.Count} links!");
                ConsoleHelper.ColorWriteLine(ConsoleColor.Cyan, $"Next to follow: {allLinks[linkNumber]}");
                ConsoleHelper.ColorWrite(ConsoleColor.Cyan, $"{allLinks.Count} Links found. About to follow the random link! Ready? Y/n: ");
                var ready = Console.ReadLine();

                if(ready == string.Empty || Char.ToUpper(ready[0]) == 'Y')
                //if(true)
                {
                    var newLinks = GetLinks(allLinks[linkNumber]);
                    followedLinks.Add(allLinks[linkNumber]);
                    AddLinks(newLinks);
                }
                else
                {
                    return;
                }
            }
        }

        private static void AddLinks(List<Uri> newLinks)
        {
            if(newLinks == null)
            {
                ConsoleHelper.ColorWriteLine(ConsoleColor.Magenta, "AddLinks(): newLinks was null!");
                return;
            }

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
            string input = String.Empty;

            try
            {
                Console.WriteLine("Enter seed URI: ");
                input = Console.ReadLine();
                seed = new Uri(input);
            }
            catch (UriFormatException e)
            {
                // Note must be a valid URI, so the Scheme is required
                // https://docs.microsoft.com/en-us/dotnet/api/system.uri?view=net-5.0

                if(!input.StartsWith("http"))
                {
                    Console.WriteLine("Did you forget to add the scheme?");
                    DemoEntryPoint();
                }

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
            HtmlDocument document = null;
            try
            {
               document = web.Load(link);
            }
            catch (System.Net.WebException e)
            {
                ConsoleHelper.ColorWriteLine($"Exception thrown: {e.Message}");
                return null;
            }

            HtmlNode[] nodes = document.DocumentNode.SelectNodes("//a")?.ToArray();
            if(nodes == null)
            {
                ConsoleHelper.ColorWriteLine(ConsoleColor.Magenta, "GetLinks(): nodes is null!");
                return null;
            }

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

                    if (!links.Contains(uri) && !followedLinks.Contains(uri))
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
                    ConsoleHelper.ColorWriteLine(ConsoleColor.Cyan, "Trying to convert to absolute!");

                    ConvertRelativeToAbsolute(link, foundLink, links);
                }

                Console.WriteLine(item.Attributes["href"].Value);
            }

            return links;
        }

        private static void ConvertRelativeToAbsolute(Uri link, string foundLink, List<Uri> links)
        {
            try
            {
                Uri fixedLink = new Uri(link, foundLink);
                ConsoleHelper.ColorWriteLine(ConsoleColor.Green, $"Converted link: {fixedLink}");

                if (!links.Contains(fixedLink) && !followedLinks.Contains(fixedLink))
                {
                    links.Add(fixedLink);
                }
            }
            catch (UriFormatException ex)
            {
                ConsoleHelper.ColorWriteLine(ConsoleColor.Red, $"Failed to convert link: {ex.Message}");
            }
        }
    }
}
