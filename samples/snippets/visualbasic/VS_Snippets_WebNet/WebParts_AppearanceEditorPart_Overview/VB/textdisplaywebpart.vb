' <snippet3>
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
  Public Class TextDisplayWebPart
    Inherits WebPart
    Private _contentText As String = Nothing
    Private _fontStyle As String = Nothing
    Private input As TextBox
    Private DisplayContent As Label
    Private lineBreak As Literal

    <Personalizable(), WebBrowsable()> _
    Public Property ContentText() As String
      Get
        Return _contentText
      End Get
      Set(ByVal value As String)
        _contentText = value
      End Set
    End Property

    Protected Overrides Sub CreateChildControls()
      Controls.Clear()
      DisplayContent = New Label()
      DisplayContent.BackColor = Color.LightBlue
      DisplayContent.Text = Me.ContentText
      Me.Controls.Add(DisplayContent)

      lineBreak = New Literal()
      lineBreak.Text = "<br />"
      Controls.Add(lineBreak)

      input = New TextBox()
      Me.Controls.Add(input)
      Dim update As New Button()
      update.Text = "Set Label Content"
      AddHandler update.Click, AddressOf Me.submit_Click
      Me.Controls.Add(update)

    End Sub

    Private Sub submit_Click(ByVal sender As Object, _
                             ByVal e As EventArgs)
      ' Update the label string.
      If input.Text <> String.Empty Then
        _contentText = input.Text + "<br />"
        input.Text = String.Empty
        DisplayContent.Text = Me.ContentText
      End If

    End Sub

  End Class

End Namespace
' </snippet3>