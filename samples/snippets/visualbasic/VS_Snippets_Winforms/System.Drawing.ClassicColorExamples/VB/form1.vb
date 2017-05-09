
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


    ' Snippet for: M:System.Drawing.Color.FromArgb(System.Int32)
    ' <snippet1>
    Public Sub FromArgb4(ByVal e As PaintEventArgs)
        Dim g As Graphics = e.Graphics

        ' Transparent red, green, and blue brushes.
        Dim trnsRedBrush As New SolidBrush(Color.FromArgb(&H78FF0000))
        Dim trnsGreenBrush As New SolidBrush(Color.FromArgb(&H7800FF00))
        Dim trnsBlueBrush As New SolidBrush(Color.FromArgb(&H780000FF))

        ' Base and height of the triangle that is used to position the
        ' circles. Each vertex of the triangle is at the center of one of
        ' the 3 circles. The base is equal to the diameter of the circle.
        Dim triBase As Single = 100
        Dim triHeight As Single = CSng(Math.Sqrt((3 * (triBase * _
        triBase) / 4)))

        ' Coordinates of first circle
        's bounding rectangle.
        Dim x1 As Single = 40
        Dim y1 As Single = 40

        ' Fill 3 over-lapping circles. Each circle is a different color.
        g.FillEllipse(trnsRedBrush, x1, y1, 2 * triHeight, 2 * triHeight)
        g.FillEllipse(trnsGreenBrush, x1 + triBase / 2, y1 + triHeight, _
        2 * triHeight, 2 * triHeight)
        g.FillEllipse(trnsBlueBrush, x1 + triBase, y1, 2 * triHeight, _
        2 * triHeight)
    End Sub
    ' </snippet1>


    ' Snippet for: M:System.Drawing.Color.FromArgb(System.Int32,System.Drawing.Color)
    ' <snippet2>
    Public Sub FromArgb3(ByVal e As PaintEventArgs)
        Dim g As Graphics = e.Graphics

        ' Opaque colors (alpha value defaults to 255 -- max value).
        Dim red As Color = Color.FromArgb(255, 0, 0)
        Dim green As Color = Color.FromArgb(0, 255, 0)
        Dim blue As Color = Color.FromArgb(0, 0, 255)

        ' Solid brush initialized to red.
        Dim myBrush As New SolidBrush(red)
        Dim alpha As Integer

        ' x coordinate of first red rectangle.
        Dim x As Integer = 50

        ' y coordinate of first red rectangle.
        Dim y As Integer = 50

        ' Fill rectangles with red, varying the alpha value from 25 to 250.
        For alpha = 25 To 250 Step 25
            myBrush.Color = Color.FromArgb(alpha, red)
            g.FillRectangle(myBrush, x, y, 50, 100)
            g.FillRectangle(myBrush, x, y + 250, 50, 50)
            x += 50
        Next alpha

        ' x coordinate of first green rectangle.
        x = 50

        ' y coordinate of first green rectangle.
        y += 50

        ' Fill rectangles with green, varying alpha value from 25 to 250.
        For alpha = 25 To 250 Step 25
            myBrush.Color = Color.FromArgb(alpha, green)
            g.FillRectangle(myBrush, x, y, 50, 150)
            x += 50
        Next alpha

        ' x coordinate of first blue rectangle.
        x = 50

        ' y coordinate of first blue rectangle.
        y += 100

        ' Fill rectangles with blue, varying alpha value from 25 to 250.
        For alpha = 25 To 250 Step 25
            myBrush.Color = Color.FromArgb(alpha, blue)
            g.FillRectangle(myBrush, x, y, 50, 150)
            x += 50
        Next alpha
    End Sub
    ' </snippet2>


    ' Snippet for: M:System.Drawing.Color.FromArgb(System.Int32,System.Int32,System.Int32)
    ' <snippet3>
    Public Sub FromArgb2(ByVal e As PaintEventArgs)
        Dim g As Graphics = e.Graphics

        ' Opaque colors (alpha value defaults to 255 -- max value).
        Dim red As Color = Color.FromArgb(255, 0, 0)
        Dim green As Color = Color.FromArgb(0, 255, 0)
        Dim blue As Color = Color.FromArgb(0, 0, 255)

        ' Solid brush initialized to red.
        Dim myBrush As New SolidBrush(red)
        Dim alpha As Integer

        ' x coordinate of first red rectangle.
        Dim x As Integer = 50

        ' y coordinate of first red rectangle.
        Dim y As Integer = 50

        ' Fill rectangles with red, varying the alpha value from 25 to 250.
        For alpha = 25 To 250 Step 25
            myBrush.Color = Color.FromArgb(alpha, red)
            g.FillRectangle(myBrush, x, y, 50, 100)
            g.FillRectangle(myBrush, x, y + 250, 50, 50)
            x += 50
        Next alpha

        ' x coordinate of first green rectangle.
        x = 50

        ' y coordinate of first green rectangle.
        y += 50


        ' Fill rectangles with green, varying alpha value from 25 to 250.
        For alpha = 25 To 250 Step 25
            myBrush.Color = Color.FromArgb(alpha, green)
            g.FillRectangle(myBrush, x, y, 50, 150)
            x += 50
        Next alpha

        ' x coordinate of first blue rectangle.
        x = 50

        ' y coordinate of first blue rectangle.
        y += 100

        ' Fill rectangles with blue, varying alpha value from 25 to 250.
        For alpha = 25 To 250 Step 25
            myBrush.Color = Color.FromArgb(alpha, blue)
            g.FillRectangle(myBrush, x, y, 50, 150)
            x += 50
        Next alpha
    End Sub
    ' </snippet3>


    ' Snippet for: M:System.Drawing.Color.FromArgb(System.Int32,System.Int32,System.Int32,System.Int32)
    ' <snippet4>
    Public Sub FromArgb1(ByVal e As PaintEventArgs)
        Dim g As Graphics = e.Graphics

        ' Transparent red, green, and blue brushes.
        Dim trnsRedBrush As New SolidBrush(Color.FromArgb(120, 255, 0, 0))
        Dim trnsGreenBrush As New SolidBrush(Color.FromArgb(120, 0, _
        255, 0))
        Dim trnsBlueBrush As New SolidBrush(Color.FromArgb(120, 0, 0, 255))

        ' Base and height of the triangle that is used to position the
        ' circles. Each vertex of the triangle is at the center of one of
        ' the 3 circles. The base is equal to the diameter of the circle.
        Dim triBase As Single = 100
        Dim triHeight As Single = CSng(Math.Sqrt((3 * (triBase * _
        triBase) / 4)))

        ' Coordinates of first circle's bounding rectangle.
        Dim x1 As Single = 40
        Dim y1 As Single = 40

        ' Fill 3 over-lapping circles. Each circle is a different color.
        g.FillEllipse(trnsRedBrush, x1, y1, 2 * triHeight, 2 * triHeight)
        g.FillEllipse(trnsGreenBrush, x1 + triBase / 2, y1 + triHeight, _
        2 * triHeight, 2 * triHeight)
        g.FillEllipse(trnsBlueBrush, x1 + triBase, y1, 2 * triHeight, _
        2 * triHeight)
    End Sub
    ' </snippet4>


    ' Snippet for: M:System.Drawing.Color.FromKnownColor(System.Drawing.KnownColor)
    ' <snippet5>
    Public Sub KnownColorBrightnessExample1(ByVal e As PaintEventArgs)
        Dim g As Graphics = e.Graphics

        ' Color structures. One is used for temporary storage. The other
        ' is a constant used for comparisons.
        Dim someColor As Color = Color.FromArgb(0)
        Dim redShade As Color = Color.FromArgb(255, 200, 0, 100)

        ' Array to store KnownColor values that match the brightness of the
        ' redShade color.
        Dim colorMatches(15) As KnownColor

        ' Number of matches found.
        Dim count As Integer = 0

        ' iterate through the KnownColor enums until 15 matches are found.
        Dim enumValue As KnownColor
        For enumValue = 0 To KnownColor.YellowGreen
            someColor = Color.FromKnownColor(enumValue)
            If (someColor.GetBrightness()) = (redShade.GetBrightness()) Then
                colorMatches(count) = enumValue
                count += 1
                If count > 15 Then
                    Exit For
                End If
            End If
        Next enumValue

        ' Display the redShade color and its argb value.
        Dim myBrush1 As New SolidBrush(redShade)
        Dim myFont As New Font("Arial", 12)
        Dim x As Integer = 20
        Dim y As Integer = 20
        someColor = redShade
        g.FillRectangle(myBrush1, x, y, 100, 30)
        g.DrawString(someColor.ToString(), myFont, Brushes.Black, _
        x + 120, y)

        ' Iterate through the matches that were found and display each
        ' color that corresponds with the enum value in the array.
        ' Display the name of the KnownColor.
        Dim i As Integer
        For i = 0 To count - 1
            y += 40
            someColor = Color.FromKnownColor(colorMatches(i))
            myBrush1.Color = someColor
            g.FillRectangle(myBrush1, x, y, 100, 30)
            g.DrawString(someColor.ToString(), myFont, Brushes.Black, _
            x + 120, y)
        Next i
    End Sub
    ' </snippet5>


    ' Snippet for: M:System.Drawing.Color.GetBrightness
    ' <snippet6>
    Public Sub KnownColorBrightnessExample2(ByVal e As PaintEventArgs)
        Dim g As Graphics = e.Graphics

        ' Color structures. One is used for temporary storage. The other
        ' is a constant used for comparisons.
        Dim someColor As Color = Color.FromArgb(0)
        Dim redShade As Color = Color.FromArgb(255, 200, 0, 100)

        ' Array to store KnownColor values that match the brightness of the
        ' redShade color.
        Dim colorMatches(15) As KnownColor

        ' Number of matches found.
        Dim count As Integer = 0

        ' iterate through the KnownColor enums until 15 matches are found.
        Dim enumValue As KnownColor
        For enumValue = 0 To KnownColor.YellowGreen
            someColor = Color.FromKnownColor(enumValue)
            If (someColor.GetBrightness()) = (redShade.GetBrightness()) Then
                colorMatches(count) = enumValue
                count += 1
                If count > 15 Then
                    Exit For
                End If
            End If
        Next enumValue

        ' Display the redShade color and its argb value.
        Dim myBrush1 As New SolidBrush(redShade)
        Dim myFont As New Font("Arial", 12)
        Dim x As Integer = 20
        Dim y As Integer = 20
        someColor = redShade
        g.FillRectangle(myBrush1, x, y, 100, 30)
        g.DrawString(someColor.ToString(), myFont, Brushes.Black, _
        x + 120, y)

        ' Iterate through the matches that were found and display each
        ' color that corresponds with the enum value in the array.
        ' Display the name of the KnownColor.
        Dim i As Integer
        For i = 0 To count - 1
            y += 40
            someColor = Color.FromKnownColor(colorMatches(i))
            myBrush1.Color = someColor
            g.FillRectangle(myBrush1, x, y, 100, 30)
            g.DrawString(someColor.ToString(), myFont, Brushes.Black, _
            x + 120, y)
        Next i
    End Sub
    ' </snippet6>


    ' Snippet for: M:System.Drawing.Color.GetHue
    ' <snippet7>
    Public Sub GetHueExample(ByVal e As PaintEventArgs)
        Dim g As Graphics = e.Graphics

        ' Color structures. One is used for temporary storage. The other
        ' is a constant used for comparisons.
        Dim someColor As Color = Color.FromArgb(0)
        Dim redShade As Color = Color.FromArgb(255, 200, 0, 100)

        ' Array for KnownColor values that match the hue of redShade
        ' color.
        Dim colorMatches(15) As KnownColor

        ' Number of matches found.
        Dim count As Integer = 0

        ' Iterate through the KnownColor enums until 15 matches are found.
        Dim enumValue As KnownColor
        For enumValue = 0 To KnownColor.YellowGreen
            someColor = Color.FromKnownColor(enumValue)
            If (someColor.GetHue()) = (redShade.GetHue()) Then
                colorMatches(count) = enumValue
                count += 1
                If count > 15 Then
                    Exit For
                End If
            End If
        Next enumValue

        ' Display the redShade color and its argb value.
        Dim myBrush1 As New SolidBrush(redShade)
        Dim myFont As New Font("Arial", 12)
        Dim x As Integer = 20
        Dim y As Integer = 20
        someColor = redShade
        g.FillRectangle(myBrush1, x, y, 100, 30)
        g.DrawString(someColor.ToString(), myFont, Brushes.Black, _
        x + 120, y)

        ' Iterate through the matches that were found and display each
        ' color that corresponds with the enum value in the array. Also
        ' display the name of the KnownColor.
        Dim i As Integer
        For i = 0 To count - 1
            y += 40
            someColor = Color.FromKnownColor(colorMatches(i))
            myBrush1.Color = someColor
            g.FillRectangle(myBrush1, x, y, 100, 30)
            g.DrawString(someColor.ToString(), myFont, Brushes.Black, _
            x + 120, y)
        Next i
    End Sub
    ' </snippet7>


    ' Snippet for: M:System.Drawing.Color.GetSaturation
    ' <snippet8>
    Public Sub GetSatExample(ByVal e As PaintEventArgs)
        Dim g As Graphics = e.Graphics

        ' Color structures. One is used for temporary storage. The other
        ' is a constant used for comparisons.
        Dim someColor As Color = Color.FromArgb(0)
        Dim redShade As Color = Color.FromArgb(255, 200, 0, 100)

        ' Array to store KnownColor values that match the saturation of the
        ' redShade color.
        Dim colorMatches(15) As KnownColor

        ' Number of matches found.
        Dim count As Integer = 0

        ' Iterate through the KnownColor enums until 15 matches are found
        Dim enumValue As KnownColor
        For enumValue = 0 To KnownColor.YellowGreen
            someColor = Color.FromKnownColor(enumValue)
            If (someColor.GetSaturation()) = (redShade.GetSaturation()) Then
                colorMatches(count) = enumValue
                count += 1
                If count > 15 Then
                    Exit For
                End If
            End If
        Next enumValue

        ' Display the redShade color and its argb value.
        Dim myBrush1 As New SolidBrush(redShade)
        Dim myFont As New Font("Arial", 12)
        Dim x As Integer = 20
        Dim y As Integer = 20
        someColor = redShade
        g.FillRectangle(myBrush1, x, y, 100, 30)
        g.DrawString(someColor.ToString(), myFont, Brushes.Black, _
        x + 120, y)

        ' Iterate through the matches that were found and display each
        ' color that corresponds with the enum value in the array. also
        ' display the name of the KnownColor.
        Dim i As Integer
        For i = 0 To count - 1
            y += 40
            someColor = Color.FromKnownColor(colorMatches(i))
            myBrush1.Color = someColor
            g.FillRectangle(myBrush1, x, y, 100, 30)
            g.DrawString(someColor.ToString(), myFont, Brushes.Black, _
            x + 120, y)
        Next i
    End Sub
    ' </snippet8>


    ' Snippet for: M:System.Drawing.Color.ToArgb
    ' <snippet9>
    Public Sub ToArgbToStringExample1(ByVal e As PaintEventArgs)
        Dim g As Graphics = e.Graphics

        ' Color structure used for temporary storage.
        Dim someColor As Color = Color.FromArgb(0)

        ' Array to store KnownColor values that match the criteria.
        Dim colorMatches(167) As KnownColor

        ' Number of matches found.
        Dim count As Integer = 0

        ' Iterate through KnownColor enums to find all corresponding colors
        ' that have a non-zero green component and zero-valued red
        ' component and that are not system colors.
        Dim enumValue As KnownColor
        For enumValue = 0 To KnownColor.YellowGreen
            someColor = Color.FromKnownColor(enumValue)
            If someColor.G <> 0 And someColor.R = 0 And _
            Not someColor.IsSystemColor Then
                colorMatches(count) = enumValue
                count += 1
            End If
        Next enumValue
        Dim myBrush1 As New SolidBrush(someColor)
        Dim myFont As New Font("Arial", 9)
        Dim x As Integer = 40
        Dim y As Integer = 40

        ' Iterate through the matches found and display each color that
        ' corresponds with the enum value in the array. Also display the
        ' name of the KnownColor and the ARGB components.
        Dim i As Integer
        For i = 0 To count - 1

            ' Display the color.
            someColor = Color.FromKnownColor(colorMatches(i))
            myBrush1.Color = someColor
            g.FillRectangle(myBrush1, x, y, 50, 30)

            ' Display KnownColor name and four component values. To display
            ' component values:  Use the ToArgb method to get the 32-bit
            ' ARGB value of someColor (created from a KnownColor). Create
            ' a Color structure from the 32-bit ARGB value and set someColor
            ' equal to this new Color structure. Then use the ToString method
            ' to convert it to a string.
            g.DrawString(someColor.ToString(), myFont, Brushes.Black, _
            x + 55, y)
            someColor = Color.FromArgb(someColor.ToArgb())
            g.DrawString(someColor.ToString(), myFont, Brushes.Black, _
            x + 55, y + 15)
            y += 40
        Next i
    End Sub
    ' </snippet9>


    ' Snippet for: M:System.Drawing.Color.ToString
    ' <snippet10>
    Public Sub ToArgbToStringExample2(ByVal e As PaintEventArgs)
        Dim g As Graphics = e.Graphics

        ' Color structure used for temporary storage.
        Dim someColor As Color = Color.FromArgb(0)

        ' Array to store KnownColor values that match the criteria.
        Dim colorMatches(167) As KnownColor

        ' Number of matches found.
        Dim count As Integer = 0

        ' Iterate through KnownColor enums to find all corresponding colors
        ' that have a non-zero green component and zero-valued red
        ' component and that are not system colors.
        Dim enumValue As KnownColor
        For enumValue = 0 To KnownColor.YellowGreen
            someColor = Color.FromKnownColor(enumValue)
            If someColor.G <> 0 And someColor.R = 0 And _
            Not someColor.IsSystemColor Then
                colorMatches(count) = enumValue
                count += 1
            End If
        Next enumValue
        Dim myBrush1 As New SolidBrush(someColor)
        Dim myFont As New Font("Arial", 9)
        Dim x As Integer = 40
        Dim y As Integer = 40

        ' Iterate through the matches found and display each color that
        ' corresponds with the enum value in the array. Also display the
        ' name of the KnownColor and the ARGB components.
        Dim i As Integer
        For i = 0 To count - 1

            ' Display the color
            someColor = Color.FromKnownColor(colorMatches(i))
            myBrush1.Color = someColor
            g.FillRectangle(myBrush1, x, y, 50, 30)

            ' Display KnownColor name and four component values. To display
            ' component values:  Use the ToArgb method to get the 32-bit
            ' ARGB value of someColor (created from a KnownColor). Create
            ' a Color structure from the 32-bit ARGB value and set someColor
            ' equal to this new Color structure. Then use the ToString method
            ' to convert it to a string.
            g.DrawString(someColor.ToString(), myFont, Brushes.Black, _
            x + 55, y)
            someColor = Color.FromArgb(someColor.ToArgb())
            g.DrawString(someColor.ToString(), myFont, Brushes.Black, _
            x + 55, y + 15)
            y += 40
        Next i
    End Sub
    ' </snippet10>

    <STAThread()> Public Shared Sub Main()
        Application.Run(New Form1)
    End Sub

End Class
