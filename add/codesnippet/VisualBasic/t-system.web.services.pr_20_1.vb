Imports System
Imports System.Web.Services.Protocols


Public Class MatchAttribute_Example
    Inherits HttpGetClientProtocol

    Public Sub New()
        Url = "http://localhost"
    End Sub 'New

    <HttpMethodAttribute(GetType(TextReturnReader), GetType(UrlParameterWriter))> _
    Public Function GetHeaders() As Headers
        Return CType(Invoke("GetHeaders", Url + "/MyHeaders.html", New Object(0) {}), Headers)
    End Function 'GetHeaders


    Public Function BeginGetHeaders(ByVal callback As System.AsyncCallback, ByVal asyncState As Object) As _
                                                                         System.IAsyncResult
        Return BeginInvoke("GetHeaders", Url + "/MyHeaders.html", New Object(0) {}, _
                                                                          callback, asyncState)
    End Function 'BeginGetHeaders


    Public Function EndGetHeaders(ByVal asyncResult As System.IAsyncResult) As Headers
        Return CType(EndInvoke(asyncResult), Headers)
    End Function 'EndGetHeaders
End Class 'MatchAttribute_Example    

Public Class Headers

    <MatchAttribute("TITLE>(.*?)<")> _
    Public Title As String

    <MatchAttribute("", Pattern:="h1>(.*?)<", IgnoreCase:=True)> _
    Public H1 As String

    <MatchAttribute("H2>((([^<,]*),?)+)<", Group:=3, Capture:=4)> _
    Public Element As String

    <MatchAttribute("H2>((([^<,]*),?){2,})<", Group:=3, MaxRepeats:=0)> _
    Public Elements1() As String

    <MatchAttribute("H2>((([^<,]*),?){2,})<", Group:=3, MaxRepeats:=1)> _
    Public Elements2() As String

    <MatchAttribute("H3 ([^=]*)=([^>]*)", Group:=1)> _
    Public Attribute As String

    <MatchAttribute("H3 ([^=]*)=([^>]*)", Group:=2)> _
    Public Value As String
End Class 'Headers
