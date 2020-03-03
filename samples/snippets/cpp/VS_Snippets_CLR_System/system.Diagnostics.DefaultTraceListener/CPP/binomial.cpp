// <Snippet1>
/////////////////////////////////////////////////////////////////////////////////
//
// NAME     DefaultTraceListener.cpp : main project file
//
// RUN:     DefaultTraceListener 4
// OUTPUT:
//
// DefaultTraceListener Sample
// Binomial( 4, 0 ) =  1
// Binomial( 4, 1 ) =  4
// Binomial( 4, 2 ) =  6
// Binomial( 4, 3 ) =  4
// Binomial( 4, 4 ) =  1
//
/////////////////////////////////////////////////////////////////////////////////
#using <System.dll>

using namespace System;
using namespace System::Diagnostics;

Decimal CalcBinomial(Decimal possibilities, Decimal outcomes)
{

    // Calculate a binomial coefficient, and minimize the chance of overflow.
    Decimal result = 1;
    Decimal iter;
    for(iter=1; iter<=possibilities-outcomes; iter++)
        {
        result *= outcomes+iter;
        result /= iter;
        }
    return result;
}


int main(array<System::String^>^ args)
{
    Console::WriteLine(L"DefaultTraceListener Sample");

    Decimal possibilities;
    Decimal iter;

    // Remove the original default trace listener.
    Trace::Listeners->RemoveAt(0);

    // Create and add a new default trace listener.
    DefaultTraceListener^ defaultListener = gcnew DefaultTraceListener();;

    Trace::Listeners->Add(defaultListener);

    // Assign the log file specification from the command line, if entered.
    if (args->Length>=2)
        defaultListener->LogFileName = args[1];

    // Validate the number of possibilities argument.
    if (args->Length>=1)

        // Verify that the argument is a number within the correct range.
        {
        try
            {
            const Decimal MAX_POSSIBILITIES = 99;
            possibilities = Decimal::Parse(args[0]);
            if (possibilities<0||possibilities>MAX_POSSIBILITIES)
                {
                throw gcnew Exception(String::Format("The number of possibilities must " +
                    "be in the range 0..{0}.", MAX_POSSIBILITIES));
                }
            }
        catch(Exception^ ex)
            {
            String^ failMessage = String::Format("\"{0}\" " +
                "is not a valid number of possibilities.", args[0]);
            defaultListener->Fail(failMessage, ex->Message);
            if (!defaultListener->AssertUiEnabled)
                Console::WriteLine(failMessage+ "\n" +ex->Message);
            return 0;
            }
        }
    else
        {
        // Report that the required argument is not present.
        String^ ENTER_PARAM = "Enter the number of " +
                  "possibilities as a command line argument.";
        defaultListener->Fail(ENTER_PARAM);
        if (!defaultListener->AssertUiEnabled)
            Console::WriteLine(ENTER_PARAM);
        return 1;
        }

    for(iter=0; iter<=possibilities; iter++)
        {
        Decimal result;
        String ^ binomial;

        // Compute the next binomial coefficient and handle all exceptions.
        try
            {
            result = CalcBinomial(possibilities, iter);
            }
        catch(Exception^ ex)
            {
            String^ failMessage = String::Format("An exception was raised when " +
                "calculating Binomial( {0}, {1} ).", possibilities, iter);
            defaultListener->Fail(failMessage, ex->Message);
            if (!defaultListener->AssertUiEnabled)
                Console::WriteLine(failMessage+ "\n" +ex->Message);
            return 0;
            }

        // Format the trace and console output.
        binomial = String::Format("Binomial( {0}, {1} ) = ", possibilities, iter);
        defaultListener->Write(binomial);
        defaultListener->WriteLine(result.ToString());
        Console::WriteLine("{0} {1}", binomial, result);
        }

return 1;
}
// </Snippet1>