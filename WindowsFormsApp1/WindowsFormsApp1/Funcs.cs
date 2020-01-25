using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    static class Funcs
    {
        public static bool FuncUP(int c)
        {
            double i = Math.Ceiling(Convert.ToDouble(c / 4));
            for (int j = 0; j < i; j++)
            {
                c = c - 4;
                if (c - 2 == 0)
                    return true;
            }
            return false;
        }
    }
}
