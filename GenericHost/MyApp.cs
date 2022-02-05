using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericHost
{
    internal class MyApp
    {
        private readonly TestService _service;

        public MyApp(TestService service)
        {
            _service = service;
        }
        public void Run()
        {
            Console.WriteLine("doing something now:");
            Console.WriteLine(_service.GetSomething());
        }
    }
}
