            ' Create an initialization expression for a new array of type Int32 with 10 indices
            Dim ca1 As New CodeArrayCreateExpression("System.Int32", 10)

            ' Declare an array of type Int32, using the CodeArrayCreateExpression ca1 as the initialization expression
            Dim cv1 As New CodeVariableDeclarationStatement("System.Int32[]", "x", ca1)

            ' A Visual Basic code generator produces the following source code for the preceeding example code:

            ' Dim x() As Integer = New Integer(9) {}