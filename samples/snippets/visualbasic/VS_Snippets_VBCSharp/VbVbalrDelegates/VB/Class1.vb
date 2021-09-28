Class Class5adbba155a1d413fab3e3ff6cc0a4669
    ' How to: Pass Procedures to Another Procedure in Visual Basic

    ' Snippet 14 is from f799c518081740ccad0b4da846fdba57
    ' Delegate Statement

    ' <snippet14>
    ' <snippet1>
    Delegate Function MathOperator( 
        ByVal x As Double, 
        ByVal y As Double 
    ) As Double
    ' </snippet1>

    ' <snippet2>
    Function AddNumbers( 
        ByVal x As Double, 
        ByVal y As Double 
    ) As Double
        Return x + y
    End Function
    ' </snippet2>

    ' <snippet3>
    Function SubtractNumbers( 
        ByVal x As Double, 
        ByVal y As Double
    ) As Double
        Return x - y
    End Function
    ' </snippet3>

    ' <snippet4>
    Sub DelegateTest( 
        ByVal x As Double, 
        ByVal op As MathOperator, 
        ByVal y As Double 
    )
        Dim ret As Double
        ret = op.Invoke(x, y) ' Call the method.
        MsgBox(ret)
    End Sub
    ' </snippet4>

    ' <snippet5>
    Protected Sub Test()
        DelegateTest(5, AddressOf AddNumbers, 3)
        DelegateTest(9, AddressOf SubtractNumbers, 3)
    End Sub
    ' </snippet5>
    ' </snippet14>
End Class

Class Class7b2ed93285984355b2f75cedb23ee86f
    ' Delegates and the AddressOf Operator

    Dim WithEvents Button1 As Button
    Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    End Sub
    Public Sub Method6()
        ' <snippet6>
        AddHandler Button1.Click, New EventHandler(AddressOf Button1_Click)
        ' The following line of code is shorthand for the previous line.
        AddHandler Button1.Click, AddressOf Me.Button1_Click
        ' </snippet6>
    End Sub


    ' <snippet7>
    Delegate Sub DelegateType()
    Event AnEvent As DelegateType
    ' </snippet7>
End Class

Class Class8105a59d60d84ab5b2215899cdfacbf4
    ' AddressOf Operator

    Dim WithEvents Button1 As Button
    Private Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    End Sub
    Sub Form1_Load()
        ' <snippet8>
        ' Add the following line to Sub Form1_Load().
        AddHandler Button1.Click, AddressOf Button1_Click
        ' </snippet8>
    End Sub

    ' <snippet9>
    Public Sub CountSheep()
        Dim i As Integer = 1 ' Sheep do not count from 0.
        Do While (True) ' Endless loop.
            Console.WriteLine("Sheep " & i & " Baah")
            i = i + 1
            System.Threading.Thread.Sleep(1000) 'Wait 1 second.
        Loop
    End Sub

    Sub UseThread()
        Dim t As New System.Threading.Thread(AddressOf CountSheep)
        t.Start()
    End Sub
    ' </snippet9>

End Class

Class Classb56866aeabf94a5aa855486359455e9c
    ' Delegate Example

    ' <snippet11>
    Delegate Sub MySubDelegate(ByVal x As Integer)

    Protected Sub DelegateTest()
        Dim c1 As New class1
        ' Create an instance of the delegate.
        Dim msd As MySubDelegate = AddressOf c1.Sub1
        ' Call the method.
        msd.Invoke(10)
    End Sub

    Class class1
        Sub Sub1(ByVal x As Integer)
            MsgBox("The value of x is: " & CStr(x))
        End Sub
    End Class
    ' </snippet11>

End Class


