Imports System.Windows.Forms
Imports System.Drawing

Partial Public Class Form1

    Public Sub New()
        InitializeComponent()
        AddHandler Me.KeyPress, AddressOf Form1_KeyPress
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
    End Sub

    '<HandleKey>
    ' Detect all numeric characters at the form level and consume 1,4, and 7.
    ' Form.KeyPreview must be set to true for this event handler to be called.
    Private Sub Form1_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar >= Chr(48) And e.KeyChar <= Chr(57) Then
            MessageBox.Show($"Form.KeyPress: '{e.KeyChar}' pressed.")

            Select Case e.KeyChar
                Case Chr(49), Chr(52), Chr(55)
                    MessageBox.Show($"Form.KeyPress: '{e.KeyChar}' consumed.")
                    e.Handled = True
            End Select
        End If

    End Sub
    '</HandleKey>

End Class