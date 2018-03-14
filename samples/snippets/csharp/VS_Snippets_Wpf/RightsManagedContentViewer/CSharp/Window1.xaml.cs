// RightsManagedContentViewer Sample - Window1.xaml.cs
// Copyright (c) Microsoft Corporation. All rights reserved.

using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Security.RightsManagement;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media.Imaging;
using System.Xml;
using System.Security.Permissions;
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
            // "Content\" folder containing the sample images.
            WinForms.OpenFileDialog dialog = new WinForms.OpenFileDialog();
            dialog.InitialDirectory = GetContentFolder();
            dialog.CheckFileExists = true;
            dialog.Filter = "Image files (*.png,*.jpg,*.jpeg, *.protected)|" +
                            "*.png;*.jpg;*.jpeg;*.protected|All (*.*)|*.*";

            // Show the "File Open" dialog.  If the user
            // clicks "Cancel", cancel the File|Open operation.
            if (dialog.ShowDialog() != true)
                return;

            // clicks "OK", load and display the specified file.
            CloseContent();                 // Close current file if open.
            _contentFile = dialog.FileName; // Save new path and file name.
            ShowStatus("Opening '" + Filename(_contentFile) + "'");

            // Check to see if the file name shows as "protected" or
            // "encrypted".  If encrypted, use OpenEncryptedContent().
            bool opened;
            if (   _contentFile.ToLower().Contains("protected")
                || _contentFile.ToLower().Contains("encrypted")  )
                opened = OpenEncryptedContent(_contentFile);

            // Otherwise open as unencrypted.
            else
                opened = OpenContent(_contentFile);

            // If the file was successfully opened, show the file name,
            // enable File|Close, and give focus to the Image control.
            if (opened == true)
            {
                this.Title = "RightsManagedContentViewer SDK Sample - " +
                              Filename(_contentFile);
                menuFileClose.IsEnabled = true;
                imageViewer.Focus();
            }
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
            // If the file is not a supported image, do not try to display it.
            if (   !filename.EndsWith(".png")
                && !filename.EndsWith(".jpg")
                && !filename.EndsWith(".jpeg"))
            {
                MessageBox.Show(filename + "\n\nThis file type extension " +
                    "is not supported.  This sample is designed to display " +
                    "png, jpg, or jpeg image files.", "Unsupported File Type",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            // If the file is a supported image, show it in the image control.
            try
            {
                //<SnippetRMContViewBitmap1>
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.UriSource = new Uri(filename); // path and file name.
                bi.EndInit();
                ImageViewer.Source = bi;
                //</SnippetRMContViewBitmap1>
            }
            catch (Exception ex)
            {
                MessageBox.Show(filename + "\n\nThe specified file " +
                    "in not a valid unprotected image file.\n\n" +
                    "Exception: " + ex.Message + "\n\n" +
                    ex.GetType().ToString() + "\n\n" + ex.StackTrace,
                    "Invalid File Format",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }// end:OpenContent()


        // ---------------------- OpenEncryptedContent -----------------------
        /// <summary>
        ///   Loads and displays a given encrypted content file.</summary>
        /// <param name="encryptedFile">
        ///   The path and name of the encrypted file to display.</param>
        /// <returns>
        ///   true if the file loads successfully; otherwise false.</returns>
        public bool OpenEncryptedContent(string encryptedFile)
        {
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

                if (_secureEnv == null)
                {
                    ShowStatus("   Initiating SecureEnvironment as user:\n   " +
                        "    " + currentUserId + " [" + _authentication + "]");
                    if (SecureEnvironment.IsUserActivated(
                        new ContentUser(currentUserId, _authentication)))
                    {
                        ShowStatus("   User is already activated.");
                        _secureEnv = SecureEnvironment.Create(
                                                applicationManifest,
                                                new ContentUser(currentUserId,
                                                    _authentication) );
                    }
                    else // if user is not yet activated.
                    {
                        ShowStatus("   User is NOT activated,\n" +
                                   "       activating now....");
                        // If using the current Windows user, no credentials are
                        // required and we can use UserActivationMode.Permanent.
                        _secureEnv = SecureEnvironment.Create(
                                                applicationManifest,
                                                _authentication,
                                                UserActivationMode.Permanent );

                        // If not using the current Windows user, use
                        // UserActivationMode.Temporary to display the Windows
                        // credentials pop-up window.
                        //  _secureEnv = SecureEnvironment.Create(
                        //                        applicationManifest,
                        //                        _authentication,
                        //                        UserActivationMode.Temporary);
                    }
                    ShowStatus("   Created SecureEnvironment for user:\n       " +
                        _secureEnv.User.Name +
                        " [" + _secureEnv.User.AuthenticationType + "]");
                }

                // If the file is a supported image, show it in the image control.
                try
                {
                    // In this sample a UseLicense is provided with the example
                    // content files.  If the UseLicense for the current user
                    // does not exist, the following steps can be performed to
                    // obtain a UseLicense:
                    //   1. Open the PublishLicense.
                    //   2. Read the PublishLicense XML file to a string.
                    //   3. Create a PublishLicense instance passing the
                    //      PublishLicense string to the constructor.
                    //   4. Pass the PublishLicense to the license server to
                    //      obtain a UseLicense.

                    // Check if there is a UseLicense for the encryptedFile.
                    string useLicenseFile = encryptedFile;
                    if (encryptedFile.EndsWith(".protected"))
                    {   // Remove ".protected" from the file name.
                        useLicenseFile = useLicenseFile.Remove(
                            useLicenseFile.Length - ".protected".Length );
                    }
                    // Append ".UseLicense.xml" as the UseLicense file extension.
                    useLicenseFile = useLicenseFile + ".UseLicense.xml";
                    if (!File.Exists(useLicenseFile))
                    {
                        MessageBox.Show(useLicenseFile + "\n\nUseLicense for '" +
                            Filename(encryptedFile) + "' not found.",
                            "UseLicense Not Found",
                            MessageBoxButton.OK, MessageBoxImage.Error);
                        ShowStatus("   UseLicense not found:\n      '" +
                                    Filename(useLicenseFile) + "'.");
                        return false;
                    }

                    ShowStatus("   Reading UseLicense '" +
                                   Filename(useLicenseFile) + "'.");
                    StreamReader useLicenseStream = File.OpenText(useLicenseFile);
                    string useLicenseString = useLicenseStream.ReadToEnd();
                    UseLicense useLicense = new UseLicense(useLicenseString);

                    //<SnippetRMContViewUseLicense>
                    ShowStatus("   Binding UseLicense with the SecureEnvironment" +
                             "\n       to obtain the CryptoProvider.");
                    CryptoProvider cryptoProvider = useLicense.Bind(_secureEnv);

                    ShowStatus("   Obtaining BoundGrants.");
                    ReadOnlyCollection<ContentGrant> grants =
                        cryptoProvider.BoundGrants;

                    rightsBlockTitle.Text = "Rights - " + Filename(useLicenseFile);
                    rightsBlock.Text = "GRANTS LIST\n-----------------\n";
                    foreach (ContentGrant grant in grants)
                    {
                        rightsBlock.Text += "USER:  " + grant.User.Name + " [" +
                            grant.User.AuthenticationType + "]\n";
                        rightsBlock.Text += "RIGHT: " + grant.Right.ToString() + "\n";
                        rightsBlock.Text += "    From:  " + grant.ValidFrom + "\n";
                        rightsBlock.Text += "    Until: " + grant.ValidUntil + "\n";
                    }

                    if (cryptoProvider.CanDecrypt == true)
                        ShowStatus("   Decryption granted.");
                    else
                        ShowStatus("   CANNOT DECRYPT!");
                    //</SnippetRMContViewUseLicense>

                    ShowStatus("   Decrypting '"+Filename(encryptedFile)+"'.");
                    //<SnippetRMContViewDecrypt>
                    byte[] imageBuffer;
                    using (Stream cipherTextStream = File.OpenRead(encryptedFile))
                    {
                        byte[] contentLengthByteBuffer = new byte[sizeof(Int32)];
                        // Read the length of the source content file
                        // from the first four bytes of the encrypted file.
                        ReliableRead(cipherTextStream, contentLengthByteBuffer,
                                     0, sizeof(Int32));

                        // Allocate the clearText buffer.
                        int contentLength =
                            BitConverter.ToInt32(contentLengthByteBuffer, 0);
                        imageBuffer = new byte[contentLength];

                        // Allocate the cipherText block.
                        byte[] cipherTextBlock =
                            new byte[cryptoProvider.BlockSize];

                        // decrypt cipherText to clearText block by block.
                        int imageBufferIndex = 0;
                        for ( ; ; )
                        {   // Read cipherText block.
                            int readCount = ReliableRead(
                                                cipherTextStream,
                                                cipherTextBlock, 0,
                                                cryptoProvider.BlockSize);
                            // readCount of zero is end of data.
                            if (readCount == 0)
                                break; // for

                            // Decrypt cipherText to clearText.
                            byte[] clearTextBlock =
                                cryptoProvider.Decrypt(cipherTextBlock);

                            // Copy the clearTextBlock to the imageBuffer.
                            int copySize = Math.Min(clearTextBlock.Length,
                                                contentLength-imageBufferIndex);
                            Array.Copy(clearTextBlock, 0,
                                imageBuffer, imageBufferIndex, copySize);
                            imageBufferIndex += copySize;
                        }
                    }// end:using (Stream cipherTextStream = (close/dispose)
                    //</SnippetRMContViewDecrypt>

                    ShowStatus("   Displaying decrypted image.");
                    //<SnippetRMContViewBitmap2>
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.StreamSource = new MemoryStream(imageBuffer);
                    bitmapImage.EndInit();
                    ImageViewer.Source = bitmapImage;
                    //</SnippetRMContViewBitmap2>
                }
                catch (Exception ex)
                {
                    MessageBox.Show(encryptedFile + "\n\nThe specified file " +
                        "in not a valid unprotected image file.\n\n" +
                        "Exception: " + ex.Message + "\n\n" +
                        ex.GetType().ToString() + "\n\n" + ex.StackTrace,
                        "Invalid File Format",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }// end:try
            catch (Exception ex)
            {
                MessageBox.Show("Exception: " + ex.Message + "\n\n" +
                    ex.GetType().ToString() + "\n\n" + ex.StackTrace,
                    "Exception",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }// end:OpenEncryptedContent()


        #endregion File|Open...


        #region File|Close
        // ----------------------------- OnClosed -----------------------------
        /// <summary>
        ///   Performs clean up when the application is closed.</summary>
        private void OnClosed(object sender, EventArgs e)
        {
            CloseContent();
        }


        // ----------------------------- OnClose ------------------------------
        /// <summary>
        ///   Handles the user "File | Close" menu operation
        ///   to close the currently open document.</summary>
        private void OnClose(object target, ExecutedRoutedEventArgs args)
        {
            CloseContent();
        }


        // --------------------------- CloseContent --------------------------
        /// <summary>
        ///   Closes the currently opened content file.</summary>
        public void CloseContent()
        {
            if (_contentFile != null)
            {
                ShowStatus("Closing '" + Filename(_contentFile) + "'");
                _contentFile = null;
            }

            // Clear the Image control and disable the File|Close menu option.
            imageViewer.Source = null;
            this.Title = "RightsManagedContentViewer SDK Sample";
            menuFileClose.IsEnabled = false;

            // Reset any information in the Rights block.
            rightsBlockTitle.Text = "Rights";
            rightsBlock.Text = "";
            ShowPrompt(
                "Click 'File | Open...' to select a file to open and view.");
        }// end:CloseContent
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
                if (bytesRead == 0) break; // while
                totalBytesRead += bytesRead;
            }
            return totalBytesRead;
        }// end:ReliableRead()

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
        private string      _contentFile=null;  // content path and filename.
        private AuthenticationType _authentication = AuthenticationType.Windows;
        private static SecureEnvironment _secureEnv = null;
        private static String _currentUserId = GetDefaultWindowsUserName();
        #endregion private fields


    }// end:partial class Window1

}// end:namespace SdkSample