imports System
imports System.Xml
imports System.Data
imports System.Data.Common
imports System.Windows.Forms


Public Class Form1: Inherits Form

Protected DataSet1 As DataSet
Protected DataGrid1 As DataGrid

' <Snippet1>
Private Sub ComputeBySalesSalesID(ByVal dataSet As DataSet)
    ' Presumes a DataTable named "Orders" that has a column named "Total."
    Dim table As DataTable
    table = dataSet.Tables("Orders")

    ' Declare an object variable.
    Dim sumObject As Object
    sumObject = table.Compute("Sum(Total)", "EmpID = 5")
 End Sub
    ' </Snippet1>

End Class
