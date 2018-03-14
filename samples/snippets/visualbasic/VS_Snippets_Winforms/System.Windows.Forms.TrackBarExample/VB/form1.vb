Imports System.Windows.Forms

Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()
        InitializeTrackBar()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If (components IsNot Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.

    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(112, 88)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(72, 20)
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.Text = ""
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(48, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 32)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Number of teams:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region
    '<snippet1>

    'Declare a new TrackBar object.
    Friend WithEvents TrackBar1 As System.Windows.Forms.TrackBar

    ' Initalize the TrackBar and add it to the form.
    Private Sub InitializeTrackBar()
        Me.TrackBar1 = New System.Windows.Forms.TrackBar

        ' Set the TickStyle property so there are ticks on both sides
        ' of the TrackBar.
        TrackBar1.TickStyle = TickStyle.Both

        ' Set the minimum and maximum number of ticks.
        TrackBar1.Minimum = 10
        TrackBar1.Maximum = 100

        ' Set the tick frequency to one tick every ten units.
        TrackBar1.TickFrequency = 10

        TrackBar1.Location = New System.Drawing.Point(75, 30)
        Me.Controls.Add(Me.TrackBar1)
    End Sub


    ' Handle the TrackBar.ValueChanged event by calculating a value for
    ' TextBox1 based on the TrackBar value.  
    Private Sub TrackBar1_ValueChanged(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles TrackBar1.ValueChanged
        TextBox1.Text = System.Math.Round(TrackBar1.Value / 10)
    End Sub
    '</snippet1>

    <System.STAThreadAttribute()> Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub
End Class
