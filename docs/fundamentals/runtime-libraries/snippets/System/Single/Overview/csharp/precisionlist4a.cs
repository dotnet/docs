﻿// <Snippet17>
using System;
using System.IO;

public class Example
{
   public static void Main()
   {
      StreamWriter sw = new StreamWriter(@".\Singles.dat");
      Single[] values = { 3.2f/1.11f, 1.0f/3f, (float) Math.PI };
      for (int ctr = 0; ctr < values.Length; ctr++) {
         sw.Write(values[ctr].ToString());
         if (ctr != values.Length - 1)
            sw.Write("|");
      }      
      sw.Close();
      
      Single[] restoredValues = new Single[values.Length];
      StreamReader sr = new StreamReader(@".\Singles.dat");
      string temp = sr.ReadToEnd();
      string[] tempStrings = temp.Split('|');
      for (int ctr = 0; ctr < tempStrings.Length; ctr++)
         restoredValues[ctr] = Single.Parse(tempStrings[ctr]);   

      for (int ctr = 0; ctr < values.Length; ctr++)
         Console.WriteLine("{0} {2} {1}", values[ctr], 
                           restoredValues[ctr],
                           values[ctr].Equals(restoredValues[ctr]) ? "=" : "<>");
   }
}
// The example displays the following output:
//       2.882883 <> 2.882883
//       0.3333333 <> 0.3333333
//       3.141593 <> 3.141593
// </Snippet17>
