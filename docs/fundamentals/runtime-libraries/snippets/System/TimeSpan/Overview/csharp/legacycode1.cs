﻿using System;

public class Example
{
   public static void Main()
   {
      // <Snippet1>
      ShowFormattingCode();
      // Output from .NET Framework 3.5 and earlier versions:
      //       12:30:45
      // Output from .NET Framework 4:
      //       Invalid Format    

      Console.WriteLine("---");

      ShowParsingCode();
      // Output:
      //       000000006 --> 6.00:00:00

      void ShowFormattingCode()
      {
         TimeSpan interval = new TimeSpan(12, 30, 45);
         string output;
         try {
            output = String.Format("{0:r}", interval);
         }
         catch (FormatException) {
            output = "Invalid Format";
         }
         Console.WriteLine(output);
      }

      void ShowParsingCode()
      {
         string value = "000000006";
         try {
            TimeSpan interval = TimeSpan.Parse(value);
            Console.WriteLine("{0} --> {1}", value, interval);
         }
         catch (FormatException) {
            Console.WriteLine("{0}: Bad Format", value);
         }   
         catch (OverflowException) {
            Console.WriteLine("{0}: Overflow", value);
         }
      }
      // </Snippet1>   
   }   
}
