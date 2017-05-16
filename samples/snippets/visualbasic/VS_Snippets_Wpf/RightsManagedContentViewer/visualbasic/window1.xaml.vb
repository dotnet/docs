' RightsManagedContentViewer Sample - Window1.xaml.vb
' Copyright (c) Microsoft Corporation. All rights reserved.


Imports System
Imports System.Collections.ObjectModel
Imports System.IO
Imports System.Net
Imports System.Security.RightsManagement
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Input
Imports System.Windows.Markup
Imports System.Windows.Media.Imaging
Imports System.Xml
Imports System.Security.Permissions
Imports WinForms = Microsoft.Win32
Imports Microsoft.VisualBasic

Namespace SdkSample
	' ========================= partial class Window1 ========================
	''' <summary>
	'''   Interaction logic for Window1.xaml</summary>
	Partial Public Class Window1
		Inherits Window
		#Region "constructor"
		' ------------------------ Window1 constructor -----------------------
		Public Sub New()
			MyBase.New()
			InitializeComponent()

			ShowPrompt("Click 'File | Open...' to select a file to open and view.")
		End Sub
		#End Region ' constructor


		#Region "File|Open..."
		' ------------------------------ OnOpen ------------------------------
		''' <summary>
		'''   Handles the user "File | Open" menu operation.</summary>
		Private Sub OnOpen(ByVal target As Object, ByVal args As ExecutedRoutedEventArgs)
			' Create a "File Open" dialog positioned to the
			' "Content\" folder containing the sample images.
			Dim dialog As New WinForms.OpenFileDialog()
			dialog.InitialDirectory = GetContentFolder()
			dialog.CheckFileExists = True
			dialog.Filter = "Image files (*.png,*.jpg,*.jpeg, *.protected)|" & "*.png;*.jpg;*.jpeg;*.protected|All (*.*)|*.*"

			' Show the "File Open" dialog.  If the user
			' clicks "Cancel", cancel the File|Open operation.
			If dialog.ShowDialog() <> True Then
				Return
			End If

			' clicks "OK", load and display the specified file.
			CloseContent() ' Close current file if open.
			_contentFile = dialog.FileName ' Save new path and file name.
			ShowStatus("Opening '" & Filename(_contentFile) & "'")

			' Check to see if the file name shows as "protected" or
			' "encrypted".  If encrypted, use OpenEncryptedContent().
			Dim opened As Boolean
			If _contentFile.ToLower().Contains("protected") OrElse _contentFile.ToLower().Contains("encrypted") Then
				opened = OpenEncryptedContent(_contentFile)

			' Otherwise open as unencrypted.
			Else
				opened = OpenContent(_contentFile)
			End If

			' If the file was successfully opened, show the file name,
			' enable File|Close, and give focus to the Image control.
			If opened = True Then
				Me.Title = "RightsManagedContentViewer SDK Sample - " & Filename(_contentFile)
				menuFileClose.IsEnabled = True
				imageViewer.Focus()
			End If
		End Sub ' end:OnOpen()


		' --------------------------- OpenContent ---------------------------
		''' <summary>
		'''   Loads and displays a given content file.</summary>
		''' <param name="filename">
		'''   The path and filename of the content file
		'''   to load and display.</param>
		''' <returns>
		'''   true if the content loads successfully; otherwise false.</returns>
		Public Function OpenContent(ByVal filename As String) As Boolean
			' If the file is not a supported image, do not try to display it.
			If (Not filename.EndsWith(".png")) AndAlso (Not filename.EndsWith(".jpg")) AndAlso (Not filename.EndsWith(".jpeg")) Then
				MessageBox.Show(filename & vbLf & vbLf & "This file type extension " & "is not supported.  This sample is designed to display " & "png, jpg, or jpeg image files.", "Unsupported File Type", MessageBoxButton.OK, MessageBoxImage.Error)
				Return False
			End If

			' If the file is a supported image, show it in the image control.
			Try
				'<SnippetRMContViewBitmap1>
				Dim bi As New BitmapImage()
				bi.BeginInit()
				bi.UriSource = New Uri(filename) ' path and file name.
				bi.EndInit()
                ImageViewerProperty.Source = bi
				'</SnippetRMContViewBitmap1>
			Catch ex As Exception
				MessageBox.Show(filename & vbLf & vbLf & "The specified file " & "in not a valid unprotected image file." & vbLf & vbLf & "Exception: " & ex.Message & vbLf & vbLf & ex.GetType().ToString() & vbLf & vbLf & ex.StackTrace, "Invalid File Format", MessageBoxButton.OK, MessageBoxImage.Error)
				Return False
			End Try

			Return True
		End Function ' end:OpenContent()


		' ---------------------- OpenEncryptedContent -----------------------
		''' <summary>
		'''   Loads and displays a given encrypted content file.</summary>
		''' <param name="encryptedFile">
		'''   The path and name of the encrypted file to display.</param>
		''' <returns>
		'''   true if the file loads successfully; otherwise false.</returns>
		Public Function OpenEncryptedContent(ByVal encryptedFile As String) As Boolean
			' Get the ID of the current user log-in.
			Dim currentUserId As String
			Try
					currentUserId = GetDefaultWindowsUserName()
			Catch
					currentUserId = Nothing
			End Try
			If currentUserId Is Nothing Then
				MessageBox.Show("No valid user ID available", "Invalid User ID", MessageBoxButton.OK, MessageBoxImage.Error)
				ShowStatus("   No valid user ID available.")
				Return False
			End If

			ShowStatus("   Current user ID:  '" & currentUserId & "'")
			ShowStatus("   Using " & _authentication & " authentication.")
			ShowStatus("   Checking rights list for user:" & vbLf & "       " & currentUserId)
			ShowStatus("   Initializing the environment.")

			Try
				Dim applicationManifest As String = "<manifest></manifest>"
				If File.Exists("rvc.xml") Then
					ShowStatus("   Reading manifest 'rvc.xml'.")
					Dim manifestReader As StreamReader = File.OpenText("rvc.xml")
					applicationManifest = manifestReader.ReadToEnd()
				End If

				If _secureEnv Is Nothing Then
					ShowStatus("   Initiating SecureEnvironment as user:" & vbLf & "   " & "    " & currentUserId & " [" & _authentication & "]")
					If SecureEnvironment.IsUserActivated(New ContentUser(currentUserId, _authentication)) Then
						ShowStatus("   User is already activated.")
						_secureEnv = SecureEnvironment.Create(applicationManifest, New ContentUser(currentUserId, _authentication))
					Else ' if user is not yet activated.
						ShowStatus("   User is NOT activated," & vbLf & "       activating now....")
						' If using the current Windows user, no credentials are
						' required and we can use UserActivationMode.Permanent.
						_secureEnv = SecureEnvironment.Create(applicationManifest, _authentication, UserActivationMode.Permanent)

						' If not using the current Windows user, use
						' UserActivationMode.Temporary to display the Windows
						' credentials pop-up window.
						'  _secureEnv = SecureEnvironment.Create(
						'                        applicationManifest,
						'                        _authentication,
						'                        UserActivationMode.Temporary)
					End If
					ShowStatus("   Created SecureEnvironment for user:" & vbLf & "       " & _secureEnv.User.Name & " [" & _secureEnv.User.AuthenticationType & "]")
				End If

				' If the file is a supported image, show it in the image control.
				Try
					' In this sample a UseLicense is provided with the example
					' content files.  If the UseLicense for the current user
					' does not exist, the following steps can be performed to
					' obtain a UseLicense:
					'   1. Open the PublishLicense.
					'   2. Read the PublishLicense XML file to a string.
					'   3. Create a PublishLicense instance passing the
					'      PublishLicense string to the constructor.
					'   4. Pass the PublishLicense to the license server to
					'      obtain a UseLicense.

					' Check if there is a UseLicense for the encryptedFile.
					Dim useLicenseFile As String = encryptedFile
					If encryptedFile.EndsWith(".protected") Then
						useLicenseFile = useLicenseFile.Remove(useLicenseFile.Length - ".protected".Length)
					End If
					' Append ".UseLicense.xml" as the UseLicense file extension.
					useLicenseFile = useLicenseFile & ".UseLicense.xml"
					If Not File.Exists(useLicenseFile) Then
						MessageBox.Show(useLicenseFile & vbLf & vbLf & "UseLicense for '" & Filename(encryptedFile) & "' not found.", "UseLicense Not Found", MessageBoxButton.OK, MessageBoxImage.Error)
						ShowStatus("   UseLicense not found:" & vbLf & "      '" & Filename(useLicenseFile) & "'.")
						Return False
					End If

					ShowStatus("   Reading UseLicense '" & Filename(useLicenseFile) & "'.")
					Dim useLicenseStream As StreamReader = File.OpenText(useLicenseFile)
					Dim useLicenseString As String = useLicenseStream.ReadToEnd()
					Dim useLicense As New UseLicense(useLicenseString)

					'<SnippetRMContViewUseLicense>
					ShowStatus("   Binding UseLicense with the SecureEnvironment" & vbLf & "       to obtain the CryptoProvider.")
					Dim cryptoProvider As CryptoProvider = useLicense.Bind(_secureEnv)

					ShowStatus("   Obtaining BoundGrants.")
					Dim grants As ReadOnlyCollection(Of ContentGrant) = cryptoProvider.BoundGrants

					rightsBlockTitle.Text = "Rights - " & Filename(useLicenseFile)
					rightsBlock.Text = "GRANTS LIST" & vbLf & "-----------------" & vbLf
					For Each grant As ContentGrant In grants
						rightsBlock.Text &= "USER:  " & grant.User.Name & " [" & grant.User.AuthenticationType & "]" & vbLf
						rightsBlock.Text &= "RIGHT: " & grant.Right.ToString() & vbLf
						rightsBlock.Text &= "    From:  " & grant.ValidFrom & vbLf
						rightsBlock.Text &= "    Until: " & grant.ValidUntil & vbLf
					Next grant

					If cryptoProvider.CanDecrypt = True Then
						ShowStatus("   Decryption granted.")
					Else
						ShowStatus("   CANNOT DECRYPT!")
					End If
					'</SnippetRMContViewUseLicense>

					ShowStatus("   Decrypting '" & Filename(encryptedFile) &"'.")
					'<SnippetRMContViewDecrypt>
					Dim imageBuffer() As Byte
                    Using cipherTextStream As Stream = File.OpenRead(encryptedFile)
                        Dim expression As Int32
                        Dim contentLengthByteBuffer(Len(expression) - 1) As Byte
                        ' Read the length of the source content file
                        ' from the first four bytes of the encrypted file.
                        ReliableRead(cipherTextStream, contentLengthByteBuffer, 0, Len(expression))

                        ' Allocate the clearText buffer.
                        Dim contentLength As Integer = BitConverter.ToInt32(contentLengthByteBuffer, 0)
                        imageBuffer = New Byte(contentLength - 1) {}

                        ' Allocate the cipherText block.
                        Dim cipherTextBlock(cryptoProvider.BlockSize - 1) As Byte

                        ' decrypt cipherText to clearText block by block.
                        Dim imageBufferIndex As Integer = 0
                        Do
                            Dim readCount As Integer = ReliableRead(cipherTextStream, cipherTextBlock, 0, cryptoProvider.BlockSize)
                            ' readCount of zero is end of data.
                            If readCount = 0 Then
                                Exit Do ' for
                            End If

                            ' Decrypt cipherText to clearText.
                            Dim clearTextBlock() As Byte = cryptoProvider.Decrypt(cipherTextBlock)

                            ' Copy the clearTextBlock to the imageBuffer.
                            Dim copySize As Integer = Math.Min(clearTextBlock.Length, contentLength - imageBufferIndex)
                            Array.Copy(clearTextBlock, 0, imageBuffer, imageBufferIndex, copySize)
                            imageBufferIndex += copySize
                        Loop
                    End Using ' end:using (Stream cipherTextStream = (close/dispose)
					'</SnippetRMContViewDecrypt>

					ShowStatus("   Displaying decrypted image.")
					'<SnippetRMContViewBitmap2>
					Dim bitmapImage As New BitmapImage()
					bitmapImage.BeginInit()
					bitmapImage.StreamSource = New MemoryStream(imageBuffer)
					bitmapImage.EndInit()
                    ImageViewerProperty.Source = bitmapImage
					'</SnippetRMContViewBitmap2>
				Catch ex As Exception
					MessageBox.Show(encryptedFile & vbLf & vbLf & "The specified file " & "in not a valid unprotected image file." & vbLf & vbLf & "Exception: " & ex.Message & vbLf & vbLf & ex.GetType().ToString() & vbLf & vbLf & ex.StackTrace, "Invalid File Format", MessageBoxButton.OK, MessageBoxImage.Error)
					Return False
				End Try ' end:try
			Catch ex As Exception
				MessageBox.Show("Exception: " & ex.Message & vbLf & vbLf & ex.GetType().ToString() & vbLf & vbLf & ex.StackTrace, "Exception", MessageBoxButton.OK, MessageBoxImage.Error)
				Return False
			End Try

			Return True
		End Function ' end:OpenEncryptedContent()


		#End Region ' File|Open...


		#Region "File|Close"
		' ----------------------------- OnClosed -----------------------------
		''' <summary>
		'''   Performs clean up when the application is closed.</summary>
		Private Overloads Sub OnClosed(ByVal sender As Object, ByVal e As EventArgs)
			CloseContent()
		End Sub


		' ----------------------------- OnClose ------------------------------
		''' <summary>
		'''   Handles the user "File | Close" menu operation
		'''   to close the currently open document.</summary>
		Private Sub OnClose(ByVal target As Object, ByVal args As ExecutedRoutedEventArgs)
			CloseContent()
		End Sub


		' --------------------------- CloseContent --------------------------
		''' <summary>
		'''   Closes the currently opened content file.</summary>
		Public Sub CloseContent()
			If _contentFile IsNot Nothing Then
				ShowStatus("Closing '" & Filename(_contentFile) & "'")
				_contentFile = Nothing
			End If

			' Clear the Image control and disable the File|Close menu option.
			imageViewer.Source = Nothing
			Me.Title = "RightsManagedContentViewer SDK Sample"
			menuFileClose.IsEnabled = False

			' Reset any information in the Rights block.
			rightsBlockTitle.Text = "Rights"
			rightsBlock.Text = ""
			ShowPrompt("Click 'File | Open...' to select a file to open and view.")
		End Sub ' end:CloseContent
		#End Region ' File|Close


		#Region "File|Exit"
		' ------------------------------ OnExit ------------------------------
		''' <summary>
		'''   Handles the user File|Exit menu selection to
		'''   shutdown and exit the application.</summary>
		Private Sub OnExit(ByVal sender As Object, ByVal e As EventArgs)
			Close() ' invokes OnClosed()
		End Sub ' end:OnExit()
		#End Region ' File|Exit


		#Region "Utilities"

		' ---------------------------- ReliableRead --------------------------
		''' <summary>
		'''   Reads a specified number of bytes from a given stream.</summary>
		''' <param name="stream">
		'''   The stream to read from.</param>
		''' <param name="buffer">
		'''   The buffer to read to.</param>
		''' <param name="offset">
		'''   The offset in the buffer to start reading into.</param>
		''' <param name="requiredCount">
		'''   The required number of bytes to read.</param>
		''' <returns>
		'''   The number of bytes read.</returns>
		''' <remarks>
		'''   <rem>At end of file the number of bytes read will be
		'''   less than the requiredCount or zero (0).</rem>
		'''   <rem>ReliableRead supports read operations from generic mediums
		'''   such as a local file, network file, database, or web service that
		'''   may otherwise return partial buffer lengths.</rem>
		''' </remarks>
		'''
		Private Shared Function ReliableRead(ByVal stream As Stream, ByVal buffer() As Byte, ByVal offset As Integer, ByVal requiredCount As Integer) As Integer
			' Read a whole block into the buffer.
			Dim totalBytesRead As Integer = 0
			Do While totalBytesRead < requiredCount
				Dim bytesRead As Integer = stream.Read(buffer, offset + totalBytesRead, requiredCount - totalBytesRead)
				If bytesRead = 0 Then ' while
					Exit Do
				End If
				totalBytesRead += bytesRead
			Loop
			Return totalBytesRead
		End Function ' end:ReliableRead()

		' ------------------------- GetContentFolder -------------------------
		''' <summary>
		'''   Locates and returns the path to the "Content\" folder
		'''   containing the fixed document for the sample.</summary>
		''' <returns>
		'''   The path to the fixed document "Content\" folder.</returns>
		Public Function GetContentFolder() As String
			' Get the path to the current directory and its length.
			Dim contentDir As String = Directory.GetCurrentDirectory()
			Dim dirLength As Integer = contentDir.Length

			' If we're in "...\bin\debug", move up to the root.
			If contentDir.ToLower().EndsWith("\bin\debug") Then
				contentDir = contentDir.Remove(dirLength - 10, 10)

			' If we're in "...\bin\release", move up to the root.
			ElseIf contentDir.ToLower().EndsWith("\bin\release") Then
				contentDir = contentDir.Remove(dirLength - 12, 12)
			End If

			' If there's a "Content" subfolder, that's what we want.
			If Directory.Exists(contentDir & "\Content") Then
				contentDir = contentDir & "\Content"
			End If

			' Return the "Content\" folder (or the "current"
			' directory if we're executing somewhere else).
			Return contentDir
		End Function ' end:GetContentFolder()


		' ------------------------------ Filename ----------------------------
		''' <summary>
		'''   Returns just the filename from a given path and filename.</summary>
		''' <param name="filepath">
		'''   A path and filename.</param>
		''' <returns>
		'''   The filename with extension.</returns>
		Private Shared Function Filename(ByVal filepath As String) As String
			' Locate the index of the last backslash.
			Dim slashIndex As Integer = filepath.LastIndexOf("\"c)

			' If there is no backslash, return the original string.
			If slashIndex < 0 Then
				Return filepath
			End If

			' Remove all the characters through the last backslash.
			Return filepath.Remove(0, slashIndex + 1)
		End Function


		' --------------------------- ShowStatus -----------------------------
		''' <summary>
		'''   Adds a line of text to the statusBlock.</summary>
		''' <param name="status">
		'''   A line of text to add to the status TextBlock.</param>
		Public Sub ShowStatus(ByVal status As String)
			statusBlock.Text += status & vbLf
		End Sub


		' ---------------------------- ShowPrompt ----------------------------
		''' <summary>
		'''   Displays a line of text in the prompt bar.</summary>
		''' <param name="prompt">
		'''   The line of text to display in the prompt bar.</param>
		Public Sub ShowPrompt(ByVal prompt As String)
			promptBlock.Text = prompt
		End Sub


		' --------------------- OnWindowsAuthentication ----------------------
		''' <summary>
		'''   Sets rights management for Windows authentication.</summary>
		Private Sub OnWindowsAuthentication(ByVal sender As Object, ByVal e As EventArgs)
			menuViewWindows.IsChecked = True
			menuViewPassport.IsChecked = False
			_authentication = AuthenticationType.Windows
		End Sub


		' --------------------- OnPassportAuthentication ---------------------
		''' <summary>
		'''   Sets rights management for Windows authentication.</summary>
		Private Sub OnPassportAuthentication(ByVal sender As Object, ByVal e As EventArgs)
			menuViewWindows.IsChecked = False
			menuViewPassport.IsChecked = True
			_authentication = AuthenticationType.Passport
		End Sub


		' -------------------- GetDefaultWindowsUserName() -------------------
		''' <summary>
		'''   Returns the email address of the current user log-in.</summary>
		''' <returns>
		'''   The email address of the current user.</returns>
		<SecurityPermissionAttribute(SecurityAction.Demand, Flags := SecurityPermissionFlag.UnmanagedCode)>
		Friend Shared Function GetDefaultWindowsUserName() As String
			' Get the identity of the currently logged in user.
			Dim wi As System.Security.Principal.WindowsIdentity = System.Security.Principal.WindowsIdentity.GetCurrent()

			' Get the user's domain and alias.
			Dim splitUserName() As String = wi.Name.Split("\"c)

			Dim src As New System.DirectoryServices.DirectorySearcher()
			src.SearchRoot = New System.DirectoryServices.DirectoryEntry("LDAP://" & splitUserName(0))

			src.PropertiesToLoad.Add("mail")

			src.Filter = String.Format("(&(objectCategory=person) " & "(objectClass=user) (SAMAccountName={0}))", splitUserName(1))

			Dim result As System.DirectoryServices.SearchResult = src.FindOne()

			' Return the email address of the currently logged in user.
			Return (CStr(result.Properties("mail")(0)))
		End Function ' end:GetDefaultWindowsUserName()


		' ----------------------- ImageViewer attribute ------------------------
		''' <summary>
		'''   Gets the Image viewer control.</summary>
        Public ReadOnly Property ImageViewerProperty() As Image
            Get
                Return imageViewer
            End Get
        End Property
		#End Region ' Utilities


		#Region "private fields"
		Private _contentFile As String=Nothing ' content path and filename.
		Private _authentication As AuthenticationType = AuthenticationType.Windows
		Private Shared _secureEnv As SecureEnvironment = Nothing
		Private Shared _currentUserId As String = GetDefaultWindowsUserName()
		#End Region ' private fields


	End Class ' end:partial class Window1

End Namespace ' end:namespace SdkSample