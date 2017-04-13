Option Explicit On
Option Strict On

Imports System
Imports System.Diagnostics
Imports System.Windows.Forms
Imports System.Xml
Imports System.Data
Imports System.Collections
Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class Form1
    Inherits Form

    <STAThread()> _
    Public Shared Sub Main()
        Application.EnableVisualStyles()
        Application.Run(New Form1())
    End Sub


    ' 0828c331-a438-4bdd-a4d6-3ef1e59e8795
    ' How to: Use a Pen to Draw Lines
    Public Sub Method11(ByVal e As PaintEventArgs)
        ' <snippet11>
        Dim pen As New Pen(Color.FromArgb(255, 0, 0, 0))
        e.Graphics.DrawLine(pen, 20, 10, 300, 100)

        ' </snippet11>
    End Sub
    ' 54a7fa14-3ad8-4d64-b424-2a12005b250c
    ' How to: Use a Pen to Draw Rectangles
    Public Sub Method21(ByVal e As PaintEventArgs)
        ' <snippet21>
        Dim blackPen As New Pen(Color.FromArgb(255, 0, 0, 0), 5)
        e.Graphics.DrawRectangle(blackPen, 10, 10, 100, 50)
        ' </snippet21>
    End Sub
    ' 9fc480c2-3c75-4fd1-8ab5-296a99e820e2
    ' How to: Join Lines
    Public Sub Method31(ByVal e As PaintEventArgs)
        ' <snippet31>
        Dim path As New GraphicsPath()
        Dim penJoin As New Pen(Color.FromArgb(255, 0, 0, 255), 8)

        path.StartFigure()
        path.AddLine(New Point(50, 200), New Point(100, 200))
        path.AddLine(New Point(100, 200), New Point(100, 250))

        penJoin.LineJoin = LineJoin.Bevel
        e.Graphics.DrawPath(penJoin, path)

        ' </snippet31>
    End Sub
    ' a202af36-4d31-4401-a126-b232f51db581
    ' How to: Set Pen Width and Alignment
    Public Sub Method41(ByVal e As PaintEventArgs)
        ' <snippet41>
        Dim blackPen As New Pen(Color.FromArgb(255, 0, 0, 0), 1)
        Dim greenPen As New Pen(Color.FromArgb(255, 0, 255, 0), 10)
        greenPen.Alignment = PenAlignment.Center

        ' Draw the line with the wide green pen.
        e.Graphics.DrawLine(greenPen, 10, 100, 100, 50)

        ' Draw the line with the thin black pen.
        e.Graphics.DrawLine(blackPen, 10, 100, 100, 50)

        ' </snippet41>
    End Sub
    Public Sub Method42(ByVal e As PaintEventArgs)
        ' <snippet42>
        Dim blackPen As New Pen(Color.FromArgb(255, 0, 0, 0), 1)
        Dim greenPen As New Pen(Color.FromArgb(255, 0, 255, 0), 10)
        greenPen.Alignment = PenAlignment.Center

        ' Draw the rectangle with the wide green pen.
        e.Graphics.DrawRectangle(greenPen, 10, 100, 50, 50)

        ' Draw the rectangle with the thin black pen.
        e.Graphics.DrawRectangle(blackPen, 10, 100, 50, 50)

        ' </snippet42>
    End Sub
    Public Sub Method43(ByVal e As PaintEventArgs)
        Dim greenPen As New Pen(Color.FromArgb(255, 0, 255, 0), 10)
        ' <snippet43>
        greenPen.Alignment = PenAlignment.Inset

        ' </snippet43>
    End Sub
    ' cd0ed96a-cce4-47b9-b58a-3bae2e3d1bee
    ' How to: Draw a Custom Dashed Line
    Public Sub Method51(ByVal e As PaintEventArgs)
        ' <snippet51>
        Dim dashValues As Single() = {5, 2, 15, 4}
        Dim blackPen As New Pen(Color.Black, 5)
        blackPen.DashPattern = dashValues
        e.Graphics.DrawLine(blackPen, New Point(5, 5), New Point(405, 5))

        ' </snippet51>
    End Sub
    ' dc9118cc-f3c2-42e5-8173-f46d41d18fd5
    ' How to: Draw a Line Filled with a Texture
    Public Sub Method61(ByVal e As PaintEventArgs)
        ' <snippet61>
        Dim bitmap As New Bitmap("Texture1.jpg")
        Dim tBrush As New TextureBrush(bitmap)
        Dim texturedPen As New Pen(tBrush, 30)

        e.Graphics.DrawImage(bitmap, 0, 0, bitmap.Width, bitmap.Height)
        e.Graphics.DrawEllipse(texturedPen, 100, 20, 200, 100)

        ' </snippet61>
    End Sub
    ' eb68c3e1-c400-4886-8a04-76978a429cb6
    ' How to: Draw a Line with Line Caps
    Public Sub Method71(ByVal e As PaintEventArgs)
        ' <snippet71>
        Dim pen As New Pen(Color.FromArgb(255, 0, 0, 255), 8)
        pen.StartCap = LineCap.ArrowAnchor
        pen.EndCap = LineCap.RoundAnchor
        e.Graphics.DrawLine(pen, 20, 175, 300, 175)

        ' </snippet71>
    End Sub
End Class