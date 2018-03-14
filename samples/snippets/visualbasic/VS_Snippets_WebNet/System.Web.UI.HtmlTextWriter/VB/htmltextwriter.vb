Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Security.Permissions

Namespace Samples.AspNet.VB
    _

    <AspNetHostingPermission(SecurityAction.Demand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public Class MyControl
        Inherits Control


        Protected Overrides Sub Render(ByVal writer As HtmlTextWriter)

            ' <snippet1>     
            writer.AddAttribute(HtmlTextWriterAttribute.Onclick, "alert('Hello');")
            ' </snippet1>
            writer.AddAttribute("myattribute", "MyAttributeValue")
            ' <snippet2>
            writer.AddStyleAttribute(HtmlTextWriterStyle.Color, "Red")
            ' </snippet2>
            writer.AddStyleAttribute("mystyleattr", "StyleValue")
            writer.RenderBeginTag(HtmlTextWriterTag.Span)
            writer.WriteLine()
            writer.Indent += 1

            writer.Write("Hello")
            writer.WriteLine()

            ' <snippet3>
            ' Control the encoding of attributes.
            ' Simple known values do not need encoding.
            writer.AddAttribute(HtmlTextWriterAttribute.Alt, "Encoding, ""Required""", True)
            writer.AddAttribute("myattribute", "No &quot;encoding &quot; required", False)
            writer.RenderBeginTag(HtmlTextWriterTag.Img)
            writer.RenderEndTag()
            writer.WriteLine()
            ' </snippet3>

            ' <snippet4>      
            ' Create a non-standard tag.
            writer.RenderBeginTag("MyTag")
            writer.Write("Contents of MyTag")
            writer.RenderEndTag()
            writer.WriteLine()
            ' </snippet4>

            ' <snippet5>     
            ' Create a manually rendered tag.
            writer.WriteBeginTag("img")
            writer.WriteAttribute("alt", "AtlValue")
            writer.WriteAttribute("myattribute", "No &quot;encoding &quot; required", False)
            writer.Write(HtmlTextWriter.TagRightChar)
            ' </snippet5>

            writer.WriteEndTag("img")
            writer.WriteLine()

            writer.Indent -= 1
            writer.RenderEndTag()

        End Sub 'Render
    End Class 'MyControl
End Namespace 'ControlTest 