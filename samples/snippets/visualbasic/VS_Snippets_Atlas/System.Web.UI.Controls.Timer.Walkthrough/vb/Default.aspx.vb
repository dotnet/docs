'<Snippet2>
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Label2.Text = "Page created at: " & _
          DateTime.Now.ToLongTimeString()
    End Sub

    Protected Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs)
        Label1.Text = "Panel refreshed at: " & _
          DateTime.Now.ToLongTimeString()
        
    End Sub
End Class
'</Snippet2>
