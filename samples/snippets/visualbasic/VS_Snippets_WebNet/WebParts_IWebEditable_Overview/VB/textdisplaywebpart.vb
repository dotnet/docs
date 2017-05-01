' <snippet1>
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
  ' <snippet2>
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

    ' <snippet4>
    Public Overrides Function CreateEditorParts() _
                                As EditorPartCollection
      Dim editorArray As New ArrayList()
      Dim edPart as New TextDisplayEditorPart()
      edPart.ID = Me.ID & "_editorPart1"
      editorArray.Add(edPart)
      Dim editorParts As New EditorPartCollection(editorArray)
      Return editorParts

    End Function

    Public Overrides ReadOnly Property WebBrowsableObject() _
                                        As Object
      Get
        Return Me
      End Get
    End Property
    ' </snippet4>

    <Personalizable(), WebBrowsable()> _
    Public Property ContentText() As String
      Get
        Return _contentText
      End Get
      Set(ByVal value As String)
        _contentText = Value
      End Set
    End Property

    <Personalizable(), WebBrowsable()> _
    Public Property FontStyle() As String
      Get
        Return _fontStyle
      End Get
      Set(ByVal value As String)
        _fontStyle = Value
      End Set
    End Property

    Protected Overrides Sub CreateChildControls()
      Controls.Clear()
      DisplayContent = New Label()
      DisplayContent.BackColor = Color.LightBlue
      DisplayContent.Text = Me.ContentText
      If FontStyle Is Nothing Then
        FontStyle = "None"
      End If
      SetFontStyle(DisplayContent, FontStyle)
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

    Private Sub SetFontStyle(ByVal label As Label, _
                             ByVal selectedStyle As String)
      If selectedStyle = "Bold" Then
        label.Font.Bold = True
        label.Font.Italic = False
        label.Font.Underline = False
      ElseIf selectedStyle = "Italic" Then
        label.Font.Italic = True
        label.Font.Bold = False
        label.Font.Underline = False
      ElseIf selectedStyle = "Underline" Then
        label.Font.Underline = True
        label.Font.Bold = False
        label.Font.Italic = False
      Else
        label.Font.Bold = False
        label.Font.Italic = False
        label.Font.Underline = False
      End If

    End Sub

    ' <snippet3>
    ' Create a custom EditorPart to edit the WebPart control.
    <AspNetHostingPermission(SecurityAction.Demand, _
      Level:=AspNetHostingPermissionLevel.Minimal)> _
    Private Class TextDisplayEditorPart
      Inherits EditorPart
      Private _partContentFontStyle As DropDownList

      ' <snippet5>
      Public Overrides Function ApplyChanges() As Boolean
        Dim part As TextDisplayWebPart = CType(WebPartToEdit, _
                                               TextDisplayWebPart)
        ' Update the custom WebPart control with the font style.
        part.FontStyle = PartContentFontStyle.SelectedValue

        Return True

      End Function
      ' </snippet5>

      ' <snippet6>
      Public Overrides Sub SyncChanges()
        Dim part As TextDisplayWebPart = CType(WebPartToEdit, _
                                               TextDisplayWebPart)
        Dim currentStyle As String = part.FontStyle

        ' Select the current font style in the drop-down control.
        Dim item As ListItem
        For Each item In PartContentFontStyle.Items
          If item.Value = currentStyle Then
            item.Selected = True
            Exit For
          End If
        Next item

      End Sub
      ' </snippet6>

      Protected Overrides Sub CreateChildControls()
        Controls.Clear()

        ' Add a set of font styles to the dropdown list.
        _partContentFontStyle = New DropDownList()
        _partContentFontStyle.Items.Add("Bold")
        _partContentFontStyle.Items.Add("Italic")
        _partContentFontStyle.Items.Add("Underline")
        _partContentFontStyle.Items.Add("None")

        Controls.Add(_partContentFontStyle)

      End Sub

      Protected Overrides Sub RenderContents(ByVal writer _
                                             As HtmlTextWriter)
        writer.Write("<b>Text Content Font Style</b>")
        writer.WriteBreak()
        writer.Write("Select a font style.")
        writer.WriteBreak()
        _partContentFontStyle.RenderControl(writer)
        writer.WriteBreak()

      End Sub

      ' Access the drop-down control through a property.
      Private ReadOnly Property PartContentFontStyle() As DropDownList
        Get
          EnsureChildControls()
          Return _partContentFontStyle
        End Get
      End Property

    End Class
    ' </snippet3>

  End Class
  ' </snippet2>

End Namespace
' </snippet1>