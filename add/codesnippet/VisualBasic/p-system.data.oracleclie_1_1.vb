    Public Sub CreateOracleParamColl(command As OracleCommand)
        Dim paramCollection As OracleParameterCollection = command.Parameters
        paramCollection.Add("pDName", OracleType.Varchar)
        paramCollection.Add("pLoc", OracleType.Varchar)
        Dim parameterNames As String = ""
        Dim i As Integer
        For i = 0 To paramCollection.Count - 1
            parameterNames &= paramCollection(i).ToString() & ControlChars.Cr
        Next i
        Console.WriteLine(parameterNames)
        paramCollection.Clear()
    End Sub 