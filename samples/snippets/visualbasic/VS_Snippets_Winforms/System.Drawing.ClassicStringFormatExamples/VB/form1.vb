Imports System
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging

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


    ' Snippet for: M:System.Drawing.StringFormat.GetTabStops(System.Single@)
    ' <snippet1>
    Public Sub GetSetTabStopsExample1(ByVal e As PaintEventArgs)
        Dim g As Graphics = e.Graphics

        ' Tools used for drawing, painting.
        Dim redPen As New Pen(Color.FromArgb(255, 255, 0, 0))
        Dim blueBrush As New SolidBrush(Color.FromArgb(255, 0, 0, 255))

        ' Layout and format for text.
        Dim myFont As New Font("Times New Roman", 12)
        Dim myStringFormat As New StringFormat
        Dim enclosingRectangle As New Rectangle(20, 20, 500, 100)
        Dim tabStops As Single() = {150.0F, 100.0F, 100.0F}

        ' Text with tabbed columns.
        Dim myString As String = "Name" & ControlChars.Tab & "Tab 1" _
        & ControlChars.Tab & "Tab 2" & ControlChars.Tab & "Tab 3" _
        & ControlChars.Cr & "George Brown" & ControlChars.Tab & "One" _
        & ControlChars.Tab & "Two" & ControlChars.Tab & "Three"

        ' Set the tab stops, paint the text specified by myString,the

        '  and draw rectangle that encloses the text.
        myStringFormat.SetTabStops(0.0F, tabStops)
        g.DrawString(myString, myFont, blueBrush, _
        RectangleF.op_Implicit(enclosingRectangle), myStringFormat)
        g.DrawRectangle(redPen, enclosingRectangle)

        ' Get the tab stops.
        Dim firstTabOffset As Single
        Dim tabStopsObtained As Single() = _
        myStringFormat.GetTabStops(firstTabOffset)
        Dim j As Integer
        For j = 0 To tabStopsObtained.Length - 1

            ' Inspect or use the value in tabStopsObtained[j].
            Console.WriteLine(ControlChars.Cr & "  Tab stop {0} = {1}", _
            j, tabStopsObtained(j))
        Next j
    End Sub
    ' </snippet1>


    ' Snippet for: M:System.Drawing.StringFormat.SetDigitSubstitution(System.Int32,System.Drawing.StringDigitSubstitute)
    ' <snippet2>
    Public Sub SetDigitSubExample(ByVal e As PaintEventArgs)
        Dim g As Graphics = e.Graphics
        Dim blueBrush As New SolidBrush(Color.FromArgb(255, 0, 0, 255))
        Dim myFont As New Font("Courier New", 12)
        Dim myStringFormat As New StringFormat
        Dim myString As String = "0 1 2 3 4 5 6 7 8 9"

        ' Arabic (0x0C01) digits.

        ' Use National substitution method.
        myStringFormat.SetDigitSubstitution(&HC01, _
        StringDigitSubstitute.National)
        g.DrawString("Arabic:" & ControlChars.Cr & _
        "Method of substitution = National:     " & myString, _
        myFont, blueBrush, New PointF(10.0F, 20.0F), myStringFormat)

        ' Use Traditional substitution method.
        myStringFormat.SetDigitSubstitution(&HC01, _
        StringDigitSubstitute.Traditional)
        g.DrawString("Method of substitution = Traditional:  " _
        & myString, myFont, blueBrush, New PointF(10.0F, 55.0F), _
        myStringFormat)

        ' Thai (0x041E) digits.

        ' Use National substitution method.
        myStringFormat.SetDigitSubstitution(&H41E, _
        StringDigitSubstitute.National)
        g.DrawString("Thai:" & ControlChars.Cr & _
        "Method of substitution = National:     " & myString, _
        myFont, blueBrush, New PointF(10.0F, 85.0F), myStringFormat)

        ' Use Traditional substitution method.
        myStringFormat.SetDigitSubstitution(&H41E, _
        StringDigitSubstitute.Traditional)
        g.DrawString("Method of substitution = Traditional:  " _
        & myString, myFont, blueBrush, New PointF(10.0F, 120.0F), _
        myStringFormat)
    End Sub
    ' </snippet2>


    ' Snippet for: M:System.Drawing.StringFormat.SetMeasurableCharacterRanges(System.Drawing.CharacterRange[])
    ' <snippet3>
    Public Sub SetMeasCharRangesExample(ByVal e As PaintEventArgs)
        Dim g As Graphics = e.Graphics
        Dim redBrush As New SolidBrush(Color.FromArgb(50, 255, 0, 0))

        ' Layout rectangles, font, and string format used for
        ' displaying string.
        Dim layoutRectA As New Rectangle(20, 20, 165, 80)
        Dim layoutRectB As New Rectangle(20, 110, 165, 80)
        Dim layoutRectC As New Rectangle(20, 200, 240, 80)
        Dim tnrFont As New Font("Times New Roman", 16)
        Dim strFormat As New StringFormat

        ' Ranges of character positions within a string.
        Dim charRanges As CharacterRange() = {New CharacterRange(3, 5), _
        New CharacterRange(15, 2), New CharacterRange(30, 15)}

        ' Each region specifies the area occupied by the characters within
        ' a range of positions. The values are obtained by using a method
        ' that measures the character ranges.
        Dim charRegions(charRanges.Length) As [Region]

        ' String to be displayed.
        Dim str As String = _
        "The quick, brown fox easily jumps over the lazy dog."

        ' Set the char ranges for the string format.
        strFormat.SetMeasurableCharacterRanges(charRanges)

        ' Loop counter (unsigned 8-bit integer).
        Dim i As Byte


        ' Measure the char ranges for a given string and layout rectangle.
        ' Each area occupied by the characters in a range is stored as a
        ' region. then draw the string and layout rectangle and paint the
        ' regions.
        charRegions = g.MeasureCharacterRanges(str, tnrFont, _
        RectangleF.op_Implicit(layoutRectA), strFormat)
        g.DrawString(str, tnrFont, Brushes.Blue, _
        RectangleF.op_Implicit(layoutRectA), strFormat)
        g.DrawRectangle(Pens.Black, layoutRectA)

        ' Paint the regions.
        For i = 0 To charRegions.Length - 1
            g.FillRegion(redBrush, charRegions(i))
        Next i

        ' Repeat the above steps, but include trailing spaces in the char
        ' range measurement by setting the appropriate string format flag.
        strFormat.FormatFlags = StringFormatFlags.MeasureTrailingSpaces
        charRegions = g.MeasureCharacterRanges(str, tnrFont, _
        RectangleF.op_Implicit(layoutRectB), strFormat)
        g.DrawString(str, tnrFont, Brushes.Blue, _
        RectangleF.op_Implicit(layoutRectB), strFormat)
        g.DrawRectangle(Pens.Black, layoutRectB)

        ' Paint the regions.
        For i = 0 To charRegions.Length - 1
            g.FillRegion(redBrush, charRegions(i))
        Next i

        ' Clear all the format flags.
        strFormat.FormatFlags = 0

        ' Repeat the steps, but use a different layout rectangle. The
        ' dimensions of the layout rectangle and the size of the font both
        ' affect the character range measurement.
        charRegions = g.MeasureCharacterRanges(str, tnrFont, _
        RectangleF.op_Implicit(layoutRectC), strFormat)
        g.DrawString(str, tnrFont, Brushes.Blue, _
        RectangleF.op_Implicit(layoutRectC), strFormat)
        g.DrawRectangle(Pens.Black, layoutRectC)

        ' Paint the regions.
        For i = 0 To charRegions.Length - 1
            g.FillRegion(redBrush, charRegions(i))
        Next i
    End Sub
    ' </snippet3>


    ' Snippet for: M:System.Drawing.StringFormat.SetTabStops(System.Single,System.Single[])
    ' <snippet4>
    Public Sub GetSetTabStopsExample2(ByVal e As PaintEventArgs)
        Dim g As Graphics = e.Graphics

        ' Tools used for drawing, painting.
        Dim redPen As New Pen(Color.FromArgb(255, 255, 0, 0))
        Dim blueBrush As New SolidBrush(Color.FromArgb(255, 0, 0, 255))

        ' Layout and format for text.
        Dim myFont As New Font("Times New Roman", 12)
        Dim myStringFormat As New StringFormat
        Dim enclosingRectangle As New Rectangle(20, 20, 500, 100)
        Dim tabStops As Single() = {150.0F, 100.0F, 100.0F}

        ' Text with tabbed columns.
        Dim myString As String = "Name" & ControlChars.Tab & "Tab 1" _
        & ControlChars.Tab & "Tab 2" & ControlChars.Tab & "Tab 3" _
        & ControlChars.Cr & "George Brown" & ControlChars.Tab & "One" _
        & ControlChars.Tab & "Two" & ControlChars.Tab & "Three"

        ' Set the tab stops, paint the text specified by myString,
        ' and draw rectangle that encloses the text.
        myStringFormat.SetTabStops(0.0F, tabStops)
        g.DrawString(myString, myFont, blueBrush, _
        RectangleF.op_Implicit(enclosingRectangle), myStringFormat)
        g.DrawRectangle(redPen, enclosingRectangle)

        ' Get the tab stops.
        Dim firstTabOffset As Single
        Dim tabStopsObtained As Single() = _
        myStringFormat.GetTabStops(firstTabOffset)
        Dim j As Integer
        For j = 0 To tabStopsObtained.Length - 1

            ' Inspect or use the value in tabStopsObtained[j].
            Console.WriteLine(ControlChars.Cr & "  Tab stop {0} = {1}", _
            j, tabStopsObtained(j))
        Next j
    End Sub
    ' </snippet4>


    ' Snippet for: M:System.Drawing.StringFormat.ToString
    ' <snippet5>
    Public Sub ToStringExample(ByVal e As PaintEventArgs)
        Dim g As Graphics = e.Graphics
        Dim blueBrush As New SolidBrush(Color.FromArgb(255, 0, 0, 255))
        Dim myFont As New Font("Times New Roman", 14)
        Dim myStringFormat As New StringFormat

        ' String variable to hold the values of the StringFormat object.
        Dim strFmtString As String

        ' Convert the string format object to a string (only certain
        ' information in the object is converted) and display the string.
        strFmtString = myStringFormat.ToString()
        g.DrawString("Before changing properties:   ", myFont, blueBrush, _
        20, 40, myStringFormat)

        ' Change some properties of the string format.
        myStringFormat.Trimming = StringTrimming.None
        myStringFormat.FormatFlags = StringFormatFlags.NoWrap Or _
        StringFormatFlags.NoClip

        ' Convert the string format object to a string and display the
        ' string. The string will be different because the properties of
        ' the string format have changed.
        strFmtString = myStringFormat.ToString()
        g.DrawString("After changing properties:   ", myFont, blueBrush, _
        20, 70, myStringFormat)
    End Sub
    ' </snippet5>

End Class
