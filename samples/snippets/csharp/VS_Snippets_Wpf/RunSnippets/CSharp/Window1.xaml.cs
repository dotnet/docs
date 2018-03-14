using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace RunSnippets
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

        void TextProp()
        {
            // <Snippet_Run_Text>
            Run textRun = new Run();
            textRun.Text = "The text contents of this text run.";
            // </Snippet_Run_Text>
        }

        void Constructors()
        {
            {
                // <Snippet_Run_Const1>
                Run textRun = new Run("The text contents of this text run.");
                // </Snippet_Run_Const1>
            }

            {
                // <Snippet_Run_Const2>
                // Create a new, empty paragraph to host the text run.
                Paragraph par = new Paragraph();

                // Get a TextPointer for the end of content in the paragraph.
                TextPointer insertionPoint = par.ContentEnd;

                // This line will create a new text run, initialize it with the supplied string,
                // and insert it at the specified insertion point (which happens to be the end of
                // content for the host paragraph).
                Run textRun = new Run("The text contents of this text run.", insertionPoint);
                // </Snippet_Run_Const2>
            }

        }
    }
}