using System;

public class Example1
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
            try
            {
                output = String.Format("{0:r}", interval);
            }
            catch (FormatException)
            {
                output = "Invalid Format";
            }
            Console.WriteLine(output);
        }

        void ShowParsingCode()
        {
            string value = "000000006";
            try
            {
                TimeSpan interval = TimeSpan.Parse(value);
                Console.WriteLine($"{value} --> {interval}");
            }
            catch (FormatException)
            {
                Console.WriteLine($"{value}: Bad Format");
            }
            catch (OverflowException)
            {
                Console.WriteLine($"{value}: Overflow");
            }
        }
        // </Snippet1>   
    }
}
