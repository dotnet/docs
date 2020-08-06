Imports System.Windows.Forms
Imports System.Drawing

Partial Public Class Form1

    Public Sub New()
        InitializeComponent()

        AddHandler Button1.Click, AddressOf Button1_Click

    End Sub

    '<ShowDropDown>
    Private Sub Button1_Click(sender As Object, e As EventArgs)
        ComboBox1.Focus()
        SendKeys.Send("%+{DOWN}")
    End Sub
    '</ShowDropDown>
End Class