Imports System
Imports System.Xml
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.Common
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    Protected DataSet1 As DataSet
    Protected dataGrid1 As DataGrid
    
' <Snippet1>
 Private Sub CreateConstraint(dataSet As DataSet)
     ' Create the ForignKeyConstraint with two DataColumn objects.
     Dim parentCol As DataColumn = _
        dataSet.Tables("Customers").Columns("id")
     Dim childCol As DataColumn = _
        dataSet.Tables("Orders").Columns("OrderID")
     Dim fkeyConstraint As _
        New ForeignKeyConstraint("fkConstraint", parentCol, childCol)

     ' Test against existing members using the Equals method.
     Dim testConstraint As ForeignKeyConstraint
     For Each testConstraint In  dataSet.Tables("Orders").Constraints
         If fkeyConstraint.Equals(testConstraint) Then
             Console.WriteLine("Identical ForeignKeyConstraint!")
             ' Insert code to delete the duplicate object, 
             ' or stop the procedure.
         End If
     Next testConstraint
 End Sub
' </Snippet1>
End Class

