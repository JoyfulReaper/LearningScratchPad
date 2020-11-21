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
            var links = GetLinks(new Uri("http://www.google.com"));

            Console.WriteLine("About to follow a link! Ready?");
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
                string foundLink = item.Attributes["href"].Value;

                try
                {
                    links.Add(new Uri(foundLink));
                }
                catch (UriFormatException e)
                {
                    ConsoleHelper.ColorWriteLine(ConsoleColor.Red, $"ERORR: {foundLink} is not a valid URI");
                }

                Console.WriteLine(item.Attributes["href"].Value);
            }

            return links;
        }
    }
}
