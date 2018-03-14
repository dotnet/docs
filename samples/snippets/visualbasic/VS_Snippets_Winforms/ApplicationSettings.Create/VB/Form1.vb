Public Class Form1
    '<SNIPPET3>
    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Mus.Save()
    End Sub
    '</SNIPPET3>

    '<SNIPPET2>
    Dim Mus As MyUserSettings

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Mus = New MyUserSettings()
        Mus.BackgroundColor = Color.AliceBlue
        Me.DataBindings.Add(New Binding("BackColor", Mus, "BackgroundColor"))
    End Sub
    '</SNIPPET2>
End Class
