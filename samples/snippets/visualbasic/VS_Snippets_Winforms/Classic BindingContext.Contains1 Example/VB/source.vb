Imports System
Imports System.Data
Imports System.Windows.Forms

Public Class Form1
 Inherits Form
 
 Protected textBox1 As TextBox
' <Snippet1>
 Private Sub TryContainsDataMember(myDataSet As DataSet)
    Dim trueorfalse As Boolean
    trueorfalse = Me.BindingContext.Contains(myDataSet, "Suppliers")
    Console.WriteLine(trueorfalse.ToString())
 End Sub

' </Snippet1>
End Class
