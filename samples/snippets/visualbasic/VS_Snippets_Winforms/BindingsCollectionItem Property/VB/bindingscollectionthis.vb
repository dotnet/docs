Imports System
Imports System.Windows.Forms
Imports System.Data

Public Class Test
    Dim textBox1 As TextBox = new TextBox()
	Shared Sub Main()
End Sub
	
'<Snippet1>
Private Sub PrintValue()

   Dim myControlBindings As ControlBindingsCollection = _
   textBox1.DataBindings

   ' Get the Binding for the Text property.
   Dim myBinding As Binding = myControlBindings("Text")

   ' Assuming the data source is a DataTable.
   Dim drv As DataRowView = _
   CType( myBinding.BindingManagerBase.Current, DataRowView)

   ' Assuming a column named "custName" exists, print the value.
   Console.WriteLine(drv("custName"))
End Sub
'</Snippet1>
End Class
