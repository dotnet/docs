' <snippet1>
' Create a custom HtmlTextWriter class that overrides 
' the RenderBeforeContent and RenderAfterContent methods.
Imports System
Imports System.IO
Imports System.Web.UI

Namespace Examples.AspNet


   Public Class CustomHtml32TextWriter
      Inherits Html32TextWriter

        ' Create a constructor for the class
        ' that takes a TextWriter as a parameter.
        Public Sub New(ByVal writer As TextWriter)
            Me.New(writer, DefaultTabString)
        End Sub

        ' Create a constructor for the class that takes
        ' a TextWriter and a string as parameters. 
        Public Sub New(ByVal writer As TextWriter, ByVal tabString As String)
            MyBase.New(writer, tabString)
        End Sub

        ' <snippet2>   
        ' Override the RenderBeforeContent method to render
        ' styles before rendering the content of a <th> element.
        Protected Overrides Function RenderBeforeContent() As String
            ' Check the TagKey property. If its value is
            ' HtmlTextWriterTag.TH, check the value of the 
            ' SupportsBold property. If true, return the
            ' opening tag of a <b> element; otherwise, render
            ' the opening tag of a <font> element with a color
            ' attribute set to the hexadecimal value for red.
            If TagKey = HtmlTextWriterTag.Th Then
                If (SupportsBold) Then
                    Return "<b>"
                Else
                    Return "<font color=""FF0000"">"
                End If
            End If

            ' Check whether the element being rendered
            ' is an <H4> element. If it is, check the 
            ' value of the SupportsItalic property.
            ' If true, render the opening tag of the <i> element
            ' prior to the <H4> element's content; otherwise, 
            ' render the opening tag of a <font> element 
            ' with a color attribute set to the hexadecimal
            ' value for navy blue.
            If TagKey = HtmlTextWriterTag.H4 Then
                If (SupportsItalic) Then
                    Return "<i>"
                Else
                    Return "<font color=""000080"">"
                End If
            End If
            ' Call the base method.
            Return MyBase.RenderBeforeContent()
        End Function
        ' </snippet2> 

        ' <snippet4>   
        ' Override the RenderAfterContent method to close
        ' styles opened during the call to the RenderBeforeContent
        ' method.
        Protected Overrides Function RenderAfterContent() As String

            ' Check whether the element being rendered is a <th> element.
            ' If so, and the requesting device supports bold formatting,
            ' render the closing tag of the <b> element. If not,
            ' render the closing tag of the <font> element.
            If TagKey = HtmlTextWriterTag.Th Then
                If SupportsBold Then
                    Return "</b>"
                Else
                    Return "</font>"
                End If
            End If

            ' Check whether the element being rendered is an <H4>.
            ' element. If so, and the requesting device supports italic
            ' formatting, render the closing tag of the <i> element.
            ' If not, render the closing tag of the <font> element.
            If TagKey = HtmlTextWriterTag.H4 Then
                If (SupportsItalic) Then
                    Return "</i>"
                Else
                    Return "</font>"
                End If
            End If
            ' Call the base method.
            Return MyBase.RenderAfterContent()
        End Function
        ' </snippet4>

        ' <snippet3>   
        ' Override the RenderBeforeTag method to render the
        ' opening tag of a <small> element to modify the text size of 
        ' any <a> elements that this writer encounters.
        Protected Overrides Function RenderBeforeTag() As String
            ' Check whether the element being rendered is an 
            ' <a> element. If so, render the opening tag
            ' of the <small> element; otherwise, call the base method.
            If TagKey = HtmlTextWriterTag.A Then
                Return "<small>"
            End If
            Return MyBase.RenderBeforeTag()
        End Function
        ' </snippet3> 

        ' <snippet5>   
        ' Override the RenderAfterTag method to render
        ' close any elements opened in the RenderBeforeTag
        ' method call.
        Protected Overrides Function RenderAfterTag() As String
            ' Check whether the element being rendered is an
            ' <a> element. If so, render the closing tag of the
            ' <small> element; otherwise, call the base method.
            If TagKey = HtmlTextWriterTag.A Then
                Return "</small>"
            End If
            Return MyBase.RenderAfterTag()
        End Function
        ' </snippet5>
    End Class
End Namespace
' </snippet1>
