      // Create an initialization expression for a new array of type Int32 with 10 indices
      CodeArrayCreateExpression^ ca1 = gcnew CodeArrayCreateExpression( "System.Int32",10 );

      // Declare an array of type Int32, using the CodeArrayCreateExpression ca1 as the initialization expression
      CodeVariableDeclarationStatement^ cv1 = gcnew CodeVariableDeclarationStatement( "System.Int32[]","x",ca1 );

      // A C# code generator produces the following source code for the preceeding example code:
      // int[] x = new int[10];