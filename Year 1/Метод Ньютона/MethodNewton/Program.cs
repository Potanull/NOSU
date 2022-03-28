using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodNewton
{
    class Program
    {
        static double Func(double x)
        {
            return x * x * x + 0.4 * x * x + 0.6 * x - 1.6;
        }

        static double FuncOne(double x)
        {
            return 3 * x * x + 0.8 * x + 0.6;
        }
        static double FuncTwo(double x)
        {
            return -1 / (x * x);
        }

        /// <summary>
        /// Метод Ньютона
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        static double Newton(double a, double b, double e)
        {
            double x0;

            if (Func(a) * FuncTwo(a) > 0)
                x0 = a;
            else if (Func(b) * FuncTwo(b) > 0)
                x0 = b;
            else
                return 0;

            double x1 = x0 - Func(x0) / FuncOne(x0);
            while (Math.Abs(x1 - x0) > e)
            {
                x0 = x1;
                x1 = x1 - Func(x1) / FuncOne(x1);
            }

            return x1;
        }

        static void Main(string[] args)
        {
            Console.Write("A: "); double a = double.Parse(Console.ReadLine());
            Console.Write("B: "); double b = double.Parse(Console.ReadLine());
            Console.Write("E: "); double e = double.Parse(Console.ReadLine());
            Console.WriteLine("===================================");
            Newton(a, b, e);
        }
    }
}
