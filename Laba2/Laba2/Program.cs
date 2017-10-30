using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Laba2.Classes;

namespace Laba2
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] arr =
            {
                {1.17, 2, 3, -2, 6}, 
                {2, -0.17, -2, -3,6.64},
                {3,2,-1,-1.83,0.68},
                {2,-3,2,1,-12.08 }
            };
            Gaus gaus=new Gaus(arr);
            gaus.Count();
        }
    }
}
