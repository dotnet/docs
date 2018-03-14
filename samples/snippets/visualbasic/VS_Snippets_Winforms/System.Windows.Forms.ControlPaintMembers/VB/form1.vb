Imports System.Windows.Forms
Imports System.Drawing

Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
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
    Friend WithEvents Button1 As System.Windows.Forms.Button


    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(24, 32)
        Me.Button1.Name = "Button1"
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub


#End Region
    '<snippet1>
    ' Handle the Button1 object's Paint Event to create a CaptionButton.
    Private Sub Button1_Paint(ByVal sender As Object, _
        ByVal e As PaintEventArgs) Handles Button1.Paint

        ' Draw a CaptionButton control using the ClientRectangle 
        ' property of Button1. Make the button a Help button 
        ' with a normal state.
        ControlPaint.DrawCaptionButton(e.Graphics, Button1.ClientRectangle, _
            CaptionButton.Help, ButtonState.Normal)
    End Sub
    '</snippet1>

    '<snippet2>
    ' Handle the Form's Paint event to draw a 3D three-dimensional 
    ' raised border just inside the border of the frame.
    Private Sub Form1_Paint(ByVal sender As Object, _
        ByVal e As PaintEventArgs) Handles MyBase.Paint

        Dim borderRectangle As Rectangle = Me.ClientRectangle
        borderRectangle.Inflate(-10, -10)
        ControlPaint.DrawBorder3D(e.Graphics, borderRectangle, _
            Border3DStyle.Raised)
    End Sub
    '</snippet2>

    Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub

End Class




