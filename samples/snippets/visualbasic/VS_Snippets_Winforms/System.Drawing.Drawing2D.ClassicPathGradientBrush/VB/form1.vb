
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


    ' Snippet for: M:System.Drawing.Drawing2D.PathGradientBrush.MultiplyTransform(System.Drawing.Drawing2D.Matrix,System.Drawing.Drawing2D.MatrixOrder)
    ' <snippet1>
    Public Sub MultiplyTransformExample(ByVal e As PaintEventArgs)

        ' Create a graphics path and add a rectangle.
        Dim myPath As New GraphicsPath
        Dim rect As New Rectangle(20, 20, 100, 50)
        myPath.AddRectangle(rect)

        ' Get the path's array of points.
        Dim myPathPointArray As PointF() = myPath.PathPoints

        ' Create a path gradient brush.
        Dim myPGBrush As New PathGradientBrush(myPathPointArray)

        ' Set the color span.
        myPGBrush.CenterColor = Color.Red
        Dim mySurroundColor As Color() = {Color.Blue}
        myPGBrush.SurroundColors = mySurroundColor

        ' Draw the brush to the screen prior to transformation.
        e.Graphics.FillRectangle(myPGBrush, 10, 10, 200, 200)

        ' Create a new matrix that rotates by 90 degrees, and
        ' translates by 100 in each direction.
        Dim myMatrix As New Matrix(0, 1, -1, 0, 100, 100)

        ' Apply the transform to the brush.
        myPGBrush.MultiplyTransform(myMatrix, MatrixOrder.Append)

        ' Draw the brush to the screen again after applying the
        ' transform.
        e.Graphics.FillRectangle(myPGBrush, 10, 10, 200, 300)
    End Sub
    ' </snippet1>


    ' Snippet for: M:System.Drawing.Drawing2D.PathGradientBrush.RotateTransform(System.Single,System.Drawing.Drawing2D.MatrixOrder)
    ' <snippet2>
    Public Sub RotateTransformExample(ByVal e As PaintEventArgs)

        ' Create a graphics path and add a rectangle.
        Dim myPath As New GraphicsPath
        Dim rect As New Rectangle(100, 20, 100, 50)
        myPath.AddRectangle(rect)

        ' Get the path's array of points.
        Dim myPathPointArray As PointF() = myPath.PathPoints

        ' Create a path gradient brush.
        Dim myPGBrush As New PathGradientBrush(myPathPointArray)

        ' Set the color span.
        myPGBrush.CenterColor = Color.Red
        Dim mySurroundColor As Color() = {Color.Blue}
        myPGBrush.SurroundColors = mySurroundColor

        ' Draw the brush to the screen prior to transformation.
        e.Graphics.FillRectangle(myPGBrush, 10, 10, 200, 200)

        ' Apply the rotate transform to the brush.
        myPGBrush.RotateTransform(45, MatrixOrder.Append)

        ' Draw the brush to the screen again after applying the
        ' transform.
        e.Graphics.FillRectangle(myPGBrush, 10, 10, 200, 300)
    End Sub
    ' </snippet2>


    ' Snippet for: M:System.Drawing.Drawing2D.PathGradientBrush.ScaleTransform(System.Single,System.Single,System.Drawing.Drawing2D.MatrixOrder)
    ' <snippet3>
    Public Sub ScaleTransformExample(ByVal e As PaintEventArgs)

        ' Create a graphics path and add a rectangle.
        Dim myPath As New GraphicsPath
        Dim rect As New Rectangle(100, 20, 100, 50)
        myPath.AddRectangle(rect)

        ' Get the path's array of points.
        Dim myPathPointArray As PointF() = myPath.PathPoints

        ' Create a path gradient brush.
        Dim myPGBrush As New PathGradientBrush(myPathPointArray)

        ' Set the color span.
        myPGBrush.CenterColor = Color.Red
        Dim mySurroundColor As Color() = {Color.Blue}
        myPGBrush.SurroundColors = mySurroundColor

        ' Draw the brush to the screen prior to transformation.
        e.Graphics.FillRectangle(myPGBrush, 10, 10, 200, 200)

        ' Scale by a factor of 2 in the x-axis by applying the scale
        ' transform to the brush.
        myPGBrush.ScaleTransform(2, 1, MatrixOrder.Append)

        ' Move the brush down by 100 by Applying the translate
        ' transform to the brush.
        myPGBrush.TranslateTransform(-100, 100, MatrixOrder.Append)

        ' Draw the brush to the screen again after applying the
        ' transforms.
        e.Graphics.FillRectangle(myPGBrush, 10, 10, 300, 300)
    End Sub
    ' </snippet3>


    ' Snippet for: M:System.Drawing.Drawing2D.PathGradientBrush.SetBlendTriangularShape(System.Single,System.Single)
    ' <snippet4>
    Public Sub SetBlendTriangularShapeExample(ByVal e As PaintEventArgs)

        ' Create a graphics path and add a rectangle.
        Dim myPath As New GraphicsPath
        Dim rect As New Rectangle(100, 20, 100, 50)
        myPath.AddRectangle(rect)

        ' Get the path's array of points.
        Dim myPathPointArray As PointF() = myPath.PathPoints

        ' Create a path gradient brush.
        Dim myPGBrush As New PathGradientBrush(myPathPointArray)

        ' Set the color span.
        myPGBrush.CenterColor = Color.Red
        Dim mySurroundColor As Color() = {Color.Blue}
        myPGBrush.SurroundColors = mySurroundColor

        ' Draw the brush to the screen prior to blend.
        e.Graphics.FillRectangle(myPGBrush, 10, 10, 200, 200)

        ' Set the Blend factors.
        myPGBrush.SetBlendTriangularShape(0.5F, 1.0F)

        ' Move the brush down by 100 by Applying the translate
        ' transform to the brush.
        myPGBrush.TranslateTransform(0, 100, MatrixOrder.Append)

        ' Draw the brush to the screen again after applying the
        ' transforms.
        e.Graphics.FillRectangle(myPGBrush, 10, 10, 300, 300)
    End Sub
    ' </snippet4>


    ' Snippet for: M:System.Drawing.Drawing2D.PathGradientBrush.SetSigmaBellShape(System.Single,System.Single)
    ' <snippet5>
    Public Sub SetSigmaBellShapeExample(ByVal e As PaintEventArgs)

        ' Create a graphics path and add a rectangle.
        Dim myPath As New GraphicsPath
        Dim rect As New Rectangle(100, 20, 100, 50)
        myPath.AddRectangle(rect)

        ' Get the path's array of points.
        Dim myPathPointArray As PointF() = myPath.PathPoints

        ' Create a path gradient brush.
        Dim myPGBrush As New PathGradientBrush(myPathPointArray)

        ' Set the color span.
        myPGBrush.CenterColor = Color.Red
        Dim mySurroundColor As Color() = {Color.Blue}
        myPGBrush.SurroundColors = mySurroundColor

        ' Draw the brush to the screen prior to blend.
        e.Graphics.FillRectangle(myPGBrush, 10, 10, 200, 200)

        ' Set the Blend factors.
        myPGBrush.SetSigmaBellShape(0.5F, 1.0F)

        ' Move the brush down by 100 by applying the translate
        ' transform to the brush.
        myPGBrush.TranslateTransform(0, 100, MatrixOrder.Append)

        ' Draw the brush to the screen again after setting the
        ' blend and applying the transform.
        e.Graphics.FillRectangle(myPGBrush, 10, 10, 300, 300)
    End Sub
    ' </snippet5>

    <STAThread()> Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub
End Class
