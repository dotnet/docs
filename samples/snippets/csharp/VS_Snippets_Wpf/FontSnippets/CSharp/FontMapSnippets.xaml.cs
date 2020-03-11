using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Markup;

namespace SDKSample
{
    public partial class FontMapSnippets : Page
    {
        private void FontMapPageLoaded(object sender, RoutedEventArgs e)
        {
            Stub1();
            Stub2();
            Stub3();
            Stub4();
            Stub5();
            Stub6();
        }

        public void Stub1()
        {
            // <SnippetFontMapSnippet1>
            FontFamilyMap fontFamilyMap = new FontFamilyMap();
            // </SnippetFontMapSnippet1>
            fontFamilyMap.Target = "Tahoma, Verdana";
        }

        public void Stub2()
        {
            FontFamilyMap fontFamilyMap = new FontFamilyMap();

            // <SnippetFontMapSnippet2>
            fontFamilyMap.Scale = 1.1;
            // </SnippetFontMapSnippet2>
        }

        public void Stub3()
        {
            FontFamilyMap fontFamilyMap = new FontFamilyMap();

            // <SnippetFontMapSnippet3>
            fontFamilyMap.Target = "Tahoma, Verdana";
            // </SnippetFontMapSnippet3>
        }

        public void Stub4()
        {
            FontFamilyMap fontFamilyMap = new FontFamilyMap();
            string unicode = fontFamilyMap.Unicode;

            // <SnippetFontMapSnippet4>
            try
            {
                fontFamilyMap.Unicode = "00e0-00ef, 0100-01ff";
            }
            catch (FormatException ex)
            {
                // Handle exception
            }
            // </SnippetFontMapSnippet4>
        }

        public void Stub5()
        {
            FontFamilyMap fontFamilyMap = new FontFamilyMap();

            // <SnippetFontMapSnippet5>
            fontFamilyMap.Language = XmlLanguage.GetLanguage("en-uk");
            // </SnippetFontMapSnippet5>
        }

        public void Stub6()
        {
            // <SnippetFontMapSnippet6>
            // Create a new FontFamily object.
            FontFamily fontFamily = new FontFamily();

            // Create the FontFamilyMap.
            FontFamilyMap fontFamilyMap = new FontFamilyMap();
            fontFamilyMap.Target = "Comic Sans MS";
            fontFamilyMap.Language = XmlLanguage.GetLanguage("en-us");
            fontFamilyMap.Unicode = "00e0-00ef";

            // Add the FontFamilyMap to the FontFamily's collection.
            fontFamily.FamilyMaps.Add(fontFamilyMap);
            // </SnippetFontMapSnippet6>
        }
    }
}
