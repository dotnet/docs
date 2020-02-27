using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SDKSample
{
    public partial class FontFamilySnippets : Page
    {
        private void FontFamilySnippetsLoaded(object sender, RoutedEventArgs e)
        {
            Fonts5();
        }

        public void FamilyStub1()
        {
            myTextBlock.Foreground = Brushes.Maroon;

            // <SnippetFontFallbackSnippet1>
            myTextBlock.FontFamily = new FontFamily("Comic Sans MS, Verdana");
            // </SnippetFontFallbackSnippet1>
        }

        public void FamilyStub2()
        {
            myTextBlock.Foreground = Brushes.Maroon;

            // <SnippetFontFallbackSnippet2>
            myTextBlock.FontFamily = new FontFamily(new Uri("pack://application:,,,/"), "./resources/#Pericles Light, Verdana");
            // </SnippetFontFallbackSnippet2>
        }

        public void FamilyStub3()
        {
            myTextBlock.Foreground = Brushes.Maroon;

            // <SnippetFontFallbackSnippet3>
            myTextBlock.FontFamily = new FontFamily("Comic Sans MS");
            // </SnippetFontFallbackSnippet3>
        }

        public void Fonts1()
        {
            // <SnippetFontsSnippet1>
            foreach (FontFamily fontFamily in Fonts.GetFontFamilies("file:///D:/MyFonts/"))
            {
                // Perform action.
            }
            // </SnippetFontsSnippet1>
        }

        public void Fonts2()
        {
            // <SnippetFontsSnippet2>
            foreach (FontFamily fontFamily in Fonts.GetFontFamilies(new Uri("pack://application:,,,/")))
            {
                // Perform action.
            }
            // </SnippetFontsSnippet2>
        }

        public void Fonts3()
        {
            // <SnippetFontsSnippet3>
            foreach (FontFamily fontFamily in Fonts.GetFontFamilies(new Uri("pack://application:,,,/"), "./resources/"))
            {
                // Perform action.
            }
            // </SnippetFontsSnippet3>
        }

        public void Fonts4()
        {
            // <SnippetFontsSnippet4>
            foreach (Typeface typeface in Fonts.GetTypefaces("D:/MyFonts/"))
            {
                // Perform action.
            }
            // </SnippetFontsSnippet4>
        }

        public void Fonts5()
        {
            // <SnippetFontsSnippet5>
            foreach (Typeface typeface in Fonts.GetTypefaces("file:///D:/MyFonts/"))
            {
                // Perform action.
            }
            // </SnippetFontsSnippet5>
        }

        public void Fonts6()
        {
            // <SnippetFontsSnippet6>
            foreach (Typeface typeface in Fonts.GetTypefaces(new Uri("pack://application:,,,/")))
            {
                // Perform action.
            }
            // </SnippetFontsSnippet6>
        }

        public void Fonts7()
        {
            // <SnippetFontsSnippet7>
            foreach (Typeface typeface in Fonts.GetTypefaces(new Uri("pack://application:,,,/"), "./resources/"))
            {
                // Perform action.
            }
            // </SnippetFontsSnippet7>
        }
    }
}
