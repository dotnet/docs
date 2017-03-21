using System;
using System.Globalization;

public enum DaysOfWeek { Monday=1, Tuesday=2 };

public class TestFormatting
{
   public static void Main()
   {
      long acctNumber;
      double balance; 
      DaysOfWeek wday; 
      string output;

      acctNumber = 104254567890;
      balance = 16.34;
      wday = DaysOfWeek.Monday;

      output = String.Format(new AcctNumberFormat(), 
                             "On {2}, the balance of account {0:H} was {1:C2}.", 
                             acctNumber, balance, wday);
      Console.WriteLine(output);

      wday = DaysOfWeek.Tuesday;
      output = String.Format(new AcctNumberFormat(), 
                             "On {2}, the balance of account {0:I} was {1:C2}.", 
                             acctNumber, balance, wday);
      Console.WriteLine(output);
   }
}
// The example displays the following output:
//       On Monday, the balance of account 10425-456-7890 was $16.34.
//       On Tuesday, the balance of account 104254567890 was $16.34.