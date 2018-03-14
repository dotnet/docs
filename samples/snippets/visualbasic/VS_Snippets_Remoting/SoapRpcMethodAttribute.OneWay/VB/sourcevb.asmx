' <Snippet1>
<%@ WebService Language="VB" Class="Stats" %>
 
Imports System.Web.Services
Imports System.Web.Services.Protocols

Public Class Stats
    Inherits WebService
        
    <SoapRpcMethod(OneWay := True), _
    WebMethod(Description := "Starts nightly stats batch process.")> _
    Public Sub _
        StartStatsCrunch()
        ' Begin a process that takes a long time to complete.
    End Sub
End Class

' </Snippet1>
