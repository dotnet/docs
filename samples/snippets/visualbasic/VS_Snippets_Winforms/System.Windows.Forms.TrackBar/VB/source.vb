' <Snippet1>
Imports System
Imports System.Drawing
Imports System.Windows.Forms

Public Class Form1
    Inherits System.Windows.Forms.Form

    Private WithEvents trackBar1 As System.Windows.Forms.TrackBar
    Private textBox1 As System.Windows.Forms.TextBox

    <System.STAThread()> _
    Public Shared Sub Main()
        System.Windows.Forms.Application.Run(New Form1)
    End Sub 'Main

    Public Sub New()
        Me.textBox1 = New System.Windows.Forms.TextBox
        Me.trackBar1 = New System.Windows.Forms.TrackBar

        ' TextBox for TrackBar.Value update.
        Me.textBox1.Location = New System.Drawing.Point(240, 16)
        Me.textBox1.Size = New System.Drawing.Size(48, 20)

        ' Set up how the form should be displayed and add the controls to the form.
        Me.ClientSize = New System.Drawing.Size(296, 62)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.textBox1, Me.trackBar1})
        Me.Text = "TrackBar Example"

        ' Set up the TrackBar.
        Me.trackBar1.Location = New System.Drawing.Point(8, 8)
        Me.trackBar1.Size = New System.Drawing.Size(224, 45)

        ' The Maximum property sets the value of the track bar when
        ' the slider is all the way to the right.
        trackBar1.Maximum = 30

        ' The TickFrequency property establishes how many positions
        ' are between each tick-mark.
        trackBar1.TickFrequency = 5

        ' The LargeChange property sets how many positions to move
        ' if the bar is clicked on either side of the slider.
        trackBar1.LargeChange = 3

        ' The SmallChange property sets how many positions to move
        ' if the keyboard arrows are used to move the slider.
        trackBar1.SmallChange = 2
    End Sub 'New

    Private Sub trackBar1_Scroll(ByVal sender As Object, _
                    ByVal e As System.EventArgs) Handles trackBar1.Scroll

        ' Display the trackbar value in the text box.
        textBox1.Text = trackBar1.Value
    End Sub 

End Class 'Form1
'</Snippet1>