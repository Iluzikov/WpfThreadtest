using System;
using System.Threading.Tasks;

namespace ConsoleThreadTest
{
    class Program
    {
        const int size = 100;

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

        static int[,] MultiplyMatrix(int[,] m1, int[,] m2)
        {
            int[,] result = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    result[i, j] = 0;

                    for (int k = 0; k < size; k++)
                    {
                        result[i, j] += m1[i, k] * m2[k, j];
                    }
                }
            }
            return result;
        }



        static void Main(string[] args)
        {
            int[,] matrix1 = new int[size, size];
            int[,] matrix2 = new int[size, size];

            Parallel.Invoke(
                () => FillArray(matrix1),
                () => FillArray(matrix2)
                );


            int[,] matrixMult = MultiplyMatrix(matrix1, matrix2);

            Console.WriteLine("Матрицы перемножены!");

            Console.WriteLine("___________________________________________");
            Console.ReadLine();
        }
    }
}
