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
        ///  а. Считает Факториал числа n
        /// </summary>
        /// <param name="number"></param>
        static void GetFactorial(long n)
        {
            long factorial = 1;
            for (long i = 1; i <= n; i++)
            {
                factorial *= i;
                if (i == n)
                    Console.Write($"{i} ");
                else
                    Console.Write($"{i} * ");
            }
            Console.Write($"Факториал = {factorial}\n");
            
        }

        /// <summary>
        /// Вычисляет сумму целыъ чисел
        /// </summary>
        /// <param name="n"></param>
        static void GetSumIntNumber(long n)
        {
            var res = (n * (n + 1)) / 2;
            Console.WriteLine($"Сумма целых чисел = {res}");
        }

        static void Main(string[] args)
        {
            Console.Write("Введите число: ");
            long num = long.Parse(Console.ReadLine());

            Parallel.Invoke(
                () => GetFactorial(num),
                () => GetSumIntNumber(num));

            MessageBox.Show($"Откиньтесь на спинку кресла и наслаждайтесь...");
            
            Console.WriteLine("\n___________________________________________");
            Console.ReadLine();
        }
    }
}
