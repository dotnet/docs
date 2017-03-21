    Public Sub CreateOdbcParameter()
        Dim parameter As New OdbcParameter("Description", OdbcType.VarChar, _
            11, ParameterDirection.Output, True, 0, 0, "Description", _
            DataRowVersion.Current, "garden hose")
        Console.WriteLine(parameter.ToString())
    End Sub