Option Explicit On
Option Strict On

Imports System.Data
Imports System.Data.OleDb

Module Module1

    Sub Main()

    End Sub

    ' <Snippet1>
    Public Sub CreateOleDbParameter()
        Dim parameter As New OleDbParameter( _
            "Description", OleDbType.VarChar, 11, _
            ParameterDirection.Output, True, 0, 0, _
            "Description", DataRowVersion.Current, "garden hose")
        Console.WriteLine(parameter.ToString())
    End Sub
    ' </Snippet1>
End Module
