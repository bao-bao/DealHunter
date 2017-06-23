using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;

namespace SqlOperation
{
    public class CppDll
    {
        [DllImport("NumCompartordll.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern int dhintCompare(int x, int y);
    }
}