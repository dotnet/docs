Option Explicit On 
Option Strict On

Imports System
Imports System.Windows.Forms
Imports System.Drawing


Public Class Form1
    Inherits System.Windows.Forms.Form

    Private Sub DoSomething1()
        ' Snippet for: \vbtskcodeexampledrawingfilledellipseonform.xml
        ' <snippet1>
        Dim myBrush As New System.Drawing.SolidBrush(System.Drawing.Color.Red)
        Dim formGraphics As System.Drawing.Graphics
        formGraphics = Me.CreateGraphics()
        formGraphics.FillEllipse(myBrush, New Rectangle(0, 0, 200, 300))
        myBrush.Dispose()
        formGraphics.Dispose()
        ' </snippet1>
    End Sub

    Private Sub DoSomething2()
        ' Snippet for: \vbtskcodeexampledrawingfilledrectangleonform.xml
        ' <snippet2>
        Dim myBrush As New System.Drawing.SolidBrush(System.Drawing.Color.Red)
        Dim formGraphics As System.Drawing.Graphics
        formGraphics = Me.CreateGraphics()
        formGraphics.FillRectangle(myBrush, New Rectangle(0, 0, 200, 300))
        myBrush.Dispose()
        formGraphics.Dispose()
        ' </snippet2>
    End Sub

    Private Sub DoSomething3()
        ' Snippet for: \vbtskcodeexamplecreatingpen.xml
        ' <snippet3>
        Dim myPen As System.Drawing.Pen
        myPen = New System.Drawing.Pen(System.Drawing.Color.Tomato)
        ' </snippet3>
    End Sub

    Private Sub DoSomething4()
        ' Snippet for: \vbtskcodeexamplecreatingsolidbrush.xml
        ' <snippet4>
        Dim myBrush As System.Drawing.SolidBrush
        myBrush = New System.Drawing.SolidBrush(System.Drawing.Color.PeachPuff)
        ' </snippet4>
    End Sub

    Private Sub DoSomething5()
        ' Snippet for: \vbtskcodeexampledrawinglineonform.xml
        ' <snippet5>
        Dim myPen As New System.Drawing.Pen(System.Drawing.Color.Red)
        Dim formGraphics As System.Drawing.Graphics
        formGraphics = Me.CreateGraphics()
        formGraphics.DrawLine(myPen, 0, 0, 200, 200)
        myPen.Dispose()
        formGraphics.Dispose()
        ' </snippet5>
    End Sub

    ' Snippet for: \vbtskcodeexampledrawingoutlinedshapes.xml
    ' <snippet6>
    Private Sub DrawEllipse()
        Dim myPen As New System.Drawing.Pen(System.Drawing.Color.Red)
        Dim formGraphics As System.Drawing.Graphics
        formGraphics = Me.CreateGraphics()
        formGraphics.DrawEllipse(myPen, New Rectangle(0, 0, 200, 300))
        myPen.Dispose()
        formGraphics.Dispose()
    End Sub

    Private Sub DrawRectangle()
        Dim myPen As New System.Drawing.Pen(System.Drawing.Color.Red)
        Dim formGraphics As System.Drawing.Graphics
        formGraphics = Me.CreateGraphics()
        formGraphics.DrawRectangle(myPen, New Rectangle(0, 0, 200, 300))
        myPen.Dispose()
        formGraphics.Dispose()
    End Sub

    ' </snippet6>
    ' Snippet for: \vbtskcodeexampledrawingtextonform2.xml
    ' <snippet7>
    Public Sub DrawString()
        Dim formGraphics As System.Drawing.Graphics = Me.CreateGraphics()
        Dim drawString As String = "Sample Text"
        Dim drawFont As New System.Drawing.Font("Arial", 16)
        Dim drawBrush As New _
           System.Drawing.SolidBrush(System.Drawing.Color.Black)
        Dim x As Single = 150.0
        Dim y As Single = 50.0
        Dim drawFormat As New System.Drawing.StringFormat
        formGraphics.DrawString(drawString, drawFont, drawBrush, _
            x, y, drawFormat)
        drawFont.Dispose()
        drawBrush.Dispose()
        formGraphics.Dispose()
    End Sub

    ' </snippet7>
    ' Snippet for: \vbtskcodeexampledrawingtextonform.xml
    ' <snippet8>
    Public Sub DrawVerticalString()
        Dim formGraphics As System.Drawing.Graphics = Me.CreateGraphics()
        Dim drawString As String = "Sample Text"
        Dim drawFont As New System.Drawing.Font("Arial", 16)
        Dim drawBrush As New _
            System.Drawing.SolidBrush(System.Drawing.Color.Black)
        Dim x As Single = 150.0
        Dim y As Single = 50.0
        Dim drawFormat As New System.Drawing.StringFormat
        drawFormat.FormatFlags = StringFormatFlags.DirectionVertical
        formGraphics.DrawString(drawString, drawFont, drawBrush, _
        x, y, drawFormat)
        drawFont.Dispose()
        drawBrush.Dispose()
        formGraphics.Dispose()
    End Sub

    ' </snippet8>
    Private Sub DoSomething9()
        Dim myPen As New Pen(Color.Red)
        ' Snippet for: \vbtskcodeexamplesetcolorofpen.xml
        ' <snippet9>
        myPen.Color = System.Drawing.Color.PeachPuff
        ' </snippet9>
    End Sub
    ' Snippet for: \vbtskcreateashapedwindowsform.xml
    ' <snippet10>
    Protected Overrides Sub OnPaint( _
   ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim shape As New System.Drawing.Drawing2D.GraphicsPath
        shape.AddEllipse(0, 0, Me.Width, Me.Height)
        Me.Region = New System.Drawing.Region(shape)
    End Sub
    ' </snippet10>

    <STAThread()> Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub
End Class
