Imports System
Imports System.Data
Imports System.Windows.Forms

Public Class Form1
Inherits Form

Protected textBox1 As TextBox
Protected myDataSet as DataSet
Shared Sub Main()
End Sub

' <Snippet1>
Private Sub CreateDataSet
   myDataSet = new DataSet("myDataSet")
   ' Populates the DataSet with tables, relations, and
   ' constraints.
End Sub

Private Sub BindTextBoxToDataSet 
   ' Binds a TextBox control to a column in the DataSet.
   textBox1.DataBindings.Add _
   ("Text", myDataSet, "Suppliers.CompanyName")
End Sub
' </Snippet1>
End Class
