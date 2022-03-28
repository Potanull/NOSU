using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integral
{
    class CalculationOfACertainIntegral
    {
        /// <summary>
        /// Подынтегральная функция
        /// </summary>
        /// <param name="x">Аргумент</param>
        /// <returns></returns>
        static double Func(double x)
        {
            return Math.Cos(x * x + 0.6) / (0.7 + Math.Sin(0.8 * x + 1));
        }

        /// <summary>
        /// Метод левых прямоугольников
        /// </summary>
        /// <param name="a">Правая граница интегрирования</param>
        /// <param name="b">Левая граница интегрирования</param>
        /// <param name="n">Кол-во разбиений</param>
        /// <returns></returns>
        static double LeftRectangleMethod(double a, double b, int n)
        {
            double sum = 0;
            double h = (b - a) / n;
            double[] points = new double[n + 1];

            double x = a;
            for (int i = 0; i < points.Length; i++, x += h)
                points[i] = Func(x);

            for (int i = 0; i < n; i++)
                sum += points[i];

            return sum * h;
        }

        /// <summary>
        /// Метод правых прямоугольников
        /// </summary>
        /// <param name="a">Правая граница интегрирования</param>
        /// <param name="b">Левая граница интегрирования</param>
        /// <param name="n">Кол-во разбиений</param>
        /// <returns></returns>
        static double RightRectangleMethod(double a, double b, int n)
        {
            double sum = 0;
            double h = (b - a) / n;
            double[] points = new double[n + 1];

            double x = a;
            for (int i = 0; i < points.Length; i++, x += h)
                points[i] = Func(x);

            for (int i = 1; i <= n; i++)
                sum += points[i];

            return sum * h;
        }

        /// <summary>
        /// Метод средних прямоугольников
        /// </summary>
        /// <param name="a">Правая граница интегрирования</param>
        /// <param name="b">Левая граница интегрирования</param>
        /// <param name="n">Кол-во разбиений</param>
        /// <returns></returns>
        static double MiddleRectangleMethod(double a, double b, int n)
        {
            double sum = 0;
            double h = (b - a) / n;
            double[] points = new double[n + 1];

            double x = (2 * a + h) / 2;
            for (int i = 0; i < points.Length; i++, x += h)
                points[i] = x;

            for (int i = 0; i <= n - 1; i++)
                sum += Func(points[i]);

            return sum * h;
        }

        /// <summary>
        /// Метод трапеций
        /// </summary>
        /// <param name="a">Правая граница интегрирования</param>
        /// <param name="b">Левая граница интегрирования</param>
        /// <param name="n">Кол-во разбиений</param>
        /// <returns></returns>
        static double TrapezoidMethod(double a, double b, int n)
        {
            double h = (b - a) / n;
            double[] points = new double[n + 1];

            double sum = 0;
            double x = a;

            for (int i = 0; i < points.Length; i++, x += h)
                points[i] = Func(x);

            for (int i = 1; i < n; i++)
                sum += points[i];

            sum = (h / 2) * (points[0] + 2 * sum + points[n]);
            return sum;
        }

        /// <summary>
        /// Метод Симпсона
        /// </summary>
        /// <param name="a">Правая граница интегрирования</param>
        /// <param name="b">Левая граница интегрирования</param>
        /// <param name="n">Кол-во разбиений</param>
        /// <returns></returns>
        static double SimpsonMethod(double a, double b, int n)
        {
            if (n % 2 != 0)
                return 0;

            double h = (b - a) / n;
            double[] points = new double[n + 1];

            double sum = 0;

            double x = a;
            for (int i = 0; i < n + 1; i++, x += h)
                points[i] = Func(x);
            
            for (int i = 1; i <= n - 1; i += 2)
                sum += points[i - 1] + 4 * points[i] + points[i + 1];

            sum = (h / 3) * sum;
            return sum;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Введите область интегрирования и кол-во разбиений");
            Console.Write("A: "); double a = double.Parse(Console.ReadLine());
            Console.Write("B: "); double b = double.Parse(Console.ReadLine());
            Console.Write("H: "); int n = int.Parse(Console.ReadLine());
            Console.WriteLine("======================================================================");
            Console.WriteLine("Метод левых прямоугольников: {0}", LeftRectangleMethod(a, b, n));
            Console.WriteLine("Метод правых прямоугольников: {0}", RightRectangleMethod(a, b, n));
            Console.WriteLine("Метод средних прямоугольников: {0}", MiddleRectangleMethod(a, b, n));
            Console.WriteLine("Метод трапеций: {0}", TrapezoidMethod(a, b, n));
            Console.WriteLine("Метод Симпсона: {0}", SimpsonMethod(a, b, n));
            Console.WriteLine("======================================================================");
        }
    }
}
