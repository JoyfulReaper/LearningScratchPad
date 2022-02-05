using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_DI
{
    public class TestService : ITestService
    {
        public string DoSomethingUseful()
        {
            return "This is useful";
        }
    }
}
