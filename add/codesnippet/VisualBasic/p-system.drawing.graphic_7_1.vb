    Private Sub ChangeTextRenderingHintAndTextContrast(ByVal e As _
        PaintEventArgs)

        ' Retrieve the graphics object.
        Dim formGraphics As Graphics = e.Graphics

        ' Declare a new font.
        Dim myFont As Font = New Font(FontFamily.GenericSansSerif, _
            20, FontStyle.Regular)

        ' Set the TextRenderingHint property.
        formGraphics.TextRenderingHint = _
            System.Drawing.Text.TextRenderingHint.SingleBitPerPixel

        ' Draw the string.
        formGraphics.DrawString("Hello World", myFont, _
            Brushes.Firebrick, 20.0F, 20.0F)

        ' Change the TextRenderingHint property.
        formGraphics.TextRenderingHint = _
            System.Drawing.Text.TextRenderingHint.AntiAliasGridFit

        ' Draw the string again.
        formGraphics.DrawString("Hello World", myFont, _
            Brushes.Firebrick, 20.0F, 60.0F)

        ' Set the text contrast to a high-contrast setting.
        formGraphics.TextContrast = 0

        ' Draw the string.
        formGraphics.DrawString("Hello World", myFont, _
            Brushes.DodgerBlue, 20.0F, 100.0F)

        ' Set the text contrast to a low-contrast setting.
        formGraphics.TextContrast = 12

        ' Draw the string again.
        formGraphics.DrawString("Hello World", myFont, _
            Brushes.DodgerBlue, 20.0F, 140.0F)

        ' Dispose of the font object.
        myFont.Dispose()

    End Sub