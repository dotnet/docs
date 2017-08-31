Public Class LoginForm1

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        ' <snippet19>
        Dim samplePrincipal As New SampleIPrincipal( 
            Me.UsernameTextBox.Text, Me.PasswordTextBox.Text)
        Me.PasswordTextBox.Text = ""
        If (Not samplePrincipal.Identity.IsAuthenticated) Then
            ' The user is still not validated.
            MsgBox("The username and password pair is incorrect")
        Else
            ' Update the current principal.
            My.User.CurrentPrincipal = samplePrincipal
            Me.Close()
        End If
        ' </snippet19>
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

End Class
