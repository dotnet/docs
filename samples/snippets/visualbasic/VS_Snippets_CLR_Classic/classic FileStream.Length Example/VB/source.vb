Imports System
Imports System.IO
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    
    Protected Sub Method(s As FileStream)
' <Snippet1>
 If s.Length = s.Position Then
     Console.WriteLine("End of file has been reached.")
 End If
' </Snippet1>
    End Sub
End Class
