 ' <snippet4>
Imports System
Imports System.Text
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts

Public Partial Class WebPartZoneBase_verbs

  Inherits System.Web.UI.Page

  Protected Sub Page_Load(ByVal sender As [Object], ByVal e As EventArgs)
    If WebPartZone1.WebParts.Count = 0 Then
      Table1.Visible = False
    Else
      Table1.Visible = True
    End If

    ' Enable all verbs on the first page load.
    If Not IsPostBack Then
      Dim item As ListItem
      For Each item In CheckBoxList1.Items
        item.Selected = True
      Next item
      CheckBoxList1_SelectedItemIndexChanged(sender, e)
    End If
  End Sub
    
  ' <snippet5>
  Protected Sub CheckBoxList1_SelectedItemIndexChanged(ByVal sender As [Object], ByVal e As EventArgs)
    Dim item As ListItem
    For Each item In CheckBoxList1.Items
      Dim theVerb As WebPartVerb
      Select Case item.Value
        Case "close"
          theVerb = WebPartZone1.CloseVerb
        Case "export"
          theVerb = WebPartZone1.ExportVerb
        Case "delete"
          theVerb = WebPartZone1.DeleteVerb
        Case "minimize"
          theVerb = WebPartZone1.MinimizeVerb
        Case "restore"
          theVerb = WebPartZone1.RestoreVerb
        Case Else
          theVerb = Nothing
      End Select

      If item.Selected Then
        theVerb.Enabled = True
      Else
        theVerb.Enabled = False
      End If
    Next item

  End Sub
  ' </snippet5>

End Class
' </snippet4>