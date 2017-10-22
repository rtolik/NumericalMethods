using System;

namespace Laba1.Classes
{
    public class Range
    {
        public Range(double left, double right)
        {
            Left = left;
            Right = right;
        }

        public double Left { get; set; }
        public double Right { get; set; }

        public override string ToString()
        {
            return "Left: " + Left + " Right: " + Right;
        }
    }
}