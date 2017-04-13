
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms



Public Class Form1
    Inherits Form

    Public Sub New()
        InitializeComponent()

    End Sub 'New


    Public Shared Sub Main()
        Application.EnableVisualStyles()
        Application.Run(New Form1())

    End Sub 'Main

    '<snippet1>
    Private Sub MeasureText1(ByVal e As PaintEventArgs)
        Dim text1 As String = "Measure this text"
        Dim arialBold As New Font("Arial", 12.0F)
        Dim textSize As Size = TextRenderer.MeasureText(text1, arialBold)
        TextRenderer.DrawText(e.Graphics, text1, arialBold, _
            New Rectangle(New Point(10, 10), textSize), Color.Red)

    End Sub

    '</snippet1>
    '<snippet10>
    Private Sub MeasureText2(ByVal e As PaintEventArgs)
        Dim text1 As String = "How big is this text?"
        Dim arialBold As New Font("Arial", 12.0F)

        ' Indicate a size taller than it is wide.
        Dim proposedSize As New Size(40, 60)

        Dim textSize As Size = TextRenderer.MeasureText(text1, _
            arialBold, proposedSize, TextFormatFlags.WordBreak)
        TextRenderer.DrawText(e.Graphics, text1, arialBold, _
            New Rectangle(New Point(10, 10), textSize), Color.Red, _
            TextFormatFlags.WordBreak)

    End Sub

    '</snippet10>
    '<snippet2>
    Private Sub RenderText1(ByVal e As PaintEventArgs)
        TextRenderer.DrawText(e.Graphics, "Regular Text", _
            Me.Font, New Point(10, 10), SystemColors.ControlText)

    End Sub


    '</snippet2>
    '<snippet3>
    Private Sub RenderText2(ByVal e As PaintEventArgs)
        TextRenderer.DrawText(e.Graphics, "Regular Text", _
            Me.Font, New Rectangle(10, 10, 100, 100), _
            SystemColors.ControlText)

    End Sub


    '</snippet3>
    '<snippet4>
    Private Sub RenderText3(ByVal e As PaintEventArgs)
        TextRenderer.DrawText(e.Graphics, "Regular Text", Me.Font, _
            New Point(10, 10), Color.Red, Color.PowderBlue)

    End Sub

    '</snippet4>
    '<snippet5>
    Private Sub RenderText4(ByVal e As PaintEventArgs)
        TextRenderer.DrawText(e.Graphics, "Regular Text.", _
            Me.Font, New Rectangle(10, 10, 70, 70), _
            SystemColors.ControlText, SystemColors.ControlDark)

    End Sub

    '</snippet5>
    '<snippet6>
    Private Sub RenderText5(ByVal e As PaintEventArgs)
        TextRenderer.DrawText(e.Graphics, "Some text.", _
        Me.Font, New Point(10, 10), SystemColors.ControlText, _
        TextFormatFlags.Bottom)

    End Sub

    '</snippet6>
    '<snippet7>
    Private Sub RenderText6(ByVal e As PaintEventArgs)
        Dim flags As TextFormatFlags = TextFormatFlags.Bottom Or _
            TextFormatFlags.EndEllipsis
        TextRenderer.DrawText(e.Graphics, _
        "This is some text that will be clipped at the end.", _
        Me.Font, New Rectangle(10, 10, 100, 50), SystemColors.ControlText, flags)

    End Sub

    '</snippet7>
    '<snippet8>
    Private Sub RenderText7(ByVal e As PaintEventArgs)
        TextRenderer.DrawText(e.Graphics, "This is some text.", _
            Me.Font, New Point(10, 10), Color.White, Color.SteelBlue, _
            TextFormatFlags.Default)

    End Sub

    '</snippet8>
    '<snippet9>
    Private Sub RenderText8(ByVal e As PaintEventArgs)
        Dim flags As TextFormatFlags = _
            TextFormatFlags.Bottom Or TextFormatFlags.WordBreak
        TextRenderer.DrawText(e.Graphics, _
            "This is some text that will display on multiple lines.", _
            Me.Font, New Rectangle(10, 10, 100, 50), _
            SystemColors.ControlText, SystemColors.ControlDark, flags)

    End Sub


    '</snippet9>
    Private Sub InitializeComponent()
        Me.SuspendLayout()
        ' 
        ' Form1
        ' 
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.Name = "Form1"
        Me.ResumeLayout(False)

    End Sub 'InitializeComponent


    Private Sub Form1_Paint(ByVal sender As Object, _
        ByVal e As PaintEventArgs) Handles MyBase.Paint
        MeasureText2(e)

    End Sub

 '<snippet11>
    Private Sub DrawALineOfText(ByVal e As PaintEventArgs)
        ' Declare strings to render on the form.
        Dim stringsToPaint() As String = {"Tail", "Spin", " Toys"}

        ' Declare fonts for rendering the strings.
        Dim fonts() As Font = {New Font("Arial", 14, FontStyle.Regular), _
            New Font("Arial", 14, FontStyle.Italic), _
            New Font("Arial", 14, FontStyle.Regular)}

        Dim startPoint As New Point(10, 10)

        ' Set TextFormatFlags to no padding so strings are drawn together.
        Dim flags As TextFormatFlags = TextFormatFlags.NoPadding

        ' Declare a proposed size with dimensions set to the maximum integer value.
        Dim proposedSize As Size = New Size(Integer.MaxValue, Integer.MaxValue)

        ' Measure each string with its font and NoPadding value and draw it to the form.
        For i As Integer = 0 To stringsToPaint.Length - 1
            Dim size As Size = TextRenderer.MeasureText(e.Graphics, _
                stringsToPaint(i), fonts(i), proposedSize, flags)
            Dim rect As Rectangle = New Rectangle(startPoint, size)
            TextRenderer.DrawText(e.Graphics, stringsToPaint(i), fonts(i), _
                startPoint, Color.Black, flags)
            startPoint.X += size.Width
        Next
    End Sub
    '</snippet11>
End Class 'Form1 



