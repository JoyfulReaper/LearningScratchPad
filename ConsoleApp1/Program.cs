using System;

namespace CrawlerFamiliarization
{
    partial class Program
    {
        static void Main()
        {
            AgilityFamiliarization af = new AgilityFamiliarization("https://google.com");
            af.Crawl();
        }
    }
}
