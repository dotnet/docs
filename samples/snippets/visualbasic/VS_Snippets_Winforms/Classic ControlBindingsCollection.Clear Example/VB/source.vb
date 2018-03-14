Imports System
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    
    Protected groupBox1 As GroupBox    
    
' <Snippet1>
 Private Sub ClearAllBindings()
     Dim c As Control
     For Each c In  groupBox1.Controls
         c.DataBindings.Clear()
     Next c
 End Sub
' </Snippet1>
End Class
