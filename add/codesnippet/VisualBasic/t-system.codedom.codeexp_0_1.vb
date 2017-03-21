        ' Creates a code expression for a CodeExpressionStatement to contain.
        Dim invokeExpression = New CodeMethodInvokeExpression( _
            New CodeTypeReferenceExpression("Console"), "Write", _
            New CodePrimitiveExpression("Example string"))

        ' Creates a statement using a code expression.
        Dim expressionStatement As CodeExpressionStatement
        expressionStatement = New CodeExpressionStatement(invokeExpression)

        ' A C# code generator produces the following source code for the preceeding example code:
        ' Console.Write( "Example string" );