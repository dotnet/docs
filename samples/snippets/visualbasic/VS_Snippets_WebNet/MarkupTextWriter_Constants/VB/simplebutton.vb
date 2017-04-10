Imports System
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Security.Permissions

Namespace Samples.AspNet.VB

    <AspNetHostingPermission(SecurityAction.Demand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
        Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public Class SimpleButton
        Inherits WebControl


        Public Overrides Sub RenderControl(ByVal writer As HtmlTextWriter)

            ' Create an input button using
            ' the HtmlTextWriter class.
            writer.Write(HtmlTextWriter.TagLeftChar)
            writer.Write("input")

            ' Write the type and a value attributes.
            writer.WriteAttribute("type", "button")
            writer.WriteAttribute("value", "This is a button.")

            ' <snippet7>
            ' Create some styles for the button.
            writer.Write(HtmlTextWriter.SpaceChar)
            writer.Write("style")
            writer.Write(HtmlTextWriter.EqualsDoubleQuoteString)
            writer.Write("font-size")
            writer.Write(HtmlTextWriter.StyleEqualsChar)
            writer.Write("12pt")
            writer.Write(HtmlTextWriter.SemicolonChar)
            writer.Write("border-style")
            writer.Write(HtmlTextWriter.StyleEqualsChar)
            writer.Write("ridge")
            writer.Write(HtmlTextWriter.DoubleQuoteChar)
            ' </snippet7>

            ' Write a closing slash for the markup element.
            writer.Write(HtmlTextWriter.SelfClosingChars)
            writer.Write(HtmlTextWriter.TagRightChar)

        End Sub

    End Class
End Namespace