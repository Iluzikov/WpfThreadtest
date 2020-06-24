using System;
using System.Threading.Tasks;

namespace ConsoleThreadTest
{
    class Program
    {
        const int size = 100;
        static int[,] result;

        /// <summary>
        /// Заполняет двумерный массив
        /// </summary>
        /// <param name="arr"></param>
        static void FillArray(int[,] arr)
        {
            Random r = new Random();

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    arr[i, j] = r.Next(0, 10);
                }
            }
            Console.WriteLine("Массив заполнен!");
        }

        /// <summary>
        /// Умножение матриц
        /// </summary>
        /// <param name="m1"></param>
        /// <param name="m2"></param>
        /// <returns></returns>
        static void MultiplyMatrix(int[,] m1, int[,] m2)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Task t = new Task(() => MakeResult(i, j, m1, m2));
                    t.RunSynchronously();
                }
            }
        }

        static void MakeResult(int i, int j, int[,] m1, int[,] m2)
        {
            result[i, j] = 0;

            for (int k = 0; k < size; k++)
            {
                result[i, j] += m1[i, k] * m2[k, j];
            }
        }


        static void Main(string[] args)
        {
            int[,] matrix1 = new int[size, size];
            int[,] matrix2 = new int[size, size];
            result = new int[size, size];

            Parallel.Invoke(
                () => FillArray(matrix1),
                () => FillArray(matrix2)
                );


            MultiplyMatrix(matrix1, matrix2);

            Console.WriteLine("Матрицы перемножены!");

            Console.WriteLine("___________________________________________");
            Console.ReadLine();
        }
    }
}
