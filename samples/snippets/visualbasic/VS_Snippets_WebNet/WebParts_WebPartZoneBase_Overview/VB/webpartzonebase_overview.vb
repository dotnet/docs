' <snippet4>
Imports System
Imports System.Text
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.WebControls.WebParts

Partial Public Class WebPartZoneBase_overview

  Inherits System.Web.UI.Page

  ' <snippet5>
  Protected Sub Page_Load(ByVal sender As [Object], ByVal e As EventArgs) 
    Label1.Text = DateTime.Now.ToLongDateString()
    Label2.Text = String.Empty
  End Sub
  ' </snippet5>
  
  ' <snippet6>
  Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) 
    If WebPartZone2.VerbButtonType = ButtonType.Button Then
        WebPartZone2.VerbButtonType = ButtonType.Link
    Else
        WebPartZone2.VerbButtonType = ButtonType.Button
    End If
  End Sub
  ' </snippet6> 
 
  ' <snippet7>
  Protected Sub Button2_Click(ByVal sender As Object, ByVal e As EventArgs) 
    If WebPartZone1.LayoutOrientation = Orientation.Vertical Then
        WebPartZone1.LayoutOrientation = Orientation.Horizontal
    Else
        WebPartZone1.LayoutOrientation = Orientation.Vertical
    End If
    Page_Load(sender, e)
  End Sub 
  ' </snippet7>
  
  ' <snippet8>
  Protected Sub Button3_Click(ByVal sender As Object, ByVal e As EventArgs) 
    Dim builder As New StringBuilder()
    builder.AppendLine("<strong>WebPartZone2 WebPart IDs</strong><br />")
    Dim part As WebPart
    For Each part In  WebPartZone1.WebParts
      builder.AppendLine("ID: " + part.ID + "; Type: " _
                          + part.GetType().ToString() _
                          + "<br />")
    Next part
    Label2.Text = builder.ToString()
    Label2.Visible = True
  End Sub 
  ' </snippet8>

  ' <snippet9>
  Protected Sub Button4_Click(ByVal sender As Object, ByVal e As EventArgs)
    Dim builder As New StringBuilder()
    builder.AppendLine("<strong>WebPartZone1 DisplayTitle Property</strong><br />")
    builder.AppendLine(WebPartZone1.DisplayTitle + "<br />")
    Label2.Text = builder.ToString()
    Label2.Visible = True
  End Sub
  ' </snippet9>

End Class
' </snippet4>