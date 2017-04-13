Option Explicit On
Option Strict On

Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Collections
Imports System.Xml
Imports System.Drawing.Text

Public Class SystemDrawingFontsAndText

' 26d74ef5-0f39-4eeb-8d20-00e66e014abe
' How to: Enumerate Installed Fonts
    Public Sub Method11(ByVal e As PaintEventArgs)
        ' <snippet11>
        Dim fontFamily As New FontFamily("Arial")
        Dim font As New Font( _
           fontFamily, _
           8, _
           FontStyle.Regular, _
           GraphicsUnit.Point)
        Dim rectF As New RectangleF(10, 10, 500, 500)
        Dim solidBrush As New SolidBrush(Color.Black)

        Dim familyName As String
        Dim familyList As String = ""
        Dim fontFamilies() As FontFamily

        Dim installedFontCollection As New InstalledFontCollection()

        ' Get the array of FontFamily objects.
        fontFamilies = installedFontCollection.Families

        ' The loop below creates a large string that is a comma-separated
        ' list of all font family names.
        Dim count As Integer = fontFamilies.Length
        Dim j As Integer

        While j < count
            familyName = fontFamilies(j).Name
            familyList = familyList & familyName
            familyList = familyList & ",  "
            j += 1
        End While

        ' Draw the large string (list of all families) in a rectangle.
        e.Graphics.DrawString(familyList, font, solidBrush, rectF)

        ' </snippet11>
    End Sub
' 48fc34f3-f236-4b01-a0cb-f0752e6d22ae
' How to: Use Antialiasing with Text
    Public Sub Method21(ByVal e As PaintEventArgs)
        ' <snippet21>
        Dim fontFamily As New FontFamily("Times New Roman")
        Dim font As New Font( _
           fontFamily, _
           32, _
           FontStyle.Regular, _
           GraphicsUnit.Pixel)
        Dim solidBrush As New SolidBrush(Color.FromArgb(255, 0, 0, 255))
        Dim string1 As String = "SingleBitPerPixel"
        Dim string2 As String = "AntiAlias"

        e.Graphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixel
        e.Graphics.DrawString(string1, font, solidBrush, New PointF(10, 10))

        e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias
        e.Graphics.DrawString(string2, font, solidBrush, New PointF(10, 60))

        ' </snippet21>
    End Sub
' 50c69046-4188-47d9-b949-cc2610ffd337
' How to: Create Vertical Text
    Public Sub Method31(ByVal e As PaintEventArgs)
        ' <snippet31>
        Dim myText As String = "Vertical text"

        Dim fontFamily As New FontFamily("Lucida Console")
        Dim font As New Font( _
           fontFamily, _
           14, _
           FontStyle.Regular, _
           GraphicsUnit.Point)
        Dim pointF As New PointF(40, 10)
        Dim stringFormat As New StringFormat()
        Dim solidBrush As New SolidBrush(Color.FromArgb(255, 0, 0, 255))

        stringFormat.FormatFlags = StringFormatFlags.DirectionVertical

        e.Graphics.DrawString(myText, font, solidBrush, pointF, stringFormat)

        ' </snippet31>
    End Sub
' 64878f98-39ba-4303-b63f-0859ab682eeb
' How to: Set Tab Stops in Drawn Text
    Public Sub Method41(ByVal e As PaintEventArgs)
        ' <snippet41>
        Dim myText As String = _
           "Name" & ControlChars.Tab & _
           "Test 1" & ControlChars.Tab & _
           "Test 2" & ControlChars.Tab & _
           "Test 3" & ControlChars.Cr

        myText = myText & "Joe" & ControlChars.Tab & _
                          "95" & ControlChars.Tab & _
                          "88" & ControlChars.Tab & _
                          "91" & ControlChars.Cr
        myText = myText & "Mary" & ControlChars.Tab & _
                          "98" & ControlChars.Tab & _
                          "84" & ControlChars.Tab & _
                          "90" & ControlChars.Cr
        myText = myText & "Sam" & ControlChars.Tab & _
                          "42" & ControlChars.Tab & _
                          "76" & ControlChars.Tab & _
                          "98" & ControlChars.Cr
        myText = myText & "Jane" & ControlChars.Tab & _
                          "65" & ControlChars.Tab & _
                          "73" & ControlChars.Tab & _
                          "92" & ControlChars.Cr

        Dim fontFamily As New FontFamily("Courier New")
        Dim font As New Font( _
           fontFamily, _
           12, _
           FontStyle.Regular, _
           GraphicsUnit.Point)
        Dim rect As New Rectangle(10, 10, 450, 100)
        Dim stringFormat As New StringFormat()
        Dim solidBrush As New SolidBrush(Color.FromArgb(255, 0, 0, 255))
        Dim tabs As Single() = {150, 100, 100, 100}

        stringFormat.SetTabStops(0, tabs)

        e.Graphics.DrawString(myText, font, solidBrush, RectangleF.op_implicit(rect), stringFormat)

        Dim pen As Pen = Pens.Black
        e.Graphics.DrawRectangle(pen, rect)

        ' </snippet41>
    End Sub
' 6533d5e5-a8dc-4b76-9fc4-3bf75c8b9212
' How to: Create a Private Font Collection
    Public Sub Method51(ByVal e As PaintEventArgs)
        ' <snippet51>
        Dim pointF As New PointF(10, 0)
        Dim solidBrush As New SolidBrush(Color.Black)

        Dim count As Integer = 0
        Dim familyName As String = ""
        Dim familyNameAndStyle As String
        Dim fontFamilies() As FontFamily
        Dim privateFontCollection As New PrivateFontCollection()

        ' Add three font files to the private collection.
        privateFontCollection.AddFontFile("D:\systemroot\Fonts\Arial.ttf")
        privateFontCollection.AddFontFile("D:\systemroot\Fonts\CourBI.ttf")
        privateFontCollection.AddFontFile("D:\systemroot\Fonts\TimesBD.ttf")

        ' Get the array of FontFamily objects.
        fontFamilies = privateFontCollection.Families

        ' How many objects in the fontFamilies array?
        count = fontFamilies.Length

        ' Display the name of each font family in the private collection
        ' along with the available styles for that font family.
        Dim j As Integer

        While j < count
            ' Get the font family name.
            familyName = fontFamilies(j).Name

            ' Is the regular style available?
            If fontFamilies(j).IsStyleAvailable(FontStyle.Regular) Then
                familyNameAndStyle = ""
                familyNameAndStyle = familyNameAndStyle & familyName
                familyNameAndStyle = familyNameAndStyle & " Regular"

                Dim regFont As New Font( _
                   familyName, _
                   16, _
                   FontStyle.Regular, _
                   GraphicsUnit.Pixel)

                e.Graphics.DrawString( _
                   familyNameAndStyle, _
                   regFont, _
                   solidBrush, _
                   pointF)

                pointF.Y += regFont.Height
            End If

            ' Is the bold style available?
            If fontFamilies(j).IsStyleAvailable(FontStyle.Bold) Then
                familyNameAndStyle = ""
                familyNameAndStyle = familyNameAndStyle & familyName
                familyNameAndStyle = familyNameAndStyle & " Bold"

                Dim boldFont As New Font( _
                   familyName, _
                   16, _
                   FontStyle.Bold, _
                   GraphicsUnit.Pixel)

                e.Graphics.DrawString( _
                   familyNameAndStyle, _
                   boldFont, _
                   solidBrush, _
                   pointF)

                pointF.Y += boldFont.Height
            End If

            ' Is the italic style available?
            If fontFamilies(j).IsStyleAvailable(FontStyle.Italic) Then
                familyNameAndStyle = ""
                familyNameAndStyle = familyNameAndStyle & familyName
                familyNameAndStyle = familyNameAndStyle & " Italic"

                Dim italicFont As New Font( _
                   familyName, _
                   16, _
                   FontStyle.Italic, _
                   GraphicsUnit.Pixel)

                e.Graphics.DrawString( _
                   familyNameAndStyle, _
                   italicFont, _
                   solidBrush, pointF)

                pointF.Y += italicFont.Height
            End If

            ' Is the bold italic style available?
            If fontFamilies(j).IsStyleAvailable(FontStyle.Italic) And _
               fontFamilies(j).IsStyleAvailable(FontStyle.Bold) Then
                familyNameAndStyle = ""
                familyNameAndStyle = familyNameAndStyle & familyName
                familyNameAndStyle = familyNameAndStyle & "BoldItalic"

                Dim italicFont As New Font( _
                    familyName, _
                    16, _
                    FontStyle.Italic Or FontStyle.Bold, _
                    GraphicsUnit.Pixel)

                e.Graphics.DrawString( _
                   familyNameAndStyle, _
                   italicFont, _
                   solidBrush, _
                   pointF)

                pointF.Y += italicFont.Height
            End If
            ' Is the underline style available?
            If fontFamilies(j).IsStyleAvailable(FontStyle.Underline) Then
                familyNameAndStyle = ""
                familyNameAndStyle = familyNameAndStyle & familyName
                familyNameAndStyle = familyNameAndStyle & " Underline"

                Dim underlineFont As New Font( _
                   familyName, _
                   16, _
                   FontStyle.Underline, _
                   GraphicsUnit.Pixel)

                e.Graphics.DrawString( _
                   familyNameAndStyle, _
                   underlineFont, _
                   solidBrush, _
                   pointF)

                pointF.Y += underlineFont.Height
            End If

            ' Is the strikeout style available?
            If fontFamilies(j).IsStyleAvailable(FontStyle.Strikeout) Then
                familyNameAndStyle = ""
                familyNameAndStyle = familyNameAndStyle & familyName
                familyNameAndStyle = familyNameAndStyle & " Strikeout"

                Dim strikeFont As New Font( _
                   familyName, _
                   16, _
                   FontStyle.Strikeout, _
                   GraphicsUnit.Pixel)

                e.Graphics.DrawString( _
                   familyNameAndStyle, _
                   strikeFont, _
                   solidBrush, _
                   pointF)

                pointF.Y += strikeFont.Height
            End If

            ' Separate the families with white space.
            pointF.Y += 10
        End While

        ' </snippet51>
    End Sub
    ' d3a4a223-9492-4b54-9afd-db1c31c3cefd
    ' How to: Construct Font Families and Fonts
    Public Sub Method61(ByVal e As PaintEventArgs)
        ' <snippet61>
        Dim fontFamily As New FontFamily("Arial")
        Dim font As New Font( _
           fontFamily, _
           16, _
           FontStyle.Regular, _
           GraphicsUnit.Pixel)

        ' </snippet61>
    End Sub
    ' ff7c0616-67f7-4fa2-84ee-b8d642f2b09b
    ' How to: Obtain Font Metrics
    Public Sub Method71(ByVal e As PaintEventArgs)
        ' <snippet71>
        Dim infoString As String = "" ' enough space for one line of output
        Dim ascent As Integer ' font family ascent in design units
        Dim ascentPixel As Single ' ascent converted to pixels
        Dim descent As Integer ' font family descent in design units
        Dim descentPixel As Single ' descent converted to pixels
        Dim lineSpacing As Integer ' font family line spacing in design units
        Dim lineSpacingPixel As Single ' line spacing converted to pixels
        Dim fontFamily As New FontFamily("Arial")
        Dim font As New Font( _
           fontFamily, _
           16, _
           FontStyle.Regular, _
           GraphicsUnit.Pixel)
        Dim pointF As New PointF(10, 10)
        Dim solidBrush As New SolidBrush(Color.Black)

        ' Display the font size in pixels.
        infoString = "font.Size returns " & font.Size.ToString() & "."
        e.Graphics.DrawString(infoString, font, solidBrush, pointF)

        ' Move down one line.
        pointF.Y += font.Height

        ' Display the font family em height in design units.
        infoString = "fontFamily.GetEmHeight() returns " & _
           fontFamily.GetEmHeight(FontStyle.Regular) & "."
        e.Graphics.DrawString(infoString, font, solidBrush, pointF)

        ' Move down two lines.
        pointF.Y += 2 * font.Height

        ' Display the ascent in design units and pixels.
        ascent = fontFamily.GetCellAscent(FontStyle.Regular)

        ' 14.484375 = 16.0 * 1854 / 2048
        ascentPixel = _
           font.Size * ascent / fontFamily.GetEmHeight(FontStyle.Regular)
        infoString = "The ascent is " & ascent & " design units, " & ascentPixel _
           & " pixels."
        e.Graphics.DrawString(infoString, font, solidBrush, pointF)

        ' Move down one line.
        pointF.Y += font.Height

        ' Display the descent in design units and pixels.
        descent = fontFamily.GetCellDescent(FontStyle.Regular)

        ' 3.390625 = 16.0 * 434 / 2048
        descentPixel = _
           font.Size * descent / fontFamily.GetEmHeight(FontStyle.Regular)
        infoString = "The descent is " & descent & " design units, " & _
           descentPixel & " pixels."
        e.Graphics.DrawString(infoString, font, solidBrush, pointF)

        ' Move down one line.
        pointF.Y += font.Height

        ' Display the line spacing in design units and pixels.
        lineSpacing = fontFamily.GetLineSpacing(FontStyle.Regular)

        ' 18.398438 = 16.0 * 2355 / 2048
        lineSpacingPixel = _
           font.Size * lineSpacing / fontFamily.GetEmHeight(FontStyle.Regular)
        infoString = "The line spacing is " & lineSpacing & " design units, " & _
           lineSpacingPixel & " pixels."
        e.Graphics.DrawString(infoString, font, solidBrush, pointF)

        ' </snippet71>
    End Sub
End Class

