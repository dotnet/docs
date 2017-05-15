Imports System.Drawing
Imports System.Windows.Forms
Imports System.Drawing.Drawing2D

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



    ' Snippet for: M:System.Drawing.Drawing2D.LinearGradientBrush.Clone
    ' <snippet1>
    Public Sub CloneExample(ByVal e As PaintEventArgs)

        ' Create a LinearGradientBrush.
        Dim x As Integer = 20
        Dim y As Integer = 20
        Dim h As Integer = 100
        Dim w As Integer = 200
        Dim myRect As New Rectangle(x, y, w, h)
        Dim myLGBrush As New LinearGradientBrush(myRect, Color.Blue, _
        Color.Aquamarine, 45.0F, True)

        ' Draw an ellipse to the screen using the LinearGradientBrush.
        e.Graphics.FillEllipse(myLGBrush, x, y, w, h)

        ' Clone the LinearGradientBrush.
        Dim clonedLGBrush As LinearGradientBrush = _
        CType(myLGBrush.Clone(), LinearGradientBrush)

        ' Justify the left edge of the gradient with the left edge of the
        ' ellipse.
        clonedLGBrush.TranslateTransform(-100.0F, 0.0F)

        ' Draw a second ellipse to the screen using the cloned HBrush.
        y = 150
        e.Graphics.FillEllipse(clonedLGBrush, x, y, w, h)
    End Sub
    ' </snippet1>


    ' Snippet for: M:System.Drawing.Drawing2D.LinearGradientBrush.MultiplyTransform(System.Drawing.Drawing2D.Matrix,System.Drawing.Drawing2D.MatrixOrder)
    ' <snippet2>
    Public Sub MultiplyTransformExample(ByVal e As PaintEventArgs)

        ' Create a LinearGradientBrush.
        Dim myRect As New Rectangle(20, 20, 200, 100)
        Dim myLGBrush As New LinearGradientBrush(myRect, Color.Blue, _
        Color.Red, 0.0F, True)

        ' Draw an ellipse to the screen using the LinearGradientBrush.
        e.Graphics.FillEllipse(myLGBrush, myRect)

        ' Transform the LinearGradientBrush.
        Dim transformArray As Point() = {New Point(20, 150), _
        New Point(400, 150), New Point(20, 200)}
        Dim myMatrix As New Matrix(myRect, transformArray)
        myLGBrush.MultiplyTransform(myMatrix, MatrixOrder.Prepend)

        ' Draw a second ellipse to the screen using the transformed brush.
        e.Graphics.FillEllipse(myLGBrush, 20, 150, 380, 50)
    End Sub
    ' </snippet2>


    ' Snippet for: M:System.Drawing.Drawing2D.LinearGradientBrush.ResetTransform
    ' <snippet3>
    Public Sub ResetTransformExample(ByVal e As PaintEventArgs)

        ' Create a LinearGradientBrush.
        Dim myRect As New Rectangle(20, 20, 200, 100)
        Dim myLGBrush As New LinearGradientBrush(myRect, Color.Blue, _
        Color.Red, 0.0F, True)

        ' Draw an ellipse to the screen using the LinearGradientBrush.
        e.Graphics.FillEllipse(myLGBrush, myRect)

        ' Transform the LinearGradientBrush.
        Dim transformArray As Point() = {New Point(20, 150), _
        New Point(400, 150), New Point(20, 200)}
        Dim myMatrix As New Matrix(myRect, transformArray)
        myLGBrush.MultiplyTransform(myMatrix, MatrixOrder.Prepend)

        ' Draw a second ellipse to the screen using the transformed brush.
        e.Graphics.FillEllipse(myLGBrush, 20, 150, 380, 50)

        ' Reset the brush transform.
        myLGBrush.ResetTransform()

        ' Draw a third ellipse to the screen using the reset brush.
        e.Graphics.FillEllipse(myLGBrush, 20, 250, 200, 100)
    End Sub
    ' </snippet3>


    ' Snippet for: M:System.Drawing.Drawing2D.LinearGradientBrush.RotateTransform(System.Single,System.Drawing.Drawing2D.MatrixOrder)
    ' <snippet4>
    Public Sub RotateTransformExample(ByVal e As PaintEventArgs)

        ' Create a LinearGradientBrush.
        Dim myRect As New Rectangle(20, 20, 200, 100)
        Dim myLGBrush As New LinearGradientBrush(myRect, Color.Blue, _
        Color.Red, 0.0F, True)

        ' Draw an ellipse to the screen using the LinearGradientBrush.
        e.Graphics.FillEllipse(myLGBrush, myRect)

        ' Rotate the LinearGradientBrush.
        myLGBrush.RotateTransform(45.0F, MatrixOrder.Prepend)

        ' Rejustify the brush to start at the left edge of the ellipse.
        myLGBrush.TranslateTransform(-100.0F, 0.0F)

        ' Draw a second ellipse to the screen using the transformed brush.
        e.Graphics.FillEllipse(myLGBrush, 20, 150, 200, 100)
    End Sub
    ' </snippet4>


    ' Snippet for: M:System.Drawing.Drawing2D.LinearGradientBrush.ScaleTransform(System.Single,System.Single,System.Drawing.Drawing2D.MatrixOrder)
    ' <snippet5>
    Public Sub ScaleTransformExample(ByVal e As PaintEventArgs)

        ' Create a LinearGradientBrush.
        Dim myRect As New Rectangle(20, 20, 200, 100)
        Dim myLGBrush As New LinearGradientBrush(myRect, Color.Blue, _
        Color.Red, 0.0F, True)

        ' Draw an ellipse to the screen using the LinearGradientBrush.
        e.Graphics.FillEllipse(myLGBrush, myRect)

        ' Scale the LinearGradientBrush.
        myLGBrush.ScaleTransform(2.0F, 1.0F, MatrixOrder.Prepend)

        ' Rejustify the brush to start at the left edge of the ellipse.
        myLGBrush.TranslateTransform(-20.0F, 0.0F)

        ' Draw a second ellipse to the screen using the transformed brush.
        e.Graphics.FillEllipse(myLGBrush, 20, 150, 200, 100)
    End Sub
    ' </snippet5>


    ' Snippet for: M:System.Drawing.Drawing2D.LinearGradientBrush.SetBlendTriangularShape(System.Single,System.Single)
    ' <snippet6>
    Public Sub SetBlendTriangularShapeExample(ByVal e As PaintEventArgs)

        ' Create a LinearGradientBrush.
        Dim myRect As New Rectangle(20, 20, 200, 100)
        Dim myLGBrush As New LinearGradientBrush(myRect, Color.Blue, _
        Color.Red, 0.0F, True)

        ' Draw an ellipse to the screen using the LinearGradientBrush.
        e.Graphics.FillEllipse(myLGBrush, myRect)

        ' Create a triangular shaped brush with the peak at the center

        ' of the drawing area.
        myLGBrush.SetBlendTriangularShape(0.5F, 1.0F)

        ' Use the triangular brush to draw a second ellipse.
        myRect.Y = 150
        e.Graphics.FillEllipse(myLGBrush, myRect)
    End Sub
    ' </snippet6>


    ' Snippet for: M:System.Drawing.Drawing2D.LinearGradientBrush.SetSigmaBellShape(System.Single,System.Single)
    ' <snippet7>
    Public Sub SetSigmaBellShapeExample(ByVal e As PaintEventArgs)

        ' Create a LinearGradientBrush.
        Dim myRect As New Rectangle(20, 20, 200, 100)
        Dim myLGBrush As New LinearGradientBrush(myRect, Color.Blue, _
        Color.Red, 0.0F, True)

        ' Draw an ellipse to the screen using the LinearGradientBrush.
        e.Graphics.FillEllipse(myLGBrush, myRect)

        ' Create a triangular shaped brush with the peak at the center
        ' of the drawing area.
        myLGBrush.SetSigmaBellShape(0.5F, 1.0F)

        ' Use the triangular brush to draw a second ellipse.
        myRect.Y = 150
        e.Graphics.FillEllipse(myLGBrush, myRect)
    End Sub
    ' </snippet7>


    ' Snippet for: M:System.Drawing.Drawing2D.LinearGradientBrush.TranslateTransform(System.Single,System.Single,System.Drawing.Drawing2D.MatrixOrder)
    ' <snippet8>
    Public Sub TranslateTransformExample(ByVal e As PaintEventArgs)

        ' Create a LinearGradientBrush.
        Dim myRect As New Rectangle(20, 20, 200, 100)
        Dim myLGBrush As New LinearGradientBrush(myRect, Color.Blue, _
        Color.Red, 0.0F, True)

        ' Draw a rectangle to the screen using the LinearGradientBrush.
        e.Graphics.FillRectangle(myLGBrush, myRect)

        ' Rotate the LinearGradientBrush.
        myLGBrush.RotateTransform(90.0F)

        ' Scale the gradient for the height of the rectangle.
        myLGBrush.ScaleTransform(0.5F, 1.0F)

        ' Draw to the screen, the rotated and scaled gradient.
        e.Graphics.FillRectangle(myLGBrush, 20, 150, 200, 100)

        ' Rejustify the brush to start at the top edge of the rectangle.
        myLGBrush.TranslateTransform(-20.0F, 0.0F)

        ' Draw a third rectangle to the screen using the translated brush.
        e.Graphics.FillRectangle(myLGBrush, 20, 300, 200, 100)
    End Sub
    ' </snippet8>

    <STAThread()> Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub
End Class
