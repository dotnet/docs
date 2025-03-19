using System;

public class Example
{
   public static void Main()
   {
      // <Snippet17>
      DateTime thisDate1 = new DateTime(2011, 6, 10);
      Console.WriteLine("Today is " + thisDate1.ToString("MMMM dd, yyyy") + ".");

      DateTimeOffset thisDate2 = new DateTimeOffset(2011, 6, 10, 15, 24, 16,
                                                    TimeSpan.Zero);
      Console.WriteLine($"The current date and time: {thisDate2:MM/dd/yy H:mm:ss zzz}");
      // The example displays the following output:
      //    Today is June 10, 2011.
      //    The current date and time: 06/10/11 15:24:16 +00:00
      // </Snippet17>
   }
}
