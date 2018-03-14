' System.Web.Services.Protocols.MatchAttribute
' System.Web.Services.Protocols.MatchAttribute.MatchAttribute(string)
' System.Web.Services.Protocols.MatchAttribute.IgnoreCase
' System.Web.Services.Protocols.MatchAttribute.Pattern
' System.Web.Services.Protocols.MatchAttribute.Capture
' System.Web.Services.Protocols.MatchAttribute.Group
' System.Web.Services.Protocols.MatchAttribute.MaxRepeats

' The following example demonstrates the constructor and 'IgnoreCase',
' 'Pattern', 'Capture', 'Group', 'MaxRepeats' properties of the
' 'MatchAttribute' class. This example shows a simple proxy that
' parses the contents of a .html file which has been returned in
' response to a web request. The web request which is a HTTP-GET
' request is done behind the scenes in the 'Invoke' method of
' 'HttpGetClientProtocol'. The .html file returned in response is
' parsed with the help of 'MatchAttribute' class and the contents
' are available in the 'Headers' instance returned by 'GetHeaders'
' method.
Imports Microsoft.VisualBasic
' <Snippet1>
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
' <Snippet2>
' <Snippet3>
' <Snippet4>
' <Snippet5>
' <Snippet6>
' <Snippet7>

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
' </Snippet7>
' </Snippet6>
' </Snippet5>
' </Snippet4>
' </Snippet3>
' </Snippet2>

' </Snippet1>


' This program is used as a client of the client proxy class. 



Public Class SvcClient
    Public Shared Sub Main()
        Dim myHeaders As Headers
        Dim mySample As New MatchAttribute_Example
        myHeaders = mySample.GetHeaders()

        Console.WriteLine(ControlChars.NewLine + "The Title html tag content is : {0}", _
                                                                       myHeaders.Title)

        Console.WriteLine(ControlChars.NewLine + "The H1 html tag content is : {0}", _
                                                                       myHeaders.H1)

        Console.WriteLine(ControlChars.NewLine + _
                    "The fifth element in H2 html tag content is : {0}", myHeaders.Element)

        Console.WriteLine(ControlChars.NewLine + "The elements in the H2 html tag are :" + _
                                                                        "(MaxRepeats = 0)")
        Dim i As Integer
        For i = 0 To myHeaders.Elements1.Length - 1
            Console.WriteLine(myHeaders.Elements1(i))
        Next i
        Console.WriteLine(ControlChars.NewLine + "The elements in the H2 html tag are :" + _
                                                     " (MaxRepeats = 1)")
        For i = 0 To myHeaders.Elements2.Length - 1
            Console.WriteLine(myHeaders.Elements2(i))
        Next i
        Console.WriteLine(ControlChars.NewLine + "The H3 html tag has attribute : {0} = {1}", _
                                                        myHeaders.Attribute, myHeaders.Value)
    End Sub 'Main
End Class 'SvcClient