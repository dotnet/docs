    Sub DelegateTest( 
        ByVal x As Double, 
        ByVal op As MathOperator, 
        ByVal y As Double 
    )
        Dim ret As Double
        ret = op.Invoke(x, y) ' Call the method.
        MsgBox(ret)
    End Sub