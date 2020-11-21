using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CrawlerFamiliarization
{
    public class AgilityFamiliarization
    {
        private string _seedLink;
        private HtmlWeb _web = new HtmlWeb();
        private HtmlDocument _doc;
        private List<string> Frontier;

        public AgilityFamiliarization(string seedLink)
        {
            _seedLink = seedLink;
            Frontier = new List<string>();
        }

        public void Crawl()
        {
            BuildFrontier(_seedLink);
            ExpandFrontier();
        }

        private void BuildFrontier(string link)
        {
            _doc = _web.Load(link);
            HtmlNode[] foundLinks = _doc.DocumentNode.SelectNodes("//a").ToArray();
            foreach (HtmlNode node in foundLinks)
            {
                string attribute;

                attribute = node.Attributes["href"]?.Value.ToString();
                if (attribute == null)
                {
                    Console.WriteLine("Link was null!");
                    return;
                }
                if (node != null)
                {
                    Frontier.Add(node.Attributes["href"].Value.ToString());
                }
            }
        }

        private void ExpandFrontier()
        {
            for (int i = 0; i < Frontier.Count; i++)
            {
                BuildFrontier(Frontier[i]);
                Frontier[i].Remove(i);
            }
            Console.WriteLine(Frontier.Count);
        }
    }
}