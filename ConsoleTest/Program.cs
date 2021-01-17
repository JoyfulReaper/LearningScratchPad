using System;
using System.Collections.Generic;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            List<ConsoleColor> colors  = new List<ConsoleColor> { ConsoleColor.Red, ConsoleColor.Yellow, ConsoleColor.Blue };
            ConsoleHelper.MulticolorWriteLine(colors, "This is a test!");
            ConsoleHelper.MulticolorWriteLine(colors, "This is also a test!", true);
        }
    }
}
