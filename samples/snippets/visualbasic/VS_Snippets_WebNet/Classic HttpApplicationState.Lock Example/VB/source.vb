Imports System
Imports System.Web
Imports System.Web.UI



Public Class Page1
    Inherits Page
    
    Private Sub Page_Load(sender As Object, e As EventArgs)

' <Snippet1>
Application.Lock()
Application("MyCode") = 21
Application("MyCount") = Convert.ToInt32(Application("MyCount")) + 1
Application.UnLock()
' </Snippet1>
    End Sub 'Page_Load 
End Class 'Page1 
