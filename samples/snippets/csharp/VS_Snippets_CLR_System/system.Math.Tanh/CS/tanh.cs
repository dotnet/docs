//<snippet1>
// Example for the hyperbolic Math.Tanh( double ) method.
using System;

class DemoTanh 
{
    public static void Main() 
    {
        Console.WriteLine( 
            "This example of hyperbolic Math.Tanh( double )\n" +
            "generates the following output." );
        Console.WriteLine( 
            "\nEvaluate these hyperbolic identities " +
            "with selected values for X:" );
        Console.WriteLine( "   tanh(X) == sinh(X) / cosh(X)" );
        Console.WriteLine( 
            "   tanh(2 * X) == 2 * tanh(X) / (1 + tanh^2(X))" );

        UseTanh(0.1);
        UseTanh(1.2);
        UseTanh(4.9);

        Console.WriteLine( 
            "\nEvaluate [tanh(X + Y) == (tanh(X) + tanh(Y)) " +
            "/ (1 + tanh(X) * tanh(Y))]" +
            "\nwith selected values for X and Y:" );

        UseTwoArgs(0.1, 1.2);
        UseTwoArgs(1.2, 4.9);
    }

    // Evaluate hyperbolic identities with a given argument.
    static void UseTanh(double arg)
    {
        double tanhArg = Math.Tanh(arg);

        // Evaluate tanh(X) == sinh(X) / cosh(X).
        Console.WriteLine( 
            "\n                       Math.Tanh({0}) == {1:E16}\n" +
            "      Math.Sinh({0}) / Math.Cosh({0}) == {2:E16}",
            arg, tanhArg, (Math.Sinh(arg) / Math.Cosh(arg)) );

        // Evaluate tanh(2 * X) == 2 * tanh(X) / (1 + tanh^2(X)).
        Console.WriteLine( 
            "                   2 * Math.Tanh({0}) /", 
            arg, 2.0 * tanhArg );
        Console.WriteLine( 
            "             (1 + (Math.Tanh({0}))^2) == {1:E16}", 
            arg, 2.0 * tanhArg / (1.0 + tanhArg * tanhArg ) );
        Console.WriteLine( 
            "                       Math.Tanh({0}) == {1:E16}", 
            2.0 * arg, Math.Tanh(2.0 * arg) );
    }

    // Evaluate a hyperbolic identity that is a function of two arguments.
    static void UseTwoArgs(double argX, double argY)
    {
        // Evaluate tanh(X + Y) == (tanh(X) + tanh(Y)) / (1 + tanh(X) * tanh(Y)).
        Console.WriteLine( 
            "\n    (Math.Tanh({0}) + Math.Tanh({1})) /\n" + 
            "(1 + Math.Tanh({0}) * Math.Tanh({1})) == {2:E16}", 
            argX, argY, (Math.Tanh(argX) + Math.Tanh(argY)) /
            (1.0 + Math.Tanh(argX) * Math.Tanh(argY)) );
        Console.WriteLine( 
            "                       Math.Tanh({0}) == {1:E16}",
            argX + argY, Math.Tanh(argX + argY));
    }
}

/*
This example of hyperbolic Math.Tanh( double )
generates the following output.

Evaluate these hyperbolic identities with selected values for X:
   tanh(X) == sinh(X) / cosh(X)
   tanh(2 * X) == 2 * tanh(X) / (1 + tanh^2(X))

                       Math.Tanh(0.1) == 9.9667994624955819E-002
      Math.Sinh(0.1) / Math.Cosh(0.1) == 9.9667994624955819E-002
                   2 * Math.Tanh(0.1) /
             (1 + (Math.Tanh(0.1))^2) == 1.9737532022490401E-001
                       Math.Tanh(0.2) == 1.9737532022490401E-001

                       Math.Tanh(1.2) == 8.3365460701215521E-001
      Math.Sinh(1.2) / Math.Cosh(1.2) == 8.3365460701215521E-001
                   2 * Math.Tanh(1.2) /
             (1 + (Math.Tanh(1.2))^2) == 9.8367485769368024E-001
                       Math.Tanh(2.4) == 9.8367485769368024E-001

                       Math.Tanh(4.9) == 9.9988910295055444E-001
      Math.Sinh(4.9) / Math.Cosh(4.9) == 9.9988910295055433E-001
                   2 * Math.Tanh(4.9) /
             (1 + (Math.Tanh(4.9))^2) == 9.9999999385024030E-001
                       Math.Tanh(9.8) == 9.9999999385024030E-001

Evaluate [tanh(X + Y) == (tanh(X) + tanh(Y)) / (1 + tanh(X) * tanh(Y))]
with selected values for X and Y:

    (Math.Tanh(0.1) + Math.Tanh(1.2)) /
(1 + Math.Tanh(0.1) * Math.Tanh(1.2)) == 8.6172315931330645E-001
                       Math.Tanh(1.3) == 8.6172315931330634E-001

    (Math.Tanh(1.2) + Math.Tanh(4.9)) /
(1 + Math.Tanh(1.2) * Math.Tanh(4.9)) == 9.9998993913939649E-001
                       Math.Tanh(6.1) == 9.9998993913939649E-001
*/
//</snippet1>
