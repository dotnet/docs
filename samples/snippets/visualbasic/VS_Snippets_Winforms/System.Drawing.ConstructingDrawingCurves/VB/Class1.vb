Option Explicit On
Option Strict On

Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Collections
Imports System.Xml
Imports System.Drawing.Drawing2D

Public Class SystemDrawingConstructingDrawingCurves

' 37a0bedb-20c2-4cf0-91fa-a5509e826b30
' How to: Draw a Sequence of Bézier Splines
    Private Sub Method11(ByVal e As PaintEventArgs)

        ' <snippet11>
        ' Point(10, 100) = start point of first spline
        ' Point(75, 10) = first control point of first spline
        ' Point(80, 50) = second control point of first spline

        ' Point(100, 150) = endpoint of first spline and start point of second spline

        ' Point(125, 80) = first control point of second spline
        ' Point(175, 200) = second control point of second spline
        ' Point(200, 80)} = endpoint of second spline
        Dim p As Point() = { _
               New Point(10, 100), _
               New Point(75, 10), _
               New Point(80, 50), _
               New Point(100, 150), _
               New Point(125, 80), _
               New Point(175, 200), _
               New Point(200, 80)}

        Dim pen As New Pen(Color.Blue)
        e.Graphics.DrawBeziers(pen, p)

        ' </snippet11>
    End Sub
' a4a41e80-4461-4b47-b6bd-2c5e68881994
' How to: Draw Cardinal Splines
    Private Sub Method21(ByVal e As PaintEventArgs)
        ' <snippet21>
        Dim points As Point() = { _
           New Point(0, 100), _
           New Point(50, 80), _
           New Point(100, 20), _
           New Point(150, 80), _
           New Point(200, 100)}

        Dim pen As New Pen(Color.FromArgb(255, 0, 0, 255))
        e.Graphics.DrawCurve(pen, points)

        ' </snippet21>
    End Sub
    Private Sub Method22(ByVal e As PaintEventArgs)
        ' <snippet22>
        Dim points As Point() = { _
           New Point(60, 60), _
           New Point(150, 80), _
           New Point(200, 40), _
           New Point(180, 120), _
           New Point(120, 100), _
           New Point(80, 160)}

        Dim pen As New Pen(Color.FromArgb(255, 0, 0, 255))
        e.Graphics.DrawClosedCurve(pen, points)

        ' </snippet22>
    End Sub
    Private Sub Method23(ByVal e As PaintEventArgs)
        ' <snippet23>
        Dim points As Point() = { _
           New Point(20, 50), _
           New Point(100, 10), _
           New Point(200, 100), _
           New Point(300, 50), _
           New Point(400, 80)}

        Dim pen As New Pen(Color.FromArgb(255, 0, 0, 255))
        e.Graphics.DrawCurve(pen, points, 0.0F)
        e.Graphics.DrawCurve(pen, points, 0.6F)
        e.Graphics.DrawCurve(pen, points, 1.0F)

        ' </snippet23>
    End Sub
' f4f3fe30-f0a6-4743-ac91-11310cebea9f
' How to: Draw a Single Bézier Spline
    Private Sub Method31(ByVal e As PaintEventArgs)
        ' <snippet31>
        Dim p1 As New Point(10, 100) ' Start point
        Dim c1 As New Point(100, 10) ' First control point
        Dim c2 As New Point(150, 150) ' Second control point
        Dim p2 As New Point(200, 100) ' Endpoint

        Dim pen As New Pen(Color.FromArgb(255, 0, 0, 255))
        e.Graphics.DrawBezier(pen, p1, c1, c2, p2)

        ' </snippet31>
    End Sub
End Class

