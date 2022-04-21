using System;
using System.Diagnostics;
using System.Threading;

namespace TimeTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            TestsHandler(10000);
        }

        static void PrintTime(int timesTested, TimeSpan funcOne, TimeSpan funcTwo)
        {
            Console.WriteLine("Times Tested = " + timesTested);
            Console.WriteLine("");
            Console.WriteLine("Function 1 Sum = " + funcOne);
            Console.WriteLine("Function 2 Sum = " + funcTwo);
            Console.WriteLine("");
            Console.WriteLine("Function 1 Average = " + new TimeSpan(funcOne.Ticks / timesTested));
            Console.WriteLine("Function 2 Average = " + new TimeSpan(funcTwo.Ticks / timesTested));
            Console.ReadLine();
        }

        static void TestsHandler(int testTimes)
        {
            Stopwatch funcOneWatch = new Stopwatch();
            Stopwatch funcTwoWatch = new Stopwatch();

            TimeSpan funcOneSum, funcTwoSum;

            funcOneWatch.Start();
            for (int i = 0; i < testTimes; i++)
            {
                Fib1(24);
            }
            funcOneWatch.Stop();

            funcTwoWatch.Start();
            for (int i = 0; i < testTimes; i++)
            {
                Fib2(24);
            }
            funcTwoWatch.Stop();

            Console.WriteLine("Fib1 - " + Fib1(24));
            Console.WriteLine("Fib2 - " + Fib2(24));

            funcOneSum = funcOneWatch.Elapsed;
            funcTwoSum = funcTwoWatch.Elapsed;

            PrintTime(testTimes, funcOneSum, funcTwoSum);
        }

        //---------------------------------------------------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------------------------------------

        public static int Fib1(int n)
        {
            int[] tab = new int[n+1];
            tab[0] = 0;
            tab[1] = 1;
            for (int i = 2; i <= n; i++)
            {
                tab[i] = tab[i - 2] + tab[i - 1];
            }
            return tab[n];
        }

        public static int Fib2(int n)
        {
            if ((n == 0) || (n == 1))
            {
                return n;
            }
            else
                return Fib2(n - 1) + Fib2(n - 2);
        }

        /*static int Fib(int n)
        {
            return (n < 2) ? n : Fib(n - 1) + Fib(n - 2);
        }*/
    }
}


