
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms



Public Class Form1
    Inherits Form
    
    Public Sub New() 

    End Sub 'New
    
    <STAThread()>  _
    Shared Sub Main() 
        Application.EnableVisualStyles()
        Application.Run(New Form1())
    
    End Sub 'Main
    
    
    Private Sub AlignTextWithTextRenderer(ByVal e As PaintEventArgs) 
        '<snippet20>
        Dim text2 As String = "Use TextFormatFlags and Rectangle objects to" & _
                " center text in a rectangle."
        
        Dim font2 As New Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point)
        Try
            Dim rect2 As New Rectangle(150, 10, 130, 140)
            
            ' Create a TextFormatFlags with word wrapping, horizontal center and
            ' vertical center specified.
            Dim flags As TextFormatFlags = TextFormatFlags.HorizontalCenter Or _
                TextFormatFlags.VerticalCenter Or TextFormatFlags.WordBreak
            
            ' Draw the text and the surrounding rectangle.
            TextRenderer.DrawText(e.Graphics, text2, font2, rect2, Color.Blue, flags)
            e.Graphics.DrawRectangle(Pens.Black, rect2)
        Finally
            font2.Dispose()
        End Try
        '</snippet20>
    End Sub

    
    
    
    Private Sub AlignTextWithDrawString(ByVal e As PaintEventArgs) 
        '<snippet10>
        Dim text1 As String = "Use StringFormat and Rectangle objects to" & _
            " center text in a rectangle."
        Dim font1 As New Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point)
        Try
            Dim rect1 As New Rectangle(10, 10, 130, 140)
            
            ' Create a StringFormat object with the each line of text, and the block
            ' of text centered on the page.
            Dim stringFormat As New StringFormat()
            stringFormat.Alignment = StringAlignment.Center
            stringFormat.LineAlignment = StringAlignment.Center
            
            ' Draw the text and the surrounding rectangle.
            e.Graphics.DrawString(text1, font1, Brushes.Blue, rect1, stringFormat)
            e.Graphics.DrawRectangle(Pens.Black, rect1)
        Finally
            font1.Dispose()
        End Try
        '</snippet10>
    End Sub

    Private Sub DrawTextAtLocation1(ByVal e As PaintEventArgs) 
        '<snippet30>
        Dim font1 As New Font("Times New Roman", 24, FontStyle.Bold, GraphicsUnit.Pixel)
        Try
            Dim pointF1 As New PointF(30, 10)
            e.Graphics.DrawString("Hello", font1, Brushes.Blue, pointF1)
        Finally
            font1.Dispose()
        End Try
        '</snippet30>
    End Sub

    
    Private Sub DrawTextAtLocation2(ByVal e As PaintEventArgs) 
        '<snippet40>
        Dim font As New Font("Times New Roman", 24, FontStyle.Bold, GraphicsUnit.Pixel)
        Try
            Dim point1 As New Point(30, 10)
            TextRenderer.DrawText(e.Graphics, "Hello", font, point1, Color.Blue)
        Finally
            font.Dispose()
        End Try
        '</snippet40>
    End Sub

    
    Private Sub DrawTextInARectangle1(ByVal e As PaintEventArgs) 
        '<snippet50>
        Dim text1 As String = "Draw text in a rectangle by passing a RectF to the DrawString method."
        Dim font1 As New Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point)
        Try
            Dim rectF1 As New RectangleF(30, 10, 100, 122)
            e.Graphics.DrawString(text1, font1, Brushes.Blue, rectF1)
            e.Graphics.DrawRectangle(Pens.Black, Rectangle.Round(rectF1))
        Finally
            font1.Dispose()
        End Try
        '</snippet50>
    End Sub

    
    Private Sub DrawTextInARectangle2(ByVal e As PaintEventArgs) 
        '<snippet60>
        Dim text2 As String = _
            "Draw text in a rectangle by passing a RectF to the DrawString method."
        Dim font2 As New Font("Arial", 12, FontStyle.Bold, GraphicsUnit.Point)
        Try
            Dim rect2 As New Rectangle(30, 10, 100, 122)
            
            ' Specify the text is wrapped.
            Dim flags As TextFormatFlags = TextFormatFlags.WordBreak
            TextRenderer.DrawText(e.Graphics, text2, font2, rect2, Color.Blue, flags)
            e.Graphics.DrawRectangle(Pens.Black, Rectangle.Round(rect2))
        Finally
            font2.Dispose()
        End Try
        '</snippet60>
    End Sub

    
    Private Sub Form1_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) _
        Handles Me.Paint
        'AlignTextWithDrawString(e);
        'AlignTextWithTextRenderer(e);
        'DrawTextAtLocation1(e);
        'DrawTextAtLocation2(e);
        DrawTextInARectangle1(e)

    End Sub 'Form1_Paint
End Class 'Form1