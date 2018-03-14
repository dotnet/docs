' <snippet1>
' Create a custom HtmlTextWriter class that overrides 
' the RenderBeforeContent and RenderAfterContent methods.
Imports System
Imports System.IO
Imports System.Web
Imports System.Web.UI
Imports System.Security.Permissions


<AspNetHostingPermission(SecurityAction.Demand, _
    Level:=AspNetHostingPermissionLevel.Minimal)> _
<AspNetHostingPermission(SecurityAction.InheritanceDemand, _
    Level:=AspNetHostingPermissionLevel.Minimal)> _
Public Class cstmHtmlTW
    Inherits HtmlTextWriter

    Public Sub New(ByVal writer As TextWriter)
        MyBase.New(writer)
    End Sub 'New


    Public Sub New(ByVal writer As TextWriter, ByVal tabString As String)
        MyBase.New(writer, tabString)
    End Sub 'New


    ' <snippet2>
    ' Override the RenderBeforeContent method to write
    ' a font element that applies red to the text in a Label element.
    Protected Overrides Function RenderBeforeContent() As String
        ' Check to determine whether the element being rendered
        ' is a label element. If so, render the opening tag
        ' of the font element; otherwise, call the base method.
        If TagKey = HtmlTextWriterTag.Label Then
            Return "<font color=""red"">"
        Else
            Return MyBase.RenderBeforeContent()
        End If
    End Function 'RenderBeforeContent

    ' </snippet2>
    ' <snippet3>
    ' Override the RenderAfterContent method to render
    ' the closing tag of a font element if the 
    ' rendered tag is a label element.
    Protected Overrides Function RenderAfterContent() As String
        ' Check to determine whether the element being rendered
        ' is a label element. If so, render the closing tag
        ' of the font element; otherwise, call the base method.
        If TagKey = HtmlTextWriterTag.Label Then
            Return "</font>"
        Else
            Return MyBase.RenderAfterContent()
        End If
    End Function 'RenderAfterContent
    ' </snippet3>
End Class 'cstmHtmlTW 
' </snippet1>