using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows;
using System.Windows.Media;

namespace SDKSample
{
    public class FontPropertyLists
    {
        static Collection<FontFamily> fontFaces;
        static Collection<FontStyle> fontStyles;
        static Collection<FontWeight> fontWeights;
        static Collection<double> fontSizes;

        /// <summary>
        /// Return a collection of avaliable font styles 
        /// </summary>
        public static ICollection<FontFamily> FontFaces
        {
            get
            {
                if (fontFaces == null) fontFaces = new Collection<FontFamily>();
                foreach (FontFamily fontFamily in Fonts.SystemFontFamilies)
                {
                    fontFaces.Add(fontFamily);
                }
                return fontFaces;
            }
        }

        /// <summary>
        /// Return a collection of avaliable font styles 
        /// </summary>
        public static ICollection FontStyles
        {
            get
            {
                if (fontStyles == null)
                {
                   fontStyles = new Collection<FontStyle>();
                   fontStyles.Add(System.Windows.FontStyles.Normal);
                   fontStyles.Add(System.Windows.FontStyles.Oblique);
                   fontStyles.Add(System.Windows.FontStyles.Italic);
                }
                return fontStyles;
            }
        }

        /// <summary>
        /// Return a collection of avaliable FontWeight
        /// </summary>
        public static ICollection FontWeights
        {
            get
            {
                if (fontWeights == null)
                {
                    fontWeights = new Collection<FontWeight>();
                    fontWeights.Add(System.Windows.FontWeights.Thin);
                    fontWeights.Add(System.Windows.FontWeights.Light);
                    fontWeights.Add(System.Windows.FontWeights.Regular);
                    fontWeights.Add(System.Windows.FontWeights.Normal);
                    fontWeights.Add(System.Windows.FontWeights.Medium);
                    fontWeights.Add(System.Windows.FontWeights.Heavy);
                    fontWeights.Add(System.Windows.FontWeights.SemiBold);
                    fontWeights.Add(System.Windows.FontWeights.DemiBold);
                    fontWeights.Add(System.Windows.FontWeights.Bold);
                    fontWeights.Add(System.Windows.FontWeights.Black);
                    fontWeights.Add(System.Windows.FontWeights.ExtraLight);
                    fontWeights.Add(System.Windows.FontWeights.ExtraBold);
                    fontWeights.Add(System.Windows.FontWeights.ExtraBlack);
                    fontWeights.Add(System.Windows.FontWeights.UltraLight);
                    fontWeights.Add(System.Windows.FontWeights.UltraBold);
                    fontWeights.Add(System.Windows.FontWeights.UltraBlack);
                }
                return fontWeights;
            }
        }

        /// <summary>
        /// Return a collection of font sizes.
        /// </summary>
        public static Collection<double> FontSizes
        {
            get
            {
                if (fontSizes == null)
                {
                    fontSizes = new Collection<double>();
                    for (double i = 8; i <= 40; i++) fontSizes.Add(i);
                }
                return fontSizes;
            }
        }

        public static bool CanParseFontStyle(string fontStyleName)
        {
            try
            {
                FontStyleConverter converter = new FontStyleConverter();
                converter.ConvertFromString(fontStyleName);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static FontStyle ParseFontStyle(string fontStyleName)
        {
            FontStyleConverter converter = new FontStyleConverter();
            return (FontStyle)converter.ConvertFromString(fontStyleName);
        }
        public static bool CanParseFontWeight(string fontWeightName)
        {
            try
            {
                FontWeightConverter converter = new FontWeightConverter();
                converter.ConvertFromString(fontWeightName);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static FontWeight ParseFontWeight(string fontWeightName)
        {
            FontWeightConverter converter = new FontWeightConverter();
            return (FontWeight)converter.ConvertFromString(fontWeightName);
        }
    }
}
