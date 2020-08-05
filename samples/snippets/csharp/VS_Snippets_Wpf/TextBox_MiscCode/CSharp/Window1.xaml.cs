using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;

using System.Collections.Specialized;

namespace TextBox_MiscCode
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

        void WindowLoaded(object sender, RoutedEventArgs args)
        {
            StringCollection lines = GetLinesCollectionFromTextBox(tbGetLines);
        }

        void MoveCursorToStart()
        {
            // <Snippet_CursorToStart>
            tbPositionCursor.Select(0, 0);
            // </Snippet_CursorToStart>
        }

        void MoveCursorToEnd()
        {
            // <Snippet_CursorToEnd>
            tbPositionCursor.Select(tbPositionCursor.Text.Length, 0);
            // </Snippet_CursorToEnd>
        }

        // <Snippet_TextChangedEventHandler>
        // TextChangedEventHandler delegate method.
        private void textChangedEventHandler(object sender, TextChangedEventArgs args)
        {
            // Omitted Code: Insert code that does something whenever
            // the text changes...
        } // end textChangedEventHandler
        // </Snippet_TextChangedEventHandler>

        // <Snippet_SelectText>
        void OnClick(object sender, RoutedEventArgs e)
        {
            String sSelectedText = tbSelectSomeText.SelectedText;
        }
        // </Snippet_SelectText>

        void FocusTextBox()
        {
            // <Snippet_FocusTextBox>
            tbFocusMe.Focus();
            // </Snippet_FocusTextBox>
        }

        void TextBoxSetText()
        {
            // <Snippet_TextBoxSetText>
            tbSettingText.Text = "Initial text contents of the TextBox.";
            // </Snippet_TextBoxSetText>
        }

        // <Snippet_TextBox_GetLines>
        StringCollection GetLinesCollectionFromTextBox(TextBox textBox)
        {
            StringCollection lines = new StringCollection();

            // lineCount may be -1 if TextBox layout info is not up-to-date.
            int lineCount = textBox.LineCount;

            for (int line = 0; line < lineCount; line++)
                // GetLineText takes a zero-based line index.
                lines.Add(textBox.GetLineText(line));

            return lines;
        }
        // </Snippet_TextBox_GetLines>
    }
}