        static void Main()
        {
            // Declaration statement.
            int counter;

            // Assignment statement.
            counter = 1;

            // Error! This is an expression, not an expression statement.
            // counter + 1; 

            // Declaration statements with initializers are functionally
            // equivalent to  declaration statement followed by assignment statement:         
            int[] radii = { 15, 32, 108, 74, 9 }; // Declare and initialize an array.
            const double pi = 3.14159; // Declare and initialize  constant.          

            // foreach statement block that contains multiple statements.
            foreach (int radius in radii)
            {
                // Declaration statement with initializer.
                double circumference = pi * (2 * radius);

                // Expression statement (method invocation). A single-line
                // statement can span multiple text lines because line breaks
                // are treated as white space, which is ignored by the compiler.
                System.Console.WriteLine("Radius of circle #{0} is {1}. Circumference = {2:N2}",
                                        counter, radius, circumference);

                // Expression statement (postfix increment).
                counter++;

            } // End of foreach statement block
        } // End of Main method body.
    } // End of SimpleStatements class.
    /*
       Output:
        Radius of circle #1 = 15. Circumference = 94.25
        Radius of circle #2 = 32. Circumference = 201.06
        Radius of circle #3 = 108. Circumference = 678.58
        Radius of circle #4 = 74. Circumference = 464.96
        Radius of circle #5 = 9. Circumference = 56.55
    */