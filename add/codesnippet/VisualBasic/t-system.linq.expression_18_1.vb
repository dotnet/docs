
        ' Lambda expression as executable code.
        Dim deleg As Func(Of Integer, Boolean) = Function(ByVal i) i < 5
        ' Invoke the delegate and display the output.
        MsgBox(String.Format("deleg(4) = {0}", deleg(4)))

        ' Lambda expression as data in the form of an expression tree.
        Dim expr As System.Linq.Expressions.Expression(Of Func(Of Integer, Boolean)) = Function(ByVal i) i < 5
        ' Compile the expression tree into executable code.
        Dim deleg2 As Func(Of Integer, Boolean) = expr.Compile()
        ' Invoke the method and print the output.
        MsgBox(String.Format("deleg2(4) = {0}", deleg2(4)))

        ' This code produces the following output:
        '
        ' deleg(4) = True
        ' deleg2(4) = True
