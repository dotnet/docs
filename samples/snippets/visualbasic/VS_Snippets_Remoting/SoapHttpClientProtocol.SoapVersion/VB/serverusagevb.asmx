<%@ WebService Language="VB" Class="ServerUsage" %>
Imports System.Web.Services

Public Class ServerUsage
    Inherits WebService
'<Snippet2>    
<WebMethod(Description := "Number of times this service has been accessed.")> _
    Public Function ServiceUsage() As Integer
       ' If the XML Web service method hasn't been accessed initialize it to 1
        If Application("appMyServiceUsage") Is Nothing Then
            Application("appMyServiceUsage") = 1
        Else
            ' Increment the usage count
            Application("appMyServiceUsage") = _
               CInt(Application("appMyServiceUsage")) + 1
        End If
        Return CInt(Application("appMyServiceUsage"))
    End Function    
    
<WebMethod(Description := "Number of times a particular client session has accessed this XML Web service method.", _
           EnableSession := True)> _
    Public Function PerSessionServiceUsage() As Integer
       ' If the XML Web service method hasn't been accessed initialize it to 1
        If Session("MyServiceUsage") Is Nothing Then
            Session("MyServiceUsage") = 1
        Else
            ' Increment the usage count
           Session("MyServiceUsage") = CInt(Session("MyServiceUsage")) + 1
        End If
        Return CInt(Session("MyServiceUsage"))
    End Function
'</Snippet2>    
End Class