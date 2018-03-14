' <Snippet1>
<%@ WebService Language="VB" Class="Util" %>
 
Imports System
Imports System.Web.Services

Public Class Util
    Inherits WebService
    
    <WebMethod(Description := "Returns the time as stored on the Server", _
        EnableSession := False)> _
    Public Function Time() As String
        
        Return Context.Timestamp.TimeOfDay.ToString()
    End Function
End Class
 
' </Snippet1>
