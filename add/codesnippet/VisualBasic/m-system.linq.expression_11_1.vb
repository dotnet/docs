
        ' Lambda expression as data in the form of an expression tree.
        Dim expression As System.Linq.Expressions.Expression(Of Func(Of Integer, Boolean)) = Function(ByVal i) i < 5
        ' Compile the expression tree into executable code.
        Dim deleg As Func(Of Integer, Boolean) = expression.Compile()
        ' Invoke the method and print the output.
        MsgBox(String.Format("deleg(4) = {0}", deleg(4)))

        ' This code produces the following output:
        '
        ' deleg(4) = True
