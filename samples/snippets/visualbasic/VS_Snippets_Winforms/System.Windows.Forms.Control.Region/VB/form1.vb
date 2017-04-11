' This example demonstrates using the Control.Region property by 
' creating a round button.  


Imports System
Imports System.Windows.Forms
Imports System.Drawing.Drawing2D

Public Class Form1
    Inherits System.Windows.Forms.Form

    Public Sub New()
        MyBase.New()
        InitializeComponent()
    End Sub

    Friend WithEvents roundButton As System.Windows.Forms.Button
    Private Sub InitializeComponent()
        Me.RoundButton = New System.Windows.Forms.Button
        Me.SuspendLayout()
        Me.RoundButton.BackColor = System.Drawing.Color.PowderBlue
        Me.RoundButton.Location = New System.Drawing.Point(88, 72)
        Me.RoundButton.Name = "RoundButton"
        Me.RoundButton.Size = New System.Drawing.Size(112, 112)
        Me.RoundButton.TabIndex = 0
        Me.RoundButton.Text = "I'm round"
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.RoundButton)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

    <System.STAThreadAttribute()> Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub

    '<snippet1>
    ' This method will change the square button to a circular button by 
    ' creating a new circle-shaped GraphicsPath object and setting it 
    ' to the RoundButton objects region.
    Private Sub roundButton_Paint(ByVal sender As Object, _
        ByVal e As System.Windows.Forms.PaintEventArgs) Handles roundButton.Paint

        Dim buttonPath As New System.Drawing.Drawing2D.GraphicsPath

        ' Set a new rectangle to the same size as the button's 
        ' ClientRectangle property.
        Dim newRectangle As Rectangle = roundButton.ClientRectangle

        ' Decrease the size of the rectangle.
        newRectangle.Inflate(-10, -10)

        ' Draw the button's border.
        'e.Graphics.DrawEllipse(System.Drawing.Pens.Black, newRectangle)

        'Increase the size of the rectangle to include the border.
        newRectangle.Inflate(1, 1)

        ' Create a circle within the new rectangle.
        buttonPath.AddEllipse(newRectangle)
        e.Graphics.DrawPath(Pens.Black, buttonPath)
        ' Set the button's Region property to the newly created 
        ' circle region.
        roundButton.Region = New System.Drawing.Region(buttonPath)

    End Sub
    '</snippet1>
End Class

