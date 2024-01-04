using System;
using System.Collections.Generic;
using System.Text;

namespace SystemDateTimeReference
{
    public static class DateTimeComparisons
    {
        public static void Snippets()
        {
            TestRoughlyEquals();
        }

        // <Snippet1>
        public static bool RoughlyEquals(DateTime time, DateTime timeWithWindow, int windowInSeconds, int frequencyInSeconds)
        {
            long delta = (long)((TimeSpan)(timeWithWindow - time)).TotalSeconds % frequencyInSeconds;
            delta = delta > windowInSeconds ? frequencyInSeconds - delta : delta;
            return Math.Abs(delta) < windowInSeconds;
        }

        public static void TestRoughlyEquals()
        {
            int window = 10;
            int freq = 60 * 60 * 2; // 2 hours;

            DateTime d1 = DateTime.Now;

            DateTime d2 = d1.AddSeconds(2 * window);
            DateTime d3 = d1.AddSeconds(-2 * window);
            DateTime d4 = d1.AddSeconds(window / 2);
            DateTime d5 = d1.AddSeconds(-window / 2);

            DateTime d6 = (d1.AddHours(2)).AddSeconds(2 * window);
            DateTime d7 = (d1.AddHours(2)).AddSeconds(-2 * window);
            DateTime d8 = (d1.AddHours(2)).AddSeconds(window / 2);
            DateTime d9 = (d1.AddHours(2)).AddSeconds(-window / 2);

            Console.WriteLine($"d1 ({d1}) ~= d1 ({d1}): {RoughlyEquals(d1, d1, window, freq)}");
            Console.WriteLine($"d1 ({d1}) ~= d2 ({d2}): {RoughlyEquals(d1, d2, window, freq)}");
            Console.WriteLine($"d1 ({d1}) ~= d3 ({d3}): {RoughlyEquals(d1, d3, window, freq)}");
            Console.WriteLine($"d1 ({d1}) ~= d4 ({d4}): {RoughlyEquals(d1, d4, window, freq)}");
            Console.WriteLine($"d1 ({d1}) ~= d5 ({d5}): {RoughlyEquals(d1, d5, window, freq)}");

            Console.WriteLine($"d1 ({d1}) ~= d6 ({d6}): {RoughlyEquals(d1, d6, window, freq)}");
            Console.WriteLine($"d1 ({d1}) ~= d7 ({d7}): {RoughlyEquals(d1, d7, window, freq)}");
            Console.WriteLine($"d1 ({d1}) ~= d8 ({d8}): {RoughlyEquals(d1, d8, window, freq)}");
            Console.WriteLine($"d1 ({d1}) ~= d9 ({d9}): {RoughlyEquals(d1, d9, window, freq)}");
        }
        // The example displays output similar to the following:
        //    d1 (1/28/2010 9:01:26 PM) ~= d1 (1/28/2010 9:01:26 PM): True
        //    d1 (1/28/2010 9:01:26 PM) ~= d2 (1/28/2010 9:01:46 PM): False
        //    d1 (1/28/2010 9:01:26 PM) ~= d3 (1/28/2010 9:01:06 PM): False
        //    d1 (1/28/2010 9:01:26 PM) ~= d4 (1/28/2010 9:01:31 PM): True
        //    d1 (1/28/2010 9:01:26 PM) ~= d5 (1/28/2010 9:01:21 PM): True
        //    d1 (1/28/2010 9:01:26 PM) ~= d6 (1/28/2010 11:01:46 PM): False
        //    d1 (1/28/2010 9:01:26 PM) ~= d7 (1/28/2010 11:01:06 PM): False
        //    d1 (1/28/2010 9:01:26 PM) ~= d8 (1/28/2010 11:01:31 PM): True
        //    d1 (1/28/2010 9:01:26 PM) ~= d9 (1/28/2010 11:01:21 PM): True
        // </Snippet1>
    }
}
