// <Snippet1>
using System;
using System.Numerics;

public class ComplexFormatter :IFormatProvider, ICustomFormatter
{
   public object GetFormat(Type formatType) 
   {   
      if (formatType == typeof(ICustomFormatter))
         return this;
      else
         return null;
   }
   
   public string Format(string format, object arg, 
                        IFormatProvider provider)
   {
      if (arg is Complex)
      {
         Complex c1 = (Complex) arg; 
         // Check if the format string has a precision specifier.
         int precision;
         string fmtString = String.Empty;
         if (format.Length > 1) {
            try {
               precision = Int32.Parse(format.Substring(1));
            }
            catch (FormatException) {
               precision = 0;
            }
            fmtString = "N" + precision.ToString();
         }
         if (format.Substring(0, 1).Equals("I", StringComparison.OrdinalIgnoreCase))
            return c1.Real.ToString(fmtString) + " + " + c1.Imaginary.ToString(fmtString) + "i";
         else if (format.Substring(0, 1).Equals("J", StringComparison.OrdinalIgnoreCase))
            return c1.Real.ToString(fmtString) + " + " + c1.Imaginary.ToString(fmtString) + "j";
         else
            return c1.ToString(format, provider);
      }
      else
      {
         if (arg is IFormattable)
            return ((IFormattable) arg).ToString(format, provider);
         else if (arg != null) 
            return arg.ToString();
         else
            return String.Empty;
      }                        
   }
}
// </Snippet1>

// <Snippet4> 
public class Example
{
   public static void Main()
   {
      Complex c1 = new Complex(12.1, 15.4);
      Console.WriteLine("Formatting with ToString():       " + 
                        c1.ToString());
      Console.WriteLine("Formatting with ToString(format): " + 
                        c1.ToString("N2"));
      Console.WriteLine("Custom formatting with I0:        " + 
                        String.Format(new ComplexFormatter(), "{0:I0}", c1));
      Console.WriteLine("Custom formatting with J3:        " + 
                        String.Format(new ComplexFormatter(), "{0:J3}", c1));
   }
}
// The example displays the following output:
//    Formatting with ToString():       (12.1, 15.4)
//    Formatting with ToString(format): (12.10, 15.40)
//    Custom formatting with I0:        12 + 15i
//    Custom formatting with J3:        12.100 + 15.400j
// </Snippet4>
