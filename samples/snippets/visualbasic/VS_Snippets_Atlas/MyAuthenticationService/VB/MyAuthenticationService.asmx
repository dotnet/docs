<%-- <Snippet1> --%>
<%@ WebService Language="VB" Class="MyAuthenticationService" %>

Imports System.Web.Services
Imports System.Web.Script.Services

<ScriptService()> _
Public Class MyAuthenticationService
    Inherits System.Web.Services.WebService
    
    <WebMethod()> _
    Public Function Login(ByVal userName As String, _
        ByVal password As String, _
        ByVal createPersistentCookie As Boolean) As Boolean
        
        'Place code here.
        Return True
        
    End Function
    
    <WebMethod()> _
    Public Sub Logout()
        
        'Place code here.
        
    End Sub

End Class
' </Snippet1>
