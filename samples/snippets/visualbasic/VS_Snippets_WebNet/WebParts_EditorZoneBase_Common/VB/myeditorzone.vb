 ' <snippet12>
Imports System
Imports System.Collections
Imports System.ComponentModel
Imports System.Drawing
Imports System.Security.Permissions
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts

Namespace Samples.AspNet.VB.Controls

  <AspNetHostingPermission(SecurityAction.Demand, _
    Level:=AspNetHostingPermissionLevel.Minimal)> _
  <AspNetHostingPermission(SecurityAction.InheritanceDemand, _
    Level:=AspNetHostingPermissionLevel.Minimal)> _
Public Class MyEditorZone
    Inherits EditorZone

    Public Sub New()
    End Sub

    ' <snippet13>
    Protected Overrides Sub OnDisplayModeChanged(ByVal sender _
      As Object, ByVal e As WebPartDisplayModeEventArgs)
      Me.BackColor = Color.LightGray
      MyBase.OnDisplayModeChanged(sender, e)
    End Sub
    ' </snippet13>
    ' <snippet14>
    Protected Overrides Sub OnSelectedWebPartChanged(ByVal sender _
      As Object, ByVal e As WebPartEventArgs)
      If Not (e.WebPart Is Nothing) Then
        e.WebPart.Zone.SelectedPartChromeStyle.BackColor = _
          Color.LightGreen
      End If
      MyBase.OnSelectedWebPartChanged(sender, e)

    End Sub
    ' </snippet14>
    ' <snippet15>
    Protected Overrides Sub RenderBody(ByVal writer As _
      HtmlTextWriter)
      writer.WriteLine("<hr />")
      MyBase.RenderBody(writer)
    End Sub
    ' </snippet15>
    ' <snippet16>
    Protected Overrides Sub RenderVerbs(ByVal writer As _
      HtmlTextWriter)
      Dim verbs() As WebPartVerb = {OKVerb, CancelVerb, ApplyVerb}
      Dim verb As WebPartVerb
      For Each verb In verbs
        If Not (verb Is Nothing) Then
          verb.Text += " Verb"
        End If
      Next verb
      MyBase.RenderVerbs(writer)
    End Sub
  End Class
  ' </snippet16>

End Namespace
' </snippet12>