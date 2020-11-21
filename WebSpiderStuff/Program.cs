using System;

namespace WebSpiderStuff
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                ConsoleHelper.DefaultColor = ConsoleColor.Green;

                ConsoleHelper.ColorWriteLine("Please select a demo: ");
                Console.WriteLine();


                ConsoleHelper.ColorWriteLine(ConsoleColor.DarkYellow, "1. Random simple demos");
                ConsoleHelper.ColorWriteLine(ConsoleColor.DarkYellow, "2. URI Demo");
                ConsoleHelper.ColorWriteLine(ConsoleColor.DarkYellow, "3. WebCleint Demo");
                ConsoleHelper.ColorWriteLine(ConsoleColor.DarkYellow, "4. HtmlAgility Demo");
                ConsoleHelper.ColorWriteLine(ConsoleColor.DarkYellow, "9. Quit");

                Console.WriteLine();
                int choice = ConsoleHelper.GetValidInt("Please make your selection: ");

                ExecuteSelection(choice);
            }
        }

        public static void ExecuteSelection(int choice)
        {
            switch (choice)
            {
                case 1:
                    Console.WriteLine();
                    SimpleNetworkingDemos.DemoEntryPoint();
                    break;
                case 2:
                    SimpleNetworkingDemos.UriDemo();
                    break;
                case 3:
                    SimpleNetworkingDemos.WebClientDemo();
                    break;
                case 4:
                    HtmlAgilityPackDemo.DemoEntryPoint();
                    break;
                case 9:
                    Environment.Exit(0);
                    break;
                default:
                    ConsoleHelper.ColorWriteLine(ConsoleColor.Red, "\nInvalid selection!\n");
                    break;
            }
        }
    }
}
