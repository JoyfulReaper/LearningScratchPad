// Just some dumb event thing for no reason

using System;

namespace Something
{
    class Program
    {
        public static event EventHandler<string> TheEvent;

        static void Main(string[] args)
        {
            TheEvent += Program_TheEvent;

            Console.WriteLine("Enter something:");
            var something = Console.ReadLine();

            if(something.ToLower().Contains("the"))
            {
                TheEvent?.Invoke(null, something);
            }
        }

        private static void Program_TheEvent(object sender, string e)
        {
            Console.WriteLine("THE!");
        }
    }
}
