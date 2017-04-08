Option Explicit
Option Strict

Imports System
Imports System.Data
Imports System.Drawing
Imports System.Windows.Forms
Imports Microsoft.VisualBasic



Public Class Form1
    Inherits Form
    Protected checkBox1 As CheckBox
    Protected label1 As Label
    
    ' <Snippet1>
    Private Sub AdjustMyCheckBoxProperties()

        ' Change the ThreeState and CheckAlign properties on every other click.
        If Not checkBox1.ThreeState Then
            checkBox1.ThreeState = True
            checkBox1.CheckAlign = ContentAlignment.MiddleRight
        Else
            checkBox1.ThreeState = False
            checkBox1.CheckAlign = ContentAlignment.MiddleLeft
        End If

        ' Concatenate the property values together on three lines.
        label1.Text = "ThreeState: " & checkBox1.ThreeState.ToString() & ControlChars.Cr & _
            "Checked: " & checkBox1.Checked.ToString() & ControlChars.Cr & _
            "CheckState: " & checkBox1.CheckState.ToString()

    End Sub
    ' </Snippet1>
End Class
