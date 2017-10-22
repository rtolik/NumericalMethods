using System;

namespace Laba1.Classes
{
    static class Execute
    {
        public static void Bisection(Range range, Func<double, double> func, float eps)
        {
            double middle = 0;
            int iterations = 0;
            while (Math.Abs(range.Left - range.Right) > eps)
            {
                middle = (range.Left + range.Right) / 2;
                if (func(middle) > 0 && func(range.Right) > 0)
                    range.Right = middle;
                else if (func(middle) > 0 && func(range.Left) > 0)
                    range.Left = middle;
                else if (func(middle) < 0 && func(range.Right) < 0)
                    range.Right = middle;
                else if (func(middle) < 0 && func(range.Left) < 0)
                    range.Left = middle;
                else
                    throw new BadRootExeption();
                iterations++;
            }
            middle = (range.Left + range.Right) / 2;
            double calcErr = Math.Floor(Math.Abs(range.Right - range.Left) * 1000000) / 1000000;
            Console.WriteLine("Method: Bisection" + "\nResult= " + middle + "\nNumber of iterations= " + iterations + "\nCalculation error= " + calcErr);
        }

        public static void Chord(Range range, Func<double, double> func, double eps)
        {
            double lastX;
            ChooseSide(range, func,out int iterations,out double currentX, out double staticDot);
            do
            {
                lastX = currentX;
                currentX = currentX- (func(currentX) * (staticDot - currentX) / (func(staticDot) - func(currentX)));
                iterations++;
            } while (Math.Abs(lastX-currentX)>=eps);
            double calcErr = Math.Floor(Math.Abs(lastX - currentX) * 1000000) / 1000000;
            PrintResult("Chord",currentX,iterations,calcErr);
        }


        public static void Attached(Range range, Func<double, double> func, Func<double, double> derivative, double eps)
        {
            double lastX = 0, currentX = 0;
            
            ChooseSide(range,func,out int iterations,out currentX,out _);
            do
            {
                lastX = currentX;
                currentX = lastX - (func(lastX) / derivative(lastX));
                iterations++;
            } while (Math.Abs(lastX - currentX) >= eps);
            double calcErr = Math.Floor(Math.Abs(lastX - currentX) * 1000000) / 1000000;
            PrintResult("Attached",currentX,iterations,calcErr);
        }
        
        public static void ChordAttached(Range range, Func<double, double> func, Func<double, double> derivate, double eps)
        {
            ChooseSide(range,func,out int iterations,out double rightDot, out double leftDot);
            do
            {
                rightDot = rightDot - func(rightDot) * (leftDot - rightDot) / (func(leftDot) - func(rightDot));
                leftDot = leftDot - func(leftDot) / derivate(leftDot);
                iterations++;
            } while (Math.Abs(rightDot-leftDot)>eps);
            double result=(rightDot+leftDot)/2;
            double calcErr = Math.Floor(Math.Abs(rightDot - leftDot) * 1000000) / 1000000;
            PrintResult("Chord-Attached",result,iterations,calcErr);
        }

        public static void Iterations(Range range, Func<double, double> func, Func<double, double> fi, double eps)
        {
            ChooseSide(range,func,out int iterations,out double currentX, out double staticDot);
            double lastX;
            currentX = (currentX - staticDot) / 2;
            do
            {
                lastX = currentX;
                currentX = fi(currentX);
                iterations++;
            } while (Math.Abs(currentX-lastX)>=eps);
            double calcErr = Math.Floor(Math.Abs(currentX - fi(currentX)) * 1000000) / 1000000;
            PrintResult("Iterations",currentX,iterations,calcErr);
        }

        private static void ChooseSide(Range range, Func<double, double> func,out int iterations, out double currentX, out double staticDot)
        {
            currentX = 0;
            iterations = 0;
            if (func(range.Left) > 0 && func(range.Right) < 0)
            {
                staticDot = range.Left;
                currentX = range.Right;
            }
            else if (func(range.Left) < 0 && func(range.Right) > 0)
            {
                staticDot = range.Right;
                currentX = range.Left;
            }
            else
                throw new BadRootExeption();
        }

        private static void PrintResult(string methodName, double result, int numOfIterations, double calculationError)
        {
            Console.WriteLine("Method: "+methodName + "\nResult= " + result + "\nNumber of iterations= " + numOfIterations + "\nCalculation error= " + calculationError);
        }
    }
}