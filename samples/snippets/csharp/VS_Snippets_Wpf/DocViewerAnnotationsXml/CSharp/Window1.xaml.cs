// DocViewerAnnotationsXml SDK Sample - Window1.xaml.cs
// Copyright (c) Microsoft Corporation. All rights reserved.

using System;
using System.Net;
using System.IO;
using System.IO.Packaging;
using System.Printing;
using System.Windows;
using System.Windows.Annotations;
using System.Windows.Annotations.Storage;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Xps;
using System.Windows.Xps.Packaging;
using WinForms = System.Windows.Forms;

namespace SDKSample
{
    // ========================= partial class Window1 ========================
    /// <summary>
    /// Interaction logic for Window1.xaml</summary>
    public partial class Window1 : Window
    {
        // ------------------------ Window1 constructor -----------------------
        public Window1()
        {
            InitializeComponent();
        }

        // ------------------------------ OnOpen ------------------------------
        /// <summary>
        ///   Handles the user "File | Open" menu operation.</summary>
        private void OnOpen(object target, ExecutedRoutedEventArgs args)
        {
            // If a document is currently open, check with the user
            // if it's ok to close it before opening a new one.
            if (_xpsPackage != null)
            {
                string msg =
                    "The currently open document needs to be closed before\n" +
                    "opening a new document.  Ok to close the current document?";
                MessageBoxResult result =
                    MessageBox.Show(msg, "Close Current Document?",
                        MessageBoxButton.OKCancel, MessageBoxImage.Question);

                // If the user did not click OK to close current
                // document, cancel the File | Open request.
                if ((result != MessageBoxResult.OK))
                    return;

                // The user clicked OK, close the current document and continue.
                CloseDocument();
            }

            // Create a "File Open" dialog positioned to the
            // "Content\" folder containing the sample fixed document.
            WinForms.OpenFileDialog dialog = new WinForms.OpenFileDialog();
            dialog.InitialDirectory = GetContentFolder();
            dialog.CheckFileExists = true;
            dialog.Filter = "XPS Document files (*.xps)|*.xps";

            // Show the "File Open" dialog.  If the user picks a file and
            // clicks "OK", load and display the specified XPS document.
            if (dialog.ShowDialog() == WinForms.DialogResult.OK)
                OpenDocument(dialog.FileName);
        }// end:OnOpen()

        // --------------------------- OpenDocument ---------------------------
        /// <summary>
        ///   Loads, displays, and enables user annotations
        ///   a given XPS document file.</summary>
        /// <param name="filename">
        ///   The path and filename of the XPS document
        ///   to load, display, and annotate.</param>
        /// <returns>
        ///   true if the document loads successfully; otherwise false.</returns>
        public bool OpenDocument(string filename)
        {
            // Load an XPS document into a DocumentViewer
            // and enable user Annotations.
            _xpsDocumentPath = filename;

            _packageUri = new Uri(filename, UriKind.Absolute);
            try
            {
                _xpsDocument = new XpsDocument(filename, FileAccess.Read);
            }
            catch (System.UnauthorizedAccessException)
            {   // If FileAccess is ReadWrite or Write.
                string msg = filename +
                    "\n\nThe specified file is Read-Only which " +
                    "prevents storing user annotations.";
                MessageBox.Show(msg, "Read-Only file",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            // Get the document's PackageStore into which
            // new user annotations will be added and saved.
            _xpsPackage = PackageStore.GetPackage(_packageUri);
            if ((_xpsPackage == null) || (_xpsDocument == null))
            {
                MessageBox.Show("Unable to get Package from file.");
                return false;
            }

            // Get the FixedDocumentSequence from the open document.
            FixedDocumentSequence fds = _xpsDocument.GetFixedDocumentSequence();
            if (fds == null)
            {
                string msg = filename +
                    "\n\nThe document package within the specified " +
                    "file does not contain a FixedDocumentSequence.";
                MessageBox.Show(msg, "Package Error");
                return false;
            }

            // Load the FixedDocumentSequence to the DocumentViewer control.
            docViewer.Document = fds;

            // Enable document menu controls.
            menuFileClose.IsEnabled = true;
            menuFilePrint.IsEnabled = true;
            menuViewAnnotations.IsEnabled = true;
            menuViewIncreaseZoom.IsEnabled = true;
            menuViewDecreaseZoom.IsEnabled = true;

            // Enable user annotations on the document.
            Uri fixedDocumentSeqUri = GetFixedDocumentSequenceUri();
            if (menuViewAnnotations.IsChecked)
                StartAnnotations();

            // Give the DocumentViewer focus.
            docViewer.Focus();

            return true;
        }// end:OpenDocument()

        // ------------------- GetFixedDocumentSequenceUri --------------------
        /// <summary>
        ///   Returns the part URI of first FixedDocumentSequence
        ///   contained in the package.</summary>
        /// <returns>
        ///   The URI of first FixedDocumentSequence in the package,
        ///   or null if no FixedDocumentSequence is found.</returns>
        private Uri GetFixedDocumentSequenceUri()
        {
            // Iterate through the package parts
            // to find first FixedDocumentSequence.
            foreach (PackagePart part in _xpsPackage.GetParts())
            {
                if (part.ContentType == _fixedDocumentSequenceContentType)
                    return part.Uri;
            }

            // Return null if a FixedDocumentSequence isn't found.
            return null;
        }// end:GetFixedDocumentSequenceUri()

        // ------------------------- GetContentFolder -------------------------
        /// <summary>
        ///   Locates and returns the path to the "Content\" folder
        ///   containing the fixed document for the sample.</summary>
        /// <returns>
        ///   The path to the fixed document "Content\" folder.</returns>
        private string GetContentFolder()
        {
            // Get the path to the current directory and its length.
            string contentDir = Directory.GetCurrentDirectory();
            int dirLength = contentDir.Length;

            // If we're in "...\bin\debug", move up to the root.
            if (contentDir.ToLower().EndsWith(@"\bin\debug"))
                contentDir = contentDir.Remove(dirLength - 10, 10);

            // If we're in "...\bin\release", move up to the root.
            else if (contentDir.ToLower().EndsWith(@"\bin\release"))
                contentDir = contentDir.Remove(dirLength - 12, 12);

            // If there's a "Content" subfolder, that's what we want.
            if (Directory.Exists(contentDir + @"\Content"))
                contentDir = contentDir + @"\Content";

            // Return the "Content\" folder (or the "current"
            // directory if we're executing somewhere else).
            return contentDir;
        }// end:GetContentFolder()

        // --------------------------- GetPackage -----------------------------
        /// <summary>
        ///   Returns the XPS package contained within a given file.</summary>
        /// <param name="filename">
        ///   The path and name of the file containing the package.</param>
        /// <returns>
        ///   The package contained within the specifed file.</returns>
        private Package GetPackage(string filename)
        {
            Package inputPackage = null;

            // "filename" should be the full path and name of the file.
            WebRequest webRequest = System.Net.WebRequest.Create(filename);
            if (webRequest != null)
            {
                WebResponse webResponse = webRequest.GetResponse();
                if (webResponse != null)
                {
                    Stream inputPackageStream = webResponse.GetResponseStream();
                    if (inputPackageStream != null)
                    {
                        // Retrieve the Package from that stream.
                        inputPackage = Package.Open(inputPackageStream);
                    }
                }
            }

            return inputPackage;
        }// end:GetPackage()

        //<SnippetDocViewXmlStartStopAnnotat>
        //<SnippetDocViewXmlStartAnnotations>
        // ------------------------ StartAnnotations --------------------------
        /// <summary>
        ///   Enables annotations and displays all that are viewable.</summary>
        private void StartAnnotations()
        {
            // If there is no AnnotationService yet, create one.
            if (_annotService == null)
                // docViewer is a document viewing control named in Window1.xaml.
                _annotService = new AnnotationService(docViewer);

            // If the AnnotationService is currently enabled, disable it.
            if (_annotService.IsEnabled == true)
                _annotService.Disable();

            // Open a stream to the file for storing annotations.
            _annotStream = new FileStream(
                _annotStorePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);

            // Create an AnnotationStore using the file stream.
            _annotStore = new XmlStreamStore(_annotStream);

            // Enable the AnnotationService using the new store.
            _annotService.Enable(_annotStore);
        }// end:StartAnnotations()
        //</SnippetDocViewXmlStartAnnotations>

        //<SnippetDocViewXmlStopAnnotations>
        // ------------------------ StopAnnotations ---------------------------
        /// <summary>
        ///   Disables annotation processing and hides all annotations.</summary>
        private void StopAnnotations()
        {
            // If the AnnotationStore is active, flush and close it.
            if (_annotStore != null)
            {
                _annotStore.Flush();
                _annotStream.Flush();
                _annotStream.Close();
                _annotStore = null;
            }

            // If the AnnotationService is active, shut it down.
            if (_annotService != null)
            {
                if (_annotService.IsEnabled)
                {
                    _annotService.Disable();  // Disable the AnnotationService.
                    _annotService = null;
                }
            }
        }// end:StopAnnotations()
        //</SnippetDocViewXmlStopAnnotations>
        //</SnippetDocViewXmlStartStopAnnotat>

        // ------------------------------ OnExit ------------------------------
        /// <summary>
        ///   Handles the user File|Exit menu selection to
        ///   shutdown and exit the application.</summary>
        private void OnExit(object sender, EventArgs e)
        {
            Close();        // invokes OnClosed()
        }// end:OnExit()

        // ----------------------------- OnClosed -----------------------------
        /// <summary>
        ///   Performs clean up when the application is closed.</summary>
        private void OnClosed(object sender, EventArgs e)
        {
            CloseDocument();
        }// end:OnClosed()

        // ----------------------------- OnClose ------------------------------
        /// <summary>
        ///   Handles the user "File | Close" menu operation
        ///   to close the currently open document.</summary>
        private void OnClose(object target, ExecutedRoutedEventArgs args)
        {
            CloseDocument();
        }// end:OnClose()

        // --------------------------- CloseDocument --------------------------
        /// <summary>
        ///   Closes the document currently displayed in
        ///   the DocumentViewer control.</summary>
        public void CloseDocument()
        {
            // Stop and close annotations.
            StopAnnotations();

            // Remove the document from the DocumentViewer control.
            docViewer.Document = null;

            // If the package is open, close it.
            if (_xpsPackage != null)
            {
                _xpsPackage.Close();
                _xpsPackage = null;
            }

            if (_packageUri != null)
                PackageStore.RemovePackage(_packageUri);

            // Disable document-related selections when there's no document.
            menuFileClose.IsEnabled = false;
            menuFilePrint.IsEnabled = false;
            menuViewAnnotations.IsEnabled = false;
            menuViewIncreaseZoom.IsEnabled = false;
            menuViewDecreaseZoom.IsEnabled = false;
        }// end:CloseDocument

        // ----------------------------- OnPrint ------------------------------
        /// <summary>
        ///   Handles the user "File | Print" menu operation.</summary>
        private void OnPrint(object target, ExecutedRoutedEventArgs args)
        {
            PrintDocument();
        }// end:OnClose()

        // -------------------------- PrintDocument ---------------------------
        /// <summary>
        ///   Prints the DocumentViewer's content and annotations.</summary>
        /// <remarks>
        public void PrintDocument()
        {
            if (docViewer == null)
                return; // DocumentViewer has not been initialized yet.

            // If Annotations are disabled, use normal DocuementViewer.Print()
            if (menuViewAnnotations.IsChecked == false)
            {
                docViewer.Print();
            }

            // If Annotations are enabled, print showing the annotations.
            else // if (menuViewAnnotations.IsChecked && (_annotHelper != null))
            {
                PrintDialog prntDialog = new PrintDialog();
                if ((bool)prntDialog.ShowDialog())
                {
                    // XpsDocumentWriter.Write() may change the current
                    // directory to "My Documents" or another user selected
                    // directory for storing the print document.  Save the
                    // current directory and restore it after calling xdw.Write().
                    string docDir = Directory.GetCurrentDirectory();

                    // Create and XpsDocumentWriter for the selected printer.
                    XpsDocumentWriter xdw = PrintQueue.CreateXpsDocumentWriter(
                                                        prntDialog.PrintQueue);

                    // Print the document with annotations.
                    try
                    {
                        xdw.Write(  GetAnnotationDocumentPaginator(
                            _xpsDocument.GetFixedDocumentSequence() )  );
                    }
                    catch (PrintingCanceledException)
                    {
                        // If in the PrintDialog the user chooses a file-based
                        // output, such as the "MS Office Document Image Writer",
                        // the user confirms or specifies the actual output
                        // filename when the xdw.write operation executes.
                        // If the user clicks "Cancel" in the filename
                        // dialog a PrintingCanceledException is thrown
                        // which we catch here and ignore.
                        // MessageBox.Show("Print output cancelled");
                    }

                    // Restore the original document directory to "current".
                    Directory.SetCurrentDirectory(docDir);
                }
            }
        }// end:PrintDocument()

        // -------------------------- ShowAnnotations -------------------------
        /// <summary>
        ///   Enables and displays user annotations.</summary>
        private void ShowAnnotations(object sender, EventArgs e)
        {
            if (menuViewAnnotations.IsEnabled && menuViewAnnotations.IsChecked)
                StartAnnotations();
        }

        // ------------------------- HideAnnotations --------------------------
        /// <summary>
        ///   Disables and hides user annotations.</summary>
        private void HideAnnotations(object sender, EventArgs e)
        {
            StopAnnotations();
        }

        // ------------------ GetAnnotationDocumentPaginator ------------------
        /// <summary>
        ///   Returns a paginator for printing annotations.</summary>
        /// <param name="fds">
        ///   The FixedDocumentSequence containing
        ///   the annotations to print.</param>
        /// <returns>
        ///   An paginator for printing the document's annotations.</returns>
        public AnnotationDocumentPaginator GetAnnotationDocumentPaginator(
                                                    FixedDocumentSequence fds)
        {
            return new AnnotationDocumentPaginator(
                                            fds.DocumentPaginator, _annotStore);
        }

        #region private fields

        private string _xpsDocumentPath;    // XPS document path and filename.
        private Uri _packageUri;            // XPS document path and filename URI.
        private Package _xpsPackage = null; // XPS document package.
        private XpsDocument _xpsDocument;   // XPS document within the package.
        private AnnotationService _annotService = null;
        private FileStream _annotStream = null;
        private XmlStreamStore _annotStore = null;
        private readonly string _annotStorePath = @"annotations.xml";
        private string _xpsFile = string.Empty;

        private readonly string _fixedDocumentSequenceContentType =
            "application/vnd.ms-package.xps-fixeddocumentsequence+xml";

        #endregion //private fields

    }// end:partial class Window1
}// end:namespace SDKSample
