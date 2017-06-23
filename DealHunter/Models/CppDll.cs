using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace DealHunter.Models
{
    public class CppDll
    {
        [DllImport("NumCompartordll.dll")]
        public static extern int dhintCompare(int x, int y);
    }
}