
Partial Class Default2
    Inherits System.Web.UI.Page

    '<snippet1>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack Then
            Response.Write("<br>Page has been posted back.")
        End If
    End Sub
    '</snippet1>

    '<snippet2>
    Protected Sub NameChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles textbox1.TextChanged
        'Sub for the OnTextChanged event
    End Sub
    '</snippet2>

    '<snippet4>
    Protected Sub SampleButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles SampleButton.Click
        ' Code goes here.
    End Sub
    '</snippet4>

    '<snippet5>
    Protected Sub AnyClicked(ByVal sender As Object, ByVal e As System.EventArgs) _
            Handles Button1.Click, Button2.Click, Button3.Click
        Dim b As Button = CType(sender, Button)
        Response.Write("You clicked the button labeled " & b.ID)
    End Sub
    '</snippet5>

End Class
