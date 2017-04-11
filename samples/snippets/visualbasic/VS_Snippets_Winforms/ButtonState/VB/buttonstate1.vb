'<snippet2>
Imports System
Imports System.Drawing
Imports System.Windows.Forms

    Public Class Form1
        Inherits System.Windows.Forms.Form

        Private button1 As System.Windows.Forms.Button = New Button
        Private button2 As System.Windows.Forms.Button = New Button

        <System.STAThreadAttribute()>  _
        Public Shared Sub Main()
            System.Windows.Forms.Application.Run(New Form1)
        End Sub

        Public Sub New()
            Me.button2.Location = New Point(0, button1.Height + 10)
            AddHandler Me.button2.Click, AddressOf Me.button2_Click
            Me.Controls.Add(Me.button1)
            Me.Controls.Add(Me.button2)
        End Sub

        ' <snippet1>
        Private Sub button2_Click(sender As Object, e As System.EventArgs)
            ' Draws a flat button on button1.
            ControlPaint.DrawButton(System.Drawing.Graphics.FromHwnd(button1.Handle), 0, 0, button1.Width, button1.Height, ButtonState.Flat)
        End Sub 'button2_Click
        ' </snippet1>
End Class
'</snippet2>