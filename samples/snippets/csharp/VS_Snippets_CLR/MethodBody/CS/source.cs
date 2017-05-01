// 1 - (entire sample) MethodBody class
// 2 - (everything through GetMethodBody and displaying InitLocals & MaxStackSize)
// 3 - (displaying locals)
// 4 - (displaying exception clauses)
// 5 - (end of Main, example method, beginning of output through output for snippet 2)
// 6 - (output for snippet 3 (locals))
// 7 - (output for snippet 4 (clauses))
// 2,5 - InitLocals, MaxStackSize
// 2,3,5,6 - LocalVariables property, LocalVariableInfo class
// 2,4,5,7 - ExceptionHandlingClauses property, ExceptionHandlingClause class, ExceptionHandlingClauseFlags enum
//
//<Snippet1>
//<Snippet2>
using System;
using System.Reflection;

public class Example
{
    public static void Main()
    {
        // Get method body information.
        MethodInfo mi = typeof(Example).GetMethod("MethodBodyExample");
        MethodBody mb = mi.GetMethodBody();
        Console.WriteLine("\r\nMethod: {0}", mi);

        // Display the general information included in the 
        // MethodBody object.
        Console.WriteLine("    Local variables are initialized: {0}", 
            mb.InitLocals);
        Console.WriteLine("    Maximum number of items on the operand stack: {0}", 
            mb.MaxStackSize);
        //</Snippet2>
        //<Snippet3>

        // Display information about the local variables in the
        // method body.
        Console.WriteLine();
        foreach (LocalVariableInfo lvi in mb.LocalVariables)
        {
            Console.WriteLine("Local variable: {0}", lvi);
        }
        //</Snippet3>
        //<Snippet4>

        // Display exception handling clauses.
        Console.WriteLine();
        foreach (ExceptionHandlingClause ehc in mb.ExceptionHandlingClauses)
        {
            Console.WriteLine(ehc.Flags.ToString());

            // The FilterOffset property is meaningful only for Filter
            // clauses. The CatchType property is not meaningful for 
            // Filter or Finally clauses. 
            switch (ehc.Flags)
            {
                case ExceptionHandlingClauseOptions.Filter:
                    Console.WriteLine("        Filter Offset: {0}", 
                        ehc.FilterOffset);
                    break;
                case ExceptionHandlingClauseOptions.Finally:
                    break;
                default:
                    Console.WriteLine("    Type of exception: {0}", 
                        ehc.CatchType);
                    break;
            }

            Console.WriteLine("       Handler Length: {0}", ehc.HandlerLength);
            Console.WriteLine("       Handler Offset: {0}", ehc.HandlerOffset);
            Console.WriteLine("     Try Block Length: {0}", ehc.TryLength);
            Console.WriteLine("     Try Block Offset: {0}", ehc.TryOffset);
        }
        //</Snippet4>
//<Snippet5>
    }

    // The Main method contains code to analyze this method, using
    // the properties and methods of the MethodBody class.
    public void MethodBodyExample(object arg)
    {
        // Define some local variables. In addition to these variables,
        // the local variable list includes the variables scoped to 
        // the catch clauses.
        int var1 = 42;
        string var2 = "Forty-two";

        try
        {
            // Depending on the input value, throw an ArgumentException or 
            // an ArgumentNullException to test the Catch clauses.
            if (arg == null)
            {
                throw new ArgumentNullException("The argument cannot be null.");
            }
            if (arg.GetType() == typeof(string))
            {
                throw new ArgumentException("The argument cannot be a string.");
            }        
        }

        // There is no Filter clause in this code example. See the Visual 
        // Basic code for an example of a Filter clause.

        // This catch clause handles the ArgumentException class, and
        // any other class derived from Exception.
        catch(Exception ex)
        {
            Console.WriteLine("Ordinary exception-handling clause caught: {0}", 
                ex.GetType());
        }        
        finally
        {
            var1 = 3033;
            var2 = "Another string.";
        }
    }
}

// This code example produces output similar to the following:
//
//Method: Void MethodBodyExample(System.Object)
//    Local variables are initialized: True
//    Maximum number of items on the operand stack: 2
//</Snippet5>
//<Snippet6>
//
//Local variable: System.Int32 (0)
//Local variable: System.String (1)
//Local variable: System.Exception (2)
//Local variable: System.Boolean (3)
//</Snippet6>
//<Snippet7>
//
//Clause
//    Type of exception: System.Exception
//       Handler Length: 21
//       Handler Offset: 70
//     Try Block Length: 61
//     Try Block Offset: 9
//Finally
//       Handler Length: 14
//       Handler Offset: 94
//     Try Block Length: 85
//     Try Block Offset: 9
//</Snippet7>
//</Snippet1>



