' <Snippet1>
<%@ WebService Language="VB" Class= "ServerVariables"%>
 
Imports System
Imports System.Web.Services

<WebService(Description := "Common Server Variables", _
 Namespace := "http://www.contoso.com/")> _
Public Class ServerVariables
    Inherits WebService 
    
    <WebMethod(Description := "Obtains the Computer Machine Name", _
        EnableSession := False)> _
    Public Function GetMachineName() As String
        
        Return Server.MachineName
    End Function
End Class
 
' </Snippet1>
