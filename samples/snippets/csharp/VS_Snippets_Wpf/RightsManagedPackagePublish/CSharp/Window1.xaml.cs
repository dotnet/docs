// RightsManagedPackagePublish Sample - Window1.xaml.cs
// Copyright (c) Microsoft Corporation. All rights reserved.

using System;
using System.IO;
using System.IO.Packaging;
using System.Net;
using System.Security.RightsManagement;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Xps.Packaging;
using System.Xml;
using WinForms = Microsoft.Win32;


namespace SdkSample
{
    // ========================= partial class Window1 ========================
    /// <summary>
    ///   Interaction logic for Window1.xaml</summary>
    public partial class Window1 : Window
    {
        // ------------------------ Window1 constructor -----------------------
        public Window1() : base()
        {
            InitializeComponent();

            WritePrompt(
                "Click 'File | Open...' to select a file to open and view.");
        }


        #region File|Open...
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
                    "opening a new document.  Ok to close '"+_xpsDocumentName+"'?";
                MessageBoxResult result =
                    MessageBox.Show(msg, "Close Current Document?",
                        MessageBoxButton.OKCancel, MessageBoxImage.Question);

                // If the user did not click OK to close current
                // document, cancel the File | Open request.
                if ((result != MessageBoxResult.OK))
                    return;

                // The user clicked OK, close the current document and continue.
                CloseDocument();
                CloseXrML();
            }

            // Create a "File Open" dialog positioned to the
            // "Content\" folder containing the sample fixed document.
            WinForms.OpenFileDialog dialog = new WinForms.OpenFileDialog();
            dialog.InitialDirectory = GetContentFolder();
            dialog.CheckFileExists = true;
            dialog.Filter = "XPS Document files (*.xps)|*.xps";

            // Show the "File Open" dialog.  If the user picks a file and
            // clicks "OK", load and display the specified XPS document.
            if (dialog.ShowDialog() == true)
                OpenDocument(dialog.FileName);

        }// end:OnOpen()


        // --------------------------- OpenDocument ---------------------------
        /// <summary>
        ///   Loads and displays a given XPS document file.</summary>
        /// <param name="filename">
        ///   The path and filename of the XPS document
        ///   to load and display.</param>
        /// <returns>
        ///   true if the document loads successfully; otherwise false.</returns>
        public bool OpenDocument(string filename)
        {
            // Save the document path and filename.
            _xpsDocumentPath = filename;

            // Extract the document filename without the path.
            _xpsDocumentName = filename.Remove(0, filename.LastIndexOf('\\')+1);

            _packageUri = new Uri(filename, UriKind.Absolute);
            try
            {
                _xpsDocument = new XpsDocument(filename, FileAccess.Read);
            }
            catch (System.IO.FileFormatException)
            {
                string msg = filename + "\n\nThe specified file " +
                    "in not a valid unprotected XPS document.\n\n" +
                    "The file is possibly encrypted with rights management.  " +
                    "Please see the RightsManagedPackageViewer\nsample that " +
                    "shows how to access and view a rights managed XPS document.";
                MessageBox.Show(msg, "Invalid File Format",
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
            menuFileClose.IsEnabled  = true;
            menuFilePrint.IsEnabled  = true;
            menuFileRights.IsEnabled = true;
            menuViewIncreaseZoom.IsEnabled = true;
            menuViewDecreaseZoom.IsEnabled = true;

            // Give the DocumentViewer focus.
            docViewer.Focus();

            WriteStatus("Opened '" + _xpsDocumentName + "'");
            WritePrompt("Click 'File | Rights...' to select an " +
                        "eXtensible Rights Markup (XrML) permissions file.");
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
                    {   // Retreive the Package from that stream.
                        inputPackage = Package.Open(inputPackageStream);
                    }
                }
            }

            return inputPackage;
        }// end:GetPackage()


        //<SnippetRmPkgPubGetFixDoc>
        // ------------------------ GetFixedDocument --------------------------
        /// <summary>
        ///   Returns the fixed document at a given URI within
        ///   the currently open XPS package.</summary>
        /// <param name="fixedDocUri">
        ///   The URI of the fixed document to return.</param>
        /// <returns>
        ///   The fixed document at a given URI
        ///   within the current XPS package.</returns>
        private FixedDocument GetFixedDocument(Uri fixedDocUri)
        {
            FixedDocument fixedDocument = null;

            // Create the URI for the fixed document within the package. The URI
            // is used to set the Parser context so fonts & other items can load.
            Uri tempUri = new Uri(_xpsDocumentPath, UriKind.RelativeOrAbsolute);
            ParserContext parserContext = new ParserContext();
            parserContext.BaseUri = PackUriHelper.Create(tempUri);

            // Retreive the fixed document.
            PackagePart fixedDocPart = _xpsPackage.GetPart(fixedDocUri);
            if (fixedDocPart != null)
            {
                object fixedObject =
                    XamlReader.Load(fixedDocPart.GetStream(), parserContext);
                if (fixedObject != null)
                    fixedDocument = fixedObject as FixedDocument;
            }

            return fixedDocument;
        }// end:GetFixedDocument()
        //</SnippetRmPkgPubGetFixDoc>
        #endregion File|Open...


        #region File|Close
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
            menuViewIncreaseZoom.IsEnabled = false;
            menuViewDecreaseZoom.IsEnabled = false;
            WriteStatus("Closed '" + _xpsDocumentName + "'");
            WritePrompt(
                "Click 'File | Open...' to select a file to open and view.");

            // Close the XrML file.
            CloseXrML();

        }// end:CloseDocument
        #endregion File|Close


        #region File|Rights...
        // ----------------------------- OnRights -----------------------------
        /// <summary>
        ///   Handles the user File|Rights... menu option to
        ///   select and load a digital rights .xrml file.</summary>
        private void OnRights(object sender, EventArgs e)
        {
            // If an XrML is currently open, check with the user
            // if it's ok to close it before opening a new one.
            if (_xrmlFilepath != null)
            {
                string msg =
                    "The currently open eXtensible Rights Markup Language (XrML)\n" +
                    "document needs to be closed before opening a new document.\n" +
                    "Ok to close '" + _xrmlFilename + "'?";
                MessageBoxResult result =
                    MessageBox.Show(msg, "Close Current XrML?",
                        MessageBoxButton.OKCancel, MessageBoxImage.Question);

                // If the user did not click OK to close current
                // document, cancel the File | Open request.
                if ((result != MessageBoxResult.OK))
                    return;

                // The user clicked OK, close the current XrML file and continue.
                CloseXrML();
            }

            // Create a "File Open" dialog positioned to the
            // "Content\" folder containing the sample fixed document.
            WinForms.OpenFileDialog dialog = new WinForms.OpenFileDialog();
            dialog.InitialDirectory = GetContentFolder();
            dialog.CheckFileExists = true;
            dialog.Filter = "XrML Rights markup files (*.xrml)|*.xrml";

            // Show the "File Open" dialog.  If the user picks a file and
            // clicks "OK", load and display the specified XPS document.
            if (dialog.ShowDialog() == true)
                OpenXrML(dialog.FileName);

        }// end:OnRights()


        // ----------------------------- OpenXrML -----------------------------
        /// <summary>
        ///   Loads and displays a given XrML rights markup file.</summary>
        /// <param name="filename">
        ///   The path and filename of the XrML rights markup file
        ///   to load and display.</param>
        /// <returns>
        ///   true if the file loads successfully; otherwise false.</returns>
        public bool OpenXrML(string filename)
        {
            // Save the document path and filename.
            _xrmlFilepath = filename;

            // Extract just the XrML filename without the path.
            _xrmlFilename = filename.Remove(0, filename.LastIndexOf('\\') + 1);

            // Load the XrML file to the "rightsBlock" control.
            using (StreamReader sr = new StreamReader(filename))
            {
                _xrmlString = sr.ReadToEnd();
                rightsBlock.Text = _xrmlString;
            }

            // Enable document menu controls.
            menuFilePublish.IsEnabled = true;

            WriteStatus("Opened '" + _xrmlFilename + "'");
            WritePrompt("Click 'File | Publish...' to publish the document " +
                "package with the permissions specified in '"+ _xrmlFilename+ "'.");
            rightsBlockTitle.Text = "Rights - " + _xrmlFilename;
            return true;
        }// end:OpenXrML()


        // ----------------------------- CloseXrML ----------------------------
        /// <summary>
        ///   Closes the document currently displayed in
        ///   the DocumentViewer control.</summary>
        public void CloseXrML()
        {
            // If an Xrml file is open, close it.
            if (_xrmlFilepath != null)
            {   // Remove the document from the "rightsBlock" control.
                _xrmlFilepath = null;
                rightsBlock.Text = "";
                rightsBlockTitle.Text = "Rights";

                // Disable "File | Publish" when there's no XrML file.
                menuFilePublish.IsEnabled = false;
                WriteStatus("Closed '" + _xrmlFilename + "'");
                _xrmlFilename = null;
            }
        }// end:CloseXrML
        #endregion File|Rights...


        #region File|Publish...
        // ---------------------------- OnPublish -----------------------------
        /// <summary>
        ///   Handles the File|Publish... menu selection to
        ///   write a digital rights encrypted document package.</summary>
        private void OnPublish(object sender, EventArgs e)
        {
            // Create a "File Save" dialog positioned to the
            // "Content\" folder to write the encrypted package to.
            WinForms.SaveFileDialog dialog = new WinForms.SaveFileDialog();
            dialog.InitialDirectory = GetContentFolder();
            dialog.Title  = "Publish Rights Managed Package As";
            dialog.Filter = "Rights Managed XPS package (*-RM.xps)|*-RM.xps";

            // Create a new package filename by prefixing
            // the document filename extension with "rm".
            dialog.FileName = _xpsDocumentPath.Insert(
                                  _xpsDocumentPath.LastIndexOf('.'), "-RM" );

            // Show the "Save As" dialog. If the user clicks "Cancel", return.
            if (dialog.ShowDialog() != true)  return;

            // Extract the filename without path.
            _rmxpsPackagePath = dialog.FileName;
            _rmxpsPackageName = _rmxpsPackagePath.Remove(
                                    0, _rmxpsPackagePath.LastIndexOf('\\')+1 );

            WriteStatus("Publishing '" + _rmxpsPackageName + "'.");
            PublishRMPackage(_xpsDocumentPath, _xrmlFilepath, dialog.FileName);

        }// end:OnPublish()


        // ------------------------ PublishRMPackage --------------------------
        /// <summary>
        ///   Writes an encrypted righted managed package.</summary>
        /// <param name="packageFilepath">
        ///   The path and filename of the source document package.</param>
        /// <param name="filename">
        ///   The path and filename of the XrML rights management file.</param>
        /// <param name="encryptedFilepath">
        ///   The path and filename for writing the RM encrypted package.</param>
        /// <returns>
        ///   true if the encrypted package is written successfully;
        ///   otherwise false.</returns>
        public bool PublishRMPackage(
            string packageFile, string xrmlFile, string encryptedFile)
        {
            string xrmlString;

            // Extract individual filenames without the path.
            string packageFilename   = packageFile.Remove( 0,
                                            packageFile.LastIndexOf('\\')+1 );
            string xrmlFilename      = xrmlFile.Remove( 0,
                                            xrmlFile.LastIndexOf('\\')+1 );
            string encryptedFilename = encryptedFile.Remove( 0,
                                            encryptedFile.LastIndexOf('\\')+1 );

            try
            {
                //<SnippetRmPkgPubUnPubLic>
                WriteStatus("   Reading '" + xrmlFilename + "' permissions.");
                try
                {
                    StreamReader sr = File.OpenText(xrmlFile);
                    xrmlString = sr.ReadToEnd();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR: '"+xrmlFilename+"' open failed.\n"+
                        "Exception: " + ex.Message, "XrML File Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }

                WriteStatus("   Building UnsignedPublishLicense");
                WriteStatus("       from '" + xrmlFilename + "'.");
                UnsignedPublishLicense unsignedLicense =
                    new UnsignedPublishLicense(xrmlString);
                ContentUser author = unsignedLicense.Owner;
                //</SnippetRmPkgPubUnPubLic>

                //<SnippetRmPkgBldSecEnv>
                WriteStatus("   Building secure environment.");
                try
                {
                    //<SnippetRmPkgPubSecEnv>
                    string applicationManifest = "<manifest></manifest>";
                    if (File.Exists("rpc.xml"))
                    {
                        StreamReader manifestReader = File.OpenText("rpc.xml");
                        applicationManifest = manifestReader.ReadToEnd();
                    }

                    if (_secureEnv == null)
                    {
                        if (SecureEnvironment.IsUserActivated(new ContentUser(
                                    _currentUserId, AuthenticationType.Windows)))
                        {
                            _secureEnv = SecureEnvironment.Create(
                                applicationManifest, new ContentUser(
                                    _currentUserId, AuthenticationType.Windows));
                        }
                        else
                        {
                            _secureEnv = SecureEnvironment.Create(
                                applicationManifest,
                                AuthenticationType.Windows,
                                UserActivationMode.Permanent);
                        }
                    }
                    //</SnippetRmPkgPubSecEnv>
                }
                catch (RightsManagementException ex)
                {
                    MessageBox.Show("ERROR: Failed to build secure environment.\n" +
                        "Exception: " + ex.Message + "\n\n" +
                        ex.FailureCode.ToString() + "\n\n" + ex.StackTrace,
                        "Rights Management Exception",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                //</SnippetRmPkgBldSecEnv>

                // If using Windows authentication and the Xrml owner name
                // does not match the current log-in name, show error message
                if ((author.AuthenticationType == AuthenticationType.Windows)
                    && (author.Name != _currentUserId))
                {
                    MessageBox.Show("ERROR: The current user name does not " +
                        "match the UnsignedPublishLicense owner.\n" +
                        "Please check the owner <NAME> element contained in '" +
                        xrmlFilename + "'\n\n" +
                        "Current user log-in ID: " + _currentUserId + "\n" +
                        "XrML UnsignedPublishLicense owner name: " + author.Name,
                        "Incorrect Authentication Name",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                   return false;
                }

                //<SnippetRmPkgPubEncrypt>
                WriteStatus("   Signing the UnsignedPublishLicense\n" +
                            "       to build the PublishLicense.");
                UseLicense authorsUseLicense;
                PublishLicense publishLicense =
                    unsignedLicense.Sign(_secureEnv, out authorsUseLicense);

                WriteStatus("   Binding the author's UseLicense and");
                WriteStatus("       obtaining the CryptoProvider.");
                CryptoProvider cryptoProvider = authorsUseLicense.Bind(_secureEnv);

                WriteStatus("   Creating the EncryptedPackage.");
                Stream packageStream = File.OpenRead(packageFile);
                EncryptedPackageEnvelope ePackage =
                    EncryptedPackageEnvelope.CreateFromPackage(encryptedFile,
                        packageStream, publishLicense, cryptoProvider);

                WriteStatus("   Adding an author's UseLicense.");
                RightsManagementInformation rmi =
                    ePackage.RightsManagementInformation;
                rmi.SaveUseLicense(author, authorsUseLicense);

                ePackage.Close();
                WriteStatus("   Done - Package encryption complete.");

                WriteStatus("Verifying package encryption.");
                if (EncryptedPackageEnvelope.IsEncryptedPackageEnvelope(encryptedFile))
                {
                    WriteStatus("   Confirmed - '" + encryptedFilename +
                                "' is encrypted.");
                }
                else
                {
                    MessageBox.Show("ERROR: '" + encryptedFilename +
                        "' is NOT ENCRYPTED.", "Encryption Error",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    WriteStatus("ERROR: '" + encryptedFilename +
                                "' is NOT ENCRYPTED.\n");
                    return false;
                }
                //</SnippetRmPkgPubEncrypt>
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message + "\n\n" +
                    ex.GetType().ToString() + "\n\n" + ex.StackTrace,
                    "Runtime Exception",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            WritePrompt("See the RightsManagedPackageViewer sample for details " +
                "on how to access the content of a rights managed package.");
            return true;
        }// end:PublishRMPackage()


        // ------------------ GetGetDefaultWindowsUserName() ------------------
        /// <summary>
        ///   Returns the email address of the current user.</summary>
        /// <returns>
        ///   The email address of the current user.</returns>
        static internal string GetDefaultWindowsUserName()
        {
            // Get the identity of the currently logged in user.
            System.Security.Principal.WindowsIdentity wi;
            wi = System.Security.Principal.WindowsIdentity.GetCurrent();

            // Get the user's domain and alias.
            string[] splitUserName = wi.Name.Split('\\');

            System.DirectoryServices.DirectorySearcher src =
                new System.DirectoryServices.DirectorySearcher();
            src.SearchRoot = new System.DirectoryServices.DirectoryEntry(
                                                "LDAP://" + splitUserName[0]);

            src.PropertiesToLoad.Add("mail");

            src.Filter = String.Format("(&(objectCategory=person) " +
                "(objectClass=user) (SAMAccountName={0}))",
                splitUserName[1]);

            System.DirectoryServices.SearchResult result = src.FindOne();

            // Return the email address of the currently logged in user.
            return ((string)result.Properties["mail"][0]);
        }// end:GetDefaultWindowsUserName()
        #endregion File|Publish...


        #region File|Exit
        // ------------------------------ OnExit ------------------------------
        /// <summary>
        ///   Handles the user File|Exit menu selection to
        ///   shutdown and exit the application.</summary>
        private void OnExit(object sender, EventArgs e)
        {
            Close();        // invokes OnClosed()
        }// end:OnExit()
        #endregion File|Exit


        #region Utilities
        // ------------------------- GetContentFolder -------------------------
        /// <summary>
        ///   Locates and returns the path to the "Content\" folder
        ///   containing the fixed document for the sample.</summary>
        /// <returns>
        ///   The path to the fixed document "Content\" folder.</returns>
        public string GetContentFolder()
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


        // ------------------------- WriteStatus --------------------------
        /// <summary>
        ///   Adds a line of text to the statusBlock.</summary>
        /// <param name="status">
        ///   A line of text to add to the status TextBlock.</param>
        public void WriteStatus(string status)
        {
            statusBlock.Text += status + "\n";
        }


        // ---------------------------- WritePrompt ---------------------------
        /// <summary>
        ///   Writes a line of text to the prompt bar.</summary>
        /// <param name="prompt">
        ///   The line of text to write in the prompt bar.</param>
        public void WritePrompt(string prompt)
        {
            promptBlock.Text = prompt;
        }


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
        public void PrintDocument()
        {
            if (docViewer == null)  return;
            docViewer.Print();

        }// end:PrintDocument()


        // ----------------------- DocViewer attribute ------------------------
        /// <summary>
        ///   Gets the current DocumentViewer.</summary>
        public DocumentViewer DocViewer
        {
            get
                { return docViewer; }  // "docViewer" declared in Window1.xaml
        }
        #endregion Utilities


        #region private fields
        private string _xrmlFilepath = null;    // xrml path and filename.
        private string _xrmlFilename = null;    // xrml filename without path.
        private string _xrmlString = null;      // xrml string.
        private string _xpsDocumentPath=null;   // XPS doc path and filename.
        private string _xpsDocumentName=null;   // XPS doc filename without path.
        private string _rmxpsPackagePath=null;  // RM package path and filename.
        private string _rmxpsPackageName=null;  // RM package name without path.
        private Uri    _packageUri;             // XPS document path and filename URI.
        private Package     _xpsPackage = null; // XPS document package.
        private XpsDocument _xpsDocument;       // XPS document within the package.
        private static SecureEnvironment _secureEnv = null;
        private static String _currentUserId = GetDefaultWindowsUserName();
        private readonly string _fixedDocumentSequenceContentType =
            "application/vnd.ms-package.xps-fixeddocumentsequence+xml";
        #endregion private fields


    }// end:partial class Window1

}// end:namespace SdkSample