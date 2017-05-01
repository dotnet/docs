Option Explicit On
Option Strict On

Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Collections
Imports System.Xml

Public Class Form1
    Inherits Form

    <STAThread()> _
    Public Shared Sub Main()
        Application.EnableVisualStyles()
        Application.Run(New Form1())
    End Sub

    ' 4c2a90ee-bbbe-4ff6-9170-1b06c195c918
    ' How to: Manually Manage Buffered Graphics
    Public Sub Method11()
        ' <snippet11>
        Dim myContext As BufferedGraphicsContext
        myContext = BufferedGraphicsManager.Current

        ' </snippet11>
    End Sub
    Public Sub Method12()
        ' <snippet12>
        Dim myContext As BufferedGraphicsContext
        myContext = New BufferedGraphicsContext
        ' Insert code to create graphics here.
        ' On a nondefault BufferedGraphicsContext instance, you should always 
        ' call Dispose when finished.
        myContext.Dispose()

        ' </snippet12>
    End Sub
    ' 5192295e-bd8e-45f7-8bd6-5c4f6bd21e61
    ' How to: Manually Render Buffered Graphics
    Public Sub Method21()
        ' <snippet21>
        ' This example assumes the existence of a form called Form1.
        Dim currentContext As BufferedGraphicsContext
        Dim myBuffer As BufferedGraphics
        ' Gets a reference to the current BufferedGraphicsContext.
        currentContext = BufferedGraphicsManager.Current
        ' Creates a BufferedGraphics instance associated with Form1, and with 
        ' dimensions the same size as the drawing surface of Form1.
        myBuffer = currentContext.Allocate(Me.CreateGraphics, _
           Me.DisplayRectangle)

        ' </snippet21>

        ' <snippet22>
        ' Draws an ellipse to the graphics buffer.
        myBuffer.Graphics.DrawEllipse(Pens.Blue, Me.DisplayRectangle)
        ' </snippet22>

        ' <snippet23>
        ' Renders the contents of the buffer to the drawing surface associated 
        ' with the buffer.
        myBuffer.Render()
        ' Renders the contents of the buffer to the specified drawing surface.
        myBuffer.Render(Me.CreateGraphics)
        ' </snippet23>

        ' <snippet24>
        myBuffer.Dispose()
        ' </snippet24>
    End Sub

    ' 91083d3a-653f-4f15-a467-0f37b2aa39d6
    ' How to: Reduce Graphics Flicker with Double Buffering for Forms and Controls
    Public Sub Method31()
        ' <snippet31>
        DoubleBuffered = True

        ' </snippet31>
    End Sub
    Public Sub Method32()
        ' <snippet32>
        SetStyle(ControlStyles.OptimizedDoubleBuffer, True)

        ' </snippet32>
    End Sub
End Class

