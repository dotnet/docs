using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace DragDropSnippets
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // <snippetRtbHandlers>
        public MainWindow()
        {
            InitializeComponent();

            // Add using System.Windows.Controls;
            richTextBox1.AddHandler(RichTextBox.DragOverEvent, new DragEventHandler(RichTextBox_DragOver), true);
            richTextBox1.AddHandler(RichTextBox.DropEvent, new DragEventHandler(RichTextBox_Drop), true);
        }

        private void RichTextBox_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effects = DragDropEffects.All;
            }
            else
            {
                e.Effects = DragDropEffects.None;
            }
            e.Handled = false;
        }

        private void RichTextBox_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] docPath = (string[])e.Data.GetData(DataFormats.FileDrop);

                // By default, open as Rich Text (RTF).
                var dataFormat = DataFormats.Rtf;

                // If the Shift key is pressed, open as plain text.
                if (e.KeyStates == DragDropKeyStates.ShiftKey)
                {
                    dataFormat = DataFormats.Text;
                }

                System.Windows.Documents.TextRange range;
                System.IO.FileStream fStream;
                if (System.IO.File.Exists(docPath[0]))
                {
                    try
                    {
                        // Open the document in the RichTextBox.
                        range = new System.Windows.Documents.TextRange(richTextBox1.Document.ContentStart, richTextBox1.Document.ContentEnd);
                        fStream = new System.IO.FileStream(docPath[0], System.IO.FileMode.OpenOrCreate);
                        range.Load(fStream, dataFormat);
                        fStream.Close();
                    }
                    catch (System.Exception)
                    {
                        MessageBox.Show("File could not be opened. Make sure the file is a text file.");
                    }
                }
            }
        }
        // </snippetRtbHandlers>

        #region DragSource
        // <snippetDoDragDrop>
        private void ellipse_MouseMove(object sender, MouseEventArgs e)
        {
            Ellipse ellipse = sender as Ellipse;
            if (ellipse != null && e.LeftButton == MouseButtonState.Pressed)
            {
                DragDrop.DoDragDrop( ellipse,
                                     ellipse.Fill.ToString(),
                                     DragDropEffects.Copy);
            }
        }
        // </snippetDoDragDrop>

        // <snippetGiveFeedback>
        // Declare the custom cursor outside of the GiveFeedback handler. GiveFeedback is
        // called continuously during the drag, so it is inefficient to create a new cursor
        // each time it is called.
        private Cursor _customCopyCursor = null;
        private void ellipse_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            try
            {
                // For a move, use a pre-defined cursor from the Cursors class.
                if (e.Effects.HasFlag(DragDropEffects.Move))
                {
                    Mouse.SetCursor(Cursors.ArrowCD);
                }
                // For a copy, use a custom cursor loaded from a stream. This cursor must be
                // a project resource.
                else if (e.Effects.HasFlag(DragDropEffects.Copy))
                {
                    // Only load the custom cursor if it hasn't been loaded yet.
                    if (_customCopyCursor == null)
                    {
                        Uri uri = new Uri("CustomCopyCursor.cur", UriKind.Relative);
                        _customCopyCursor = new Cursor(App.GetResourceStream(uri).Stream);
                    }
                    Mouse.SetCursor(_customCopyCursor);
                }
            }
            catch (System.Exception)
            {
                // If there was a problem setting a custom cursor, use the default cursors.
                e.UseDefaultCursors = true;
            }
            e.Handled = true;
        }
        // </snippetGiveFeedback>
        #endregion

        #region DropTarget

        // <snippetDragEnterLeave>
        // <snippetDragEnter>
        private Brush _previousFill = null;
        private void ellipse_DragEnter(object sender, DragEventArgs e)
        {
            Ellipse ellipse = sender as Ellipse;
            if (ellipse != null)
            {
                // Save the current Fill brush so that you can revert back to this value in DragLeave.
                _previousFill = ellipse.Fill;

                // If the DataObject contains string data, extract it.
                if (e.Data.GetDataPresent(DataFormats.StringFormat))
                {
                    string dataString = (string)e.Data.GetData(DataFormats.StringFormat);

                    // If the string can be converted into a Brush, convert it.
                    BrushConverter converter = new BrushConverter();
                    if (converter.IsValid(dataString))
                    {
                        Brush newFill = (Brush)converter.ConvertFromString(dataString);
                        ellipse.Fill = newFill;
                    }
                }
            }
        }
        // </snippetDragEnter>

        // <snippetDragLeave>
        private void ellipse_DragLeave(object sender, DragEventArgs e)
        {
            Ellipse ellipse = sender as Ellipse;
            if (ellipse != null)
            {
                ellipse.Fill = _previousFill;
            }
        }
        // </snippetDragLeave>
        // </snippetDragEnterLeave>

        // <snippetDragOver>
        private void ellipse_DragOver(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.None;

            // If the DataObject contains string data, extract it.
            if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                string dataString = (string)e.Data.GetData(DataFormats.StringFormat);

                // If the string can be converted into a Brush, allow copying.
                BrushConverter converter = new BrushConverter();
                if (converter.IsValid(dataString))
                {
                    e.Effects = DragDropEffects.Copy | DragDropEffects.Move;
                }
            }
        }
        // </snippetDragOver>

        // <snippetDrop>
        private void ellipse_Drop(object sender, DragEventArgs e)
        {
            Ellipse ellipse = sender as Ellipse;
            if (ellipse != null)
            {
                // If the DataObject contains string data, extract it.
                if (e.Data.GetDataPresent(DataFormats.StringFormat))
                {
                    string dataString = (string)e.Data.GetData(DataFormats.StringFormat);

                    // If the string can be converted into a Brush,
                    // convert it and apply it to the ellipse.
                    BrushConverter converter = new BrushConverter();
                    if (converter.IsValid(dataString))
                    {
                        Brush newFill = (Brush)converter.ConvertFromString(dataString);
                        ellipse.Fill = newFill;
                    }
                }
            }
        }
        // </snippetDrop>
        #endregion

    }
}
