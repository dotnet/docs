using System;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Input;
using System.Windows.Xps.Packaging;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using System.IO;
using System.Collections.Generic;


namespace SDKSample
{
    // ----------------------------- Class Window1 ----------------------------
    /// <summary>
    ///   Demonstrates the use of the XPS Packaging APIs.</summary>
    /// <remarks>
    ///   <rem>File|New - demonstrates how to create an XPS document
    ///     from scratch.</rem>
    ///   <rem>File|Open - Demonstrates opening an XPS document
    ///     with a DocumentViewer.</rem>
    ///   <rem>File|Outline - Demonstrates interating through the parts of
    ///     of an XpsDocument.</rem>
    ///   <rem>File|Properties - Demonstrates viewing and editing the
    ///     properties of an XpsDocument.</rem>
    ///   <rem>File|Sign - Demonstrates viewing XPS document digital signature
    ///     definitions and how to digitally sign an XpsDocument.</rem>
    /// </remarks>
    public partial class Window1 : Window
    {
        #region Constructors
        public Window1()
            : base()
        {

            InitializeComponent();

            //
            //This utility has helper methods that demonstrate creating the XpsDocument
            //and iterating its parts
            //
            _xpsReadWriteUtility = new XpsReadWriteUtility(Directory.GetCurrentDirectory());

            //
            //The following commands are manually created and bound to menu items
            //New, Open and Properties are predefined command types
            //

            //Create Sign Command
            SignCommand = new RoutedCommand("Sign",typeof(Window1));
            SigMenuItem.Command = SignCommand;

            //Create Outline Command
            OutlineCommand = new RoutedCommand("Outline", typeof(Window1));
            OutlineMenuItem.Command = OutlineCommand;

            //Create Outline Command
            ThumbnailCommand = new RoutedCommand("Thumbnail", typeof(Window1));
            ThumbnailItem.Command = ThumbnailCommand;

            // Add the New Command
            AddCommandBindings(ApplicationCommands.New, NewCommandHandler);
            // Add the Open Command
            AddCommandBindings(ApplicationCommands.Open, OpenCommandHandler);
            // Add the Outline Command
            AddCommandBindings(OutlineCommand, OutlineCommandHandler);
            // Add the Properties Command
            AddCommandBindings(ApplicationCommands.Properties, ProportiesCommandHandler);
            // Add the Signatures Command
            AddCommandBindings(SignCommand, SignatureCommandHandler);
            // Add the Thumbnail Command
            AddCommandBindings(ThumbnailCommand, ThumbnailCommandHandler);
            // Add the Close Command
            AddCommandBindings(ApplicationCommands.Close, CloseCommandHandler);


        }
        #endregion

        #region Private Methods
        // ----------------------- OpenCommandHandler -------------------------
        /// <summary>
        ///   Opens an existing XPS document and displays
        ///   it with a DocumentViewer./// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenCommandHandler(
            object sender, ExecutedRoutedEventArgs e)
        {
            //Display a file open dialog to find and existing document
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Xps Documents (*.xps)|*.xps";
            dlg.FilterIndex = 1;
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (_xpsDocument != null)
                {
                    _xpsDocument.Close();
                }
                try
                {
                    _xpsDocument = new
                        XpsDocument(dlg.FileName, System.IO.FileAccess.ReadWrite);
                }
                catch (UnauthorizedAccessException)
                {
                    System.Windows.MessageBox.Show(
                        String.Format("Unable to access {0}", dlg.FileName ) );
                    return;
                }
                // For optimal performance the XPS document should be remain
                // open while its FixedDocumentSequence is active in the
                // DocumentViewer control.  When the XPS document is opened
                // with the XpsDocument constructor ("new" above) a reference
                // to it is automatically added to the PackageStore.  The
                // PackStore is a static application collection that contains a
                // reference to each open package along the package's URI as a
                // key.  Adding a reference of the XPS package to the
                // PackageStore keeps the package open and avoids repeated opens
                // and closes while the document content is actively being
                // processed by the DocumentViewer control.  The XpsDocument
                // Dispose() method automatically removes the package from the
                // PackageStore after the document is removed from the
                // DocumentViewer control and is no longer in use.
                docViewer.Document = _xpsDocument.GetFixedDocumentSequence();
                _fileName = dlg.FileName;
             }
            EnableMenuItems();
        }// end:OpenCommandHandler()


        // ----------------------- OutlineCommandHandler ----------------------
        /// <summary>
        ///   Iterates through the parts of an XpsDocument initializing
        ///   a tree view control with the names of its parts.</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OutlineCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            if (_xpsDocument != null)
            {
                _xpsReadWriteUtility.IterateXpsPackageParts(
                    _xpsDocument, treeView, _fileName);
            }
        }// end:OutlineCommandHandler()


        // ---------------------- SignatureCommandHandler ---------------------
        /// <summary>
        ///   Displays a dialog showing the current digital signatures and
        ///   signature definitions.  A button on the dialog allows additional
        ///   signatures to be added.</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SignatureCommandHandler(
            object sender, ExecutedRoutedEventArgs e)
        {
            if (_fileName != null)
            {
                SignatureDialog signatureDialog =
                    new SignatureDialog(_xpsDocument);
                signatureDialog.ShowDialog();

                // Close to flush the new signature definition, then reopen.
                _xpsDocument.Close();
                _xpsDocument = new XpsDocument(_fileName, FileAccess.ReadWrite);
            }
        }// end:SignatureCommandHandler()

        // ---------------------- ThumbnailCommandHandler ---------------------
        /// <summary>
        ///   Displays a dialog showing the current thumbnail.  A button on the dialog creates a
        ///   thumbnail add adds it.</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThumbnailCommandHandler(
            object sender, ExecutedRoutedEventArgs e)
        {
            if (_fileName != null)
            {
                ThumnailDialog thumnailDialog =
                    new ThumnailDialog(_xpsDocument);
                thumnailDialog.ShowDialog();

                // Close and re-open the document in case a new thumbnail was added.
                _xpsDocument.Close();
                _xpsDocument = new XpsDocument(_fileName, FileAccess.ReadWrite);
            }
        }// end:ThumbnailCommandHandler()

        // ------------------------- NewCommandHandler ------------------------
        /// <summary>
        ///   Prompts the user for a new XPS document file name, creates the
        ///   new document, fills the document with a preset block of content,
        ///   and then sets the new document as the current document.</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            // Prompt the user for new file to be saved
            SaveFileDialog saveDlg = new SaveFileDialog();
            saveDlg.Title = "New Xps Document";
            saveDlg.Filter = "Xps Documents (*.xps)|*.xps";
            saveDlg.FilterIndex = 1;
            saveDlg.DefaultExt = "*.xps";
            if (saveDlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (_xpsDocument != null)
                {
                    _xpsDocument.Close();
                }
                try
                {
                    // Open a "Save As" dialog to query the user
                    // for where to create the new XPS document.
                    if (File.Exists(saveDlg.FileName))
                    {   // Delete the file if it already exists.
                        File.Delete(saveDlg.FileName);
                    }
                    _xpsDocument =
                        new XpsDocument(
                            saveDlg.FileName, System.IO.FileAccess.ReadWrite);
                }
                catch(UnauthorizedAccessException)
                {
                    System.Windows.MessageBox.Show(String.Format(
                        "Unable to access {0}", saveDlg.FileName));
                    return;
                }

                // Fill the newly created document.
                _xpsReadWriteUtility.Create(_xpsDocument);

                // Close it to flush the values.
                _xpsDocument.Close();

                // Re-open the document and set as the current document.
                _xpsDocument = new
                    XpsDocument(saveDlg.FileName, System.IO.FileAccess.ReadWrite);
                docViewer.Document = _xpsDocument.GetFixedDocumentSequence();
                 _fileName = saveDlg.FileName;
            }// end:if (saveDlg.ShowDialog() == DialogResult.OK)

            EnableMenuItems();
        }// end:NewCommandHandler()


        // ---------------------- ProportiesCommandHandler --------------------
        /// <summary>
        ///   File|Properties handler - Opens a dialog to display the
        ///   document properties and allows them to be edited.</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProportiesCommandHandler(
            object sender, ExecutedRoutedEventArgs e)
        {
            PropertiesDialog properties = new PropertiesDialog(_xpsDocument);
            properties.ShowDialog();
        }// end:ProportiesCommandHandler()


        // ------------------------ CloseCommandHandler -----------------------
        /// <summary>
        ///   File|Close handler - Closes current XPS document.</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
            EnableMenuItems();
        }// end:CloseCommandHandler()


        // ------------------------ AddCommandBindings ------------------------
        /// <summary>
        ///     Registers menu commands (helper method).</summary>
        /// <param name="command"></param>
        /// <param name="handler"></param>
        private void AddCommandBindings(ICommand command, ExecutedRoutedEventHandler handler)
        {
            CommandBinding cmdBindings = new CommandBinding(command);
            cmdBindings.Executed += handler;
            CommandBindings.Add(cmdBindings);
        }// end:AddCommandBindings()


        // -------------------------- EnableMenuItems -------------------------
        /// <summary>
        ///   Evaluates and sets the menu state.</summary>
        private void EnableMenuItems()
        {
            if (_fileName != null)
            {
                SigMenuItem.IsEnabled = true;
                PropMenuItem.IsEnabled = true;
                OutlineMenuItem.IsEnabled = true;
                ThumbnailItem.IsEnabled = true;
            }
            else
            {
                SigMenuItem.IsEnabled = false;
                PropMenuItem.IsEnabled = false;
                OutlineMenuItem.IsEnabled = false;
                ThumbnailItem.IsEnabled = false;
            }
        }// end:EnableMenuItems()
        #endregion Private Methods

        #region Private Members
        private XpsDocument             _xpsDocument;
        private XpsReadWriteUtility     _xpsReadWriteUtility;
        private string                  _fileName;
        private static RoutedCommand    OutlineCommand;
        private static RoutedCommand    SignCommand;
        private static RoutedCommand    ThumbnailCommand;
        #endregion  Private Members

    }// end:partial class Window1

}// end:namespace