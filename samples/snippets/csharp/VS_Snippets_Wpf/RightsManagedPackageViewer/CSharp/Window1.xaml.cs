// RightsManagedPackageViewer Sample - Window1.xaml.cs
// Copyright (c) Microsoft Corporation. All rights reserved.

using System;
using System.Collections.ObjectModel;
using System.IO;
using System.IO.Packaging;
using System.Net;
using System.Security.RightsManagement;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Xps.Packaging;
using System.Security.Permissions;
using System.Xml;
using WinForms = Microsoft.Win32;


namespace SdkSample
{
    // ========================= partial class Window1 ========================
    /// <summary>
    ///   Interaction logic for Window1.xaml</summary>
    public partial class Window1 : Window
    {
        #region constructor
        // ------------------------ Window1 constructor -----------------------
        public Window1() : base()
        {
            InitializeComponent();

            ShowPrompt(
                "Click 'File | Open...' to select a file to open and view.");
        }
        #endregion constructor


        #region File|Open...
        // ------------------------------ OnOpen ------------------------------
        /// <summary>
        ///   Handles the user "File | Open" menu operation.</summary>
        private void OnOpen(object target, ExecutedRoutedEventArgs args)
        {
            // Create a "File Open" dialog positioned to the
            // "Content\" folder containing the sample fixed document.
            WinForms.OpenFileDialog dialog = new WinForms.OpenFileDialog();
            dialog.InitialDirectory = GetContentFolder();
            dialog.CheckFileExists = true;
            dialog.Filter = "XPS Document files (*.xps)|*.xps";

            // Show the "File Open" dialog.  If the user picks a file and
            // clicks "OK", load and display the specified XPS document.
            if (dialog.ShowDialog() == true)
            {
                CloseDocument();            // Close current document if open.
                _xpsFile = dialog.FileName; // Save the path and file name.

                // Check to see if the document is encrypted.
                // If encrypted, use OpenEncryptedDocument().
                if (EncryptedPackageEnvelope.IsEncryptedPackageEnvelope(_xpsFile))
                    OpenEncryptedDocument(_xpsFile);

                // Otherwise open as a normal document.
                else
                    OpenDocument(_xpsFile);
            }
        }// end:OnOpen()


        //<SnippetRmPkgViewOpenDoc>
        // --------------------------- OpenDocument ---------------------------
        /// <summary>
        ///   Loads and displays a given XPS document file.</summary>
        /// <param name="filename">
        ///   The path and file name of the XPS
        ///   document to load and display.</param>
        /// <returns>
        ///   true if the document loads successfully; otherwise false.</returns>
        public bool OpenDocument(string xpsFile)
        {
            // Check to see if the document is encrypted.
            // If encrypted, use OpenEncryptedDocument().
            if (EncryptedPackageEnvelope.IsEncryptedPackageEnvelope(xpsFile))
                return OpenEncryptedDocument(xpsFile);

            // Document is not encrypted, open normally.
            ShowStatus("Opening '" + Filename(xpsFile) + "'");

            _packageUri = new Uri(xpsFile, UriKind.Absolute);
            try
            {
                _xpsDocument = new XpsDocument(xpsFile, FileAccess.Read);
            }
            catch (System.IO.FileFormatException ex)
            {
                MessageBox.Show(xpsFile + "\n\nThe file " +
                    "is not a valid XPS document.\n\n" +
                    "Exception: " + ex.Message + "\n\n" +
                    ex.GetType().ToString() + "\n\n" + ex.StackTrace,
                    "Invalid File Format",
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
                MessageBox.Show(xpsFile + "\n\nThe document package within " +
                    "the specified file does not contain a " +
                    "FixedDocumentSequence.", "Package Error");
                return false;
            }

            // Load the FixedDocumentSequence to the DocumentViewer control.
            DocViewer.Document = fds;

            // Enable document menu controls.
            menuFileClose.IsEnabled  = true;
            menuFilePrint.IsEnabled  = true;
            menuViewIncreaseZoom.IsEnabled = true;
            menuViewDecreaseZoom.IsEnabled = true;

            // Give the DocumentViewer focus.
            docViewer.Focus();

            this.Title = "RightsManagedPackageViewer SDK Sample - " +
                         Filename(xpsFile);
            return true;
        }// end:OpenDocument()
        //</SnippetRmPkgViewOpenDoc>


        // ---------------------- OpenEncryptedDocument -----------------------
        /// <summary>
        ///   Loads and displays a given encrypted XPS document file.</summary>
        /// <param name="xpsFile">
        ///   The path and filename of the encrypted XPS
        ///   document to load and display.</param>
        /// <returns>
        ///   true if the document loads successfully; otherwise false.</returns>
        [SecurityPermissionAttribute(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        public bool OpenEncryptedDocument(string xpsFile)
        {
            // Check to see if the document is encrypted.
            // If not encrypted, use OpenDocument().
            if (!EncryptedPackageEnvelope.IsEncryptedPackageEnvelope(xpsFile))
                return OpenDocument(xpsFile);

            ShowStatus("Opening encrypted '" + Filename(xpsFile) + "'");

            // Get the ID of the current user log-in.
            string currentUserId;
            try
                { currentUserId = GetDefaultWindowsUserName(); }
            catch
                { currentUserId = null; }
            if (currentUserId == null)
            {
                MessageBox.Show("No valid user ID available", "Invalid User ID",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                ShowStatus("   No valid user ID available.");
                return false;
            }

            ShowStatus("   Current user ID:  '" + currentUserId + "'");
            ShowStatus("   Using " + _authentication + " authentication.");
            ShowStatus("   Checking rights list for user:\n       " +
                           currentUserId);
            ShowStatus("   Initializing the environment.");

            try
            {
                string applicationManifest = "<manifest></manifest>";
                if (File.Exists("rvc.xml"))
                {
                    ShowStatus("   Reading manifest 'rvc.xml'.");
                    StreamReader manifestReader = File.OpenText("rvc.xml");
                    applicationManifest = manifestReader.ReadToEnd();
                }

                //<SnippetRmPkgViewSecEnv>
                ShowStatus("   Initiating SecureEnvironment as user: \n       " +
                    currentUserId + " [" + _authentication + "]");
                if (SecureEnvironment.IsUserActivated(
                    new ContentUser(currentUserId, _authentication)))
                {
                    ShowStatus("   User is already activated.");
                    _secureEnv = SecureEnvironment.Create(applicationManifest,
                                    new ContentUser(currentUserId, _authentication));
                }
                else // if user is not yet activated.
                {
                    ShowStatus("   User is NOT activated,\n       activating now....");
                    // If using the current Windows user, no credentials are
                    // required and we can use UserActivationMode.Permanent.
                    _secureEnv = SecureEnvironment.Create(applicationManifest,
                                    _authentication, UserActivationMode.Permanent);

                    // If not using the current Windows user, use
                    // UserActivationMode.Temporary to display the Windows
                    // credentials pop-up window.
                    ///_secureEnv = SecureEnvironment.Create(applicationManifest,
                    ///     a_authentication, UserActivationMode.Temporary);
                }
                ShowStatus("   Created SecureEnvironment for user:\n       " +
                    _secureEnv.User.Name +
                    " [" + _secureEnv.User.AuthenticationType + "]");
                //</SnippetRmPkgViewSecEnv>

                //<SnippetRmPkgViewOpenPkg>
                ShowStatus("   Opening the encrypted Package.");
                EncryptedPackageEnvelope ePackage =
                    EncryptedPackageEnvelope.Open(xpsFile, FileAccess.ReadWrite);
                RightsManagementInformation rmi =
                    ePackage.RightsManagementInformation;

                ShowStatus("   Looking for an embedded UseLicense for user:\n       " +
                           currentUserId + " [" + _authentication + "]");
                UseLicense useLicense =
                    rmi.LoadUseLicense(
                        new ContentUser(currentUserId, _authentication));

                ReadOnlyCollection<ContentGrant> grants;
                if (useLicense == null)
                {
                    ShowStatus("   No Embedded UseLicense found.\n       " +
                               "Attempting to acqure UseLicnese\n       " +
                               "from the PublishLicense.");
                    PublishLicense pubLicense = rmi.LoadPublishLicense();

                    ShowStatus("   Referral information:");

                    if (pubLicense.ReferralInfoName == null)
                        ShowStatus("       Name: (null)");
                    else
                        ShowStatus("       Name: " + pubLicense.ReferralInfoName);

                    if (pubLicense.ReferralInfoUri == null)
                        ShowStatus("    Uri: (null)");
                    else
                        ShowStatus("    Uri: " +
                            pubLicense.ReferralInfoUri.ToString());

                    useLicense = pubLicense.AcquireUseLicense(_secureEnv);
                    if (useLicense == null)
                    {
                        ShowStatus("   User DOES NOT HAVE RIGHTS\n       " +
                            "to access this document!");
                        return false;
                    }
                }// end:if (useLicense == null)
                ShowStatus("   UseLicense acquired.");
                //</SnippetRmPkgViewOpenPkg>

                //<SnippetRmPkgViewBind>
                ShowStatus("   Binding UseLicense with the SecureEnvironment" +
                         "\n       to obtain the CryptoProvider.");
                rmi.CryptoProvider = useLicense.Bind(_secureEnv);

                ShowStatus("   Obtaining BoundGrants.");
                grants = rmi.CryptoProvider.BoundGrants;

                // You can access the Package via GetPackage() at this point.

                rightsBlock.Text = "GRANTS LIST\n-----------\n";
                foreach (ContentGrant grant in grants)
                {
                    rightsBlock.Text += "USER  :" + grant.User.Name + " [" +
                        grant.User.AuthenticationType + "]\n";
                    rightsBlock.Text += "RIGHT :" + grant.Right.ToString()+"\n";
                    rightsBlock.Text += "    From:  " + grant.ValidFrom + "\n";
                    rightsBlock.Text += "    Until: " + grant.ValidUntil + "\n";
                }
                //</SnippetRmPkgViewBind>

                //<SnippetRmPkgViewDecrypt>
                if (rmi.CryptoProvider.CanDecrypt == true)
                    ShowStatus("   Decryption granted.");
                else
                    ShowStatus("   CANNOT DECRYPT!");

                ShowStatus("   Getting the Package from\n" +
                           "      the EncryptedPackage.");
                _xpsPackage = ePackage.GetPackage();
                if (_xpsPackage == null)
                {
                    MessageBox.Show("Unable to get Package.");
                    return false;
                }

                // Set a PackageStore Uri reference for the encrypted stream.
                // ("sdk://packLocation" is a pseudo URI used by
                //  PackUriHelper.Create to define the parserContext.BaseURI
                //  that XamlReader uses to access the encrypted data stream.)
                Uri packageUri = new Uri(@"sdk://packLocation", UriKind.Absolute);
                // Add the URI package
                PackageStore.AddPackage(packageUri, _xpsPackage);
                // Determine the starting part for the package.
                PackagePart startingPart = GetPackageStartingPart(_xpsPackage);

                // Set the DocViewer.Document property.
                ShowStatus("   Opening in DocumentViewer.");
                ParserContext parserContext = new ParserContext();
                parserContext.BaseUri = PackUriHelper.Create(
                                            packageUri, startingPart.Uri);
                parserContext.XamlTypeMapper = XamlTypeMapper.DefaultMapper;
                DocViewer.Document = XamlReader.Load(
                    startingPart.GetStream(), parserContext)
                        as IDocumentPaginatorSource;

                // Enable document menu controls.
                menuFileClose.IsEnabled = true;
                menuFilePrint.IsEnabled = true;
                menuViewIncreaseZoom.IsEnabled = true;
                menuViewDecreaseZoom.IsEnabled = true;

                // Give the DocumentViewer focus.
                DocViewer.Focus();
                //</SnippetRmPkgViewDecrypt>
            }// end:try
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message + "\n\n" +
                    ex.GetType().ToString() + "\n\n" + ex.StackTrace,
                    "Exception",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            this.Title = "RightsManagedPackageViewer SDK Sample - " +
                         Filename(xpsFile) + " (encrypted)";
            return true;
        }// end:OpenEncryptedDocument()

        private static string PackageURI = "http://schemas.microsoft.com/xps/2005/06/fixedrepresentation";
        private static PackagePart GetPackageStartingPart(Package package)
        {
            PackageRelationship startingPartRelationship = null;

            foreach (PackageRelationship rel in package.GetRelationshipsByType(PackageURI))
            {
                startingPartRelationship = rel;
            }

            if (startingPartRelationship != null)
            {
                Uri startPartUri = PackUriHelper.CreatePartUri(startingPartRelationship.TargetUri);

                if (package.PartExists(startPartUri))
                {
                    return (package.GetPart(startPartUri));
                }
                else
                {
                    return null;
                }
            }
            return null;
        }

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
            Uri tempUri = new Uri(_xpsFile, UriKind.RelativeOrAbsolute);
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


        //<SnippetRmPkgViewCloseDoc>
        // --------------------------- CloseDocument --------------------------
        /// <summary>
        ///   Closes the document currently displayed in
        ///   the DocumentViewer control.</summary>
        public void CloseDocument()
        {
            if (_xpsFile != null)
            {
                ShowStatus("Closing '" + Filename(_xpsFile) + "'");
                DocViewer.Document = null;
                _xpsFile = null;
            }

            // If the package is open, close it.
            if (_xpsPackage != null)
            {
                _xpsPackage.Close();
                _xpsPackage = null;
            }

            // The package is closed, remove it from the store.
            if (_packageUri != null)
            {
                PackageStore.RemovePackage(_packageUri);
                _packageUri = null;
            }

            // Disable document-related selections when there's no document.
            menuFileClose.IsEnabled = false;
            menuFilePrint.IsEnabled = false;
            menuViewIncreaseZoom.IsEnabled = false;
            menuViewDecreaseZoom.IsEnabled = false;
            this.Title = "RightsManagedPackageViewer SDK Sample";
            ShowPrompt(
                "Click 'File | Open...' to select a file to open and view.");
            rightsBlock.Text = "";

        }// end:CloseDocument
        //</SnippetRmPkgViewCloseDoc>
        #endregion File|Close


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


        // ------------------------------ Filename ----------------------------
        /// <summary>
        ///   Returns just the filename from a given path and filename.</summary>
        /// <param name="filepath">
        ///   A path and filename.</param>
        /// <returns>
        ///   The filename with extension.</returns>
        private static string Filename(string filepath)
        {
            // Locate the index of the last backslash.
            int slashIndex = filepath.LastIndexOf('\\');

            // If there is no backslash, return the original string.
            if (slashIndex < 0)
                return filepath;

            // Remove all the characters through the last backslash.
            return filepath.Remove(0, slashIndex + 1);
        }


        // --------------------------- ShowStatus -----------------------------
        /// <summary>
        ///   Adds a line of text to the statusBlock.</summary>
        /// <param name="status">
        ///   A line of text to add to the status TextBlock.</param>
        public void ShowStatus(string status)
        {
            statusBlock.Text += status + "\n";
        }


        // ---------------------------- ShowPrompt ----------------------------
        /// <summary>
        ///   Displays a line of text in the prompt bar.</summary>
        /// <param name="prompt">
        ///   The line of text to display in the prompt bar.</param>
        public void ShowPrompt(string prompt)
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
        }


        // --------------------- OnWindowsAuthentication ----------------------
        /// <summary>
        ///   Sets rights management for Windows authentication.</summary>
        private void OnWindowsAuthentication(object sender, EventArgs e)
        {
            menuViewWindows.IsChecked  = true;
            menuViewPassport.IsChecked = false;
            _authentication = AuthenticationType.Windows;
        }


        // --------------------- OnPassportAuthentication ---------------------
        /// <summary>
        ///   Sets rights management for Windows authentication.</summary>
        private void OnPassportAuthentication(object sender, EventArgs e)
        {
            menuViewWindows.IsChecked  = false;
            menuViewPassport.IsChecked = true;
            _authentication = AuthenticationType.Passport;
        }


        // -------------------- GetDefaultWindowsUserName() -------------------
        /// <summary>
        ///   Returns the email address of the current user log-in.</summary>
        /// <returns>
        ///   The email address of the current user.</returns>
        [SecurityPermissionAttribute(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
        static internal string GetDefaultWindowsUserName()
        {
            // Get the identity of the currently logged in user.
            System.Security.Principal.WindowsIdentity wi =
                System.Security.Principal.WindowsIdentity.GetCurrent();

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
        private string      _xpsFile=null;      // XPS doc path and filename.
        private Uri         _packageUri;        // XPS document path and filename URI.
        private Package     _xpsPackage = null; // XPS document package.
        private XpsDocument _xpsDocument;       // XPS document within the package.
        private AuthenticationType _authentication = AuthenticationType.Windows;
        private static SecureEnvironment _secureEnv = null;
        private static String _currentUserId = GetDefaultWindowsUserName();
        private readonly string _fixedDocumentSequenceContentType =
            "application/vnd.ms-package.xps-fixeddocumentsequence+xml";
        #endregion private fields


    }// end:partial class Window1

}// end:namespace SdkSample