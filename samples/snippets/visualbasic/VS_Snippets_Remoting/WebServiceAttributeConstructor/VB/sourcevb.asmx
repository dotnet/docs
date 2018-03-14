' <Snippet1>
<%@ WebService Language="VB" class= "ServerVariables"%>
 
Imports System
Imports System.Web.Services
Imports System.Web.Services.Protocols

<WebService(Namespace := "http://www.contoso.com/")> _
Public Class ServerVariables
    Inherits WebService

    <WebMethod(Description := "Returns the time as stored on the Server", _
        EnableSession := False)> _
    Public Function Time() As String
        
        Return Context.Timestamp.TimeOfDay.ToString()
    End Function
End Class

' </Snippet1>
