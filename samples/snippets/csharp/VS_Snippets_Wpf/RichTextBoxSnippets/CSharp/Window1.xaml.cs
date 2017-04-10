using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;


namespace RichTextBoxSnippets
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
            // <Snippet_RTB_StringFromCall>            
            string plainText = StringFromRichTextBox(richTB);
            // </Snippet_RTB_StringFromCall>            
        }

        void Constructor()
        {
            // <Snippet_RTB_Constructor>
            // Create a simple FlowDocument to serve as the content input for the construtor.
            FlowDocument flowDoc = new FlowDocument(new Paragraph(new Run("Simple FlowDocument")));
            // After this constructor is called, the new RichTextBox rtb will contain flowDoc.
            RichTextBox rtb = new RichTextBox(flowDoc);
            // </Snippet_RTB_Constructor>
        }

        void ShowSelection()
        {
            // <Snippet_RTB_Selection>
            // Create a simple FlowDocument to serve as the content input for the construtor.
            FlowDocument flowDoc = new FlowDocument(new Paragraph(new Run("Simple FlowDocument")));
            // After this constructor is called, the new RichTextBox rtb will contain flowDoc.
            RichTextBox rtb = new RichTextBox(flowDoc);
            // This call will select the entire contents of the RichTextBox.
            rtb.SelectAll();
            // This call returns the current selection (which happens to be the entire contents
            // of the RichTextBox) as a TextSelection object.
            TextSelection currentSelection = rtb.Selection;
            // </Snippet_RTB_Selection>
        }

        void ShowDocument()
        {
            // <Snippet_RTB_Document>
            // Create a simple FlowDocument to serve as content.
            FlowDocument flowDoc = new FlowDocument(new Paragraph(new Run("Simple FlowDocument")));
            // Create an empty, default RichTextBox.
            RichTextBox rtb = new RichTextBox();
            // This call sets the contents of the RichTextBox to the specified FlowDocument.
            rtb.Document = flowDoc;
            // This call gets a FlowDocument representing the contents of the RichTextBox.
            FlowDocument rtbContents = rtb.Document;
            // </Snippet_RTB_Document>
        }

        void ShowCaretPosition()
        {
            // <Snippet_RTB_CaretPosition>

            // Create a new FlowDocument, and add 3 paragraphs.
            FlowDocument flowDoc = new FlowDocument();
            flowDoc.Blocks.Add(new Paragraph(new Run("Paragraph 1"))); 
            flowDoc.Blocks.Add(new Paragraph(new Run("Paragraph 2"))); 
            flowDoc.Blocks.Add(new Paragraph(new Run("Paragraph 3")));
            // Set the FlowDocument to be the content for a new RichTextBox.
            RichTextBox rtb = new RichTextBox(flowDoc);

            // Get the current caret position.
            TextPointer caretPos = rtb.CaretPosition;

            // Set the TextPointer to the end of the current document.
            caretPos = caretPos.DocumentEnd;

            // Specify the new caret position at the end of the current document.
            rtb.CaretPosition = caretPos;
            // </Snippet_RTB_CaretPosition>            
        }

        // <Snippet_RTB_StringFrom>            
        string StringFromRichTextBox(RichTextBox rtb)
        {
            TextRange textRange = new TextRange(
                // TextPointer to the start of content in the RichTextBox.
                rtb.Document.ContentStart, 
                // TextPointer to the end of content in the RichTextBox.
                rtb.Document.ContentEnd
            );

            // The Text property on a TextRange object returns a string
            // representing the plain text content of the TextRange.
            return textRange.Text;
        }
        // </Snippet_RTB_StringFrom>  

        // <Snippet_TextBox_MouseUpDownHandlers>
        void MouseUpHandler(Object sender, RoutedEventArgs args)
        {
            // This method is called whenever the PreviewMouseUp event fires.
        }
        
        void MouseDownHandler(Object sender, RoutedEventArgs args)
        {
            // This method is called whenever the PreviewMouseDown event fires.
        }
        // </Snippet_TextBox_MouseUpDownHandlers>

        void AttacheHandlers()
        {
            // <Snippet_TextBox_MouseUpDown>
            TextBox textBox = new TextBox();
            textBox.PreviewMouseUp += MouseUpHandler;
            textBox.PreviewMouseDown += MouseDownHandler;
            // Note: Event listeners can also be added using the AddHandler
            // method.
            // </Snippet_TextBox_MouseUpDown>

            // <Snippet_RichTextBox_MouseUpDown>
            RichTextBox richTextBox = new RichTextBox();
            richTextBox.PreviewMouseUp += MouseUpHandler;
            richTextBox.PreviewMouseDown += MouseDownHandler;
            // Note: Event listeners can also be added using the AddHandler
            // method.
            // </Snippet_RichTextBox_MouseUpDown>

            // <Snippet_PasswordBox_MouseUpDown>
            PasswordBox pwBox = new PasswordBox();
            pwBox.PreviewMouseUp += MouseUpHandler;
            pwBox.PreviewMouseDown += MouseDownHandler;
            // </Snippet_PasswordBox_MouseUpDown>
        }

        void InvokeEditingCommands()
        {
            // <Snippet_EditingCommands_Invoke>
            RichTextBox rTB = new RichTextBox();

            EditingCommands.ToggleInsert.Execute(null, rTB);
            // </Snippet_EditingCommands_Invoke>
        }
    }
}
