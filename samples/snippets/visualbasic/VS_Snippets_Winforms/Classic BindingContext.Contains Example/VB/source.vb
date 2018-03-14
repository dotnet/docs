Imports System
Imports System.Data
Imports System.Windows.Forms

Public Class Form1
 Inherits Form
 
 Protected textBox1 As TextBox
' <Snippet1>
 Private Sub TryContains(myDataSet As DataSet)
    Dim thisTable As DataTable
    ' Test each DataTable in a DataSet to see if it is bound to a BindingManagerBase.
    For Each thisTable In myDataSet.Tables
       Console.WriteLine(thisTable.TableName & ": " & Me.BindingContext.Contains(thisTable))
    Next
 End Sub

' </Snippet1>
End Class
