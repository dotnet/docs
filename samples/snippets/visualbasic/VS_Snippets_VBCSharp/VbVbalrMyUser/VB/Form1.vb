Option Explicit On
Option Strict On

' c47b8c08-3ca9-46c4-b4b0-b06dd2b956f8
' Walkthrough: Implementing Custom Authentication and Authorization

Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ' <snippet4>
        My.Forms.LoginForm1.ShowDialog()
        ' Check if the user was authenticated.
        If My.User.IsAuthenticated Then
            Me.Label1.Text = "Authenticated " & My.User.Name
        Else
            Me.Label1.Text = "User not authenticated"
        End If

        If My.User.IsInRole(ApplicationServices.BuiltInRole.Administrator) Then
            Me.Label2.Text = "User is an Administrator"
        Else
            Me.Label2.Text = "User is not an Administrator"
        End If
        ' </snippet4>
    End Sub
End Class


Class Classc47b8c083ca946c4b4b0b06dd2b956f8


End Class
