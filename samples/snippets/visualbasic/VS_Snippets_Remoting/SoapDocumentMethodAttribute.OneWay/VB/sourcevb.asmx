' <Snippet1>
<%@ WebService Language="VB" Class="Stats" %>
 
Imports System.Web.Services
Imports System.Web.Services.Protocols

Public Class Stats
    Inherits WebService
        
    <SoapDocumentMethod(OneWay := True), _
    WebMethod(Description := "Starts nightly statistics batch process.")> _
    Public Sub _
        StartStatsCrunch()
        
        ' Begin nightly statistics crunching process.
        ' A one-way method cannot have return values.
    End Sub
End Class

' </Snippet1>
