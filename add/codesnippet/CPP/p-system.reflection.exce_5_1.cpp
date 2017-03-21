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