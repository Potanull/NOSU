using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dichotomy
{
    class Program
    {
        static double Func(double x)
        {
            return x + Math.Log(x) - 0.5;
        }

        /// <summary>
        /// Метод дихотомии
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        static double Dichotomies(double a, double b, double e)
        {
            double c = (a + b) / 2;
            int i = 1;
            while (true)
            {
                if (Math.Abs(Func(c)) < e)
                    break;

                if (Func(a) * Func(c) < 0)
                    b = c;
                else
                    a = c;

                Console.WriteLine("{0}: {1}", i++, c);

                c = (a + b) / 2;
            }

            return c;
        }

        static void Main(string[] args)
        {
            Console.Write("A: "); double a = double.Parse(Console.ReadLine());
            Console.Write("B: "); double b = double.Parse(Console.ReadLine());
            Console.Write("E: "); double e = double.Parse(Console.ReadLine());
            Console.WriteLine("======================================");
            Console.WriteLine(Dichotomies(a, b, e));
            Console.WriteLine();
        }
    }
}
