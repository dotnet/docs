Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data


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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container
        Me.Text = "Form1"
    End Sub

#End Region


    ' Snippet for: M:System.Drawing.Pen.Clone
    ' <snippet1>
    Public Sub Clone_Example(ByVal e As PaintEventArgs)

        ' Create a Pen object.
        Dim myPen As New Pen(Color.Black, 5)

        ' Clone myPen.
        Dim clonePen As Pen = CType(myPen.Clone(), Pen)

        ' Draw a line with clonePen.
        e.Graphics.DrawLine(clonePen, 0, 0, 100, 100)
    End Sub
    ' </snippet1>


    ' Snippet for: M:System.Drawing.Pen.MultiplyTransform(System.Drawing.Drawing2D.Matrix)
    ' <snippet2>
    Public Sub MultiplyTransform_Example1(ByVal e As PaintEventArgs)

        ' Create a Pen object.
        Dim myPen As New Pen(Color.Black, 5)

        ' Create a translation matrix.
        Dim penMatrix As New Matrix
        penMatrix.Scale(3, 1)

        ' Multiply the transformation matrix of myPen by transMatrix.
        myPen.MultiplyTransform(penMatrix)

        ' Draw a line to the screen.
        e.Graphics.DrawLine(myPen, 0, 0, 100, 100)
    End Sub
    ' </snippet2>


    ' Snippet for: M:System.Drawing.Pen.MultiplyTransform(System.Drawing.Drawing2D.Matrix,System.Drawing.Drawing2D.MatrixOrder)
    ' <snippet3>
    Public Sub MultiplyTransform_Example2(ByVal e As PaintEventArgs)

        ' Create a Pen object.
        Dim myPen As New Pen(Color.Black, 5)

        ' Create a translation matrix.
        Dim penMatrix As New Matrix
        penMatrix.Scale(3, 1)

        ' Multiply the transformation matrix of myPen by transMatrix.
        myPen.MultiplyTransform(penMatrix, MatrixOrder.Prepend)

        ' Draw a line to the screen.
        e.Graphics.DrawLine(myPen, 0, 0, 100, 100)
    End Sub
    ' </snippet3>


    ' Snippet for: M:System.Drawing.Pen.ResetTransform
    ' <snippet4>
    Public Sub ResetTransform_Example(ByVal e As PaintEventArgs)

        ' Create a Pen object.
        Dim myPen As New Pen(Color.Black, 3)

        ' Scale the transformation matrix of myPen.
        myPen.ScaleTransform(2, 1)

        ' Draw a line with myPen.
        e.Graphics.DrawLine(myPen, 10, 0, 10, 200)

        ' Reset the transformation matrix of myPen to identity.
        myPen.ResetTransform()

        ' Draw a second line with myPen.
        e.Graphics.DrawLine(myPen, 100, 0, 100, 200)
    End Sub
    ' </snippet4>


    ' Snippet for: M:System.Drawing.Pen.RotateTransform(System.Single)
    ' <snippet5>
    Public Sub RotateTransform_Example1(ByVal e As PaintEventArgs)

        ' Create a Pen object.
        Dim rotatePen As New Pen(Color.Black, 5)

        ' Draw a rectangle with rotatePen.
        e.Graphics.DrawRectangle(rotatePen, 10, 10, 100, 100)

        ' Scale rotatePen by 2X in the x-direction.
        rotatePen.ScaleTransform(2, 1)

        ' Rotate rotatePen 90 degrees clockwise.
        rotatePen.RotateTransform(90)

        ' Draw a second rectangle with rotatePen.
        e.Graphics.DrawRectangle(rotatePen, 140, 10, 100, 100)
    End Sub
    ' </snippet5>


    ' Snippet for: M:System.Drawing.Pen.RotateTransform(System.Single,System.Drawing.Drawing2D.MatrixOrder)
    ' <snippet6>
    Public Sub RotateTransform_Example2(ByVal e As PaintEventArgs)

        ' Create a Pen object.
        Dim rotatePen As New Pen(Color.Black, 5)

        ' Scale rotatePen by 2X in the x-direction.
        rotatePen.ScaleTransform(2, 1)

        ' Draw a rectangle with rotatePen.
        e.Graphics.DrawRectangle(rotatePen, 10, 10, 100, 100)

        ' Rotate rotatePen 90 degrees clockwise.
        rotatePen.RotateTransform(90, MatrixOrder.Append)

        ' Draw a second rectangle with rotatePen.
        e.Graphics.DrawRectangle(rotatePen, 120, 10, 100, 100)
    End Sub
    ' </snippet6>


    ' Snippet for: M:System.Drawing.Pen.ScaleTransform(System.Single,System.Single)
    ' <snippet7>
    Public Sub ScaleTransform_Example1(ByVal e As PaintEventArgs)

        ' Create a Pen object.
        Dim scalePen As New Pen(Color.Black, 5)

        ' Draw a rectangle with scalePen.
        e.Graphics.DrawRectangle(scalePen, 10, 10, 100, 100)

        ' Scale scalePen by 2X in the x-direction.
        scalePen.ScaleTransform(2, 1)

        ' Draw a second rectangle with rotatePen.
        e.Graphics.DrawRectangle(scalePen, 120, 10, 100, 100)
    End Sub
    ' </snippet7>


    ' Snippet for: M:System.Drawing.Pen.ScaleTransform(System.Single,System.Single,System.Drawing.Drawing2D.MatrixOrder)
    ' <snippet8>
    Public Sub ScaleTransform_Example2(ByVal e As PaintEventArgs)

        ' Create a Pen object.
        Dim scalePen As New Pen(Color.Black, 5)

        ' Draw a rectangle with scalePen.
        e.Graphics.DrawRectangle(scalePen, 10, 10, 100, 100)

        ' Scale scalePen by 2X in the x-direction.
        scalePen.ScaleTransform(2, 1, MatrixOrder.Prepend)

        ' Draw a second rectangle with rotatePen.
        e.Graphics.DrawRectangle(scalePen, 120, 10, 100, 100)
    End Sub
    ' </snippet8>


    ' Snippet for: M:System.Drawing.Pen.SetLineCap(System.Drawing.Drawing2D.LineCap,System.Drawing.Drawing2D.LineCap,System.Drawing.Drawing2D.DashCap)
    ' <snippet9>
    Public Sub SetLineCap_Example(ByVal e As PaintEventArgs)

        ' Create a Pen object with a dash pattern.
        Dim capPen As New Pen(Color.Black, 5)
        capPen.DashStyle = DashStyle.Dash

        ' Set the start and end caps for capPen.
        capPen.SetLineCap(LineCap.ArrowAnchor, LineCap.Flat, DashCap.Flat)

        ' Draw a line with capPen.
        e.Graphics.DrawLine(capPen, 10, 10, 200, 10)
    End Sub
    ' </snippet9>

    Private Sub Form1_Paint(ByVal sender As Object, ByVal e As Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        SetLineCap_Example(e)
    End Sub

    <STAThread()> _
    Shared Sub Main()
        Application.Run(New Form1)

    End Sub 'Main
End Class
