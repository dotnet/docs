    Public Sub TestCallByName2()
        Dim col As New Collection()

        'Store the string "Item One" in a collection by 
        'calling the Add method.
        CallByName(col, "Add", CallType.Method, "Item One")

        'Retrieve the first entry from the collection using the 
        'Item property and display it using MsgBox().
        MsgBox(CallByName(col, "Item", CallType.Get, 1))
    End Sub