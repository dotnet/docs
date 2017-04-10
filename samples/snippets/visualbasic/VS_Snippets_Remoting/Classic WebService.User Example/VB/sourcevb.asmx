' <Snippet1>
<%@ WebService Language="VB" Class="Util" %>
 
Imports System.Web.Services

Public Class Util
    Inherits WebService
    
    <WebMethod(Description := "Obtains the User Name", _
        EnableSession := False)> _
    Public Function GetUserName() As String
        
        Return User.Identity.Name
    End Function
End Class
    
' </Snippet1>
