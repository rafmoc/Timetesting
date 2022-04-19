using System;
using System.Diagnostics;
using System.Threading;

namespace TimeTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            TestsHandler(4);
        }

        static void PrintTime(int timesTested, TimeSpan funcOne, TimeSpan funcOneAv, TimeSpan funcTwo, TimeSpan funcTwoAv)
        {
            Console.WriteLine("Times Tested = " + timesTested);
            Console.WriteLine("");
            Console.WriteLine("Function 1 Sum = " + funcOne);
            Console.WriteLine("Function 2 Sum = " + funcTwo);
            Console.WriteLine("");
            Console.WriteLine("Function 1 Average = " + funcOneAv);
            Console.WriteLine("Function 2 Average = " + funcTwoAv);
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
                FunctionOne();
            }
            funcOneWatch.Stop();

            funcTwoWatch.Start();
            for (int i = 0; i < testTimes; i++)
            {
                FunctionTwo();
            }
            funcTwoWatch.Stop();

            funcOneSum = funcOneWatch.Elapsed;
            funcTwoSum = funcTwoWatch.Elapsed;

            PrintTime(testTimes, funcOneSum, new TimeSpan(funcOneSum.Ticks / testTimes), funcTwoSum, new TimeSpan(funcTwoSum.Ticks / testTimes));
        }

        static void FunctionOne()
        {
            Thread.Sleep(1000);
        }

        static void FunctionTwo()
        {
            for(int i = 0; i < 1000; i++)
            {
                Thread.Sleep(1);
            }
        }
    }
}
