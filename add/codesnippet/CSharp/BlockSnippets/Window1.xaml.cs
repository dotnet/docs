using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;


namespace BlockSnippets
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

        void WindowLoaded(Object sender, RoutedEventArgs args)
        {
            Borders();
            MarginPadding();
        }

        void Borders()
        {
            // <Snippet_Block_Borders>
            Paragraph par = new Paragraph();

            Run run1 = new Run("Child elements in this Block element (Paragraph) will be surrounded by a blue border.");
            Run run2 = new Run("This border will be one quarter inch thick in all directions.");

            par.Inlines.Add(run1);
            par.Inlines.Add(run2);

            par.BorderBrush = Brushes.Blue;
            ThicknessConverter tc = new ThicknessConverter();
            par.BorderThickness = (Thickness)tc.ConvertFromString("0.25in");
            // </Snippet_Block_Borders>

        }

        void MarginPadding()
        {
            // <Snippet_Block_MarginPadding>
            FlowDocument flowDoc = new FlowDocument();
            Section sec = new Section();

            flowDoc.Background = Brushes.LightSlateGray;
            flowDoc.ColumnWidth = 2000;
            sec.Background = Brushes.DarkMagenta;
            sec.Padding = sec.Margin = new Thickness(0);

            Paragraph defPar1 = new Paragraph(new Run("Default paragraph."));
            Paragraph defPar2 = new Paragraph(new Run("Default paragraph."));
            Paragraph defPar3 = new Paragraph(new Run("Default paragraph."));
            Paragraph defPar4 = new Paragraph(new Run("Default paragraph."));
            defPar1.Background = defPar2.Background = defPar3.Background = defPar4.Background = Brushes.White;

            Paragraph marginPar = new Paragraph(new Run("This paragraph has a magin of 50 pixels set, but no padding."));
            marginPar.Background = Brushes.LightBlue;
            marginPar.Margin = new Thickness(50);
            Paragraph paddingPar = new Paragraph(new Run("This paragraph has padding of 50 pixels set, but no margin."));
            paddingPar.Background = Brushes.LightCoral;
            paddingPar.Padding = new Thickness(50);
            Paragraph marginPaddingPar = new Paragraph(new Run("This paragraph has both padding and margin set to 50 pixels."));
            marginPaddingPar.Background = Brushes.LightGreen;
            marginPaddingPar.Padding = marginPaddingPar.Margin = new Thickness(50);

            sec.Blocks.Add(defPar1);
            sec.Blocks.Add(defPar2);
            sec.Blocks.Add(marginPar);
            sec.Blocks.Add(paddingPar);
            sec.Blocks.Add(marginPaddingPar);
            sec.Blocks.Add(defPar3);
            sec.Blocks.Add(defPar4);
            flowDoc.Blocks.Add(sec);
            // </Snippet_Block_MarginPadding>
        }

        void FlowDir()
        {
            // <Snippet_Block_FlowDirection>
            Paragraph par = new Paragraph(new Run("This paragraph will flow from left to right."));
            par.FlowDirection = FlowDirection.LeftToRight;
            // </Snippet_Block_FlowDirection>
        }

        void LineHeight()
        {
            // <Snippet_Block_LineHeight>
            Paragraph par = new Paragraph();
            par.LineHeight = 48;
            // </Snippet_Block_LineHeight>
        }

        void TextAlign()
        {
            // <Snippet_Block_TextAlignment>
            Paragraph par = new Paragraph();
            par.TextAlignment = TextAlignment.Center;
            // </Snippet_Block_TextAlignment>
        }

        void Hyphenate()
        {
            // <Snippet_Block_Hyphenate>
            Paragraph par = new Paragraph();
            par.IsEnabled = true;
            // </Snippet_Block_Hyphenate>
        }
    }
}