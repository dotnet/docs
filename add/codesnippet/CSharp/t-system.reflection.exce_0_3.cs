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