// <Snippet1>
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
// </Snippet1>

// <Snippet2>
public class AcctNumberFormat : IFormatProvider, ICustomFormatter
{
   private const int ACCT_LENGTH = 12;
   
   public object GetFormat(Type formatType)
   {
      if (formatType == typeof(ICustomFormatter))
         return this;
      else
         return null;
   }
   
   public string Format(string fmt, object arg, IFormatProvider formatProvider) 
   {
      // Provide default formatting if arg is not an Int64.
      if (arg.GetType() != typeof(Int64))
         try {
            return HandleOtherFormats(fmt, arg); 
         }
         catch (FormatException e) {
            throw new FormatException(String.Format("The format of '{0}' is invalid.", fmt), e);
         }
      
      // Provide default formatting for unsupported format strings.
      string ufmt = fmt.ToUpper(CultureInfo.InvariantCulture);
      if (! (ufmt == "H" || ufmt == "I")) 
         try {
            return HandleOtherFormats(fmt, arg);
         }
         catch (FormatException e) {
            throw new FormatException(String.Format("The format of '{0}' is invalid.", fmt), e);
         }
           
      // Convert argument to a string.
      string result = arg.ToString();
      
      // If account number is less than 12 characters, pad with leading zeroes.
      if (result.Length < ACCT_LENGTH)
         result = result.PadLeft(ACCT_LENGTH, '0');
      // If account number is more than 12 characters, truncate to 12 characters.
      if (result.Length > ACCT_LENGTH)
         result = result.Substring(0, ACCT_LENGTH);   

      if (ufmt == "I")                    // Integer-only format. 
         return result;
      // Add hyphens for H format specifier.
      else                                         // Hyphenated format.
         return result.Substring(0, 5) + "-" + result.Substring(5, 3) + "-" + result.Substring(8);
   }

   private string HandleOtherFormats(string format, object arg)
   {
      if (arg is IFormattable) 
         return ((IFormattable)arg).ToString(format, CultureInfo.CurrentCulture);
      else if (arg != null)
         return arg.ToString();
      else
         return String.Empty;
   }
}
// </Snippet2>
