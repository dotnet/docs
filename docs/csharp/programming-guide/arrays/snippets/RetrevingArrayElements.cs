using System;
using System.Collections.Generic;
using System.Text;

namespace arrays
{
    public class RetrevingArrayElements
    {
        public static void Examples()
        {
            Retreving();
        }

        private static void Retreving()
        {
            //<RetrevingDataArray>
            string[] weekDays2 = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };

            Console.WriteLine(weekDays2[0]);
            Console.WriteLine(weekDays2[1]);
            Console.WriteLine(weekDays2[2]);
            Console.WriteLine(weekDays2[3]);
            Console.WriteLine(weekDays2[4]);
            Console.WriteLine(weekDays2[5]);
            Console.WriteLine(weekDays2[6]);

            /*Output:
            Sun
            Mon
            Tue
            Wed
            Thu
            Fri
            Sat
            */
            //</RetrevingDataArray>
        }
    }
}
