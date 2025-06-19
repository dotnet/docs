// <Snippet1>
using System;
using System.Numerics;

public class ComplexFormatter : IFormatProvider, ICustomFormatter
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
        if (arg is Complex c1)
        {
            // Check if the format string has a precision specifier.
            int precision;
            string fmtString = string.Empty;
            if (format.Length > 1)
            {
                try
                {
                    precision = int.Parse(format.Substring(1));
                }
                catch (FormatException)
                {
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
            if (arg is IFormattable formattable)
                return formattable.ToString(format, provider);
            else if (arg != null)
                return arg.ToString();
            else
                return string.Empty;
        }
    }
}
// </Snippet1>

// <Snippet4>
public class CustomFormatEx
{
    public static void Run()
    {
        Complex c1 = new(12.1, 15.4);
        Console.WriteLine($"Formatting with ToString:         {c1}");
        Console.WriteLine($"Formatting with ToString(format): {c1:N2}");
        Console.WriteLine($"Custom formatting with I0:\t" +
            $"  {string.Format(new ComplexFormatter(), "{0:I0}", c1)}");
        Console.WriteLine($"Custom formatting with J3:\t" +
            $"  {string.Format(new ComplexFormatter(), "{0:J3}", c1)}");
    }
}

// The example displays the following output:
//    Formatting with ToString():       <12.1; 15.4>
//    Formatting with ToString(format): <12.10; 15.40>
//    Custom formatting with I0:        12 + 15i
//    Custom formatting with J3:        12.100 + 15.400j
// </Snippet4>

public class TestNegativeImaginary
{
    public static void Run()
    {
        // Test with positive imaginary part
        Complex c1 = new(12.1, 15.4);
        Console.WriteLine("=== Positive imaginary part ===");
        Console.WriteLine($"Complex number: {c1}");
        Console.WriteLine($"Custom formatting with I0: {string.Format(new ComplexFormatter(), "{0:I0}", c1)}");
        Console.WriteLine($"Custom formatting with J3: {string.Format(new ComplexFormatter(), "{0:J3}", c1)}");
        
        // Test with negative imaginary part - this should demonstrate the bug
        Complex c2 = new(12.1, -15.4);
        Console.WriteLine("\n=== Negative imaginary part ===");
        Console.WriteLine($"Complex number: {c2}");
        Console.WriteLine($"Custom formatting with I0: {string.Format(new ComplexFormatter(), "{0:I0}", c2)}");
        Console.WriteLine($"Custom formatting with J3: {string.Format(new ComplexFormatter(), "{0:J3}", c2)}");
        
        // Test with zero imaginary part
        Complex c3 = new(12.1, 0.0);
        Console.WriteLine("\n=== Zero imaginary part ===");
        Console.WriteLine($"Complex number: {c3}");
        Console.WriteLine($"Custom formatting with I0: {string.Format(new ComplexFormatter(), "{0:I0}", c3)}");
        Console.WriteLine($"Custom formatting with J3: {string.Format(new ComplexFormatter(), "{0:J3}", c3)}");
    }
}
