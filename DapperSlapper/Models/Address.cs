﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperSlapper.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public string City { get; set; }
        public string StateAbr { get; set; }
        public string Zip { get; set; }
    }
}
