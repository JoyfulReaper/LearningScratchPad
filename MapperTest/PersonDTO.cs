using System;
using System.Collections.Generic;
using System.Text;

namespace MapperTest
{
    public class PersonDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return $"{LastName}, {FirstName}";
        }
    }
}
