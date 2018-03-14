using System.IO;
using System.Windows;
using System.Windows.Xps.Packaging;

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