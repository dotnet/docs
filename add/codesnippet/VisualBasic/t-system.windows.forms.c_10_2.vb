Public Class Form1
    Inherits System.Windows.Forms.Form

    Friend WithEvents MyStdButton As System.Windows.Forms.Button
    Friend WithEvents MyIconButton As MyIconButton
    Friend WithEvents OpenDlg As OpenFileDialog

    Public Sub New()
        MyBase.New()
        Try
            ' Create the button with the default icon.
            MyIconButton = New MyIconButton(New Icon(Application.StartupPath + "\Default.ico"))

        Catch ex As Exception
            ' If the default icon does not exist, create the button without an icon.
            MyIconButton = New MyIconButton()
            System.Diagnostics.Debug.WriteLine(ex.ToString())
        Finally
            MyStdButton = New Button()

            'Set the location, text and width of the standard button.
            MyStdButton.Location = New Point(MyIconButton.Location.X, _
                        MyIconButton.Location.Y + MyIconButton.Height + 20)
            MyStdButton.Text = "Change Icon"
            MyStdButton.Width = 100

            ' Add the buttons to the Form.
            Me.Controls.Add(MyStdButton)
            Me.Controls.Add(MyIconButton)
        End Try

    End Sub

    Public Shared Sub Main()
        Application.Run(New Form1())
    End Sub

    Private Sub MyStdButton_Click(ByVal sender As System.Object, _
                ByVal e As System.EventArgs) Handles MyStdButton.Click
        ' Use an OpenFileDialog to allow the user to assign a new image to the derived button.
        OpenDlg = New OpenFileDialog()
        OpenDlg.InitialDirectory = Application.StartupPath
        OpenDlg.Filter = "Icon files (*.ico)|*.ico"
        OpenDlg.Multiselect = False
        OpenDlg.ShowDialog()

        If OpenDlg.FileName <> "" Then
            MyIconButton.Icon = New Icon(OpenDlg.FileName)
        End If
    End Sub

    Private Sub MyIconButton_Click(ByVal sender As System.Object, _
                ByVal e As System.EventArgs) Handles MyIconButton.Click
        ' Make sure MyIconButton works.
        MessageBox.Show("MyIconButton was clicked!")
    End Sub
End Class