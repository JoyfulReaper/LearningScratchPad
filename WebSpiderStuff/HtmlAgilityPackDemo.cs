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
            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = web.Load("http://google.com");

            HtmlNode[] nodes = document.DocumentNode.SelectNodes("//a").ToArray();

            List<Uri> links = new List<Uri>();

            foreach (var item in nodes)
            {
                string link = item.Attributes["href"].Value;

                try
                {
                    links.Add(new Uri(link));
                }
                catch(UriFormatException e)
                {
                    ConsoleHelper.ColorWriteLine(ConsoleColor.Red, $"ERORR: {link} is not a valid URI");
                }

                Console.WriteLine(item.Attributes["href"].Value);
            }


        }
    }
}
