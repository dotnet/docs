Imports System
Imports System.Net

Public Class Sample
    
    
    Public Sub Method()
' <Snippet1>
 Dim myUri As New Uri("http://www.contoso.com/")
        
 Dim mySP As ServicePoint = ServicePointManager.FindServicePoint(myUri)

' </Snippet1>
    End Sub
End Class
