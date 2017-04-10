' <Snippet1>
<%@ WebService Language="VB" class="MyUser" %>

Imports System.Web.Services
Imports System.Web.Services.Protocols

Public Class MyUser
    Inherits WebService
        
    <SoapDocumentMethod(Action := "http://www.contoso.com/GetUserName")> _
    Public Function _
        GetUserName() As String
        
        Return User.Identity.Name
    End Function
End Class

' </Snippet1>
