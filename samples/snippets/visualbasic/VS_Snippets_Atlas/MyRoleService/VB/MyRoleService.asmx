<%-- <Snippet1> --%>
<%@ WebService Language="VB" Class="MyRoleService" %>

Imports System.Web.Services
Imports System.Web.Script.Services

<ScriptService()> _
Public Class MyRoleService
    Inherits System.Web.Services.WebService
      
    <WebMethod()> _
    Public Function GetRolesForCurrentUser() As String()
    
        'Place code here.
        Return Nothing
        
    End Function
    
    <WebMethod()> _
    Public Function IsCurrentUserInRole(ByVal role As String) _
        As Boolean
        
        'Place code here.
        Return False
    
    End Function
  
End Class
' </Snippet1>