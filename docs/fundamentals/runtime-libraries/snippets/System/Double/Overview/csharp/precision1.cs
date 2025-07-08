using System;

public class Example8
{
    public static void Main()
    {
        // <Snippet1>
        double value = -4.42330604244772E-305;

        double fromLiteral = -4.42330604244772E-305;
        double fromVariable = value;
        double fromParse = Double.Parse("-4.42330604244772E-305");

        Console.WriteLine("Double value from literal: {0,29:R}", fromLiteral);
        Console.WriteLine("Double value from variable: {0,28:R}", fromVariable);
        Console.WriteLine("Double value from Parse method: {0,24:R}", fromParse);
        // On 32-bit versions of the .NET Framework, the output is:
        //    Double value from literal:        -4.42330604244772E-305
        //    Double value from variable:       -4.42330604244772E-305
        //    Double value from Parse method:   -4.42330604244772E-305
        //
        // On other versions of the .NET Framework, the output is:
        //    Double value from literal:      -4.4233060424477198E-305
        //    Double value from variable:     -4.4233060424477198E-305
        //    Double value from Parse method:   -4.42330604244772E-305
        // </Snippet1>
    }
}
