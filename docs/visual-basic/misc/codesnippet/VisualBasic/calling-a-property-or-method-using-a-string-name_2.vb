    Private Sub CallMath()
        Dim Math As New MathClass
        Me.TextBox1.Text = CStr(CallByName(Math, Me.TextBox2.Text, 
           Microsoft.VisualBasic.CallType.Method, TextBox1.Text))
    End Sub