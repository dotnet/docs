' <snippet1>

Imports System
Imports System.IO
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Security.Permissions

Namespace Samples.AspNet.VB
    ' <snippet10>
    ' A custom class that overrides the CreateHtmlTextWriter method.
    ' This page uses the StyledLabelHtmlWriter to render its content.  
    <AspNetHostingPermission(SecurityAction.Demand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public Class MyPage
        Inherits Page

        Protected Overrides Function CreateHtmlTextWriter(ByVal writer As TextWriter) As HtmlTextWriter
            Return New HtmlStyledLabelWriter(writer)
        End Function 'CreateHtmlTextWriter
    End Class 'MyPage
    ' </snippet10> 

    ' Create a custom markup writer that overrides two versions
    ' of the RenderBeginTag method and one version of the
    ' RenderEndTag method. 
    <AspNetHostingPermission(SecurityAction.Demand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public Class HtmlStyledLabelWriter
        Inherits HtmlTextWriter
        Private writer As TextWriter


        Public Sub New(ByVal writer As TextWriter)
            MyBase.New(writer)
            Me.writer = writer
        End Sub 'New


        Public Sub New(ByVal writer As TextWriter, ByVal tabString As String)
            MyBase.New(writer, tabString)

            Me.writer = writer
        End Sub 'New


        ' <snippet2>
        Public Overloads Overrides Sub RenderBeginTag(ByVal tagKey As HtmlTextWriterTag)


            ' <snippet3>
            ' <snippet4>
            ' If the markup element being rendered is a Label,
            ' render the opening tag of a Font element before it.
            If tagKey = HtmlTextWriterTag.Label Then
                ' Check whether a Color style attribute is 
                ' included on the Label. If not, use the
                ' AddStyleAttribute and GetStyleName methods to add one
                ' and set its value to red.
                If Not IsStyleAttributeDefined(HtmlTextWriterStyle.Color) Then
                    AddStyleAttribute(GetStyleName(HtmlTextWriterStyle.Color), "red")
                End If
                ' </snippet4>
                writer.Write(TagLeftChar)
                ' <snippet5>
                ' Use the GetTagName method to associate 
                ' the Font element with its HtmlTextWriteTag
                ' enumeration value in a Write method call.
                writer.Write(GetTagName(HtmlTextWriterTag.Font))
                ' </snippet5>
                writer.Write(SpaceChar)
                ' <snippet6>                 
                ' Use the GetAttributeName method to associate 
                ' the Size attribute with its HtmlTextWriteAttribute
                ' enumeration value in a Write method call.
                writer.Write(GetAttributeName(HtmlTextWriterAttribute.Size))
                ' </snippet6>
                writer.Write(EqualsChar)
                writer.Write(DoubleQuoteChar)
                writer.Write("30pt")
                writer.Write(DoubleQuoteChar)
                writer.Write(TagRightChar)

                ' <snippet7>
                ' Close the Font element.
                Me.WriteEndTag(GetTagName(HtmlTextWriterTag.Font))
            End If
            ' </snippet7>
            ' </snippet3>
            ' Call the base class's RenderBeginTag method.
            MyBase.RenderBeginTag(tagKey)
        End Sub

        ' </snippet2>
        ' <snippet8>
        Public Overloads Overrides Sub RenderBeginTag(ByVal tagName As String)
            ' Call the overloaded RenderBeginTag(HtmlTextWriterTag) method.
            RenderBeginTag(GetTagKey(tagName))
        End Sub

        ' </snippet8>
        ' <snippet9>
        Public Overrides Sub RenderEndTag()
            ' Call the RenderEndTag method of the base class.
            MyBase.RenderEndTag()

            ' If the element being rendered is a Label, 
            ' call the PopEndTag method to write its closing tag.
            If TagKey = HtmlTextWriterTag.Label Then
                writer.Write(PopEndTag())
            End If
        End Sub
    End Class
    ' </snippet9>

End Namespace
' </snippet1>