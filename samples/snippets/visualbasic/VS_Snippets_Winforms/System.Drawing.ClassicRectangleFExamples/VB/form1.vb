Imports System.Drawing
Imports System.Windows.Forms
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices

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


    ' Snippet for: M:System.Drawing.RectangleF.Inflate(System.Drawing.SizeF)
    ' <snippet1>
    Public Sub RectangleFInflateExample(ByVal e As PaintEventArgs)

        ' Create a RectangleF structure.
        Dim myRectF As New RectangleF(100, 20, 100, 100)

        ' Draw myRect to the screen.
        Dim myRect As Rectangle = Rectangle.Truncate(myRectF)
        e.Graphics.DrawRectangle(Pens.Black, myRect)

        ' Create a Size structure.
        Dim inflateSize As New SizeF(100, 0)

        ' Inflate myRect.
        myRectF.Inflate(inflateSize)

        ' Draw the inflated rectangle to the screen.
        myRect = Rectangle.Truncate(myRectF)
        e.Graphics.DrawRectangle(Pens.Red, myRect)
    End Sub
    ' </snippet1>


    ' Snippet for: M:System.Drawing.RectangleF.Intersect(System.Drawing.RectangleF,System.Drawing.RectangleF)
    ' <snippet2>
    Public Sub RectangleFIntersectExample(ByVal e As PaintEventArgs)

        ' Create two rectangles.
        Dim firstRectangleF As New RectangleF(0, 0, 75, 50)
        Dim secondRectangleF As New RectangleF(50, 20, 50, 50)

        ' Convert the RectangleF structures to Rectangle structures and

        ' draw them to the screen.
        Dim firstRect As Rectangle = Rectangle.Truncate(firstRectangleF)
        Dim secondRect As Rectangle = Rectangle.Truncate(secondRectangleF)
        e.Graphics.DrawRectangle(Pens.Black, firstRect)
        e.Graphics.DrawRectangle(Pens.Red, secondRect)

        ' Get the intersection.
        Dim intersectRectangleF As RectangleF = _
        RectangleF.Intersect(firstRectangleF, secondRectangleF)

        ' Draw the intersectRectangleF to the screen.
        Dim intersectRect As Rectangle = _
        Rectangle.Truncate(intersectRectangleF)
        e.Graphics.DrawRectangle(Pens.Blue, intersectRect)
    End Sub
    ' </snippet2>


    ' Snippet for: M:System.Drawing.RectangleF.Union(System.Drawing.RectangleF,System.Drawing.RectangleF)
    ' <snippet3>
    Public Sub RectangleFUnionExample(ByVal e As PaintEventArgs)

        ' Create two rectangles and draw them to the screen.
        Dim firstRectangleF As New RectangleF(0, 0, 75, 50)
        Dim secondRectangleF As New RectangleF(100, 100, 20, 20)

        ' Convert the RectangleF structures to Rectangle structures and

        ' draw them to the screen.
        Dim firstRect As Rectangle = Rectangle.Truncate(firstRectangleF)
        Dim secondRect As Rectangle = Rectangle.Truncate(secondRectangleF)
        e.Graphics.DrawRectangle(Pens.Black, firstRect)
        e.Graphics.DrawRectangle(Pens.Red, secondRect)

        ' Get the union rectangle.
        Dim unionRectangleF As RectangleF = _
        RectangleF.Union(firstRectangleF, secondRectangleF)

        ' Draw the unionRectangleF to the screen.
        Dim unionRect As Rectangle = Rectangle.Truncate(unionRectangleF)
        e.Graphics.DrawRectangle(Pens.Blue, unionRect)
    End Sub
    ' </snippet3>

    <STAThread()> Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub

End Class
