using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Media;

namespace WindowsApplication1
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void OnClick(object sender, EventArgs e)
        {
            Stub01();
            Stub02();
            Stub03();
        }

        public void Stub01()
        {
            // <SnippetGlyphTypefaceSnippet1>
            // Create a glyph typeface by referencing the Kootenay OpenType font.
            GlyphTypeface glyphTypeface = new GlyphTypeface(new Uri("file:///C:\\WINDOWS\\Fonts\\Kooten.ttf"));
            // </SnippetGlyphTypefaceSnippet1>
        }


        public void Stub02()
        {
            // <SnippetGlyphTypefaceSnippet2>
            // Create a glyph typeface by referencing the Verdana font.
            GlyphTypeface glyphTypeface = new GlyphTypeface(new Uri("file:///C:\\WINDOWS\\Fonts\\verdana.ttf"));

            // Retrieve the advance heights for the glyphs in the Verdana font.
            IDictionary<ushort, double> dictionary = glyphTypeface.AdvanceHeights;
            foreach (KeyValuePair<ushort, double> kvp in dictionary)
            {
                // Retrieve the key/value pair information.
            }
            // </SnippetGlyphTypefaceSnippet2>
        }

        public void Stub03()
        {
            // <SnippetGlyphTypefaceSnippet3>
            // Create a glyph typeface by referencing the Pericles OpenType font.
            GlyphTypeface glyphTypeface = new GlyphTypeface(new Uri("file:///C:\\WINDOWS\\Fonts\\Peric.ttf"));

            // Retrieve the copyright information for the Pericles OpenType font.
            IDictionary<CultureInfo, string> dictionary = glyphTypeface.Copyrights;
            foreach (KeyValuePair<CultureInfo, string> kvp in dictionary)
            {
                // Retrieve the key/value pair information.
            }
            // </SnippetGlyphTypefaceSnippet3>
        }
    }
}