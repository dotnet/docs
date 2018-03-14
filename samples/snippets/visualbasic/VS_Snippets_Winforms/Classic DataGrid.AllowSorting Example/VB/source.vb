imports System
imports System.Data
imports System.Drawing
imports System.Windows.Forms

public class Form1
   Inherits Form

Shared Sub Main()
End Sub
Private DataGrid1 As DataGrid 

' <Snippet1>
Private Sub ToggleAllowSorting()

   ' Toggle the AllowSorting property.
   DataGrid1.AllowSorting = Not DataGrid1.AllowSorting
End Sub

' </Snippet1>
End Class
