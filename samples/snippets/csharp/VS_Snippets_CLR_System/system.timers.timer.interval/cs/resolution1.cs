// <Snippet2>
using System;
using System.Runtime.InteropServices;

public class Example
{
   [DllImport("kernel32.dll", SetLastError=true)]
   static extern bool GetSystemTimeAdjustment(out long lpTimeAdjustment,
                                              out long lpTimeIncrement,
                                              out bool lpTimeAdjustmentDisabled);
   
   public static void Main()
   {
      long timeAdjustment, timeIncrement = 0;
      bool timeAdjustmentDisabled;
      
      if (GetSystemTimeAdjustment(out timeAdjustment, out timeIncrement, 
                                  out timeAdjustmentDisabled)) {
         if (! timeAdjustmentDisabled)
            Console.WriteLine("System clock resolution: {0:N3} milliseconds", 
                              timeIncrement/10000.0);
         else
            Console.WriteLine("Unable to determine system clock resolution.");                     
      }
   }      
}
// The example displays output like the following:
//        System clock resolution: 15.600 milliseconds
// </Snippet2>