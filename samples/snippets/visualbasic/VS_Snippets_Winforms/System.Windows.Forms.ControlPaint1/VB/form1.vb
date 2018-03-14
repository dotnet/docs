'The code example demonstrates using the ControlPaint.DrawReversibleLine, 
'ControlPaint.DrawFocusRectangle, and ControlPaint.FillReversibleRectangle methods.


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
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(48, 40)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(88, 80)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Click for focus rectangle on Button2"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(176, 48)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(72, 64)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Hover over me for filled rectangle"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(104, 160)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(96, 72)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "Hover over for me for reversible lines"
        '
        'Form1
        '
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region

  
    Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub

    '<snippet2>
    ' This method draws a focus rectangle on Button2 using the 
    ' handle and client rectangle of Button2.
    Private Sub Button1_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button1.Click
        ControlPaint.DrawFocusRectangle(Graphics.FromHwnd(Button2.Handle), _
        Button2.ClientRectangle)
    End Sub
    '</snippet2>

    '<snippet1>
    ' When the mouse hovers over Button2, its ClientRectangle is filled.
    Private Sub Button2_MouseHover(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Button2.MouseHover

        Dim senderControl As Control = CType(sender, Control)
        Dim screenRectangle As Rectangle = _
            senderControl.RectangleToScreen(senderControl.ClientRectangle)
        ControlPaint.FillReversibleRectangle(screenRectangle, _
            senderControl.BackColor)
    End Sub


    ' When the mouse leaves Button2, its ClientRectangle is cleared by
    ' calling the FillReversibleRectangle method again.
    Private Sub Button2_MouseLeave(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Button2.MouseLeave

        Dim senderControl As Control = CType(sender, Control)
        Dim screenRectangle As Rectangle = _
            senderControl.RectangleToScreen(senderControl.ClientRectangle)
        ControlPaint.FillReversibleRectangle(screenRectangle, _
            senderControl.BackColor)
    End Sub
    '</snippet1>

    '<snippet3>
    ' When the mouse hovers over Button3, two reversible lines are drawn
    ' using the corner coordinates of Button3, which are first 
    ' converted to screen coordinates.
    Private Sub Button3_MouseHover(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Button3.MouseHover

        ControlPaint.DrawReversibleLine(Button3.PointToScreen(New Point(0, 0)), _
        Button3.PointToScreen(New Point(Button3.ClientRectangle.Right, _
            Button3.ClientRectangle.Bottom)), SystemColors.Control)
        ControlPaint.DrawReversibleLine(Button3.PointToScreen( _
            New Point(Button3.ClientRectangle.Right, Button3.ClientRectangle.Top)), _
           Button3.PointToScreen(New Point _
                (Button1.ClientRectangle.Left, Button3.ClientRectangle.Bottom)), _
                SystemColors.Control)
    End Sub

    ' When the mouse moves from Button3, the reversible lines are 
    ' erased by using the same coordinates as are used in the
    ' Button3_MouseHover method.
    Private Sub Button3_MouseLeave(ByVal sender As Object, _
        ByVal e As System.EventArgs) Handles Button3.MouseLeave

        ControlPaint.DrawReversibleLine(Button3.PointToScreen(New Point(0, 0)), _
        Button3.PointToScreen(New Point(Button3.ClientRectangle.Right, _
            Button3.ClientRectangle.Bottom)), SystemColors.Control)
        ControlPaint.DrawReversibleLine(Button3.PointToScreen( _
            New Point(Button3.ClientRectangle.Right, Button3.ClientRectangle.Top)), _
           Button3.PointToScreen(New Point(Button3.ClientRectangle.Left, _
           Button3.ClientRectangle.Bottom)), SystemColors.Control)
    End Sub
    '</snippet3>

End Class
