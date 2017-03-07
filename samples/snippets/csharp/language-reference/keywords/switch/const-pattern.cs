// <Snippet1>
using System;

class Program
{
    static void Main()
    {
        switch (DateTime.Now.DayOfWeek)
        {
           case DayOfWeek.Sunday:
           case DayOfWeek.Saturday:
              Console.WriteLine("The weekend");
              break;
           case DayOfWeek.Monday:
              Console.WriteLine("The first day of the work week.");
              break;
           case DayOfWeek.Friday:
              Console.WriteLine("The last day of teh work week.");
              break;
           default:
              Console.WriteLine("The middle of the work week.");
              break;   
        }
    }
}
// The example displays output like the following:
//       The middle of the work week.
// </Snippet1>


