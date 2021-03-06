﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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

            Parallel.For(0, 3, PrintEnum);


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
