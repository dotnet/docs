' <Snippet2>
Imports Microsoft.VisualBasic
Imports System
Imports System.Web
Imports System.Web.Security
Imports System.Web.UI
Imports System.Web.UI.HtmlControls
Imports System.Web.UI.WebControls

<Assembly: WebResource("image1.gif", "image/jpeg")> 
<Assembly: WebResource("help.htm", "text/html", PerformSubstitution:=True)> 
Namespace Samples.AspNet.VB.Controls

    Public Class MyCustomControl
        Inherits Control

        <System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
        Protected Overrides Sub CreateChildControls()

            ' Create a new Image control.
            Dim _img As New Image()
            _img.ImageUrl = Me.Page.ClientScript.GetWebResourceUrl(GetType(MyCustomControl), "image1.jpg")
            Me.Controls.Add(_img)

            ' Create a new Label control.
            Dim _lab As New Label()
            _lab.Text = "A composite control using the WebResourceAttribute class."
            Me.Controls.Add(_lab)

            ' Create a new HtmlAnchor control linking to help.htm.
            Dim a As HtmlAnchor = New HtmlAnchor()
            a.HRef = Me.Page.ClientScript.GetWebResourceUrl(GetType(MyCustomControl), "help.htm")
            a.InnerText = "help link"
            Me.Controls.Add(New LiteralControl("<br />"))
            Me.Controls.Add(a)

        End Sub
    End Class

End Namespace
' </Snippet2>
