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

            foreach (var item in nodes)
            {
                Console.WriteLine(item.Attributes["href"].Value);
                
            }
        }
    }
}
