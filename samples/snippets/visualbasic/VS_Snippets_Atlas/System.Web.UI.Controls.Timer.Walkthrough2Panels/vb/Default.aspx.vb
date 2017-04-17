'<Snippet2>
Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Label1.Text = "UpdatePanel1 refreshed at: " & _
          DateTime.Now.ToLongTimeString()
        Label2.Text = "UpdatePanel2 refreshed at: " & _
          DateTime.Now.ToLongTimeString()
    End Sub
End Class
'</Snippet2>
