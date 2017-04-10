Imports System
Imports System.Drawing
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


    ' Snippet for: M:System.Drawing.TextureBrush.Clone
    ' <snippet1>
    Public Sub Clone_Example(ByVal e As PaintEventArgs)

        ' Create a TextureBrush object.
        Dim tBrush As New TextureBrush(New Bitmap("texture.jpg"))

        ' Create an exact copy of tBrush.
        Dim cloneBrush As TextureBrush = CType(tBrush.Clone(), _
        TextureBrush)

        ' Fill a rectangle with cloneBrush.
        e.Graphics.FillRectangle(cloneBrush, 0, 0, 100, 100)
    End Sub
    ' </snippet1>


    ' Snippet for: M:System.Drawing.TextureBrush.MultiplyTransform(System.Drawing.Drawing2D.Matrix)
    ' <snippet2>
    Public Sub MultiplyTransform_Example1(ByVal e As PaintEventArgs)

        ' Create a TextureBrush object.
        Dim tBrush As New TextureBrush(New Bitmap("texture.jpg"))

        ' Create a transformation matrix.
        Dim translateMatrix As New Matrix
        translateMatrix.Translate(50, 0)

        ' Multiply the transformation matrix of tBrush by translateMatrix.
        tBrush.MultiplyTransform(translateMatrix, MatrixOrder.Prepend)

        ' Fill a rectangle with tBrush.
        e.Graphics.FillRectangle(tBrush, 0, 110, 100, 100)
    End Sub
    ' </snippet2>


    ' Snippet for: M:System.Drawing.TextureBrush.MultiplyTransform(System.Drawing.Drawing2D.Matrix,System.Drawing.Drawing2D.MatrixOrder)
    ' <snippet3>
    Public Sub MultiplyTransform_Example2(ByVal e As PaintEventArgs)

        ' Create a TextureBrush object.
        Dim tBrush As New TextureBrush(New Bitmap("texture.jpg"))

        ' Create a transformation matrix.
        Dim translateMatrix As New Matrix
        translateMatrix.Translate(50, 0)

        ' Multiply the transformation matrix of tBrush by translateMatrix.
        tBrush.MultiplyTransform(translateMatrix)

        ' Fill a rectangle with tBrush.
        e.Graphics.FillRectangle(tBrush, 0, 110, 100, 100)
    End Sub
    ' </snippet3>


    ' Snippet for: M:System.Drawing.TextureBrush.ResetTransform
    ' <snippet4>
    Public Sub ResetTransform_Example(ByVal e As PaintEventArgs)

        ' Create a TextureBrush object.
        Dim tBrush As New TextureBrush(New Bitmap("texture.jpg"))

        ' Rotate the texture image by 90 degrees.
        tBrush.RotateTransform(90)

        ' Fill a rectangle with tBrush.
        e.Graphics.FillRectangle(tBrush, 0, 0, 100, 100)

        ' Reset transformation matrix to identity.
        tBrush.ResetTransform()

        ' Fill a rectangle with tBrush.
        e.Graphics.FillRectangle(tBrush, 0, 110, 100, 100)
    End Sub
    'ResetTransform_Example.
    ' </snippet4>


    ' Snippet for: M:System.Drawing.TextureBrush.RotateTransform(System.Single)
    ' <snippet5>
    Public Sub RotateTransform_Example1(ByVal e As PaintEventArgs)

        ' Create a TextureBrush object.
        Dim tBrush As New TextureBrush(New Bitmap("texture.jpg"))

        ' Rotate the texture image by 90 degrees.
        tBrush.RotateTransform(90)

        ' Fill a rectangle with tBrush.
        e.Graphics.FillRectangle(tBrush, 0, 0, 100, 100)
    End Sub
    ' </snippet5>


    ' Snippet for: M:System.Drawing.TextureBrush.RotateTransform(System.Single,System.Drawing.Drawing2D.MatrixOrder)
    ' <snippet6>
    Public Sub RotateTransform_Example2(ByVal e As PaintEventArgs)

        ' Create a TextureBrush object.
        Dim tBrush As New TextureBrush(New Bitmap("texture.jpg"))

        ' Rotate the texture image by 90 degrees.
        tBrush.RotateTransform(90, MatrixOrder.Prepend)

        ' Fill a rectangle with tBrush.
        e.Graphics.FillRectangle(tBrush, 0, 0, 100, 100)
    End Sub
    ' </snippet6>


    ' Snippet for: M:System.Drawing.TextureBrush.ScaleTransform(System.Single,System.Single)
    ' <snippet7>
    Public Sub ScaleTransform_Example1(ByVal e As PaintEventArgs)

        ' Create a TextureBrush object.
        Dim tBrush As New TextureBrush(New Bitmap("texture.jpg"))

        ' Scale the texture image 2X in the x-direction.
        tBrush.ScaleTransform(2, 1)

        ' Fill a rectangle with tBrush.
        e.Graphics.FillRectangle(tBrush, 0, 0, 100, 100)
    End Sub
    ' </snippet7>


    ' Snippet for: M:System.Drawing.TextureBrush.ScaleTransform(System.Single,System.Single,System.Drawing.Drawing2D.MatrixOrder)
    ' <snippet8>
    Public Sub ScaleTransform_Example2(ByVal e As PaintEventArgs)

        ' Create a TextureBrush object.
        Dim tBrush As New TextureBrush(New Bitmap("texture.jpg"))

        ' Scale the texture image 2X in the x-direction.
        tBrush.ScaleTransform(2, 1, MatrixOrder.Prepend)

        ' Fill a rectangle with tBrush.
        e.Graphics.FillRectangle(tBrush, 0, 0, 100, 100)
    End Sub
    ' </snippet8>


    ' Snippet for: M:System.Drawing.TextureBrush.TranslateTransform(System.Single,System.Single)
    ' <snippet9>
    Public Sub TranslateTransform_Example1(ByVal e As PaintEventArgs)

        ' Create a TextureBrush object.
        Dim tBrush As New TextureBrush(New Bitmap("texture.jpg"))

        ' Move the texture image 2X in the x-direction.
        tBrush.TranslateTransform(50, 0, MatrixOrder.Prepend)

        ' Fill a rectangle with tBrush.
        e.Graphics.FillRectangle(tBrush, 0, 0, 100, 100)
    End Sub
    ' </snippet9>


    ' Snippet for: M:System.Drawing.TextureBrush.TranslateTransform(System.Single,System.Single,System.Drawing.Drawing2D.MatrixOrder)
    ' <snippet10>
    Public Sub TranslateTransform_Example2(ByVal e As PaintEventArgs)

        ' Create a TextureBrush object.
        Dim tBrush As New TextureBrush(New Bitmap("texture.jpg"))

        ' Move the texture image 2X in the x-direction.
        tBrush.TranslateTransform(50, 0)

        ' Fill a rectangle with tBrush.
        e.Graphics.FillRectangle(tBrush, 0, 0, 100, 100)
    End Sub
    ' </snippet10>

    <STAThread()> Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub
End Class
