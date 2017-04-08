Option Explicit
Option Strict

Imports System
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms


Public Class Form1
   Inherits Form
   Protected textBox1 As TextBox
    
   ' <Snippet1>
   Private Sub ShowGetItemProperties()
      ' Create a new DataTable and add two columns.
      Dim dt As New DataTable()
      dt.Columns.Add("Name", Type.GetType("System.String"))
      dt.Columns.Add("ID", Type.GetType("System.String"))
      ' Add a row to the table.
      Dim dr As DataRow = dt.NewRow()
      dr("Name") = "Ann"
      dr("ID") = "AAA"
      dt.Rows.Add(dr)
        
      Dim myPropertyDescriptors As PropertyDescriptorCollection = _
      Me.BindingContext(dt).GetItemProperties()
      Dim myPropertyDescriptor As PropertyDescriptor = myPropertyDescriptors("Name")
      Console.WriteLine(myPropertyDescriptor.Name)
      Console.WriteLine(myPropertyDescriptor.GetValue(dt.DefaultView(0)))
   End Sub 'ShowGetItemProperties
    ' </Snippet1>
End Class 'Form1 
