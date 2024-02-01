Option Explicit On
Option Strict On

Imports System.Windows.Forms
Imports System.Drawing
Imports System.Collections
Imports System.Xml
Imports System.Drawing.Imaging
Imports System.Drawing.Drawing2D

Public Class Form1
    Inherits Form

    <STAThread()> _
    Public Shared Sub Main()
        Application.EnableVisualStyles()
        Application.Run(New Form1())
    End Sub

    Dim myPen As Pen = Pens.Black
    ' 0659fe00-9e0c-41c4-9118-016f2404c905
    ' Matrix Representation of Transformations
    Public Sub Method11()
        Dim myGraphics As Graphics = Me.CreateGraphics()
        ' <snippet11>
        Dim myMatrix As New Matrix()
        myMatrix.Rotate(30)
        myMatrix.Scale(1, 2, MatrixOrder.Append)
        myMatrix.Translate(5, 0, MatrixOrder.Append)

        ' </snippet11>
    End Sub
    ' b601d66d-d572-4f11-9d2e-92f0dc8893f3
    ' Global and Local Transformations
    Public Sub Method21()
        Dim myGraphics As Graphics = Me.CreateGraphics()
        ' <snippet21>
        myGraphics.DrawEllipse(myPen, 0, 0, 100, 50)
        myGraphics.ScaleTransform(1, 0.5F)
        myGraphics.TranslateTransform(50, 0, MatrixOrder.Append)
        myGraphics.RotateTransform(30, MatrixOrder.Append)
        myGraphics.DrawEllipse(myPen, 0, 0, 100, 50)

        ' </snippet21>
    End Sub
    Public Sub Method22()
        Dim myGraphics As Graphics = Me.CreateGraphics()
        Dim myGraphicsPath As New GraphicsPath()
        ' <snippet22>
        Dim myMatrix As New Matrix()
        myMatrix.Rotate(45)
        myGraphicsPath.Transform(myMatrix)
        myGraphics.DrawRectangle(myPen, 10, 10, 100, 50)
        myGraphics.DrawPath(myPen, myGraphicsPath)

        ' </snippet22>
    End Sub
    Public Sub Method23()
        Dim myGraphics As Graphics = Me.CreateGraphics()
        ' <snippet23>
        Dim myMatrix As New Matrix(1, 0, 0, -1, 0, 0)
        myGraphics.Transform = myMatrix
        myGraphics.TranslateTransform(200, 150, MatrixOrder.Append)

        ' </snippet23>
    End Sub
    Public Sub Method24()
        Dim myGraphics As Graphics = Me.CreateGraphics()
        Dim mySolidBrush1 As New SolidBrush(Color.Red)
        Dim mySolidBrush2 As New SolidBrush(Color.Black)

        ' <snippet24>
        ' Create the path.
        Dim myGraphicsPath As New GraphicsPath()
        Dim myRectangle As New Rectangle(0, 0, 60, 60)
        myGraphicsPath.AddRectangle(myRectangle)

        ' Fill the path on the new coordinate system.
        ' No local transformation
        myGraphics.FillPath(mySolidBrush1, myGraphicsPath)

        ' Set the local transformation of the GraphicsPath object.
        Dim myPathMatrix As New Matrix()
        myPathMatrix.Scale(2, 1)
        myPathMatrix.Rotate(30, MatrixOrder.Append)
        myGraphicsPath.Transform(myPathMatrix)

        ' Fill the transformed path on the new coordinate system.
        myGraphics.FillPath(mySolidBrush2, myGraphicsPath)

        ' </snippet24>
    End Sub
    ' c61ff50a-eb1d-4e6c-83cd-f7e9764cfa9f
    ' Types of Coordinate Systems
    Public Sub Method31()
        Dim myGraphics As Graphics = Me.CreateGraphics()
        ' <snippet31>
        myGraphics.TranslateTransform(100, 50)
        myGraphics.DrawLine(myPen, 0, 0, 160, 80)

        ' </snippet31>
    End Sub
    Public Sub Method32()
        Dim myGraphics As Graphics = Me.CreateGraphics()
        ' <snippet32>
        myGraphics.PageUnit = GraphicsUnit.Inch
        myGraphics.DrawLine(myPen, 0, 0, 2, 1)

        ' </snippet32>
    End Sub
    Public Sub Method33()
        Dim myGraphics As Graphics = Me.CreateGraphics()
        ' <snippet33>
        Dim myPen As New Pen(Color.Black, 1 / myGraphics.DpiX)

        ' </snippet33>
    End Sub
    Public Sub Method34()
        Dim myGraphics As Graphics = Me.CreateGraphics()
        ' <snippet34>
        myGraphics.TranslateTransform(2, 0.5F)
        myGraphics.PageUnit = GraphicsUnit.Inch
        myGraphics.DrawLine(myPen, 0, 0, 2, 1)

        ' </snippet34>
    End Sub
End Class

