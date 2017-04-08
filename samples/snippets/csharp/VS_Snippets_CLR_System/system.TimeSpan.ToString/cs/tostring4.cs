// <Snippet4>
using System;
using System.Globalization;

public class Example
{
   public static void Main()
   {
      TimeSpan[] intervals = { new TimeSpan(38, 30, 15), 
                               new TimeSpan(16, 14, 30) }; 
      CultureInfo[] cultures = { new CultureInfo("en-US"), 
                                 new CultureInfo("fr-FR") };
      string[] formats = {"c", "g", "G", @"hh\:mm\:ss" };
      Console.WriteLine("{0,12}      Format  {1,22}  {2,22}\n", 
                        "Interval", cultures[0].Name, cultures[1].Name);

      foreach (var interval in intervals) {
         foreach (var fmt in formats)
            Console.WriteLine("{0,12}  {1,10}  {2,22}  {3,22}", 
                              interval, fmt, 
                              interval.ToString(fmt, cultures[0]), 
                              interval.ToString(fmt, cultures[1]));
         Console.WriteLine();
      }  
   }
}
// The example displays the following output:
//        Interval      Format                   en-US                   fr-FR
//    
//      1.14:30:15           c              1.14:30:15              1.14:30:15
//      1.14:30:15           g              1:14:30:15              1:14:30:15
//      1.14:30:15           G      1:14:30:15.0000000      1:14:30:15,0000000
//      1.14:30:15  hh\:mm\:ss                14:30:15                14:30:15
//    
//        16:14:30           c                16:14:30                16:14:30
//        16:14:30           g                16:14:30                16:14:30
//        16:14:30           G      0:16:14:30.0000000      0:16:14:30,0000000
//        16:14:30  hh\:mm\:ss                16:14:30                16:14:30
// </Snippet4>