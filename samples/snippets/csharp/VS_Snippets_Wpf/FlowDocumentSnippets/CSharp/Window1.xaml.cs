using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;

using System.Windows.Media.Animation;
using System.IO;
using System.Windows.Markup;

namespace FlowDocumentSnippets
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

        private void WindowLoaded(Object sender, RoutedEventArgs args)
        {
            SetBackground();
            CallBlockConstructor();
            BlocksProperty();
            BlocksPropertyGen();
            ColumnStuff();
            ContentStartEnd();
            FlowDirectionStuff();
            FontStuff();
            LineHeightStuff();
            PageWidthHeight();
            PaddingStuff();
            TextAlignmentStuff();
            TypographyStuff();
            TextEffectsStuff();
            Hyphenate();

            FDRProps();
        }

        void SetBackground()
        {
            // <Snippet_FlowDocumentBackground>
            FlowDocument flowDoc = new FlowDocument(new Paragraph(new Run("A bit of text content...")));
            flowDoc.Background = Brushes.IndianRed;
            flowDoc.Foreground = Brushes.NavajoWhite;
            // </Snippet_FlowDocumentBackground>
        }

        void CallBlockConstructor()
        {
            {
                // <Snippet_FlowDocumentConstructorSimple>
                FlowDocument flowDoc = new FlowDocument(new Paragraph(new Run("A bit of text content...")));
                // </Snippet_FlowDocumentConstructorSimple>
            }

            {
                // <Snippet_TextBlockConstructorSimple>
                TextBlock txtBlock = new TextBlock(new Run("A bit of text content..."));
                // </Snippet_TextBlockConstructorSimple>
            }

            {
                // <Snippet_FlowDocumentConstructorTable>
                // A paragraph with sample text will serve as table content.
                Paragraph tableText = new Paragraph(new Run("A bit of text content..."));

                Table sampleTable = new Table();

                // Create and add a couple of columns.
                sampleTable.Columns.Add(new TableColumn());
                sampleTable.Columns.Add(new TableColumn());

                // Create and add a row group and a couple of rows.
                sampleTable.RowGroups.Add(new TableRowGroup());
                sampleTable.RowGroups[0].Rows.Add(new TableRow());
                sampleTable.RowGroups[0].Rows.Add(new TableRow());

                // Create four cells initialized with the sample text paragraph.
                sampleTable.RowGroups[0].Rows[0].Cells.Add(new TableCell(tableText));
                sampleTable.RowGroups[0].Rows[0].Cells.Add(new TableCell(tableText));
                sampleTable.RowGroups[0].Rows[1].Cells.Add(new TableCell(tableText));
                sampleTable.RowGroups[0].Rows[1].Cells.Add(new TableCell(tableText));

                // Finally, use the FlowDocument constructor to create a new FlowDocument containing
                // the table constructed above.
                FlowDocument flowDoc = new FlowDocument(sampleTable);
                // </Snippet_FlowDocumentConstructorTable>
            }
        }

        void BlocksProperty()
        {
            // Append a content block to the contents of the FlowDocument.
            // <Snippet_FlowDocumentBlocksAdd>
            FlowDocument flowDoc = new FlowDocument(new Paragraph(new Run("A bit of text content...")));
            flowDoc.Blocks.Add(new Paragraph(new Run("Text to append...")));
            // </Snippet_FlowDocumentBlocksAdd>

            // Insert a content block at the begining of the FlowDocument.
            // <Snippet_FlowDocumentBlocksInsert>
            Paragraph p = new Paragraph(new Run("Text to insert..."));
            flowDoc.Blocks.InsertBefore(flowDoc.Blocks.FirstBlock, p);
            // </Snippet_FlowDocumentBlocksInsert>

            // Get the number of top-level Block elements in the FlowDocument.
            // <Snippet_FlowDocumentBlocksCount>
            int countTopLevelBlocks = flowDoc.Blocks.Count;
            // </Snippet_FlowDocumentBlocksCount>

            // Remove the last block in the FlowDocument.
            // <Snippet_FlowDocumentBlocksRemoveLast>
            flowDoc.Blocks.Remove(flowDoc.Blocks.LastBlock);
            // </Snippet_FlowDocumentBlocksRemoveLast>

            // Clear all of the blocks (contents) of the FlowDocument.
            // <Snippet_FlowDocumentBlocksClear>
            flowDoc.Blocks.Clear();
            // </Snippet_FlowDocumentBlocksClear>
        }

        void BlocksPropertyGen()
        {
            // Append a content block to the contents of the Section.
            // <Snippet_SectionBlocksAdd>
            Section secx = new Section();
            secx.Blocks.Add(new Paragraph(new Run("A bit of text content...")));
            // </Snippet_SectionBlocksAdd>

            // Insert a content block at the begining of the Section.
            // <Snippet_SectionBlocksInsert>
            Paragraph parx = new Paragraph(new Run("Text to insert..."));
            secx.Blocks.InsertBefore(secx.Blocks.FirstBlock, parx);
            // </Snippet_SectionBlocksInsert>

            // Get the number of top-level Block elements in the Section.
            // <Snippet_SectionBlocksCount>
            int countTopLevelBlocks = secx.Blocks.Count;
            // </Snippet_SectionBlocksCount>

            // Remove the last block in the Section.
            // <Snippet_SectionBlocksRemoveLast>
            secx.Blocks.Remove(secx.Blocks.LastBlock);
            // </Snippet_SectionBlocksRemoveLast>

            // Clear all of the blocks (contents) of the Section.
            // <Snippet_SectionBlocksClear>
            secx.Blocks.Clear();
            // </Snippet_SectionBlocksClear>
        }

        void ColumnStuff()
        {
            {
                // <Snippet_FlowDocumentColumnGap>
                FlowDocument flowDoc = new FlowDocument(new Paragraph(new Run("A bit of text content...")));
                // Set the desired column gap to 10 device independend pixels.
                flowDoc.ColumnGap = 10.0;
                // </Snippet_FlowDocumentColumnGap>
            }

            {
                // <Snippet_FlowDocumentColumnRule>
                FlowDocument flowDoc = new FlowDocument(new Paragraph(new Run("A bit of text content...")));
                // Set a column rule two pixels wide colored Dodger blue.
                flowDoc.ColumnRuleWidth = 2.0;
                flowDoc.ColumnRuleBrush = Brushes.DodgerBlue;
                // </Snippet_FlowDocumentColumnRule>
            }

            {
                // <Snippet_FlowDocumentColumnWidth>
                FlowDocument flowDoc = new FlowDocument(new Paragraph(new Run("A bit of text content...")));
                // Set minimum column width to 140 pixels.
                flowDoc.ColumnWidth = 140.0;
                // </Snippet_FlowDocumentColumnWidth>
            }

            {
                // <Snippet_FlowDocumentColumnFlex>
                FlowDocument flowDoc = new FlowDocument(new Paragraph(new Run("A bit of text content...")));
                // Set minimum column width to 140 pixels.
                flowDoc.IsColumnWidthFlexible = true;
                // </Snippet_FlowDocumentColumnFlex>
            }
        }

        void ContentStartEnd()
        {
            {
                // <Snippet_FlowDocumentContentEnd>
                // Create a new, empty FlowDocument.
                FlowDocument flowDoc = new FlowDocument();

                // Append an initial paragraph at the "end" of the empty FlowDocument.
                flowDoc.Blocks.Add(new Paragraph(new Run(
                    "Since the new FlowDocument is empty at this point, this will be the initial content " +
                    "in the FlowDocument."
                )));
                // Append a line-break.
                flowDoc.Blocks.Add(new Paragraph(new LineBreak()));
                // Append another paragraph.
                flowDoc.Blocks.Add(new Paragraph(new Run(
                    "This text will be in a paragraph that is inserted at the end of the FlowDocument.")));
                // </Snippet_FlowDocumentContentEnd>
            }

            {
                // <Snippet_FlowDocumentContentStart>
                // Create a new, empty FlowDocument.
                FlowDocument flowDoc = new FlowDocument();

                // Insert an initial paragraph at the beginning of the empty FlowDocument.
                flowDoc.Blocks.Add(new Paragraph(new Run(
                    "Since the new FlowDocument is empty at this point, this will be the initial content " +
                    "in the FlowDocument."
                )));
                // Insert a line-break at the beginnign of the document, before the previously inserted paragraph.
                flowDoc.Blocks.InsertBefore(flowDoc.Blocks.FirstBlock, new Paragraph(new LineBreak()));
                // Insert another paragraph at the beginning of the document.
                flowDoc.Blocks.InsertBefore(flowDoc.Blocks.FirstBlock, new Paragraph(new Run(
                    "This paragraph will be inserted before the previously added paragraph, replacing the previously" +
                    "added paragraph as the first paragraph in the document."
                )));
                // </Snippet_FlowDocumentContentStart>
            }
        }

        void FlowDirectionStuff()
        {
            // <Snippet_FlowDocumentFlowDirection>
            FlowDocument flowDoc = new FlowDocument(new Paragraph(new Run("A bit of text content...")));
            // Set the content flow direction to left-to-right.
            flowDoc.FlowDirection = System.Windows.FlowDirection.LeftToRight;
            // </Snippet_FlowDocumentFlowDirection>
        }

        void FontStuff()
        {
            // <Snippet_FlowDocumentFontStuff>
            FlowDocument flowDoc = new FlowDocument(new Paragraph(new Run("A bit of text content...")));
            // Set the desired column gap to 10 device independend pixels.
            flowDoc.FontFamily = new FontFamily("Century Gothic");
            flowDoc.FontSize = 12.0;
            flowDoc.FontStretch = FontStretches.UltraExpanded;
            flowDoc.FontStyle = FontStyles.Italic;
            flowDoc.FontWeight = FontWeights.UltraBold;
            // </Snippet_FlowDocumentFontStuff>
        }

        void LineHeightStuff()
        {
            // <Snippet_FlowDocumentLineHeight>
            FlowDocument flowDoc = new FlowDocument(new Paragraph(new Run("A bit of text content...")));
            // Set the content flow direction to left-to-right.
            flowDoc.LineHeight = 48;
            // </Snippet_FlowDocumentLineHeight>
        }

        void PageWidthHeight()
        {
            // <Snippet_FlowDocumentPageWidthHeight>
            FlowDocument flowDoc = new FlowDocument(new Paragraph(new Run("A bit of text content...")));
            // Set PageHeight and PageWidth to "Auto".
            flowDoc.PageHeight = Double.NaN;
            flowDoc.PageWidth = Double.NaN;
            // Specify minimum page sizes.
            flowDoc.MinPageWidth = 680.0;
            flowDoc.MinPageHeight = 480.0;
            //Specify maximum page sizes.
            flowDoc.MaxPageWidth = 1024.0;
            flowDoc.MaxPageHeight = 768.0;
            // </Snippet_FlowDocumentPageWidthHeight>
        }

        void PaddingStuff()
        {
            // <Snippet_FlowDocumentPadding>
            FlowDocument flowDoc = new FlowDocument(new Paragraph(new Run("A bit of text content...")));

            // Padding is 10 pixels all around.
            flowDoc.PagePadding = new Thickness(10);
            // Padding is 5 pixels on the right and left, and 10 pixels on the top and botton.
            flowDoc.PagePadding = new Thickness(5, 10, 5, 10);
            // </Snippet_FlowDocumentPadding>
        }
        void TextAlignmentStuff()
        {
            // <Snippet_FlowDocumentTextAlignment>
            FlowDocument flowDoc = new FlowDocument(new Paragraph(new Run("A bit of text content...")));

            // Text will be centered.
            flowDoc.TextAlignment = TextAlignment.Center;
            // </Snippet_FlowDocumentTextAlignment>
        }

        void TypographyStuff()
        {
            // <Snippet_FlowDocumentTypography>
            FlowDocument flowDoc = new FlowDocument(new Paragraph(new Run("A bit of text content...")));

            // Change various default typography variations.
            flowDoc.Typography.Capitals               = FontCapitals.SmallCaps;
            flowDoc.Typography.CapitalSpacing         = true;
            flowDoc.Typography.CaseSensitiveForms     = true;
            flowDoc.Typography.ContextualAlternates   = false;
            flowDoc.Typography.ContextualLigatures    = false;
            flowDoc.Typography.DiscretionaryLigatures = true;
            flowDoc.Typography.EastAsianExpertForms   = true;
            flowDoc.Typography.EastAsianLanguage      = FontEastAsianLanguage.Traditional;
            flowDoc.Typography.EastAsianWidths        = FontEastAsianWidths.Proportional;
            flowDoc.Typography.Fraction               = FontFraction.Stacked;
            flowDoc.Typography.HistoricalForms        = true;
            flowDoc.Typography.HistoricalLigatures    = true;
            flowDoc.Typography.Kerning                = false;
            flowDoc.Typography.MathematicalGreek      = true;
            flowDoc.Typography.NumeralAlignment       = FontNumeralAlignment.Proportional;
            flowDoc.Typography.NumeralStyle           = FontNumeralStyle.OldStyle;
            flowDoc.Typography.SlashedZero            = true;
            flowDoc.Typography.StandardLigatures      = false;
            flowDoc.Typography.Variants               = FontVariants.Ruby;
            // </Snippet_FlowDocumentTypography>
        }

        void TextEffectsStuff()
        {

            // Create and configure a simple color animation sequence.  Timespan in 100 nanosecond ticks.
            ColorAnimation blackToWhite = new ColorAnimation(Colors.White, Colors.Black, new Duration(new TimeSpan(10000000)));
            blackToWhite.AutoReverse = true;
            blackToWhite.RepeatBehavior = RepeatBehavior.Forever;

            // Create a new brush and apply the color animation.
            SolidColorBrush scb = new SolidColorBrush(Colors.Black);
            scb.BeginAnimation(SolidColorBrush.ColorProperty, blackToWhite);

            // Create a new TextEffect object; set foreground brush to the previously created brush.
            TextEffect tfe = new TextEffect();
            tfe.Foreground = scb;
            // Range of text to apply (all).
            tfe.PositionStart = 0;
            tfe.PositionCount = int.MaxValue;

            // Add this text effect to the FlowDocument's effects colleciton.
            fd.TextEffects = new TextEffectCollection();
            fd.TextEffects.Add(tfe);

            fd.Blocks.Add(new Paragraph(new Run("Blah blah animate me")));

            Run runx = new Run("Blah blah animate me");
            runx.TextEffects = new TextEffectCollection();
            runx.TextEffects.Add(tfe);
            fd.Blocks.Add(new Paragraph(runx));
        }

        void Hyphenate()
        {
            // <Snippet_FlowDocumentHyphenate>
            FlowDocument flowDoc = new FlowDocument(new Paragraph(new Run("A bit of text content...")));

            // Enable automatic hyphenation.
            flowDoc.IsHyphenationEnabled = true;
            // Enable optimal paragraph layout.
            flowDoc.IsOptimalParagraphEnabled = true;
            // </Snippet_FlowDocumentHyphenate>
        }

        void FDRProps()
        {
            // <Snippet_FlowDocumentReader>
            FlowDocumentReader flowDocRdr = new FlowDocumentReader();

            // Enable find...
            flowDocRdr.IsFindEnabled = true;
            // Enable printing...
            flowDocRdr.IsPrintEnabled = true;
            // Set zoom between 50% and 1000%.
            flowDocRdr.MinZoom = 50;
            flowDocRdr.MaxZoom = 1000;
            // Set the zoom increment to 5%.
            flowDocRdr.ZoomIncrement = 5;
            // Set the initial zoom to 120%.
            flowDocRdr.Zoom = 120;

            FlowDocument flowDoc = new FlowDocument(new Paragraph(new Run("Flow content...")));
            flowDocRdr.Document = flowDoc;
            // </Snippet_FlowDocumentReader>
        }

        void FDPVProps()
        {
            // <Snippet_FlowDocumentPageViewer>
            FlowDocumentPageViewer flowDocPageViewer = new FlowDocumentPageViewer();

            // Set zoom between 50% and 1000%.
            flowDocPageViewer.MinZoom = 50;
            flowDocPageViewer.MaxZoom = 1000;
            // Set the zoom increment to 5%.
            flowDocPageViewer.ZoomIncrement = 5;
            // Set the initial zoom to 120%.
            flowDocPageViewer.Zoom = 120;

            FlowDocument flowDoc = new FlowDocument(new Paragraph(new Run("Flow content...")));
            flowDocPageViewer.Document = flowDoc;
            // </Snippet_FlowDocumentPageViewer>
        }

        void FDSVProps()
        {
            // <Snippet_FlowDocumentScrollViewer>
            FlowDocumentScrollViewer flowDocScrollViewer = new FlowDocumentScrollViewer();

            // Enable content selection.
            flowDocScrollViewer.IsSelectionEnabled = true;
            // Enable the toolbar.
            flowDocScrollViewer.IsToolBarVisible = true;

            // Set zoom between 50% and 1000%.
            flowDocScrollViewer.MinZoom = 50;
            flowDocScrollViewer.MaxZoom = 1000;
            // Set the zoom increment to 5%.
            flowDocScrollViewer.ZoomIncrement = 5;
            // Set the initial zoom to 120%.
            flowDocScrollViewer.Zoom = 120;

            FlowDocument flowDoc = new FlowDocument(new Paragraph(new Run("Flow content...")));
            flowDocScrollViewer.Document = flowDoc;
            // </Snippet_FlowDocumentScrollViewer>
        }

        // <Snippet_FlowDocRdr_Load>
        void LoadFlowDocumentReaderWithXAMLFile(string fileName)
        {
            // Open the file that contains the FlowDocument...
            FileStream xamlFile = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            // and parse the file with the XamlReader.Load method.
            FlowDocument content = XamlReader.Load(xamlFile) as FlowDocument;
            // Finally, set the Document property to the FlowDocument object that was
            // parsed from the input file.
            flowDocRdr.Document = content;

            xamlFile.Close();
        }
        // </Snippet_FlowDocRdr_Load>

        // <Snippet_FlowDocPageViewer_Load>
        void LoadFlowDocumentPageViewerWithXAMLFile(string fileName)
        {
            // Open the file that contains the FlowDocument...
            FileStream xamlFile = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            // and parse the file with the XamlReader.Load method.
            FlowDocument content = XamlReader.Load(xamlFile) as FlowDocument;
            // Finally, set the Document property to the FlowDocument object that was
            // parsed from the input file.
            flowDocPageViewer.Document = content;

            xamlFile.Close();
        }
        // </Snippet_FlowDocPageViewer_Load>

        // <Snippet_FlowDocScrollViewer_Load>
        void LoadFlowDocumentScrollViewerWithXAMLFile(string fileName)
        {
            // Open the file that contains the FlowDocument...
            FileStream xamlFile = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            // and parse the file with the XamlReader.Load method.
            FlowDocument content = XamlReader.Load(xamlFile) as FlowDocument;
            // Finally, set the Document property to the FlowDocument object that was
            // parsed from the input file.
            flowDocScrollViewer.Document = content;

            xamlFile.Close();
        }
        // </Snippet_FlowDocScrollViewer_Load>

        // <Snippet_FlowDocRdr_Save>
        void SaveFlowDocumentReaderWithXAMLFile(string fileName)
        {
            // Open or create the output file.
            FileStream xamlFile = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite);
            // Save the contents of the FlowDocumentReader to the file stream that was just opened.
            XamlWriter.Save(flowDocRdr.Document, xamlFile);

            xamlFile.Close();
        }
        // </Snippet_FlowDocRdr_Save>

        // <Snippet_FlowDocPageViewer_Save>
        void SaveFlowDocumentPageViewerWithXAMLFile(string fileName)
        {
            // Open or create the output file.
            FileStream xamlFile = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite);
            // Save the contents of the FlowDocumentReader to the file stream that was just opened.
            XamlWriter.Save(flowDocPageViewer.Document, xamlFile);

            xamlFile.Close();
        }
        // </Snippet_FlowDocPageViewer_Save>

        // <Snippet_FlowDocScrollViewer_Save>
        void SaveFlowDocumentScrollViewerWithXAMLFile(string fileName)
        {
            // Open or create the output file.
            FileStream xamlFile = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite);
            // Save the contents of the FlowDocumentReader to the file stream that was just opened.
            XamlWriter.Save(flowDocScrollViewer.Document, xamlFile);

            xamlFile.Close();
        }
        // </Snippet_FlowDocScrollViewer_Save>

        void TextBlockProps()
        {
            // <Snippet_TextBlockProps>
            TextBlock textBlock = new TextBlock(new Run("A bit of text content..."));

            textBlock.Background              = Brushes.AntiqueWhite;
            textBlock.Foreground              = Brushes.Navy;

            textBlock.FontFamily              = new FontFamily("Century Gothic");
            textBlock.FontSize                = 12;
            textBlock.FontStretch             = FontStretches.UltraExpanded;
            textBlock.FontStyle               = FontStyles.Italic;
            textBlock.FontWeight              = FontWeights.UltraBold;

            textBlock.LineHeight              = Double.NaN;
            textBlock.Padding                 = new Thickness(5, 10, 5, 10);
            textBlock.TextAlignment           = TextAlignment.Center;
            textBlock.TextWrapping            = TextWrapping.Wrap;

            textBlock.Typography.NumeralStyle = FontNumeralStyle.OldStyle;
            textBlock.Typography.SlashedZero  = true;
            // </Snippet_TextBlockProps>
        }

        void TextBlockBase()
        {
            {
                // <Snippet_TextBlockSimple>
                TextBlock textBlock1 = new TextBlock();
                TextBlock textBlock2 = new TextBlock();

                textBlock1.TextWrapping = textBlock2.TextWrapping = TextWrapping.Wrap;
                textBlock2.Background = Brushes.AntiqueWhite;
                textBlock2.TextAlignment = TextAlignment.Center;

                textBlock1.Inlines.Add(new Bold(new Run("TextBlock")));
                textBlock1.Inlines.Add(new Run(" is designed to be "));
                textBlock1.Inlines.Add(new Italic(new Run("lightweight")));
                textBlock1.Inlines.Add(new Run(", and is geared specifically at integrating "));
                textBlock1.Inlines.Add(new Italic(new Run("small")));
                textBlock1.Inlines.Add(new Run(" portions of flow content into a UI."));

                textBlock2.Text =
                    "By default, a TextBlock provides no UI beyond simply displaying its contents.";
                // </Snippet_TextBlockSimple>
            }
        }
    }
}