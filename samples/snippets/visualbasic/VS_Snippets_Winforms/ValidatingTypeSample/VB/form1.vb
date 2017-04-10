Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms

Public Class Form1
    '<SNIPPET1>
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MaskedTextBox1.Mask = "00/00/0000"
        Me.MaskedTextBox1.ValidatingType = GetType(System.DateTime)

        Me.ToolTip1.IsBalloon = True
    End Sub

    Private Sub MaskedTextBox1_TypeValidationCompleted(ByVal sender As Object, ByVal e As TypeValidationEventArgs) Handles MaskedTextBox1.TypeValidationCompleted
        If (Not e.IsValidInput) Then
            Me.ToolTip1.ToolTipTitle = "Invalid Date"
            Me.ToolTip1.Show("The data you supplied must be a valid date in the format mm/dd/yyyy.", Me.MaskedTextBox1, 0, -20, 5000)
        Else
            ' Now that the type has passed basic type validation, enforce more specific type rules.
            Dim UserDate As DateTime = CDate(e.ReturnValue)
            If (UserDate < DateTime.Now) Then
                Me.ToolTip1.ToolTipTitle = "Invalid Date"
                Me.ToolTip1.Show("The date in this field must be greater than today's date.", Me.MaskedTextBox1, 0, -20, 5000)
                e.Cancel = True
            End If
        End If
    End Sub

    ' Hide the tooltip if the user starts typing again before the five-second display limit on the tooltip expires.
    Private Sub MaskedTextBox1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MaskedTextBox1.KeyDown
        Me.ToolTip1.Hide(Me.MaskedTextBox1)
    End Sub
    '</SNIPPET1>
End Class
