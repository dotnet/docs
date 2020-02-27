
Partial Class Preferences
    Inherits System.Web.UI.Page
    ' <Snippet110>
    Protected Sub Page_Load(ByVal sender As Object,
                            ByVal e As EventArgs)

        If Session("Heading") IsNot Nothing Then
            HeadingTextBox.Text = Session("Heading").ToString()
        End If

        If Session("Path") IsNot Nothing Then
            VirtualPathTextBox.Text = Session("Path").ToString()
        End If

        If Session("Site") IsNot Nothing Then
            SiteNameTextBox.Text = Session("Site").ToString()
        End If

        If Session("SubPath") IsNot Nothing Then
            SubPathTextBox.Text = Session("SubPath").ToString()
        End If

        If Session("Server") IsNot Nothing Then
            ServerTextBox.Text = Session("Server").ToString()
        End If
    End Sub

    Protected Sub SaveButton_Click(ByVal sender As Object,
                                   ByVal e As EventArgs)

        If Page.IsValid <> True Then
            ConfigFileRequiredFieldValidator.Visible = True
        Else
            Session("Heading") = HeadingTextBox.Text
            Session("Path") = VirtualPathTextBox.Text
            Session("Site") = SiteNameTextBox.Text
            Session("SubPath") = SubPathTextBox.Text
            Session("Server") = ServerTextBox.Text
            Server.Transfer("~/Default.aspx")
        End If
    End Sub
    Protected Sub CancelButton_Click(ByVal sender As Object,
                                     ByVal e As EventArgs)

        Server.Transfer("~/Default.aspx")
    End Sub
    ' </Snippet110>
End Class
