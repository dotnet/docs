#using <System.dll>

using namespace System;
using namespace System::Reflection;

public ref class Example
{
    // The Main method contains code to analyze this method, using
    // the properties and methods of the MethodBody class.
public:
    void MethodBodyExample(Object^ arg)
    {
        // Define some local variables. In addition to these variables,
        // the local variable list includes the variables scoped to 
        // the catch clauses.
        int var1 = 42;
        String^ var2 = "Forty-two";

        try
        {
            // Depending on the input value, throw an ArgumentException or 
            // an ArgumentNullException to test the Catch clauses.
            if (arg == nullptr)
            {
                throw gcnew ArgumentNullException("The argument cannot " +
                    "be null.");
            }
            if (arg->GetType() == String::typeid)
            {
                throw gcnew ArgumentException("The argument cannot " + 
                    "be a string.");
            }        
        }

        // There is no Filter clause in this code example. See the Visual 
        // Basic code for an example of a Filter clause.

        // This catch clause handles the ArgumentException class, and
        // any other class derived from Exception.
        catch (ArgumentException^ ex)
        {
            Console::WriteLine("Ordinary exception-handling clause caught:" +
                " {0}", ex->GetType());
        }        
        finally
        {
            var1 = 3033;
            var2 = "Another string.";
        }
    }
};

int main()
{ 
    // Get method body information.
    MethodInfo^ mi = 
        Example::typeid->GetMethod("MethodBodyExample");

    MethodBody^ mb = mi->GetMethodBody();
    Console::WriteLine("\r\nMethod: {0}", mi);

    // Display the general information included in the 
    // MethodBody object.
    Console::WriteLine("    Local variables are initialized: {0}", 
        mb->InitLocals);
    Console::WriteLine("    Maximum number of items on the operand " +
        "stack: {0}", mb->MaxStackSize);

    // Display information about the local variables in the
    // method body.
    Console::WriteLine();
    for each (LocalVariableInfo^ lvi in mb->LocalVariables)
    {
        Console::WriteLine("Local variable: {0}", lvi);
    }

    // Display exception handling clauses.
    Console::WriteLine();
    for each(ExceptionHandlingClause^ exhc in mb->ExceptionHandlingClauses)
    {
        Console::WriteLine(exhc->Flags.ToString());

        // The FilterOffset property is meaningful only for Filter
        // clauses. The CatchType property is not meaningful for 
        // Filter or Finally clauses. 
        switch(exhc->Flags)
        {
        case ExceptionHandlingClauseOptions::Filter:
            Console::WriteLine("        Filter Offset: {0}", 
                exhc->FilterOffset);
            break;
        case ExceptionHandlingClauseOptions::Finally:
            break;
        default:
            Console::WriteLine("    Type of exception: {0}", 
                exhc->CatchType);
            break;
        }

        Console::WriteLine("       Handler Length: {0}",
            exhc->HandlerLength);
        Console::WriteLine("       Handler Offset: {0}", 
            exhc->HandlerOffset);
        Console::WriteLine("     Try Block Length: {0}", exhc->TryLength);
        Console::WriteLine("     Try Block Offset: {0}", exhc->TryOffset);
    }
}

//This code example produces output similar to the following:
//
//Method: Void MethodBodyExample(System.Object)
//    Local variables are initialized: False
//    Maximum number of items on the operand stack: 4
//
//Local variable: System.ArgumentException (0)
//Local variable: System.String (1)
//Local variable: System.Int32 (2)
//Clause
//    Type of exception: System.ArgumentException
//       Handler Length: 29
//       Handler Offset: 78
//     Try Block Length: 65
//     Try Block Offset: 13
//Finally
//       Handler Length: 13
//       Handler Offset: 113
//     Try Block Length: 100
//     Try Block Offset: 13