    Public Sub CreateOleDbParameter()
        Dim parameter As New OleDbParameter( _
            "Description", OleDbType.VarChar, 11, _
            ParameterDirection.Output, True, 0, 0, _
            "Description", DataRowVersion.Current, "garden hose")
        Console.WriteLine(parameter.ToString())
    End Sub