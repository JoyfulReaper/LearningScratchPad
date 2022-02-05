using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_DI
{
    internal class ConsoleApplication
    {
        private readonly ITestService _test;

        public ConsoleApplication(ITestService test)
        {
            _test = test;
        }

        public void Run()
        {
            Console.WriteLine("Hello Whirled");
            Console.WriteLine(_test.DoSomethingUseful());
        }
    }
}
