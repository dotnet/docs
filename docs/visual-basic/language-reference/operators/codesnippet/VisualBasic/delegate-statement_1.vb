    Delegate Function MathOperator( 
        ByVal x As Double, 
        ByVal y As Double 
    ) As Double

    Function AddNumbers( 
        ByVal x As Double, 
        ByVal y As Double 
    ) As Double
        Return x + y
    End Function

    Function SubtractNumbers( 
        ByVal x As Double, 
        ByVal y As Double
    ) As Double
        Return x - y
    End Function

    Sub DelegateTest( 
        ByVal x As Double, 
        ByVal op As MathOperator, 
        ByVal y As Double 
    )
        Dim ret As Double
        ret = op.Invoke(x, y) ' Call the method.
        MsgBox(ret)
    End Sub

    Protected Sub Test()
        DelegateTest(5, AddressOf AddNumbers, 3)
        DelegateTest(9, AddressOf SubtractNumbers, 3)
    End Sub