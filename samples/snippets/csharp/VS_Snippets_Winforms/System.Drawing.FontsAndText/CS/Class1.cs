using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections;
using System.Xml;
using System.Drawing.Text;

public class SystemDrawingFontsAndText
{

    // 26d74ef5-0f39-4eeb-8d20-00e66e014abe
    // How to: Enumerate Installed Fonts

    public void Method11(PaintEventArgs e)
    {
        // <snippet11>
        FontFamily fontFamily = new FontFamily("Arial");
        Font font = new Font(
           fontFamily,
           8,
           FontStyle.Regular,
           GraphicsUnit.Point);
        RectangleF rectF = new RectangleF(10, 10, 500, 500);
        SolidBrush solidBrush = new SolidBrush(Color.Black);

        string familyName;
        string familyList = "";
        FontFamily[] fontFamilies;

        InstalledFontCollection installedFontCollection = new InstalledFontCollection();

        // Get the array of FontFamily objects.
        fontFamilies = installedFontCollection.Families;

        // The loop below creates a large string that is a comma-separated
        // list of all font family names.

        int count = fontFamilies.Length;
        for (int j = 0; j < count; ++j)
        {
            familyName = fontFamilies[j].Name;
            familyList = familyList + familyName;
            familyList = familyList + ",  ";
        }

        // Draw the large string (list of all families) in a rectangle.
        e.Graphics.DrawString(familyList, font, solidBrush, rectF);
        // </snippet11>
    }
    // 48fc34f3-f236-4b01-a0cb-f0752e6d22ae
    // How to: Use Antialiasing with Text

    public void Method21(PaintEventArgs e)
    {
        // <snippet21>
        FontFamily fontFamily = new FontFamily("Times New Roman");
        Font font = new Font(
           fontFamily,
           32,
           FontStyle.Regular,
           GraphicsUnit.Pixel);
        SolidBrush solidBrush = new SolidBrush(Color.FromArgb(255, 0, 0, 255));
        string string1 = "SingleBitPerPixel";
        string string2 = "AntiAlias";

        e.Graphics.TextRenderingHint = TextRenderingHint.SingleBitPerPixel;
        e.Graphics.DrawString(string1, font, solidBrush, new PointF(10, 10));

        e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
        e.Graphics.DrawString(string2, font, solidBrush, new PointF(10, 60));
        // </snippet21>
    }
    // 50c69046-4188-47d9-b949-cc2610ffd337
    // How to: Create Vertical Text

    public void Method31(PaintEventArgs e)
    {
        // <snippet31>
        string myText = "Vertical text";

        FontFamily fontFamily = new FontFamily("Lucida Console");
        Font font = new Font(
        fontFamily,
           14,
           FontStyle.Regular,
           GraphicsUnit.Point);
        PointF pointF = new PointF(40, 10);
        StringFormat stringFormat = new StringFormat();
        SolidBrush solidBrush = new SolidBrush(Color.FromArgb(255, 0, 0, 255));

        stringFormat.FormatFlags = StringFormatFlags.DirectionVertical;

        e.Graphics.DrawString(myText, font, solidBrush, pointF, stringFormat); 

        // </snippet31>
    }
    // 64878f98-39ba-4303-b63f-0859ab682eeb
    // How to: Set Tab Stops in Drawn Text

    public void Method41(PaintEventArgs e)
    {
        // <snippet41>
        string text = "Name\tTest 1\tTest 2\tTest 3\n";
        text = text + "Joe\t95\t88\t91\n";
        text = text + "Mary\t98\t84\t90\n";
        text = text + "Sam\t42\t76\t98\n";
        text = text + "Jane\t65\t73\t92\n";

        FontFamily fontFamily = new FontFamily("Courier New");
        Font font = new Font(
           fontFamily,
           12,
           FontStyle.Regular,
           GraphicsUnit.Point);
        Rectangle rect = new Rectangle(10, 10, 450, 100);
        StringFormat stringFormat = new StringFormat();
        SolidBrush solidBrush = new SolidBrush(Color.FromArgb(255, 0, 0, 255));
        float[] tabs = { 150, 100, 100, 100 };

        stringFormat.SetTabStops(0, tabs);

        e.Graphics.DrawString(text, font, solidBrush, rect, stringFormat);

        Pen pen = Pens.Black;
        e.Graphics.DrawRectangle(pen, rect);
        // </snippet41>
    }
    // 6533d5e5-a8dc-4b76-9fc4-3bf75c8b9212
    // How to: Create a Private Font Collection

    public void Method51(PaintEventArgs e)
    {
        // <snippet51>
        PointF pointF = new PointF(10, 0);
        SolidBrush solidBrush = new SolidBrush(Color.Black);

        int count = 0;
        string familyName = "";
        string familyNameAndStyle;
        FontFamily[] fontFamilies;
        PrivateFontCollection privateFontCollection = new PrivateFontCollection();

        // Add three font files to the private collection.
        privateFontCollection.AddFontFile("D:\\systemroot\\Fonts\\Arial.ttf");
        privateFontCollection.AddFontFile("D:\\systemroot\\Fonts\\CourBI.ttf");
        privateFontCollection.AddFontFile("D:\\systemroot\\Fonts\\TimesBD.ttf");

        // Get the array of FontFamily objects.
        fontFamilies = privateFontCollection.Families;

        // How many objects in the fontFamilies array?
        count = fontFamilies.Length;

        // Display the name of each font family in the private collection
        // along with the available styles for that font family.
        for (int j = 0; j < count; ++j)
        {
            // Get the font family name.
            familyName = fontFamilies[j].Name;

            // Is the regular style available?
            if (fontFamilies[j].IsStyleAvailable(FontStyle.Regular))
            {
                familyNameAndStyle = "";
                familyNameAndStyle = familyNameAndStyle + familyName;
                familyNameAndStyle = familyNameAndStyle + " Regular";

                Font regFont = new Font(
                   familyName,
                   16,
                   FontStyle.Regular,
                   GraphicsUnit.Pixel);

                e.Graphics.DrawString(
                   familyNameAndStyle,
                   regFont,
                   solidBrush,
                   pointF);

                pointF.Y += regFont.Height;
            }

            // Is the bold style available?
            if (fontFamilies[j].IsStyleAvailable(FontStyle.Bold))
            {
                familyNameAndStyle = "";
                familyNameAndStyle = familyNameAndStyle + familyName;
                familyNameAndStyle = familyNameAndStyle + " Bold";

                Font boldFont = new Font(
                   familyName,
                   16,
                   FontStyle.Bold,
                   GraphicsUnit.Pixel);

                e.Graphics.DrawString(familyNameAndStyle, boldFont, solidBrush, pointF);

                pointF.Y += boldFont.Height;
            }
            // Is the italic style available?
            if (fontFamilies[j].IsStyleAvailable(FontStyle.Italic))
            {
                familyNameAndStyle = "";
                familyNameAndStyle = familyNameAndStyle + familyName;
                familyNameAndStyle = familyNameAndStyle + " Italic";

                Font italicFont = new Font(
                   familyName,
                   16,
                   FontStyle.Italic,
                   GraphicsUnit.Pixel);

                e.Graphics.DrawString(
                   familyNameAndStyle,
                   italicFont,
                   solidBrush,
                   pointF);

                pointF.Y += italicFont.Height;
            }

            // Is the bold italic style available?
            if (fontFamilies[j].IsStyleAvailable(FontStyle.Italic) &&
            fontFamilies[j].IsStyleAvailable(FontStyle.Bold))
            {
                familyNameAndStyle = "";
                familyNameAndStyle = familyNameAndStyle + familyName;
                familyNameAndStyle = familyNameAndStyle + "BoldItalic";

                Font italicFont = new Font(
                   familyName,
                   16,
                   FontStyle.Italic | FontStyle.Bold,
                   GraphicsUnit.Pixel);

                e.Graphics.DrawString(
                   familyNameAndStyle,
                   italicFont,
                   solidBrush,
                   pointF);

                pointF.Y += italicFont.Height;
            }
            // Is the underline style available?
            if (fontFamilies[j].IsStyleAvailable(FontStyle.Underline))
            {
                familyNameAndStyle = "";
                familyNameAndStyle = familyNameAndStyle + familyName;
                familyNameAndStyle = familyNameAndStyle + " Underline";

                Font underlineFont = new Font(
                   familyName,
                   16,
                   FontStyle.Underline,
                   GraphicsUnit.Pixel);

                e.Graphics.DrawString(
                   familyNameAndStyle,
                   underlineFont,
                   solidBrush,
                   pointF);

                pointF.Y += underlineFont.Height;
            }

            // Is the strikeout style available?
            if (fontFamilies[j].IsStyleAvailable(FontStyle.Strikeout))
            {
                familyNameAndStyle = "";
                familyNameAndStyle = familyNameAndStyle + familyName;
                familyNameAndStyle = familyNameAndStyle + " Strikeout";

                Font strikeFont = new Font(
                   familyName,
                   16,
                   FontStyle.Strikeout,
                   GraphicsUnit.Pixel);

                e.Graphics.DrawString(
                   familyNameAndStyle,
                   strikeFont,
                   solidBrush,
                   pointF);

                pointF.Y += strikeFont.Height;
            }

            // Separate the families with white space.
            pointF.Y += 10;

        } // for
        // </snippet51>
    }
    // d3a4a223-9492-4b54-9afd-db1c31c3cefd
    // How to: Construct Font Families and Fonts

    public void Method61(PaintEventArgs e)
    {
        // <snippet61>
        FontFamily fontFamily = new FontFamily("Arial");
        Font font = new Font(
           fontFamily,
           16,
           FontStyle.Regular,
           GraphicsUnit.Pixel);
        // </snippet61>
    }
    // ff7c0616-67f7-4fa2-84ee-b8d642f2b09b
    // How to: Obtain Font Metrics

    public void Method71(PaintEventArgs e)
    {
        // <snippet71>
        string infoString = "";  // enough space for one line of output
        int ascent;             // font family ascent in design units
        float ascentPixel;      // ascent converted to pixels
        int descent;            // font family descent in design units
        float descentPixel;     // descent converted to pixels
        int lineSpacing;        // font family line spacing in design units
        float lineSpacingPixel; // line spacing converted to pixels

        FontFamily fontFamily = new FontFamily("Arial");
        Font font = new Font(
           fontFamily,
           16, FontStyle.Regular,
           GraphicsUnit.Pixel);
        PointF pointF = new PointF(10, 10);
        SolidBrush solidBrush = new SolidBrush(Color.Black);

        // Display the font size in pixels.
        infoString = "font.Size returns " + font.Size + ".";
        e.Graphics.DrawString(infoString, font, solidBrush, pointF);

        // Move down one line.
        pointF.Y += font.Height;

        // Display the font family em height in design units.
        infoString = "fontFamily.GetEmHeight() returns " +
           fontFamily.GetEmHeight(FontStyle.Regular) + ".";
        e.Graphics.DrawString(infoString, font, solidBrush, pointF);

        // Move down two lines.
        pointF.Y += 2 * font.Height;

        // Display the ascent in design units and pixels.
        ascent = fontFamily.GetCellAscent(FontStyle.Regular);

        // 14.484375 = 16.0 * 1854 / 2048
        ascentPixel =
           font.Size * ascent / fontFamily.GetEmHeight(FontStyle.Regular);
        infoString = "The ascent is " + ascent + " design units, " + ascentPixel +
           " pixels.";
        e.Graphics.DrawString(infoString, font, solidBrush, pointF);

        // Move down one line.
        pointF.Y += font.Height;

        // Display the descent in design units and pixels.
        descent = fontFamily.GetCellDescent(FontStyle.Regular);

        // 3.390625 = 16.0 * 434 / 2048
        descentPixel =
           font.Size * descent / fontFamily.GetEmHeight(FontStyle.Regular);
        infoString = "The descent is " + descent + " design units, " +
           descentPixel + " pixels.";
        e.Graphics.DrawString(infoString, font, solidBrush, pointF);

        // Move down one line.
        pointF.Y += font.Height;

        // Display the line spacing in design units and pixels.
        lineSpacing = fontFamily.GetLineSpacing(FontStyle.Regular);

        // 18.398438 = 16.0 * 2355 / 2048
        lineSpacingPixel =
        font.Size * lineSpacing / fontFamily.GetEmHeight(FontStyle.Regular);
        infoString = "The line spacing is " + lineSpacing + " design units, " +
           lineSpacingPixel + " pixels.";
        e.Graphics.DrawString(infoString, font, solidBrush, pointF);
        // </snippet71>
    }
}

