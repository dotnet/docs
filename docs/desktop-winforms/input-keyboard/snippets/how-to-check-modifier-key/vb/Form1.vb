Imports System.Windows.Forms
Imports System.Drawing

Partial Public Class Form1

    Public Sub New()
        InitializeComponent()

        AddHandler Button1.Click, AddressOf Button1_Click
        AddHandler TextBox1.KeyPress, AddressOf TextBox1_KeyPress
        AddHandler TextBox1.KeyDown, AddressOf TextBox1_KeyDown
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
    End Sub

    '<DetectModifier>
    ' Event only raised when non-modifier key is pressed
    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs)
        If ((Control.ModifierKeys And Keys.Shift) = Keys.Shift) Then
            MessageBox.Show("KeyPress " & [Enum].GetName(GetType(Keys), Keys.Shift))
        End If
    End Sub

    ' Event raised as soon as shift is pressed
    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs)
        If ((Control.ModifierKeys And Keys.Shift) = Keys.Shift) Then
            MessageBox.Show("KeyPress " & [Enum].GetName(GetType(Keys), Keys.Shift))
        End If
    End Sub
    '</DetectModifier>

End Class