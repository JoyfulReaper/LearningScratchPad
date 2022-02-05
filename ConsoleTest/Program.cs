using System;
using System.Collections.Generic;
using System.Text;

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

            Console.WriteLine();
            Console.Write("Length: ");
            var length = int.Parse(Console.ReadLine());

            var output = test(new StringBuilder[26 * length], 0, 'a', length);

            foreach(var s in output)
            {
                Console.WriteLine(s);
            }
        }

        static StringBuilder[] test(StringBuilder[] strings, int index, int pos, int length )
        {
            if (index == length)
                return strings;

            foreach(StringBuilder sb in strings)
            {
                sb.Append(pos);
            }

            if(pos > 'z')
            {
                index++;
            }

            
            return test(strings, index, pos++, length);
        }
    }
}
