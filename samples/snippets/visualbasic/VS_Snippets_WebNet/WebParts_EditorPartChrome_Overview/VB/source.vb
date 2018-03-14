Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Security.Permissions
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts

' <Snippet2>
Namespace Samples.AspNet.VB.Controls


    <AspNetHostingPermission(SecurityAction.Demand, _
      Level:=AspNetHostingPermissionLevel.Minimal)> _
    <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
      Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public Class MyEditorPartChrome
        Inherits EditorPartChrome

        Public Sub New(ByVal zone As EditorZoneBase)
            MyBase.New(zone)
        End Sub

        ' <Snippet3>
        Protected Overrides Function CreateEditorPartChromeStyle(ByVal editorPart As System.Web.UI.WebControls.WebParts.EditorPart, ByVal chromeType As System.Web.UI.WebControls.WebParts.PartChromeType) As System.Web.UI.WebControls.Style
            Dim editorStyle As Style
            editorStyle = MyBase.CreateEditorPartChromeStyle(editorPart, chromeType)
            editorStyle.BackColor = Drawing.Color.Bisque
            Return editorStyle
        End Function
        ' </Snippet3>

        ' <Snippet4>
        Public Overrides Sub PerformPreRender()
            Dim zoneStyle As Style = New Style
            zoneStyle.BackColor = Drawing.Color.Cornsilk

            Zone.Page.Header.StyleSheet.RegisterStyle(zoneStyle, Nothing)
            Zone.MergeStyle(zoneStyle)
        End Sub
        ' </Snippet4>

        ' <Snippet5>
        Protected Overrides Sub RenderPartContents(ByVal writer As System.Web.UI.HtmlTextWriter, ByVal editorPart As System.Web.UI.WebControls.WebParts.EditorPart)
            writer.AddStyleAttribute("color", "red")
            writer.RenderBeginTag("p")
            writer.Write("Apply all changes")
            writer.RenderEndTag()
            editorPart.RenderControl(writer)
        End Sub
        ' </Snippet5>

        Public Overrides Sub RenderEditorPart(ByVal writer As System.Web.UI.HtmlTextWriter, ByVal editorPart As System.Web.UI.WebControls.WebParts.EditorPart)
            MyBase.RenderEditorPart(writer, editorPart)
        End Sub
    End Class


    <AspNetHostingPermission(SecurityAction.Demand, _
      Level:=AspNetHostingPermissionLevel.Minimal)> _
    <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
      Level:=AspNetHostingPermissionLevel.Minimal)> _
    Public Class MyEditorZone
        Inherits EditorZone

        Protected Overrides Function CreateEditorPartChrome() As System.Web.UI.WebControls.WebParts.EditorPartChrome
            Return New MyEditorPartChrome(Me)
        End Function
    End Class
End Namespace
' </Snippet2>
