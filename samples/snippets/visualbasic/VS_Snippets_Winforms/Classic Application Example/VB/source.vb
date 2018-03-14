Imports System
Imports System.Windows.Forms

' <Snippet1>
Public Class Form1 
    Inherits Form

    <STAThread()> _
     Shared Sub Main()
        ' Start the application.
        Application.Run(New Form1)
    End Sub

    Private WithEvents button1 As Button
    Private WithEvents listBox1 As ListBox

    Public Sub New()
        button1 = New Button
        button1.Left = 200
        button1.Text = "Exit"

        listBox1 = New ListBox
        Me.Controls.Add(button1)
        Me.Controls.Add(listBox1)
    End Sub

    Private Sub button1_Click(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles button1.Click
        Dim count As Integer = 1
        ' Check to see whether the user wants to exit the application.
        ' If not, add a number to the list box.
        While (MessageBox.Show("Exit application?", "", _
            MessageBoxButtons.YesNo) = DialogResult.No)

            listBox1.Items.Add(count)
            count += 1

        End While

        ' The user wants to exit the application. 
        ' Close everything down.
        Application.Exit()
    End Sub

End Class
' </Snippet1>
