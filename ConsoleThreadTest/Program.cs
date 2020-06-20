using System;
using System.Threading;
using System.Threading.Tasks;

// Написать приложение, считающее в раздельных потоках:
//  a. факториал числа N, которое вводится с клавиатуры;
//  b. сумму целых чисел до N.
//
// Лузиков Иван

namespace ConsoleThreadTest
{
    class Program
    {
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

            Console.WriteLine("Введите число: ");
            int number = int.Parse(Console.ReadLine());
            int factorial = 1;
            for (int i = 1; i < number; i++)
            {
                factorial *= i;
                if(i==number)
                    Console.Write($"{i} ");
                else
                    Console.Write($"{i} * ");
            }
            Console.Write($" = {factorial}");

            #region PrintEnum

            //Parallel.For(0, 3, PrintEnum);
            #endregion

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
