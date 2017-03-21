         // Creates a code expression for a CodeExpressionStatement to contain.
         array<CodeExpression^>^ temp = {gcnew CodePrimitiveExpression( "Example string" )};
         CodeExpression^ invokeExpression = gcnew CodeMethodInvokeExpression(
            gcnew CodeTypeReferenceExpression( "Console" ),"Write",temp );
         
         // Creates a statement using a code expression.
         CodeExpressionStatement^ expressionStatement;
         expressionStatement = gcnew CodeExpressionStatement( invokeExpression );
         
         // A C++ code generator produces the following source code for the preceeding example code:

         // Console::Write( "Example string" );