    Sub ShowSidebarMenu(ByVal newTitle As String)
        If My.Forms.SidebarMenu IsNot Nothing Then
            My.Forms.SidebarMenu.Text = newTitle
        End If
    End Sub