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
    Public Class SimpleImage
        Inherits WebControl

        Dim fileValue As String

        Public Property FileName() As String
            Get
                Return fileValue
            End Get

            Set(ByVal value As String)
                fileValue = value
            End Set
        End Property

        ' <snippet8>
        Public Overrides Sub RenderControl(ByVal writer As HtmlTextWriter)

            ' Create an <img> element using members 
            ' of the HtmlTextWriter class.
            writer.WriteBeginTag("img")
            writer.Write(HtmlTextWriter.SpaceChar)

            ' <snippet10>
            ' Write the src attribute and the path
            ' for the image file.
            writer.Write("src")
            writer.Write(HtmlTextWriter.EqualsChar)
            writer.Write(HtmlTextWriter.DoubleQuoteChar)
            writer.Write(HtmlTextWriter.SlashChar)
            writer.Write("images")
            writer.Write(HtmlTextWriter.SlashChar)
            ' </snippet10>

            ' <snippet11> 
            ' Write the name of the image file from the 
            ' FileName property, close the path, and then
            ' close the <img> element.
            writer.Write(FileName)
            writer.Write(HtmlTextWriter.DoubleQuoteChar)
            writer.Write(HtmlTextWriter.SelfClosingTagEnd)
            ' </snippet11>

        End Sub
        ' </snippet8>
    End Class

End Namespace