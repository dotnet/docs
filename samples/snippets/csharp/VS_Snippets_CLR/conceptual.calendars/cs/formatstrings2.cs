﻿using System;

public class Example
{
   public static void Main()
   {
      // <Snippet9>
         DateTime dat = new DateTime(2012, 5, 1);
         Console.WriteLine("{0:MM-dd-yyyy g}", dat);
      // The example displays the following output:
      //     05-01-2012 A.D.
      // </Snippet9>
   }
}
