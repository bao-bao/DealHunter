using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DealHunter.Models
{
    public class BasicGood
    {
        public string gid { get; set; }
        public string gname { get; set; }
        public int glow { get; set; }
        public int ghigh { get; set; }
        public string gstarttime { get; set; }
    }
}