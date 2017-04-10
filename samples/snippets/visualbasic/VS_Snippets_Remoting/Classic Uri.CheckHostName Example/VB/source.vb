Imports System
Imports System.Data
Imports System.Security.Principal
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    
    Protected Sub Method()
' <Snippet1>
 Console.WriteLine(Uri.CheckHostName("www.contoso.com"))

' </Snippet1>
    End Sub
End Class
