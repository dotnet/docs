Imports System
Imports System.Data
Imports System.Security.Principal
Imports System.Windows.Forms

Public Class Form1
    Inherits Form
    
    Protected Sub Method()
' <Snippet1>
 Dim baseUri As New Uri("http://www.contoso.com/")
 Dim myUri As New Uri(baseUri, "catalog/shownew.htm?date=today")
        
 Console.WriteLine(myUri.AbsolutePath)

' </Snippet1>
    End Sub
End Class
