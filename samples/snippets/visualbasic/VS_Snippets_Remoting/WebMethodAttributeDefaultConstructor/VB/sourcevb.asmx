' <Snippet1>
<%@ WebService Language="VB" Class="Util"%>

Imports System
Imports System.Web.Services

Public Class Util
    Inherits WebService
    
    Public Function GetUserName() As String
        Return User.Identity.Name
    End Function    
    
    <WebMethod> _
    Public Function GetMachineName() As String
        
        Return Server.MachineName
    End Function
End Class

' </Snippet1>
