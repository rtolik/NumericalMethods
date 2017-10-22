using System;
using Laba1.Classes;

namespace Laba1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Range range = new Range(0.2,3);
            Func<double, double> func = Function;
            Func<double, double> derivative = Derivative;
            Console.WriteLine("Start range: "+ range);
            Console.WriteLine("\n");
            Execute.Bisection(range,func, 0.001f);
            range = new Range(0.2, 3);
            Console.WriteLine("\n");
            Execute.Chord(range,func,0.001);
            Console.WriteLine("\n");
            Execute.Attached(range,func,derivative,0.001);
            Console.WriteLine("\n");
            Execute.ChordAttached(range,func,derivative,0.001f);
            Console.WriteLine("\n");
            Execute.Iterations(range,func,Fi,0.001);
            //Console.WriteLine(Fi(Fi(0.2)));
        }

        public static double Function(double value)
        {
            return 2*Math.Log(value)-(1/value);
        }

        public static double Derivative(double value)
        {
            return 2 / value + 1 / Math.Pow(value, 2);
        }

        public static double Fi(double value)
        {
            return Math.Exp(1 / (2 * value));
        }
    }
}