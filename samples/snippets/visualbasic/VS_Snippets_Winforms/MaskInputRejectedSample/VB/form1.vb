Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms

Public Class Form1
    '<SNIPPET1>
    Private Sub MaskedTextBox1_MaskInputRejected(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MaskInputRejectedEventArgs) Handles MaskedTextBox1.MaskInputRejected
        If (Me.MaskedTextBox1.MaskFull) Then
            ToolTip1.ToolTipTitle = "Input Rejected - Too Much Data"
            ToolTip1.Show("You cannot enter any more data into the date field. Delete some characters in order to insert more data.", Me.MaskedTextBox1, Me.MaskedTextBox1.Location.X, Me.MaskedTextBox1.Location.Y, 5000)
        ElseIf (e.Position = Me.MaskedTextBox1.Mask.Length) Then
            ToolTip1.ToolTipTitle = "Input Rejected - End of Field"
            ToolTip1.Show("You cannot add extra characters to the end of this date field.", Me.MaskedTextBox1, 0, -20, 5000)
        Else
            ToolTip1.ToolTipTitle = "Input Rejected"
            ToolTip1.Show("You can only add numeric characters (0-9) into this date field.", Me.MaskedTextBox1, 0, -20, 5000)
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ToolTip1.IsBalloon = True
        Me.MaskedTextBox1.Mask = "00/00/0000"
    End Sub

    Private Sub MaskedTextBox1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MaskedTextBox1.KeyDown
        ' The balloon tip is visible for five seconds; if the user types any data before it disappears, collapse it ourselves.
        Me.ToolTip1.Hide(Me.MaskedTextBox1)
    End Sub
    '</SNIPPET1>
End Class
