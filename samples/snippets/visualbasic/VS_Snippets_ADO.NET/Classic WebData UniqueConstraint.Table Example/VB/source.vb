imports System
imports System.Xml
imports System.Data
imports System.Data.SqlClient
imports System.Data.Common
imports System.Windows.Forms 


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet
Protected DataGrid1 As DataGrid

' <Snippet1>
Private Sub GetTableFromConstraint()
    Dim dataTable As DataTable
    Dim uniqueConstraint As UniqueConstraint

    ' Get a UniqueConstraint.
    uniqueConstraint = _
        CType(DataSet1.Tables("Suppliers").Constraints(0), _
        UniqueConstraint)

    ' Get the DataTable.
    dataTable = uniqueConstraint.Table
End Sub
' </Snippet1>

End Class
