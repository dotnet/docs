Option Explicit On
Option Strict On
Imports System.Data
Imports System.Data.Odbc


Module Module1

    Sub Main()

    End Sub
    ' <Snippet1>
    Public Sub CreateOdbcParameter()
        Dim parameter As New OdbcParameter("Description", OdbcType.VarChar, _
            11, ParameterDirection.Output, True, 0, 0, "Description", _
            DataRowVersion.Current, "garden hose")
        Console.WriteLine(parameter.ToString())
    End Sub
    ' </Snippet1>

End Module
