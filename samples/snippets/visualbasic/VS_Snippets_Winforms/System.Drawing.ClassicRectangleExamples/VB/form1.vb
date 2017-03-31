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


    ' Snippet for: M:System.Drawing.Rectangle.Inflate(System.Drawing.Rectangle,System.Int32,System.Int32)
    ' <snippet1>
    Public Sub RectangleInflateTest(ByVal e As PaintEventArgs)

        ' Create a rectangle.
        Dim rect As New Rectangle(100, 100, 50, 50)

        ' Draw the uninflated rectangle to screen.
        e.Graphics.DrawRectangle(Pens.Black, rect)

        ' Call Inflate.
        Dim rect2 As Rectangle = Rectangle.Inflate(rect, 50, 50)

        ' Draw the inflated rectangle to screen.
        e.Graphics.DrawRectangle(Pens.Red, rect2)
    End Sub
    ' </snippet1>


    ' Snippet for: M:System.Drawing.Rectangle.Inflate(System.Drawing.Size)
    ' <snippet2>
    Public Sub RectangleInflateTest2(ByVal e As PaintEventArgs)

        ' Create a rectangle.
        Dim rect As New Rectangle(100, 100, 50, 50)

        ' Draw the uninflated rect to screen.
        e.Graphics.DrawRectangle(Pens.Black, rect)

        ' Set up the inflate size.
        Dim inflateSize As New Size(50, 50)

        ' Call Inflate.
        rect.Inflate(inflateSize)

        ' Draw the inflated rect to screen.
        e.Graphics.DrawRectangle(Pens.Red, rect)
    End Sub
    ' </snippet2>


    ' Snippet for: M:System.Drawing.Rectangle.Inflate(System.Int32,System.Int32)
    ' <snippet3>
    Public Sub RectangleInflateTest3(ByVal e As PaintEventArgs)

        ' Create a rectangle.
        Dim rect As New Rectangle(100, 100, 50, 50)

        ' Draw the uninflated rectangle to screen.
        e.Graphics.DrawRectangle(Pens.Black, rect)

        ' Call Inflate.
        rect.Inflate(50, 50)

        ' Draw the inflated rectangle to screen.
        e.Graphics.DrawRectangle(Pens.Red, rect)
    End Sub
    ' </snippet3>

    <STAThread()> Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub
End Class
