Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    Protected dataGrid1 As DataGrid
Shared Sub Main()
End Sub
    
' <Snippet1>
Private Sub SetBackColorAndBackgroundColor()
   ' Set the BackColor and BackgroundColor properties.
   dataGrid1.BackColor = System.Drawing.Color.Blue
   dataGrid1.BackgroundColor = System.Drawing.Color.Red
End Sub 
' </Snippet1>

End Class 'Form1 
