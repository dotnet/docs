// <Snippet1>
using System;
using System.Diagnostics;
using Microsoft.VisualBasic;

class DefaultTraceListenerMod
{

    private static DefaultTraceListener defaultListener;

    // <Snippet2>
    // args(0) is the number of possibilities for binomial coefficients.
    // args(1) is the file specification for the trace log file.
    public static void Main(string[] args)
    {

        decimal possibilities;

        // <Snippet3>
        // Remove the original default trace listener.
        Trace.Listeners.RemoveAt(0);

        // Add a new default trace listener.
        defaultListener = new DefaultTraceListener();
        Trace.Listeners.Add(defaultListener);
        // </Snippet3>

        // Assign the log file specification from the command line, if entered.
        if (args.Length>=2)
        {
            defaultListener.LogFileName = args[1];
        }

        // Validate the number of possibilities argument.
        if (args.Length>=1)

            // <Snippet5>
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
                    Console.WriteLine(failMessage+ "\n" + ex.Message);
                }
                return;
            }
            // </Snippet5>
        }
        else
        {
            // <Snippet6>
            // Request the required argument if it was not entered 
            // on the command-line.
            const string ENTER_PARAM = "Enter the number of " +
                      "possibilities as a command-line argument.";
            defaultListener.Fail(ENTER_PARAM);
            if (!defaultListener.AssertUiEnabled)
            {
                Console.WriteLine(ENTER_PARAM);
            }
            // </Snippet6>
            return;
        }

        decimal iter;
        for(iter=0; iter<=possibilities; iter++)
        {

            // <Snippet4>
            // Compute the next binomial coefficient.  
            // If an exception is thrown, quit.
            decimal result = CalcBinomial(possibilities, iter);
            if (result==0) {return;}

            // Format the trace and console output.
            string binomial = String.Format("Binomial( {0}, {1} ) = ", possibilities, iter);
            defaultListener.Write(binomial);
            defaultListener.WriteLine(result.ToString());
            Console.WriteLine("{0} {1}", binomial, result);
            // </Snippet4>
        }
    }
    // </Snippet2>

    // <Snippet7>
    public static decimal CalcBinomial(decimal possibilities, decimal outcomes)
    {

        decimal result = 1;
        try
        {
            // Calculate a binomial coefficient, and minimize the chance 
            // of overflow.
            decimal iter;
            for(iter=1; iter<=possibilities-outcomes; iter++)
            {
                result *= outcomes+iter;
                result /= iter;
            }
            return result;

        }
        catch(Exception ex)
        {
            string failMessage = String.Format("An exception was raised when " +
                "calculating Binomial( {0}, {1} ).", possibilities, outcomes);
            defaultListener.Fail(failMessage, ex.Message);
            if (!defaultListener.AssertUiEnabled)
            {
                Console.WriteLine(failMessage + "\n" + ex.Message);
            }
            return 0;
        }
    }
    // </Snippet7>
}
// </Snippet1>

