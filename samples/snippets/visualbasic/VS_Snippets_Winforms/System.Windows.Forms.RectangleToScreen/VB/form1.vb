' This example demonstrates using the following members: 
' Form.BackColor, Control.RectangleToScreen, Control.PointToScreen,
' ControlPaint.DrawReversibleFrame, and Rectangle.Intersects.


Imports System.Windows.Forms
Imports System.Drawing

Public Class Form1
    Inherits System.Windows.Forms.Form


    Public Sub New()
        MyBase.New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

    End Sub

    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label

    Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        Me.Button1.Location = New System.Drawing.Point(40, 64)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(80, 50)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Click for a bigger form."
        Me.Button2.Location = New System.Drawing.Point(144, 64)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(72, 48)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Click me and nothing happens."
        Me.Label1.Location = New System.Drawing.Point(72, 168)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(152, 32)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Click and drag on screen to see a frame drawn."
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "Form1"

        ' Explicitly set the form's BackColor property.
        Me.BackColor = Color.Cornsilk
        Me.ResumeLayout(False)

    End Sub

    <System.STAThreadAttribute()> Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub

    ' <snippet1>
    ' This method retrieves the form's client rectangle, inflates it,
    ' and forces layout of the form by resetting the bounds.  
    Private Sub Button1_Click(ByVal sender As System.Object, _
        ByVal e As System.EventArgs) Handles Button1.Click
        Dim clientRectangle As Rectangle = Me.ClientRectangle
        clientRectangle.Inflate(50, 50)

        ' Convert the rectangle coordinates to screen coordinates.
        Me.Bounds = Me.RectangleToScreen(clientRectangle)
    End Sub
    '</snippet1>

    '<snippet2>
    ' The following three methods will draw a rectangle and allow 
    ' the user to use the mouse to resize the rectangle.  If the 
    ' rectangle intersects a control's client rectangle, the 
    ' control's color will change.

    Dim isDrag As Boolean = False
    Dim theRectangle As New rectangle(New Point(0, 0), New Size(0, 0))
    Dim startPoint As Point

    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As _
        System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown

        ' Set the isDrag variable to true and get the starting point 
        ' by using the PointToScreen method to convert form coordinates to
        ' screen coordinates.
        If (e.Button = MouseButtons.Left) Then
            isDrag = True
        End If

        Dim control As Control = CType(sender, Control)

        ' Calculate the startPoint by using the PointToScreen 
        ' method.
        startPoint = control.PointToScreen(New Point(e.X, e.Y))
    End Sub

    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As _
    System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove

        ' If the mouse is being dragged, undraw and redraw the rectangle
        ' as the mouse moves.
        If (isDrag) Then

            ' Hide the previous rectangle by calling the DrawReversibleFrame 
            ' method with the same parameters.
            ControlPaint.DrawReversibleFrame(theRectangle, Me.BackColor, _
                FrameStyle.Dashed)

            ' Calculate the endpoint and dimensions for the new rectangle, 
            ' again using the PointToScreen method.
            Dim endPoint As Point = CType(sender, Control).PointToScreen(New Point(e.X, e.Y))
            Dim width As Integer = endPoint.X - startPoint.X
            Dim height As Integer = endPoint.Y - startPoint.Y
            theRectangle = New Rectangle(startPoint.X, startPoint.Y, _
                width, height)

            ' Draw the new rectangle by calling DrawReversibleFrame again.  
            ControlPaint.DrawReversibleFrame(theRectangle, Me.BackColor, _
                 FrameStyle.Dashed)
        End If
    End Sub

    Private Sub Form1_MouseUp(ByVal sender As Object, ByVal e As _
    System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseUp

        ' If the MouseUp event occurs, the user is not dragging.
        isDrag = False

        ' Draw the rectangle to be evaluated. Set a dashed frame style 
        ' using the FrameStyle enumeration.
        ControlPaint.DrawReversibleFrame(theRectangle, Me.BackColor, _
            FrameStyle.Dashed)

        ' Find out which controls intersect the rectangle and change their color.
        ' The method uses the RectangleToScreen method to convert the 
        ' Control's client coordinates to screen coordinates.
        Dim i As Integer
        Dim controlRectangle As Rectangle
        For i = 0 To Controls.Count - 1
            controlRectangle = Controls(i).RectangleToScreen _
                (Controls(i).ClientRectangle)
            If controlRectangle.IntersectsWith(theRectangle) Then
                Controls(i).BackColor = Color.BurlyWood
            End If
        Next

        ' Reset the rectangle.
        theRectangle = New Rectangle(0, 0, 0, 0)
    End Sub
    ' </snippet2>
End Class


