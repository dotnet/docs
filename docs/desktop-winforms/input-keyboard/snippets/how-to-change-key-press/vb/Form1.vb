Imports System.Windows.Forms
Imports System.Drawing

Partial Public Class Form1

    Public Sub New()
        InitializeComponent()

        AddHandler Button1.Click, AddressOf Button1_Click
        AddHandler TextBox1.KeyPress, AddressOf TextBox1_KeyPress
        AddHandler TextBox2.KeyPress, AddressOf TextBox2_KeyPress
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        ComboBox1.Focus()
        SendKeys.Send("%+{DOWN}")
    End Sub

    '<ConsumeKey>
    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar = "a"c Or e.KeyChar = "A"c Then
            e.Handled = True
        End If
    End Sub
    '</ConsumeKey>

    '<ModifyKey>
    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs)
        If e.KeyChar = "a"c Or e.KeyChar = "A"c Then
            e.KeyChar = "!"c
            e.Handled = False
        End If
    End Sub
    '</ModifyKey>
End Class