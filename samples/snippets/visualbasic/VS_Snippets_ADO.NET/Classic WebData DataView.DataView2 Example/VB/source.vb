Option Explicit On
Option Strict On

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Odbc

Module Module1

    Sub Main()
    End Sub

    ' <Snippet1>
    Private Sub MakeDataView(ByVal dataSet As DataSet)
        Dim view As New DataView(dataSet.Tables("Suppliers"), _
            "Country = 'UK'", "CompanyName", _
            DataViewRowState.CurrentRows)
        view.AllowEdit = True
        view.AllowNew = True
        view.AllowDelete = True
    End Sub
    ' </Snippet1>

End Module
