using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleThreadTest
{
    class Program
    {
        const int size = 10000;
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
            Console.WriteLine("Done!");
        }

        static int[,] MultiplyMatrix(int[,] m1, int[,] m2)
        {
            int[,] result = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    result[i, j] = m1[i, j] * m2[i, j];
                }
            }
            return result;
        }




        static void ThreadMethod()
        {
            Thread.Sleep(5000);
            Console.WriteLine($"{Thread.CurrentThread.Name} - is ended");
        }

        static double MakeWork(int number)
        {
            double a = 1;

            for (int i = 0; i < 100000; i++)
                for (int j = 0; j < 10; j++)
                    a /= 1.01;
            Console.WriteLine(number);
            return a;
        }

        static void PrintNumber(int number)
        {
            double a = 1;

            for (int i = 0; i < 100000; i++)
                for (int j = 0; j < 50; j++)
                    a /= 1.01;
            Console.WriteLine(number);
        }

        static void PrintEnum(int n)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(n + " " + i);
            }
        }

        static void Main(string[] args)
        {
            int[,] matrix1 = new int[size, size];
            int[,] matrix2 = new int[size, size];

            Parallel.Invoke(
                () => FillArray(matrix1),
                () => FillArray(matrix2)
                );

            //FillArray(matrix1);
            //FillArray(matrix2);

            Console.Write(matrix1[1, 1]);
            Console.Write(" * ");
            Console.Write(matrix2[1, 1]);

            int[,] matrixMult = MultiplyMatrix(matrix1, matrix2);
            Console.Write(" = ");
            Console.WriteLine(matrixMult[1, 1]);




            //Parallel.For(0, 3, PrintEnum);


            #region PrintNumber

            //Parallel.For(0, 10, PrintNumber);
            #endregion

            #region MakeWork

            //var func = new Func<int, double>(MakeWork);
            //var result = func.BeginInvoke(1, null, null);
            //while (!result.IsCompleted)
            //    Console.Write(".");
            //var returnedValue = func.EndInvoke(result);
            //Console.WriteLine(returnedValue);
            #endregion

            #region ThreadMethod

            //Thread thread = new Thread(new ThreadStart(ThreadMethod));
            //thread.Name = "Second thread";
            //thread.Start();
            //Console.WriteLine("Waiting for thread end");
            //ThreadMethod();
            #endregion


            Console.WriteLine("___________________________________________");
            Console.ReadLine();
        }
    }
}
