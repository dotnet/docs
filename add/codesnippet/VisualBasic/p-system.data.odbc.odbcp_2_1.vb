    Public Sub CreateParameterCollection(command As OdbcCommand)
        Dim paramCollection As OdbcParameterCollection = _
            command.Parameters
        paramCollection.Add("@CategoryName", OdbcType.Char)
        paramCollection.Add("@Description", OdbcType.Char)
        paramCollection.Add("@Picture", OdbcType.Binary)
        Dim paramNames As String = ""
        Dim i As Integer
        For i = 0 To paramCollection.Count - 1
            paramNames += paramCollection(i).ToString() & _
                ControlChars.Cr
        Next i
        Console.WriteLine(paramNames)
        paramCollection.Clear()
    End Sub 