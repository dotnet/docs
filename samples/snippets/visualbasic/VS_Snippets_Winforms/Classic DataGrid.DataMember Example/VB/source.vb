imports System
imports System.Data
imports System.Drawing
imports System.Windows.Forms


Public Class Form1: Inherits Form

 Protected dataGrid1 As DataGrid
 private myDataSet as DataSet
' <Snippet1>
Private Sub SetSourceAndMember()
    Dim myDataSet As DataSet = New DataSet("myDataSet")
    Dim customersTable As DataTable = new DataTable("Customers")
    ' Insert code to set source to populate DataSet.
    
    ' Set DataSource and DataMember with SetDataBinding method.
    Dim member As String
    ' The name of a DataTable is Customers.
    member = "Customers"
    DataGrid1.SetDataBinding(myDataSet, member)
 End Sub

' </Snippet1>
End Class
