using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

// Написать приложение, считающее в раздельных потоках:
//  a. факториал числа N, которое вводится с клавиатуры;
//  b. сумму целых чисел до N.
//
// Лузиков Иван

namespace ConsoleThreadTest
{
    class Program
    {
        /// <summary>
        /// Считает Факториал числа
        /// </summary>
        /// <param name="number"></param>
        static void GetFactorial(object obj)
        {
            if(obj is int number)
            {
                int factorial = 1;
                for (int i = 1; i < number; i++)
                {
                    factorial *= i;
                    if (i == number)
                        Console.Write($"{i} ");
                    else
                        Console.Write($"{i} * ");
                }
                Console.Write($" = {factorial}");
            }
        }

        static void Main(string[] args)
        {

            Console.WriteLine("Введите число: ");
            int number = int.Parse(Console.ReadLine());
            Thread thread = new Thread(new ParameterizedThreadStart(GetFactorial));
            thread.Start(number);

            MessageBox.Show($"Откиньтесь на спинку кресла и наслаждайтесь подсчётом\n факториала числа: {number}");


            Console.WriteLine("___________________________________________");
            Console.ReadLine();
        }
    }
}
