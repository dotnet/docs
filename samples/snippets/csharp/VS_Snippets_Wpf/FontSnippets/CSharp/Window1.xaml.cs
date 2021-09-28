using System;
using System.Collections;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;

namespace SDKSample
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void OnClick1(object sender, RoutedEventArgs e)
        {
            TestCodeSnippet8();
            TestAPIs();
        }

        public void TestCodeSnippet1()
        {
            //<Snippet100>
            // Return the font family collection for the selected directory location.
            System.Collections.Generic.ICollection<FontFamily> fontFamilies = Fonts.GetFontFamilies("C:/MyFonts");

            // Enumerate through the font family collection.
            foreach (FontFamily fontFamily in fontFamilies)
            {
                // Separate the URI directory source info from the font family name.
                string[] familyName = fontFamily.Source.Split('#');

                // Add the font family name to the fonts combo box.
                comboBoxFonts.Items.Add(familyName[familyName.Length - 1]);
            }

            comboBoxFonts.SelectedIndex = 0;
            //</Snippet100>
        }

        public void TestCodeSnippet2()
        {
            //<Snippet101>
            // Return the font family collection for the selected URI location.
            System.Collections.Generic.ICollection<FontFamily> fontFamilies = Fonts.GetFontFamilies("file:///C:\\Windows\\Fonts\\#Georgia");

            // Enumerate through the font family collection.
            foreach (FontFamily fontFamily in fontFamilies)
            {
                // Separate the URI directory source info from the font family name.
                string[] familyName = fontFamily.Source.Split('#');

                // Add the font family name to the fonts combo box.
                comboBoxFonts.Items.Add(familyName[familyName.Length - 1]);
            }

            comboBoxFonts.SelectedIndex = 0;
            //</Snippet101>
        }

        public void TestCodeSnippet3()
        {
            //<Snippet102>
            // Return the typeface collection for the fonts in the selected URI location.
            System.Collections.Generic.ICollection<Typeface> typefaces = Fonts.GetTypefaces("file:///C:\\Windows\\Fonts\\#Georgia");

            // Enumerate the typefaces in the collection.
            foreach (Typeface face in typefaces)
            {
                // Separate the URI directory source info from the font family name.
                string[] familyName = face.FontFamily.Source.Split('#');

                // Add the font family name, weight, and style values to the typeface combo box.
                comboBoxTypeface.Items.Add(familyName[familyName.Length - 1] + " " + face.Weight + " " + face.Style);
            }

            comboBoxTypeface.SelectedIndex = 0;
            //</Snippet102>
        }

        public void TestCodeSnippet4()
        {
            //<Snippet103>
            // Return the font family using an implied reference for a font in the default system font directory.
            FontFamily fontFamily1 = new FontFamily("Arial Narrow");

            // Return the font family using a directory reference for the font name.
            FontFamily fontFamily2 = new FontFamily("C:/MyFonts/#Pericles Light");

            // Return the font family using a URI reference for the font name.
            FontFamily fontFamily3 = new FontFamily("file:///C:\\Windows\\Fonts\\#Palatino Linotype");
            //</Snippet103>

            // Return the collection of typefaces for the font family.
            System.Collections.Generic.ICollection<Typeface> typefaces = fontFamily1.GetTypefaces();

            // Enumerate the typefaces in the collection.
            foreach (Typeface face in typefaces)
            {
                // Separate the URI directory source info from the font family name.
                string[] familyName = face.FontFamily.Source.Split('#');

                // Add the font family name, weight, and style values to the typeface combo box.
                comboBoxTypeface.Items.Add(familyName[familyName.Length - 1] + " " + face.Weight + " " + face.Style);
            }

            comboBoxTypeface.SelectedIndex = 0;
        }

        public void TestCodeSnippet5()
        {
            //<Snippet104>
            // Return the font family for the selected font name.
            FontFamily fontFamily = new FontFamily("Palatino Linotype");

            // Return the collection of typefaces for the font family.
            System.Collections.Generic.ICollection<Typeface> typefaces = fontFamily.GetTypefaces();
            //</Snippet104>

            // Enumerate the typefaces in the collection.
            foreach (Typeface face in typefaces)
            {
                // Separate the URI directory source info from the font family name.
                string[] familyName = face.FontFamily.Source.Split('#');

                // Add the font family name, weight, and style values to the typeface combo box.
                comboBoxTypeface.Items.Add(familyName[familyName.Length - 1] + " " + face.Weight + " " + face.Style);
            }

            comboBoxTypeface.SelectedIndex = 0;
        }

        public void TestCodeSnippet6()
        {
            //<Snippet105>
            // Return the typeface for the selected font family name.
            Typeface typeface1 = new Typeface("Verdana");

            // Return the typeface for the selected font family name and font values.
            Typeface typeface2 = new Typeface(new FontFamily("file:///C:\\MyFonts\\#Pericles Light"),
                                                             FontStyles.Italic,
                                                             FontWeights.ExtraBold,
                                                             FontStretches.Condensed);

            // Return the typeface for the selected font family name, font values, and fallback font family name.
            Typeface typeface3 = new Typeface(new FontFamily("file:///C:\\MyFonts\\#Pericles"),
                                                             FontStyles.Italic,
                                                             FontWeights.ExtraBold,
                                                             FontStretches.Condensed,
                                                             new FontFamily("Arial"));
            //</Snippet105>

            TextBlock1.FontFamily = typeface3.FontFamily;
        }

        public void TestCodeSnippet7()
        {
            // Return the font family for the selected font name.
            FontFamily fontFamily = new FontFamily("Arial");

            //<Snippet106>
            // Return the dictionary for the font family names.
            LanguageSpecificStringDictionary dictionary = fontFamily.FamilyNames;

            // Return the current culture info.
            CultureInfo cultureInfo = CultureInfo.CurrentCulture;

            // Determine whether the dictionary contains the current culture info.
            //if (dictionary.ContainsKey())
            //{
                // Font family contains the family name for the current culture info.
            //}
            //</Snippet106>
            //else
            //{
            //}
        }

        public void TestCodeSnippet8()
        {
            //<Snippet107>
            // Return the font family for the selected font name.
            FontFamily fontFamily = new FontFamily("Arial Narrow");

            // Return the family typeface collection for the font family.
            FamilyTypefaceCollection familyTypefaceCollection = fontFamily.FamilyTypefaces;

            // Enumerate the family typefaces in the collection.
            foreach (FamilyTypeface typeface in familyTypefaceCollection)
            {
                // Add the typeface style values to the styles combo box.
                comboBoxStyles.Items.Add(typeface.Style);
            }

            comboBoxStyles.SelectedIndex = 0;
            //</Snippet107>
        }

        public void TestCodeSnippet9()
        {
            // Return the typeface for the selected font family name and font values.
            Typeface typeface = new Typeface(new FontFamily("file:///C:\\MyFonts\\#Pericles Light"), FontStyles.Italic, FontWeights.ExtraBold, FontStretches.Condensed);

            //<Snippet108>
            // Get the font stretch value for the typeface.
            FontStretch fontStretch = typeface.Stretch;

            if (fontStretch == FontStretches.Condensed)
            {
                // Perform action based on condensed stretch value.
            }
            //</Snippet108>
        }

        public void TestCodeSnippet10()
        {
            // Return the typeface for the selected font family name and font values.
            Typeface typeface = new Typeface(new FontFamily("file:///C:\\MyFonts\\#Pericles Light"), FontStyles.Italic, FontWeights.ExtraBold, FontStretches.Condensed);

            //<Snippet109>
            // Get the font style value for the typeface.
            FontStyle fontStyle = typeface.Style;

            if (fontStyle == FontStyles.Italic)
            {
                // Perform action based on italic style value.
            }
            //</Snippet109>
        }

        public void TestCodeSnippet11()
        {
            // Return the typeface for the selected font family name and font values.
            Typeface typeface = new Typeface(new FontFamily("file:///C:\\MyFonts\\#Pericles Light"), FontStyles.Italic, FontWeights.ExtraBold, FontStretches.Condensed);

            //<Snippet110>
            // Get the font weight value for the typeface.
            FontWeight fontWeight = typeface.Weight;

            if (fontWeight == FontWeights.ExtraBold)
            {
                // Perform action based on extra bold weight value.
            }
            //</Snippet110>
        }

        public void TestCodeSnippet12()
        {
            //<SnippetFontSnippet11>
            // Return the typefaces for the selected font family name and font values.
            Typeface typeface1 = new Typeface(new FontFamily("Arial"), FontStyles.Normal, FontWeights.Normal, FontStretches.Normal);
            Typeface typeface2 = new Typeface(new FontFamily("Arial"), FontStyles.Normal, FontWeights.UltraBold, FontStretches.Normal);

            if (FontWeight.Compare(typeface1.Weight, typeface2.Weight) < 0)
            {
                // Code execution follows this path because
                // the FontWeight of typeface1 (Normal) is less than of typeface2 (UltraBold).
            }
            //</SnippetFontSnippet11>
        }

        public void TestAPIs()
        {
            // Return the font family for the selected font name.
            FontFamily fontFamily = new FontFamily("Arial");
            FontFamily fontFamilyNameless = new FontFamily();

            string toString = fontFamily.ToString();
            string source = fontFamily.Source;
            string toStringNameless = fontFamilyNameless.ToString();
        }
    }
}
