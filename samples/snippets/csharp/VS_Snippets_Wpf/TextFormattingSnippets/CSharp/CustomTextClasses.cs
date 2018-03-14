using System;
using System.Globalization;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.TextFormatting;

namespace CustomTextClasses
{
    class CustomTextSource : TextSource
    {
        // <SnippetTextFormattingSnippet4>
        // Retrieve the next formatted text run for the text source.
        public override TextRun GetTextRun(int textSourceCharacterIndex)
        {
            // Determine whether the text source index is in bounds.
            if (textSourceCharacterIndex < 0)
            {
                throw new ArgumentOutOfRangeException("textSourceCharacterIndex", "Value must be greater than 0.");
            }

            // Determine whether the text source index has exceeded or equaled the text source length.
            if (textSourceCharacterIndex >= _text.Length)
            {
                // Return an end-of-paragraph indicator -- a TextEndOfParagraph object is a special type of text run.
                return new TextEndOfParagraph(1);
            }

            // Create and return a TextCharacters object, which is formatted according to
            // the current layout and rendering properties.
            if (textSourceCharacterIndex < _text.Length)
            {
                // The TextCharacters object is a special type of text run that contains formatted text.
                return new TextCharacters(
                   _text,                                       // The text store
                   textSourceCharacterIndex,                    // The text store index
                   _text.Length - textSourceCharacterIndex,     // The text store length
                   new CustomTextRunProperties());              // The layout and rendering properties
            }

            // Return an end-of-paragraph indicator if there is no more text source.
            return new TextEndOfParagraph(1);
        }
        // </SnippetTextFormattingSnippet4>

        public override TextSpan<CultureSpecificCharacterBufferRange> GetPrecedingText(int textSourceCharacterIndexLimit)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public override int GetTextEffectCharacterIndexFromTextSourceCharacterIndex(int textSourceCharacterIndex)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #region Properties
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }
        #endregion

        #region Private Fields

        private string _text;      //text store

        #endregion
    }

    class CustomTextParagraphProperties : TextParagraphProperties
    {
        private CustomTextRunProperties _customTextRunProperties = new CustomTextRunProperties();

        public override TextRunProperties DefaultTextRunProperties
        {
            get { return _customTextRunProperties; }
        }

        public override bool FirstLineInParagraph
        {
            get { return true; }
        }

        public override FlowDirection FlowDirection
        {
            get { return FlowDirection.LeftToRight; }
        }

        public override double Indent
        {
            get { return 0; }
        }

        public override double LineHeight
        {
            get { return 24; }
        }

        public override TextAlignment TextAlignment
        {
            get { return TextAlignment.Left; }
        }

        public override TextMarkerProperties TextMarkerProperties
        {
            get { return null; }
        }

        public override TextWrapping TextWrapping
        {
            get { return TextWrapping.Wrap; }
        }
    }

    class CustomTextRunProperties : TextRunProperties
    {
        public override Brush BackgroundBrush
        {
            get { return Brushes.Transparent; }
        }

        public override CultureInfo CultureInfo
        {
            get { return CultureInfo.CurrentUICulture; }
        }

        public override double FontHintingEmSize
        {
            get { return 24.0; }
        }

        public override double FontRenderingEmSize
        {
            get { return 24.0; }
        }

        public override Brush ForegroundBrush
        {
            get { return Brushes.Teal; }
        }

        public override TextDecorationCollection TextDecorations
        {
            get { return null; }
        }

        public override TextEffectCollection TextEffects
        {
            get { return null; }
        }

        public override Typeface Typeface
        {
            get { return new Typeface("Narkism"); }
        }
    }
}
