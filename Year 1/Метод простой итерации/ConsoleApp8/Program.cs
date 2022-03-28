using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    class Program
    {
        public static int i = 1;
        static double Func(double x)
        {
            return Math.Pow(Math.E, 0.5 - x);
        }

        static double FuncOne(double x)
        {
            return Math.Pow(-1 * Math.E, 0.5 - x);

        }

        static double Iteration(double a, double b, double e)
        {
            double temp = (a + b) / 2;
            if (FuncOne(temp) < 1)
                return 0;

            double x0 = Func(temp);
            double x1 = Func(x0);
            while (true)
            {
                if (Math.Abs(x0 - x1) < e)
                    break;

                x0 = x1;
                x1 = Func(x0);
                Console.WriteLine("{0}: {1}", i++, x1);
            }
            Console.WriteLine("{0}: {1}", i++, x1);
            return x1;
        }

        static void Main(string[] args)
        {
            Console.Write("A: "); double a = double.Parse(Console.ReadLine());
            Console.Write("B: "); double b = double.Parse(Console.ReadLine());
            Console.Write("E: "); double e = double.Parse(Console.ReadLine());
            Console.WriteLine("==================================");
            Iteration(a, b, e);
        }
    }
}
