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
Private Sub GetPrimaryKey()
    Dim dataRelation As DataRelation
    Dim uniqueConstraint As UniqueConstraint

    ' Get a DataRelation from a DataSet.
    dataRelation = DataSet1.Relations("CustomerOrders")

    ' Get the ParentKeyConstraint.
    uniqueConstraint = dataRelation.ParentKeyConstraint

    ' Test if the IsPrimaryKey is true.
    If uniqueConstraint.IsPrimaryKey Then
       Console.WriteLine("IsPrimaryKey=True")
    Else
       Console.WriteLine("IsPrimaryKey=False")
    End If
 End Sub
 ' </Snippet1>

End Class
