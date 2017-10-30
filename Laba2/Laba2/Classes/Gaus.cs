using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2.Classes
{
    class Gaus
    {
        private double [,] koeficients;
        private double[,] koefUtils;
        private double[] answers;


        public double[,] Koeficients
        {
            get { return koeficients; }
            private set { koeficients = value; }
        }
        public double[,] KoefUtils {
            get { return koefUtils; }
            private set { koefUtils = value; }
        }
        public double[] Answers {
            get { return answers; }
            private set { answers = value; }
        }

        public Gaus(double[,] koeficients)
        {
            this.koeficients = koeficients;
            koefUtils = new double[koeficients.GetLength(0),koeficients.GetLength(1)];
            answers = new double[koeficients.GetLength(0)];
        }

        public double[] Count()
        {
            for (int i = 0; i < koeficients.GetLength(0); i++)
            {
                FindUtils(koeficients[i,i],i);
                NewKoeficients(i+1);
                PrintZero(i);
                Formatter(3);
                PrintRes();
            }
            CountAnswers();
            PrintAnswers();
            return Answers;
        }

        private void FindUtils(double staticKoeficient,int stage)
        {
            for (int i = stage; i < koeficients.GetLength(1); i++)
            {
                koefUtils[stage,i] = koeficients[stage,i] / staticKoeficient;
            }
        }

        private void NewKoeficients(int stage)
        {
            for (int i = stage; i < koeficients.GetLength(0); i++)
            {
                for (int j = stage; j < koeficients.GetLength(1); j++)
                {
                    koeficients[i, j] = koeficients[i, j] -  koeficients[i, stage-1]* koefUtils[stage-1, j];
                }
            }
        }

        private void PrintZero(int stage)
        {
            for (int i = 0; i < koeficients.GetLength(0); i++)
            {
                for (int j = 0; j < stage; j++)
                {
                    koeficients[i, j] = 0;
                }
            }
        }

        private void CountAnswers()
        {
            Console.WriteLine("I`m ALIVE SUKOBLEAT!!!!!!!!!!!!!!!!!!!!");
            answers[answers.Length - 1] = koeficients[koeficients.GetLength(0) - 1, koeficients.GetLength(1) - 1] /
                                          koeficients[koeficients.GetLength(0) - 1, koeficients.GetLength(1) - 2];
            int utilsKoefInd = koefUtils.GetLength(0) - 1;
            int countInKoefArr=2;
            double tmp = 0;
            for (int i = answers.Length-2 ; i >= 0; i--)
            {
                tmp = koefUtils[utilsKoefInd, koefUtils.GetLength(1) - 1];
                for (int j = koefUtils.GetLength(1)-2; j < i; j--)
                {
                    Console.WriteLine("J= " + j);
                    tmp -= koefUtils[utilsKoefInd, j] * answers[j+1];
                }
                answers[i] = tmp;
                utilsKoefInd--;
                countInKoefArr++;
            }
        }

        private void Formatter(int count)
        {
            for (int i = 0; i < koeficients.GetLength(0); i++)
            {
                for (int j = 0; j < koeficients.GetLength(1); j++)
                {
                    koeficients[i,j]= Math.Floor(koeficients[i, j] * Math.Pow(10,count) ) / Math.Pow(10, count);
                    koefUtils[i,j]= Math.Floor(koefUtils[i, j] * Math.Pow(10, count)) / Math.Pow(10, count);
                }
            }
        }
        
        private void PrintRes()
        {
            Console.WriteLine("Koeficients");
            for (int i = 0; i < koeficients.GetLength(0); i++)
            {
                for (int y = 0; y < koeficients.GetLength(1); y++)
                {
                    Console.Write("|" + koeficients[i, y] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("B: ");
            for (int i = 0; i < koefUtils.GetLength(0); i++)
            {
                for (int j = 0; j < koefUtils.GetLength(1); j++)
                {
                    Console.Write("| " + koefUtils[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }

        private void PrintAnswers()
        {
            for (int i = 0; i < answers.Length; i++)
            {
                Console.WriteLine("X"+(i+1)+" : "+answers[i]);
            }
        }
    }
}
