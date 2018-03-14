' <Snippet1>
<%@ WebService Language="VB" class= "ServerVariables"%>
 
Imports System.Web.Services

<WebService(Description := "Server Variables", _
    Namespace := "http://www.microsoft.com/", _
    Name := "MyName")> _
Public Class ServerVariables
    Inherits WebService
    
    <WebMethod(Description := "Returns the time as stored on the Server", _
        EnableSession := False)> _
    Public Function Time() As String
        
        Return Context.Timestamp.TimeOfDay.ToString()
    End Function
End Class
 
' </Snippet1>
