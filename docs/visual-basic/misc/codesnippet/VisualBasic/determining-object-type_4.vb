    Sub ShowType(ByVal Ctrl As Object)
        'Use the TypeName function to display the class name as text.
        MsgBox(TypeName(Ctrl))
        'Use the TypeOf function to determine the object's type.
        If TypeOf Ctrl Is Button Then
            MsgBox("The control is a button.")
        ElseIf TypeOf Ctrl Is CheckBox Then
            MsgBox("The control is a check box.")
        Else
            MsgBox("The object is some other type of control.")
        End If
    End Sub

    Protected Sub TestObject()
        'Test the ShowType procedure with three kinds of objects.
        ShowType(Me.Button1)
        ShowType(Me.CheckBox1)
        ShowType(Me.RadioButton1)
    End Sub