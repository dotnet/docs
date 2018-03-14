Option Explicit On
Option Strict On

Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Collections
Imports System.Xml
Imports System.Drawing.Drawing2D

Public Class SystemDrawingConstructingDrawingPaths

' 5a36b0e4-f1f4-46c0-a85a-22ae98491950
' How to: Fill Open Figures
    Private Sub Method11(ByVal e As PaintEventArgs)
        ' <snippet11>
        Dim path As New GraphicsPath()

        ' Add an open figure.
        path.AddArc(0, 0, 150, 120, 30, 120)

        ' Add an intrinsically closed figure.
        path.AddEllipse(50, 50, 50, 100)

        Dim pen As New Pen(Color.FromArgb(128, 0, 0, 255), 5)
        Dim brush As New SolidBrush(Color.Red)

        ' The fill mode is FillMode.Alternate by default.
        e.Graphics.FillPath(brush, path)
        e.Graphics.DrawPath(pen, path)

        ' </snippet11>
    End Sub
' 82fd56c7-b443-4765-9b7c-62ce030656ec
' How to: Create Figures from Lines, Curves, and Shapes
    Private Sub Method21(ByVal e As PaintEventArgs)
        ' <snippet21>
        Dim path As New GraphicsPath()
        path.AddArc(175, 50, 50, 50, 0, -180)
        e.Graphics.DrawPath(New Pen(Color.FromArgb(128, 255, 0, 0), 4), path)

        ' </snippet21>
    End Sub
    Private Sub Method22(ByVal e As PaintEventArgs)
        ' <snippet22>
        ' Create an array of points for the curve in the second figure.
        Dim points As Point() = { _
           New Point(40, 60), _
           New Point(50, 70), _
           New Point(30, 90)}

        Dim path As New GraphicsPath()

        path.StartFigure() ' Start the first figure.
        path.AddArc(175, 50, 50, 50, 0, -180)
        path.AddLine(100, 0, 250, 20)
        ' First figure is not closed.

        path.StartFigure() ' Start the second figure.
        path.AddLine(50, 20, 5, 90)
        path.AddCurve(points, 3)
        path.AddLine(50, 150, 150, 180)
        path.CloseFigure() ' Second figure is closed.
        e.Graphics.DrawPath(New Pen(Color.FromArgb(255, 255, 0, 0), 2), path)

        ' </snippet22>
    End Sub
End Class

