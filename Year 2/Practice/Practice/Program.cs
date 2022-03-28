using Practice.Class;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    class Program
    {
        static void Input()
        {
            Console.WriteLine("Введите количество неизвестных");
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите коэффиценты матрицы системы");
            double[,] matrix = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                string[] str = Console.ReadLine().Split();
                for (int j = 0; j < n; j++)
                    matrix[i, j] = Convert.ToDouble(str[j]);
            }

            Console.WriteLine("Введите вектор свободных коэффицентов");
            double[] value = new double[n];
            string[] temp = Console.ReadLine().Split();
            for (int i = 0; i < n; i++)
                value[i] = double.Parse(temp[i]);

            SLE system = new SLE(new Matrix(matrix), new Vector(value));
            Console.WriteLine();
            
            Console.WriteLine("Метод Крамера");
            system.Kramer();

            Console.WriteLine("Метод обратной матрицы");
            system.InvertibleMatrix();

            Console.WriteLine("Метод Гаусса");
            system.Gauss();

            Console.WriteLine("Метод прогонки");
            system.TridiagonalMatrixAlgorithm();

            Console.WriteLine("Метод квадратных корней");
            system.CholeskyDecomposition();

            Console.WriteLine("Метод простых итераций");
            system.Itera(0.001);

            Console.WriteLine("Метод Зейделя");
            system.Seidel(0.001);
        }

        static void Main(string[] args)
        {
            Input();
        }
    }
}

public void Seidel(double eps)
{
    if (!data.IsSquare) { Console.WriteLine("Матрица не квадратная" + '\n'); return; }

    Matrix initMatrix = data.Copy();
    Vector initValue = value.Copy();
    if (!initMatrix.ChecIteratAlgo(initValue))
    { Console.WriteLine("Метод неподходит для решение данной системы" + '\n'); ; return; }

    Matrix L = new Matrix(initMatrix.Rows, initMatrix.Columns);
    Matrix U = new Matrix(data.Rows, data.Columns);
    Matrix E = Matrix.CreateIdentityMatrix(data.Rows);


    Matrix alpha = initMatrix.Copy();
    Vector x = new Vector(initMatrix.Rows);
    Vector x0 = initValue.Copy();
    int count = 0;

    for (int i = 0; i < initMatrix.Rows; i++)
    {
        for (int j = 0; j < initMatrix.Columns; j++)
            if (i != j)
                alpha[i, j] /= -alpha[i, i];
        x0[i] /= alpha[i, i];
        alpha[i, i] = 0;
    }

    if (alpha.NormColum >= 1 || alpha.NormRow >= 1)
    { Console.WriteLine("Метод неподходит для решение данной системы" + '\n'); return; }

    for (int i = 0; i < initMatrix.Rows; i++)
    {
        for (int j = 0; j < initMatrix.Columns; j++)
        {
            if (i <= j)
                U[i, j] = alpha[i, j];
            else
                L[i, j] = alpha[i, j];
        }
    }

    if (((E - L).CreateInvertibleMatrix() * U).NormColum >= 1 ||
            ((E - L).CreateInvertibleMatrix() * U).NormRow >= 1)
    { Console.WriteLine("Метод неподходит для решение данной системы" + '\n'); return; }

    Vector beta = x0.Copy();
    do
    {
        Vector temp = x.Copy();
        x = ((E - L).CreateInvertibleMatrix() * U) * x + ((E - L).CreateInvertibleMatrix()) * beta;
        x0 = temp.Copy();
        count++;
    } while ((x0 - x).Norm >= eps);

    Console.WriteLine("Кол-во итераций: {0}", count);
    x.Print();
}
