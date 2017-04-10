using System.IO; // FileAccess
using System.Windows; // Window
using System.Windows.Xps.Packaging; // XpsDocument

namespace SDKSample
{
    public partial class DocumentViewerWindow : System.Windows.Window
    {
        public DocumentViewerWindow()
        {
            InitializeComponent();

            XpsDocument xpsDocument = new XpsDocument("documents/XpsDocument.xps", FileAccess.Read);
            this.documentViewer.Document = xpsDocument.GetFixedDocumentSequence();
        }
    }
}