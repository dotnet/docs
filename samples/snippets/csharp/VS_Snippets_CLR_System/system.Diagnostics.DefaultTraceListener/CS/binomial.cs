// <Snippet1>
// <Snippet11>
using System;
using System.Diagnostics;
using Microsoft.VisualBasic;

class Binomial
{

    // args(0) is the number of possibilities for binomial coefficients.
    // args(1) is the file specification for the trace log file.
    public static void Main(string[] args)
    {

        // <Snippet2>
        decimal possibilities;
        decimal iter;
        // </Snippet2>

        // <Snippet3>
        // Remove the original default trace listener.
        Trace.Listeners.RemoveAt(0);

        // <Snippet4>
        // Create and add a new default trace listener.
        // <Snippet5>
        DefaultTraceListener defaultListener;
        // </Snippet5>
        defaultListener = new DefaultTraceListener();
        Trace.Listeners.Add(defaultListener);

        // Assign the log file specification from the command line, if entered.
        if (args.Length>=2)
        {
            defaultListener.LogFileName = args[1];
        }
        // </Snippet4>
        // </Snippet3>

        // Validate the number of possibilities argument.
        if (args.Length>=1)

            // Verify that the argument is a number within the correct range.
        {
            try
            {
                const decimal MAX_POSSIBILITIES = 99;
                possibilities = Decimal.Parse(args[0]);
                if (possibilities<0||possibilities>MAX_POSSIBILITIES)
                {
                    throw new Exception(String.Format("The number of possibilities must " +
                        "be in the range 0..{0}.", MAX_POSSIBILITIES));
                }
            }
            catch(Exception ex)
            {
                string failMessage = String.Format("\"{0}\" " +
                    "is not a valid number of possibilities.", args[0]);
                defaultListener.Fail(failMessage, ex.Message);
                if (!defaultListener.AssertUiEnabled)
                {
                    Console.WriteLine(failMessage+ "\n" +ex.Message);
                }
                return;
            }
        }
        else
        {
            // <Snippet6>
            // Report that the required argument is not present.
            const string ENTER_PARAM = "Enter the number of " +
                      "possibilities as a command line argument.";
            defaultListener.Fail(ENTER_PARAM);
            if (!defaultListener.AssertUiEnabled)
            {
                Console.WriteLine(ENTER_PARAM);
            }
            // </Snippet6>
            return;
        }

        for(iter=0; iter<=possibilities; iter++)
        {
            // <Snippet7>
            decimal result;
            string binomial;

            // </Snippet7>
            // <Snippet8>
            // Compute the next binomial coefficient and handle all exceptions.
            try
            {
                // <Snippet9>
                result = CalcBinomial(possibilities, iter);
                // </Snippet9>
            }
            catch(Exception ex)
            {
                string failMessage = String.Format("An exception was raised when " +
                    "calculating Binomial( {0}, {1} ).", possibilities, iter);
                defaultListener.Fail(failMessage, ex.Message);
                if (!defaultListener.AssertUiEnabled)
                {
                    Console.WriteLine(failMessage+ "\n" +ex.Message);
                }
                return;
            }
            // </Snippet8>
            // <Snippet10>

            // Format the trace and console output.
            binomial = String.Format("Binomial( {0}, {1} ) = ", possibilities, iter);
            defaultListener.Write(binomial);
            defaultListener.WriteLine(result.ToString());
            Console.WriteLine("{0} {1}", binomial, result);
            // </Snippet10>
        }
    }

    public static decimal CalcBinomial(decimal possibilities, decimal outcomes)
    {

        // Calculate a binomial coefficient, and minimize the chance of overflow.
        decimal result = 1;
        decimal iter;
        for(iter=1; iter<=possibilities-outcomes; iter++)
        {
            result *= outcomes+iter;
            result /= iter;
        }
        return result;
    }
}
// </Snippet11>
// </Snippet1>



