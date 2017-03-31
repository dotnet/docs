//<SnippetFlowDocumentReaderCODEBEHIND>
using System.Windows; // Window
using System.Windows.Documents; // FlowDocument
using System.IO; // FileStream, FileMode
using System.Windows.Markup; // XamlReader

namespace SDKSample
{
    public partial class FlowDocumentReaderWindow : System.Windows.Window
    {
        public FlowDocumentReaderWindow()
        {
            InitializeComponent();

            // Open the file that contains the FlowDocument
            using (FileStream xamlFile = new FileStream("AFlowDocument.xaml", 
                FileMode.Open, FileAccess.Read))
            {
                // Parse the file with the XamlReader.Load method
                FlowDocument content = XamlReader.Load(xamlFile) as FlowDocument;

                // Set the Document property to the parsed FlowDocument object
                this.flowDocumentReader.Document = content;
            }
        }
    }
}
//</SnippetFlowDocumentReaderCODEBEHIND>