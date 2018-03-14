Option Explicit On
Option Strict On

Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Collections
Imports System.Xml
Imports System.Drawing.Drawing2D

Public Class class1

    ' 1948e834-e104-481c-b71d-d8aa9e4d106e
    ' How to: Create a Path Gradient
    Public Sub Method11(ByVal e As PaintEventArgs)
        ' <snippet11>
        ' Create a path that consists of a single ellipse.
        Dim path As New GraphicsPath()
        path.AddEllipse(0, 0, 140, 70)

        ' Use the path to construct a brush.
        Dim pthGrBrush As New PathGradientBrush(path)

        ' Set the color at the center of the path to blue.
        pthGrBrush.CenterColor = Color.FromArgb(255, 0, 0, 255)

        ' Set the color along the entire boundary 
        ' of the path to aqua.
        Dim colors As Color() = {Color.FromArgb(255, 0, 255, 255)}
        pthGrBrush.SurroundColors = colors

        e.Graphics.FillEllipse(pthGrBrush, 0, 0, 140, 70)

        ' </snippet11>
    End Sub
    'The following example constructs a path gradient brush from a star-shaped path. T
    Public Sub Method12(ByVal e As PaintEventArgs)

        '<snippet12>
        ' Put the points of a polygon in an array.
        Dim points As Point() = { _
           New Point(75, 0), _
           New Point(100, 50), _
           New Point(150, 50), _
           New Point(112, 75), _
           New Point(150, 150), _
           New Point(75, 100), _
           New Point(0, 150), _
           New Point(37, 75), _
           New Point(0, 50), _
           New Point(50, 50)}

        ' Use the array of points to construct a path.
        Dim path As New GraphicsPath()
        path.AddLines(points)

        ' Use the path to construct a path gradient brush.
        Dim pthGrBrush As New PathGradientBrush(path)

        ' Set the color at the center of the path to red.
        pthGrBrush.CenterColor = Color.FromArgb(255, 255, 0, 0)

        ' Set the colors of the points in the array.
        Dim colors As Color() = { _
           Color.FromArgb(255, 0, 0, 0), _
           Color.FromArgb(255, 0, 255, 0), _
           Color.FromArgb(255, 0, 0, 255), _
           Color.FromArgb(255, 255, 255, 255), _
           Color.FromArgb(255, 0, 0, 0), _
           Color.FromArgb(255, 0, 255, 0), _
           Color.FromArgb(255, 0, 0, 255), _
           Color.FromArgb(255, 255, 255, 255), _
           Color.FromArgb(255, 0, 0, 0), _
           Color.FromArgb(255, 0, 255, 0)}

        pthGrBrush.SurroundColors = colors

        ' Fill the path with the path gradient brush.
        e.Graphics.FillPath(pthGrBrush, path)
        '</snippet12>
    End Sub
    

    Public Sub Method13(ByVal e As PaintEventArgs)
        '<snippet13>
        ' Construct a path gradient brush based on an array of points.
        Dim ptsF As PointF() = { _
           New PointF(0, 0), _
           New PointF(160, 0), _
           New PointF(160, 200), _
           New PointF(80, 150), _
           New PointF(0, 200)}

        Dim pBrush As New PathGradientBrush(ptsF)

        ' An array of five points was used to construct the path gradient
        ' brush. Set the color of each point in that array.  
        'Point (0, 0) is red
        'Point (160, 0) is green
        'Point (160, 200) is green
        'Point (80, 150) is blue
        'Point (0, 200) is red
        Dim colors As Color() = { _
           Color.FromArgb(255, 255, 0, 0), _
           Color.FromArgb(255, 0, 255, 0), _
           Color.FromArgb(255, 0, 255, 0), _
           Color.FromArgb(255, 0, 0, 255), _
           Color.FromArgb(255, 255, 0, 0)}
        pBrush.SurroundColors = colors

        ' Set the center color to white.
        pBrush.CenterColor = Color.White

        ' Use the path gradient brush to fill a rectangle.
        e.Graphics.FillRectangle(pBrush, New Rectangle(0, 0, 160, 200))
        '</snippet13>
    End Sub

    Public Sub Method14(ByVal e As PaintEventArgs)

        ' <snippet14>
        ' Create a path that consists of a single ellipse.
        Dim path As New GraphicsPath()
        path.AddEllipse(0, 0, 200, 100)

        ' Create a path gradient brush based on the elliptical path.
        Dim pthGrBrush As New PathGradientBrush(path)

        ' Set the color along the entire boundary to blue.
        ' Changed variable name from color
        Dim blueColor As Color() = {Color.Blue}
        pthGrBrush.SurroundColors = blueColor

        ' Set the center color to aqua.
        pthGrBrush.CenterColor = Color.Aqua

        ' Use the path gradient brush to fill the ellipse. 
        e.Graphics.FillPath(pthGrBrush, path)

        ' Set the focus scales for the path gradient brush.
        pthGrBrush.FocusScales = New PointF(0.3F, 0.8F)

        ' Use the path gradient brush to fill the ellipse again.
        ' Show this filled ellipse to the right of the first filled ellipse.
        e.Graphics.TranslateTransform(220.0F, 0.0F)
        e.Graphics.FillPath(pthGrBrush, path)

        ' </snippet14>
    End Sub

    Public Sub Method15(ByVal e As PaintEventArgs)
        ' <snippet15>
        ' Vertices of the outer triangle
        Dim points As Point() = { _
           New Point(100, 0), _
           New Point(200, 200), _
           New Point(0, 200)}

        ' No GraphicsPath object is created. The PathGradientBrush
        ' object is constructed directly from the array of points.
        Dim pthGrBrush As New PathGradientBrush(points)

        ' Create an array of colors containing dark green, aqua, and  blue.
        Dim colors As Color() = { _
           Color.FromArgb(255, 0, 128, 0), _
           Color.FromArgb(255, 0, 255, 255), _
           Color.FromArgb(255, 0, 0, 255)}

        ' Dark green is at the boundary of the triangle.
        ' Aqua is 40 percent of the way from the boundary to the center point.
        ' Blue is at the center point.
        Dim relativePositions As Single() = { _
           0.0F, _
           0.4F, _
           1.0F}

        Dim colorBlend As New ColorBlend()
        colorBlend.Colors = colors
        colorBlend.Positions = relativePositions
        pthGrBrush.InterpolationColors = colorBlend

        ' Fill a rectangle that is larger than the triangle
        ' specified in the Point array. The portion of the
        ' rectangle outside the triangle will not be painted.
        e.Graphics.FillRectangle(pthGrBrush, 0, 0, 200, 200)

        ' </snippet15>
    End Sub

    Public Sub Method16(ByVal e As PaintEventArgs)
        ' <snippet16>
        ' Create a path that consists of a single ellipse.
        Dim path As New GraphicsPath()
        path.AddEllipse(0, 0, 140, 70)

        ' Use the path to construct a brush.
        Dim pthGrBrush As New PathGradientBrush(path)

        ' Set the center point to a location that is not
        ' the centroid of the path.
        pthGrBrush.CenterPoint = New PointF(120, 40)

        ' Set the color at the center of the path to blue.
        pthGrBrush.CenterColor = Color.FromArgb(255, 0, 0, 255)

        ' Set the color along the entire boundary 
        ' of the path to aqua.
        Dim colors As Color() = {Color.FromArgb(255, 0, 255, 255)}
        pthGrBrush.SurroundColors = colors

        e.Graphics.FillEllipse(pthGrBrush, 0, 0, 140, 70)
        ' </snippet16>
    
        '<snippet17>
        pthGrBrush.CenterPoint = New PointF(145, 35)
        '</snippet17>
    End Sub

    ' 6c88e1cc-1217-4399-ac12-cb37592b9f01
    ' How to: Create a Linear Gradient
    Public Sub Method21(ByVal e As PaintEventArgs)
        ' <snippet21>
        Dim linGrBrush As New LinearGradientBrush( _
           New Point(0, 10), _
           New Point(200, 10), _
           Color.FromArgb(255, 255, 0, 0), _
           Color.FromArgb(255, 0, 0, 255))
        Dim pen As New Pen(linGrBrush)

        e.Graphics.DrawLine(pen, 0, 10, 200, 10)
        e.Graphics.FillEllipse(linGrBrush, 0, 30, 200, 100)
        e.Graphics.FillRectangle(linGrBrush, 0, 155, 500, 30)

        ' </snippet21>
    End Sub


    Public Sub Method22(ByVal e As PaintEventArgs)
        ' <snippet22>
        Dim linGrBrush As New LinearGradientBrush( _
           New Point(0, 10), _
           New Point(200, 10), _
           Color.FromArgb(255, 0, 0, 0), _
           Color.FromArgb(255, 255, 0, 0))

        Dim relativeIntensities As Single() = {0.0F, 0.5F, 1.0F}
        Dim relativePositions As Single() = {0.0F, 0.2F, 1.0F}

        'Create a Blend object and assign it to linGrBrush.
        Dim blend As New Blend()
        blend.Factors = relativeIntensities
        blend.Positions = relativePositions
        linGrBrush.Blend = blend

        e.Graphics.FillEllipse(linGrBrush, 0, 30, 200, 100)
        e.Graphics.FillRectangle(linGrBrush, 0, 155, 500, 30)

        ' </snippet22>
    End Sub


    Public Sub Method23(ByVal e As PaintEventArgs)
        ' <snippet23>
        Dim linGrBrush As New LinearGradientBrush( _
           New Point(0, 0), _
           New Point(200, 100), _
           Color.FromArgb(255, 0, 0, 255), _
           Color.FromArgb(255, 0, 255, 0))
        ' opaque blue
        ' opaque green
        Dim pen As New Pen(linGrBrush, 10)

        e.Graphics.DrawLine(pen, 0, 0, 600, 300)
        e.Graphics.FillEllipse(linGrBrush, 10, 100, 200, 100)

        ' </snippet23>
    End Sub

    ' da4690e7-5fac-4fd2-b3f0-5cb35c165b92
    ' How to: Apply Gamma Correction to a Gradient
    Public Sub Method31(ByVal e As PaintEventArgs)
        ' <snippet31>
        Dim linGrBrush As New LinearGradientBrush( _
           New Point(0, 10), _
           New Point(200, 10), _
           Color.Red, _
           Color.Blue)

        e.Graphics.FillRectangle(linGrBrush, 0, 0, 200, 50)
        linGrBrush.GammaCorrection = True
        e.Graphics.FillRectangle(linGrBrush, 0, 60, 200, 50)
        ' </snippet31>
    End Sub
End Class


