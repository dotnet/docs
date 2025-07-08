// <Snippet8>
using System;

public class Example
{
   public static void Main()
   {
       DateTime dat = new DateTime(2009, 6, 15, 13, 45, 30,
                                   DateTimeKind.Unspecified);
       Console.WriteLine($"{dat} ({dat.Kind}) --> {dat:O}");

       DateTime uDat = new DateTime(2009, 6, 15, 13, 45, 30,
                                    DateTimeKind.Utc);
       Console.WriteLine($"{uDat} ({uDat.Kind}) --> {uDat:O}");

       DateTime lDat = new DateTime(2009, 6, 15, 13, 45, 30,
                                    DateTimeKind.Local);
       Console.WriteLine($"{lDat} ({lDat.Kind}) --> {lDat:O}\n");

       DateTimeOffset dto = new DateTimeOffset(lDat);
       Console.WriteLine($"{dto} --> {dto:O}");
   }
}
// The example displays the following output:
//    6/15/2009 1:45:30 PM (Unspecified) --> 2009-06-15T13:45:30.0000000
//    6/15/2009 1:45:30 PM (Utc) --> 2009-06-15T13:45:30.0000000Z
//    6/15/2009 1:45:30 PM (Local) --> 2009-06-15T13:45:30.0000000-07:00
//
//    6/15/2009 1:45:30 PM -07:00 --> 2009-06-15T13:45:30.0000000-07:00
// </Snippet8>
