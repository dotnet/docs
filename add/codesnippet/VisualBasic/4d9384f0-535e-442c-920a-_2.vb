    Sub TestCallByName1()
        'Set a property.
        CallByName(TextBox1, "Text", CallType.Set, "New Text")

        'Retrieve the value of a property.
        MsgBox(CallByName(TextBox1, "Text", CallType.Get))

        'Call a method.
        CallByName(TextBox1, "Hide", CallType.Method)
    End Sub