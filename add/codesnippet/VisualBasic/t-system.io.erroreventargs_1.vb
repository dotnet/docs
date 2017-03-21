    Overloads Public Shared Sub Main(args() As String)
        ' Creates an exception with an error message.
        Dim myException As New Exception("This is an exception test")
        
        ' Creates an ErrorEventArgs with the exception.
        Dim myErrorEventArgs As New ErrorEventArgs(myException)
        
        ' Extracts the exception from the ErrorEventArgs and display it.
        Dim myReturnedException As Exception = myErrorEventArgs.GetException()
        MessageBox.Show(("The returned exception is: " & myReturnedException.Message))
    End Sub 'Main