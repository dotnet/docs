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
Private Sub GetColsFromConstraint()
    Dim dataColumns() As DataColumn

    ' Get a named relation from a DataSet.
    Dim dataRelation As DataRelation
    dataRelation = DataSet1.Relations("CustomerOrders")

    ' Get the ParentKeyConstraint
    Dim uniqueConstraint As UniqueConstraint
    uniqueConstraint= dataRelation.ParentKeyConstraint

    ' Get the DataColumn objects being constrained.
    dataColumns = uniqueConstraint.Columns

    ' Print the column name of each column.
    Dim i As Integer
    For i = 0 to dataColumns.GetUpperBound(0)
       Console.Write(dataColumns(i).ColumnName)
    Next i
 End Sub
 ' </Snippet1>

End Class
