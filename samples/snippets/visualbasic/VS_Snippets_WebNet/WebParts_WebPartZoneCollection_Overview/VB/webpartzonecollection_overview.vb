' <snippet2>
Imports System
Imports System.Data
Imports System.Configuration
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts
Imports System.Web.UI.HtmlControls


Partial Public Class webpartzonecollection_overview

  Inherits Page

  Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs)
    Label1.Text = String.Empty
    Label1.Text = "WebPartZone Count:  " & mgr.Zones.Count

  End Sub


  ' <snippet3>
  Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs)
    Label1.Text = String.Empty
    Label1.Text = mgr.Zones.Contains(WebPartZone2).ToString()

  End Sub
  ' </snippet3>

  ' <snippet4>
  Protected Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs)
    Label1.Text = String.Empty
    Dim zoneArray(mgr.Zones.Count) As WebPartZoneBase
    mgr.Zones.CopyTo(zoneArray, 0)
    Label1.Text = zoneArray(2).ID
    Label1.Text += ", " & zoneArray(1).ID
    Label1.Text += ", " & zoneArray(0).ID

  End Sub
  ' </snippet4>

  ' <snippet5>
  Protected Sub Button4_Click(ByVal sender As Object, ByVal e As EventArgs)
    Label1.Text = String.Empty
    Label1.Text = "WebPartZone1 index:  " & mgr.Zones.IndexOf(WebPartZone1)

  End Sub
  ' </snippet5>

  ' <snippet6>
  Protected Sub Button5_Click(ByVal sender As Object, ByVal e As EventArgs)
    Label1.Text = String.Empty

    Dim zoneCollection As WebPartZoneCollection = mgr.Zones
    Dim zone As WebPartZone
    For Each zone In zoneCollection
      If zone.WebPartVerbRenderMode = WebPartVerbRenderMode.Menu Then
        zone.WebPartVerbRenderMode = WebPartVerbRenderMode.TitleBar
      Else
        zone.WebPartVerbRenderMode = WebPartVerbRenderMode.Menu
      End If
    Next zone

  End Sub
  ' </snippet6>

End Class
' </snippet2>