    Public Sub CreateOracleCommand(ByVal connection As OracleConnection, _
    ByVal queryString As String, ByVal prmArray() As OracleParameter)

        Dim command As New OracleCommand(queryString, connection)
        command.CommandText = _
            "SELECT * FROM Emp WHERE Job = :pJob AND Sal = :pSal"

        Dim j As Integer
        For j = 0 To prmArray.Length - 1
            command.Parameters.Add(prmArray(j))
        Next j

        Dim message As String = ""
        Dim i As Integer
        For i = 0 To command.Parameters.Count - 1
            message += command.Parameters(i).ToString() + ControlChars.Cr
        Next i

        Console.WriteLine(message)

        Dim reader As OracleDataReader = command.ExecuteReader
        While reader.Read
            Console.WriteLine(reader.GetValue(0))
        End While

    End Sub