' <Snippet1>
<%@ WebService Language="VB" Class="Counter" %>

Imports System.Web.Services
Imports System
Imports System.Web

Public Class Counter
    Inherits WebService  

    <WebMethod(Description := "Number of times this service has been accessed", _
        CacheDuration := 60, _
        MessageName := "ServiceUsage")> _
    Public Function ServiceUsage() As Integer
        
        ' If the XML Web service has not been accessed, initialize it to 1.
        If Application("MyServiceUsage") Is Nothing Then
            Application("MyServiceUsage") = 1
        Else
            ' Increment the usage count.
            Application("MyServiceUsage") = CInt(Application("MyServiceUsage")) + 1
        End If
        
        ' Return the usage count.
        Return CInt(Application("MyServiceUsage"))
    End Function
End Class

' </Snippet1>
