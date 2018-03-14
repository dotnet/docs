// RightsManagedContentPublish Sample - Window1.xaml.cs
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
using System.Windows.Media.Imaging;
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
            // If a content file is currently open, check with the user
            // if it's ok to close it before opening a new one.
            if (_contentFilename != null)
            {
                string msg =
                    "The currently open file needs to be closed before\n" +
                    "opening a one.  Ok to close '"+_contentFilename+"'?";
                MessageBoxResult result =
                    MessageBox.Show(msg, "Close Current File?",
                        MessageBoxButton.OKCancel, MessageBoxImage.Question);

                // If the user did not click OK to close current
                // file, cancel the File | Open request.
                if ((result != MessageBoxResult.OK))
                    return;

                // The user clicked OK, close the current file and continue.
                CloseContent();
                CloseXrML();
            }

            // Create a "File Open" dialog positioned to the
            // "Content\" folder containing the sample fixed document.
            WinForms.OpenFileDialog dialog = new WinForms.OpenFileDialog();
            dialog.InitialDirectory = GetContentFolder();
            dialog.CheckFileExists = true;
            dialog.Filter = "Image files (*.png,*.jpg,*.jpeg)|" +
                                         "*.png;*.jpg;*.jpeg|All (*.*)|*.*";

            // Show the "File Open" dialog.  If the user picks a file and
            // clicks "OK", load and display the specified XPS document.
            if (dialog.ShowDialog() == true)
                OpenContent(dialog.FileName);

        }// end:OnOpen()


        // --------------------------- OpenContent ---------------------------
        /// <summary>
        ///   Loads and displays a given content file.</summary>
        /// <param name="filename">
        ///   The path and filename of the content file
        ///   to load and display.</param>
        /// <returns>
        ///   true if the content loads successfully; otherwise false.</returns>
        public bool OpenContent(string filename)
        {
            // Save the content path and filename.
            _contentFilepath = filename;
            _contentFilename = FilenameOnly(filename);

            // If the file is a supported image, show it in the image control.
            if (filename.EndsWith(".png")
                || filename.EndsWith(".jpg")
                || filename.EndsWith(".jpeg"))
            {
                try
                {
                    //<SnippetRmContPubBitmap>
                    BitmapImage bi = new BitmapImage();
                    bi.BeginInit();
                    bi.UriSource = new Uri(filename);  // path and file name.
                    bi.EndInit();
                    ImageViewer.Source = bi;
                    //</SnippetRmContPubBitmap>
                }
                catch (Exception ex)
                {
                    string msg = filename + "\n\nThe specified file " +
                        "in not a valid unprotected image file.\n\n" +
                        "The file is possibly encrypted with rights " +
                        "management.  Please see the RightsManagedContentViewer\n" +
                        "sample that shows how to access a file with rights " +
                        "managed content.\n\n" +
                        "Exception: " + ex.Message + "\n\n" +
                        ex.GetType().ToString() + "\n\n" + ex.StackTrace;
                    MessageBox.Show(msg, "Invalid File Format",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }

            // Enable document menu controls.
            menuFileClose.IsEnabled  = true;
            menuFileRights.IsEnabled = true;

            // Give the ImageViewer focus.
            imageViewer.Focus();

            WriteStatus("Opened '" + _contentFilename + "'");
            WritePrompt("Click 'File | Rights...' to select an " +
                        "eXtensible Rights Markup (XrML) permissions file.");
            return true;
        }// end:OpenContent()
        #endregion File|Open...


        #region File|Close
        // ----------------------------- OnClosed -----------------------------
        /// <summary>
        ///   Performs clean up when the application is closed.</summary>
        private void OnClosed(object sender, EventArgs e)
        {
            CloseContent();
        }// end:OnClosed()


        // ----------------------------- OnClose ------------------------------
        /// <summary>
        ///   Handles the user "File | Close" menu operation
        ///   to close the currently open document.</summary>
        private void OnClose(object target, ExecutedRoutedEventArgs args)
        {
            CloseContent();
        }// end:OnClose()


        // --------------------------- CloseContent --------------------------
        /// <summary>
        ///   Closes the currently opened content file.</summary>
        public void CloseContent()
        {
            // Clear the Image control.
            imageViewer.Source = null;

            WriteStatus("Closed '" + _contentFilename + "'");
            _contentFilename = null;
            _contentFilepath = null;

            // Disable content-related menu selections.
            menuFileClose.IsEnabled = false;
            WritePrompt(
                "Click 'File | Open...' to select a file to open and view.");

            // Close the XrML file.
            CloseXrML();

        }// end:CloseContent
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
            _xrmlFilename = FilenameOnly(filename);

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
            // "Content\" folder to write the encrypted content file to.
            WinForms.SaveFileDialog dialog = new WinForms.SaveFileDialog();
            dialog.InitialDirectory = GetContentFolder();
            dialog.Title  = "Publish Rights Managed Content As";
            dialog.Filter = "Rights Managed content (*.protected)|*.protected";

            // Create a new content ".protected" file extension.
            dialog.FileName = _contentFilepath.Insert(
                                _contentFilepath.Length, ".protected" );

            // Show the "Save As" dialog. If the user clicks "Cancel", return.
            if (dialog.ShowDialog() != true)  return;

            // Extract the filename without path.
            _rmContentFilepath = dialog.FileName;
            _rmContentFilename = FilenameOnly(_rmContentFilepath);

            WriteStatus("Publishing '" + _rmContentFilename + "'.");
            PublishRMContent(_contentFilepath, _xrmlFilepath, dialog.FileName);

        }// end:OnPublish()


        // ------------------------ PublishRMContent --------------------------
        /// <summary>
        ///   Writes an encrypted righted managed content file.</summary>
        /// <param name="contentFile">
        ///   The path and filename of the source content file.</param>
        /// <param name="xrmlFile">
        ///   The path and filename of the XrML rights management file.</param>
        /// <param name="encryptedFile">
        ///   The path and filename for writing the RM encrypted content.</param>
        /// <returns>
        ///   true if the encrypted package is written successfully;
        ///   otherwise false.</returns>
        public bool PublishRMContent(
            string contentFile, string xrmlFile, string encryptedFile)
        {
            string xrmlString;

            // Extract individual filenames without the path.
            string contentFilename   = FilenameOnly(contentFile);
            string xrmlFilename      = FilenameOnly(xrmlFile);
            string encryptedFilename = FilenameOnly(encryptedFile);

            try
            {
                //<SnippetRmContPubUnsLic>
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
                //</SnippetRmContPubUnsLic>

                WriteStatus("   Building secure environment.");
                try
                {
                    //<SnippetRmContPubSecEnv>
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
                    //</SnippetRmContPubSecEnv>
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

                WriteStatus("   Signing the UnsignedPublishLicense\n" +
                            "       to create a signed PublishLicense.");
                UseLicense authorsUseLicense;
                PublishLicense publishLicense =
                    unsignedLicense.Sign(_secureEnv, out authorsUseLicense);

                // Save an XML version of the UseLicense.
                WriteStatus("   Saving UseLicense");
                string useLicenseFilepath = contentFile + ".UseLicense.xml";
                WriteStatus("       '" + FilenameOnly(useLicenseFilepath) + "'.");
                FileStream useStream =
                    new FileStream(useLicenseFilepath, FileMode.Create);
                StreamWriter useWriter =
                    new StreamWriter(useStream, System.Text.Encoding.ASCII);
                useWriter.WriteLine(authorsUseLicense.ToString());
                useWriter.Close();
                useStream.Close();

                // Save an XML version of the signed PublishLicense.
                WriteStatus("   Saving signed PublishLicense");
                string pubLicenseFilepath = contentFile + ".PublishLicense.xml";
                WriteStatus("       '" + FilenameOnly(pubLicenseFilepath) + "'.");
                FileStream pubStream =
                    new FileStream(pubLicenseFilepath, FileMode.Create);
                StreamWriter pubWriter =
                    new StreamWriter(pubStream, System.Text.Encoding.ASCII);
                pubWriter.WriteLine(publishLicense.ToString());
                pubWriter.Close();
                pubStream.Close();

                //<SnippetRmContPubEncrypt>
                WriteStatus("   Binding the author's UseLicense and");
                WriteStatus("       obtaining the CryptoProvider.");
                using (CryptoProvider cryptoProvider =
                            authorsUseLicense.Bind(_secureEnv))
                {
                    WriteStatus("   Writing encrypted content.");
                    using (Stream clearTextStream =
                                File.OpenRead(contentFile) )
                    {
                        using (Stream cryptoTextStream =
                                    File.OpenWrite(encryptedFile))
                        {
                            // Write the length of the source content file
                            // as the first four bytes of the encrypted file.
                            cryptoTextStream.Write(
                                BitConverter.GetBytes(clearTextStream.Length),
                                0, sizeof(Int32));

                            // Allocate clearText buffer.
                            byte[] clearTextBlock =
                                new byte[cryptoProvider.BlockSize];

                            // Encrypt clearText to cryptoText block by block.
                            for(;;)
                            {   // Read clearText block.
                                int readCount = ReliableRead(
                                                    clearTextStream,
                                                    clearTextBlock, 0 ,
                                                    cryptoProvider.BlockSize);
                                // readCount of zero is end of data.
                                if (readCount == 0)  break; // for

                                // Encrypt clearText to cryptoText.
                                byte[] cryptoTextBlock =
                                    cryptoProvider.Encrypt(clearTextBlock);

                                // Write cryptoText block.
                                cryptoTextStream.Write(cryptoTextBlock, 0,
                                                       cryptoTextBlock.Length);
                            }
                            WriteStatus("   Closing '" + encryptedFilename + "'.");
                        }// end:using (Stream cryptoTextStream =
                    }// end:using (Stream clearTextStream =
                }// end:using (CryptoProvider cryptoProvider =
                WriteStatus("   Done - Content encryption complete.");
                //</SnippetRmContPubEncrypt>
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message + "\n\n" +
                    ex.GetType().ToString() + "\n\n" + ex.StackTrace,
                    "Runtime Exception",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            WritePrompt("See the RightsManagedContentViewer sample for " +
                "details on how to access rights managed content.");
            return true;
        }// end:PublishRMContent()


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


        // ---------------------------- WriteStatus ---------------------------
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


        // ---------------------------- FilenameOnly --------------------------
        /// <summary>
        ///   Returns the filename only from a given path and filename.</summary>
        /// <param name="filepath">
        ///   A path and filename.</param>
        /// <returns>
        ///   The filename with extension.</returns>
        private static string FilenameOnly(string filepath)
        {
            // Locate the index of the last backslash.
            int slashIndex = filepath.LastIndexOf('\\');

            // If there is no backslash, return the original string.
            if (slashIndex < 0)
                return filepath;

            // Remove all the characters through the last backslash.
            return filepath.Remove(0, slashIndex + 1);
        }


        // ---------------------------- ReliableRead --------------------------
        /// <summary>
        ///   Reads a specified number of bytes from a given stream.</summary>
        /// <param name="stream">
        ///   The stream to read from.</param>
        /// <param name="buffer">
        ///   The buffer to read to.</param>
        /// <param name="offset">
        ///   The offset in the buffer to start reading into.</param>
        /// <param name="requiredCount">
        ///   The required number of bytes to read.</param>
        /// <returns>
        ///   The number of bytes read.</returns>
        /// <remarks>
        ///   <rem>At end of file the number of bytes read will be
        ///   less than the requiredCount or zero (0).</rem>
        ///   <rem>ReliableRead supports read operations from generic mediums
        ///   such as a local file, network file, database, or web service that
        ///   may otherwise return partial buffer lengths.</rem>
        /// </remarks>
        ///
        private static int ReliableRead(
            Stream stream, byte[] buffer, int offset, int requiredCount)
        {
            // Read a whole block into the buffer.
            int totalBytesRead = 0;
            while (totalBytesRead < requiredCount)
            {
                int bytesRead = stream.Read(buffer,
                                offset + totalBytesRead,
                                requiredCount - totalBytesRead);
                if (bytesRead == 0)  break; // while
                totalBytesRead += bytesRead;
            }
            return totalBytesRead;
        }// end:ReliableRead()


        // ----------------------- ImageViewer attribute ------------------------
        /// <summary>
        ///   Gets the Image viewer control.</summary>
        public Image ImageViewer
        {
            get
                { return imageViewer; }  // "imageViewer" declared in Window1.xaml
        }
        #endregion Utilities


        #region private fields
        private string _xrmlFilepath = null;    // xrml path and filename.
        private string _xrmlFilename = null;    // xrml filename without path.
        private string _xrmlString = null;      // xrml string.
        private string _contentFilepath=null;   // content path and filename.
        private string _contentFilename=null;   // content filename without path.
        private string _rmContentFilepath=null; // RM content path and filename.
        private string _rmContentFilename=null; // RM content filename without path.
        private static SecureEnvironment _secureEnv = null;
        private static String _currentUserId = GetDefaultWindowsUserName();
        #endregion private fields


    }// end:partial class Window1

}// end:namespace SdkSample