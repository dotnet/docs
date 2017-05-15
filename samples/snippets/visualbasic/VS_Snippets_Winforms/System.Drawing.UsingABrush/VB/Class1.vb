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

Public Class class1
    ' 06088b31-bac9-4ef3-9ebe-06c2c764d6df
    ' How to: Fill a Shape with a Solid Color
    Public Sub Method11(ByVal e As PaintEventArgs)
        ' <snippet11>
        Dim solidBrush As New SolidBrush( _
           Color.FromArgb(255, 255, 0, 0))
        e.Graphics.FillEllipse(solidBrush, 0, 0, 100, 60)

        ' </snippet11>
    End Sub
    ' 508da5a6-2433-4d2b-9680-eaeae4e96e3b
    ' How to: Fill a Shape with an Image Texture
    Public Sub Method21(ByVal e As PaintEventArgs)
        ' <snippet21>
        Dim image As New Bitmap("ImageFile.jpg")
        Dim tBrush As New TextureBrush(image)
        tBrush.Transform = New Matrix( _
           75.0F / 640.0F, _
           0.0F, _
           0.0F, _
           75.0F / 480.0F, _
           0.0F, _
           0.0F)
        e.Graphics.FillEllipse(tBrush, New Rectangle(0, 150, 150, 250))

        ' </snippet21>
    End Sub
    ' 6d407891-6e5c-4495-a546-3da5604e9fb8
    ' How to: Tile a Shape with an Image
    Public Sub Method31(ByVal e As PaintEventArgs)
        ' <snippet31>
        Dim image As New Bitmap("HouseAndTree.gif")
        Dim tBrush As New TextureBrush(image)
        Dim blackPen As New Pen(Color.Black)
        e.Graphics.FillRectangle(tBrush, New Rectangle(0, 0, 200, 200))
        e.Graphics.DrawRectangle(blackPen, New Rectangle(0, 0, 200, 200))

        ' </snippet31>
    End Sub
    Public Sub Method32(ByVal e As PaintEventArgs)
        ' <snippet32>
        Dim image As New Bitmap("HouseAndTree.gif")
        Dim tBrush As New TextureBrush(image)
        Dim blackPen As New Pen(Color.Black)
        tBrush.WrapMode = WrapMode.TileFlipX
        e.Graphics.FillRectangle(tBrush, New Rectangle(0, 0, 200, 200))
        e.Graphics.DrawRectangle(blackPen, New Rectangle(0, 0, 200, 200))

        ' </snippet32>
    End Sub
    Public Sub Method33(ByVal e As PaintEventArgs)
        ' <snippet33>
        Dim image As New Bitmap("HouseAndTree.gif")
        Dim tBrush As New TextureBrush(image)
        Dim blackPen As New Pen(Color.Black)
        tBrush.WrapMode = WrapMode.TileFlipY
        e.Graphics.FillRectangle(tBrush, New Rectangle(0, 0, 200, 200))
        e.Graphics.DrawRectangle(blackPen, New Rectangle(0, 0, 200, 200))

        ' </snippet33>
    End Sub
    Public Sub Method34(ByVal e As PaintEventArgs)
        ' <snippet34>
        Dim image As New Bitmap("HouseAndTree.gif")
        Dim tBrush As New TextureBrush(image)
        Dim blackPen As New Pen(Color.Black)
        tBrush.WrapMode = WrapMode.TileFlipXY
        e.Graphics.FillRectangle(tBrush, New Rectangle(0, 0, 200, 200))
        e.Graphics.DrawRectangle(blackPen, New Rectangle(0, 0, 200, 200))

        ' </snippet34>
    End Sub
    ' 9c8300ff-187b-404f-af1f-ebd499f5b16f
    ' How to: Fill a Shape with a Hatch Pattern
    Public Sub Method41(ByVal e As PaintEventArgs)
        ' <snippet41>
        Dim hBrush As New HatchBrush( _
           HatchStyle.Horizontal, _
           Color.Red, _
           Color.FromArgb(255, 128, 255, 255))
        e.Graphics.FillEllipse(hBrush, 0, 0, 100, 60)

        ' </snippet41>
    End Sub
End Class

