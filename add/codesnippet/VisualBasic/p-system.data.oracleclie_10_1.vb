    Public Sub SearchOracleParams()
        ' ...
        ' create OracleParameterCollection parameters
        ' ...
        If Not parameters.Contains("DName") Then
            Console.WriteLine("ERROR: no such parameter in the collection")
        Else
            Console.WriteLine("Name: " & parameters("DName").ToString() & _
                "Index: " & parameters.IndexOf("DName").ToString())
        End If
    End Sub 