' <snippet1>
Imports System
Imports System.IO
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.Adapters
Imports Microsoft.VisualBasic

' A derived PageAdapter class.
Public Class CustomPageAdapter
    Inherits PageAdapter

    ' Override RenderBeginHyperlink to add an attribute that 
    ' references the referring page.
    Public Overrides Sub RenderBeginHyperlink( _
        ByVal writer As HtmlTextWriter, ByVal targetUrl As String, _
        ByVal encodeUrl As Boolean, ByVal softkeyLabel As String, _
        ByVal accessKey As String)

        Dim url As String

        ' Add the src attribute, if referring page URL is available.
        If Not (Page Is Nothing) Then
            If Not (Page.Request Is Nothing) Then
                If Not (Page.Request.Url Is Nothing) Then

                    url = Page.Request.Url.AbsoluteUri
                    If encodeUrl Then
                        url = HttpUtility.HtmlAttributeEncode(url)
                    End If
                    writer.AddAttribute("src", url)
                End If
            End If
        End If

        ' Render the accessKey attribute, if requested.
        If Not (accessKey Is Nothing) Then
            If accessKey.Length = 1 Then
                writer.AddAttribute("accessKey", accessKey)
            End If
        End If

        ' Add the href attribute, encode the URL if requested.
        If (encodeUrl) Then
            url = HttpUtility.HtmlAttributeEncode(targetUrl)
        Else
            url = targetUrl
        End If
        writer.AddAttribute("href", url)

        ' Render the hyperlink opening tag with the added attributes.
        writer.RenderBeginTag("a")

    End Sub ' RenderBeginHyperlink
End Class ' CustomPageAdapter
' </snippet1>

Module MainMod
    Sub Main()
        Dim cpa As New CustomPageAdapter()
        Dim sw As New StreamWriter("cpa.htm")
        Dim htw As New HtmlTextWriter(sw)

        cpa.RenderBeginHyperlink(htw, "http://target.url.com", True, "Click", "X")
        htw.Close()
    End Sub
End Module 'MainMod
