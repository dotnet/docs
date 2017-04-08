Imports System
Imports System.Windows.Forms

Public Class Form1
    Inherits Form    
    
' <Snippet1>
 Private Sub GetControl(myBindings As ControlBindingsCollection)
     Dim c As Control = myBindings.Control
     Console.WriteLine(c.ToString())
 End Sub
' </Snippet1>
End Class
