using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealHunter.Models
{
    public class Deal
    {
        public string uname { get; set; }
        public int low { get; set; }
        public int high { get; set; }
        public string des { get; set; }
        public string cellphone { get; set; }
        public string mail { get; set; }
    }
}