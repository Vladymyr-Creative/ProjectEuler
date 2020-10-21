using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ProjectEuler
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();

            sw.Start();
            Problem3();
            sw.Stop();

            Console.WriteLine("Processor Time of current problem is >> " + sw.Elapsed);
            Console.ReadLine();
        }

        static void PrintProblemResult(int result)
        {
            Console.WriteLine("+++++++++++++++++");
            Console.WriteLine("The problem result is: ");
            Console.WriteLine(result);
            Console.WriteLine("+++++++++++++++++");
        }

        static void Problem1()
        {
            /*Если выписать все натуральные числа меньше 10, кратные 3 или 5, то получим 3, 5, 6 и 9.Сумма этих чисел равна 23.
            Найдите сумму всех чисел меньше 1000, кратных 3 или 5.*/

            int result = default;
            for (int i = 0; i < 10; i++) {
                if (i % 3 == 0 || i % 5 == 0) {
                    result += i;
                }
            }
            PrintProblemResult(result);
        }

        static void Problem2()
        {
            /*Четные числа Фибоначчи
            Каждый следующий элемент ряда Фибоначчи получается при сложении двух предыдущих. Начиная с 1 и 2, первые 10 элементов будут:
            1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...
            Найдите сумму всех четных элементов ряда Фибоначчи, которые не превышают четыре миллиона.*/

            int num1 = 1,
                num2 = 2,
                next;
            do {
                next = num1 + num2;
                num1 = num2;
                num2 = next;
                Console.WriteLine(next);
            }
            while (next < 4_000_000);
        }

        static void Problem3()
        {
            /*Простые делители числа 13195 - это 5, 7, 13 и 29.
            Каков самый большой делитель числа 600851475143, являющийся простым числом?*/
            
            /*Notice! I cant solve with huge number!*/
            //long target = 600_851_475_143;

            int target = 13195;
            List<int> primes = new List<int> {3};
            int divider = 3, largestPrime = default;
            bool goOn = true, isPrime;
            
            while (goOn) {
                if (divider % 2 == 0) {
                    divider++;
                    continue;
                }
                isPrime = false;
                foreach (int prime in primes) {
                    if ((divider > prime) && (divider % prime != 0)) {
                        isPrime = true;
                    }
                    else {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime) {
                    primes.Add(divider);
                    if (target % divider == 0) {
                        largestPrime = divider;
                    }
                }

                divider++;
                if (divider > target) {
                    goOn = false;
                }
            }

            PrintProblemResult(largestPrime);            
        }
    }
}
