' RightsManagedContentPublish Sample - Window1.xaml.vb
' Copyright (c) Microsoft Corporation. All rights reserved.


Imports System
Imports System.IO
Imports System.IO.Packaging
Imports System.Net
Imports System.Security.RightsManagement
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Markup
Imports System.Windows.Media.Imaging
Imports System.Windows.Xps.Packaging
Imports System.Xml
Imports WinForms = Microsoft.Win32
Imports Microsoft.VisualBasic

Namespace SdkSample
	' ========================= partial class Window1 ========================
	''' <summary>
	'''   Interaction logic for Window1.xaml</summary>
	Partial Public Class Window1
		Inherits Window
		' ------------------------ Window1 constructor -----------------------
		Public Sub New()
			MyBase.New()
			InitializeComponent()

			WritePrompt("Click 'File | Open...' to select a file to open and view.")
		End Sub


		#Region "File|Open..."
		' ------------------------------ OnOpen ------------------------------
		''' <summary>
		'''   Handles the user "File | Open" menu operation.</summary>
		Private Sub OnOpen(ByVal target As Object, ByVal args As ExecutedRoutedEventArgs)
			' If a content file is currently open, check with the user
			' if it's ok to close it before opening a new one.
			If _contentFilename IsNot Nothing Then
				Dim msg As String = "The currently open file needs to be closed before" & vbLf & "opening a one.  Ok to close '" & _contentFilename &"'?"
				Dim result As MessageBoxResult = MessageBox.Show(msg, "Close Current File?", MessageBoxButton.OKCancel, MessageBoxImage.Question)

				' If the user did not click OK to close current
				' file, cancel the File | Open request.
				If (result <> MessageBoxResult.OK) Then
					Return
				End If

				' The user clicked OK, close the current file and continue.
				CloseContent()
				CloseXrML()
			End If

			' Create a "File Open" dialog positioned to the
			' "Content\" folder containing the sample fixed document.
			Dim dialog As New WinForms.OpenFileDialog()
			dialog.InitialDirectory = GetContentFolder()
			dialog.CheckFileExists = True
			dialog.Filter = "Image files (*.png,*.jpg,*.jpeg)|" & "*.png;*.jpg;*.jpeg|All (*.*)|*.*"

			' Show the "File Open" dialog.  If the user picks a file and
			' clicks "OK", load and display the specified XPS document.
			If dialog.ShowDialog() = True Then
				OpenContent(dialog.FileName)
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
			' Save the content path and filename.
			_contentFilepath = filename
			_contentFilename = FilenameOnly(filename)

			' If the file is a supported image, show it in the image control.
			If filename.EndsWith(".png") OrElse filename.EndsWith(".jpg") OrElse filename.EndsWith(".jpeg") Then
				Try
					'<SnippetRmContPubBitmap>
					Dim bi As New BitmapImage()
					bi.BeginInit()
					bi.UriSource = New Uri(filename) ' path and file name.
					bi.EndInit()
                    ImageViewerProperty.Source = bi
					'</SnippetRmContPubBitmap>
				Catch ex As Exception
					Dim msg As String = filename & vbLf & vbLf & "The specified file " & "in not a valid unprotected image file." & vbLf & vbLf & "The file is possibly encrypted with rights " & "management.  Please see the RightsManagedContentViewer" & vbLf & "sample that shows how to access a file with rights " & "managed content." & vbLf & vbLf & "Exception: " & ex.Message & vbLf & vbLf & ex.GetType().ToString() & vbLf & vbLf & ex.StackTrace
					MessageBox.Show(msg, "Invalid File Format", MessageBoxButton.OK, MessageBoxImage.Error)
					Return False
				End Try
			End If

			' Enable document menu controls.
			menuFileClose.IsEnabled = True
			menuFileRights.IsEnabled = True

			' Give the ImageViewer focus.
			imageViewer.Focus()

			WriteStatus("Opened '" & _contentFilename & "'")
			WritePrompt("Click 'File | Rights...' to select an " & "eXtensible Rights Markup (XrML) permissions file.")
			Return True
		End Function ' end:OpenContent()
		#End Region ' File|Open...


		#Region "File|Close"
		' ----------------------------- OnClosed -----------------------------
		''' <summary>
		'''   Performs clean up when the application is closed.</summary>
		Private Overloads Sub OnClosed(ByVal sender As Object, ByVal e As EventArgs)
			CloseContent()
		End Sub ' end:OnClosed()


		' ----------------------------- OnClose ------------------------------
		''' <summary>
		'''   Handles the user "File | Close" menu operation
		'''   to close the currently open document.</summary>
		Private Sub OnClose(ByVal target As Object, ByVal args As ExecutedRoutedEventArgs)
			CloseContent()
		End Sub ' end:OnClose()


		' --------------------------- CloseContent --------------------------
		''' <summary>
		'''   Closes the currently opened content file.</summary>
		Public Sub CloseContent()
			' Clear the Image control.
			imageViewer.Source = Nothing

			WriteStatus("Closed '" & _contentFilename & "'")
			_contentFilename = Nothing
			_contentFilepath = Nothing

			' Disable content-related menu selections.
			menuFileClose.IsEnabled = False
			WritePrompt("Click 'File | Open...' to select a file to open and view.")

			' Close the XrML file.
			CloseXrML()

		End Sub ' end:CloseContent
		#End Region ' File|Close


		#Region "File|Rights..."
		' ----------------------------- OnRights -----------------------------
		''' <summary>
		'''   Handles the user File|Rights... menu option to
		'''   select and load a digital rights .xrml file.</summary>
		Private Sub OnRights(ByVal sender As Object, ByVal e As EventArgs)
			' If an XrML is currently open, check with the user
			' if it's ok to close it before opening a new one.
			If _xrmlFilepath IsNot Nothing Then
				Dim msg As String = "The currently open eXtensible Rights Markup Language (XrML)" & vbLf & "document needs to be closed before opening a new document." & vbLf & "Ok to close '" & _xrmlFilename & "'?"
				Dim result As MessageBoxResult = MessageBox.Show(msg, "Close Current XrML?", MessageBoxButton.OKCancel, MessageBoxImage.Question)

				' If the user did not click OK to close current
				' document, cancel the File | Open request.
				If (result <> MessageBoxResult.OK) Then
					Return
				End If

				' The user clicked OK, close the current XrML file and continue.
				CloseXrML()
			End If

			' Create a "File Open" dialog positioned to the
			' "Content\" folder containing the sample fixed document.
			Dim dialog As New WinForms.OpenFileDialog()
			dialog.InitialDirectory = GetContentFolder()
			dialog.CheckFileExists = True
			dialog.Filter = "XrML Rights markup files (*.xrml)|*.xrml"

			' Show the "File Open" dialog.  If the user picks a file and
			' clicks "OK", load and display the specified XPS document.
			If dialog.ShowDialog() = True Then
				OpenXrML(dialog.FileName)
			End If

		End Sub ' end:OnRights()


		' ----------------------------- OpenXrML -----------------------------
		''' <summary>
		'''   Loads and displays a given XrML rights markup file.</summary>
		''' <param name="filename">
		'''   The path and filename of the XrML rights markup file
		'''   to load and display.</param>
		''' <returns>
		'''   true if the file loads successfully; otherwise false.</returns>
		Public Function OpenXrML(ByVal filename As String) As Boolean
			' Save the document path and filename.
			_xrmlFilepath = filename
			_xrmlFilename = FilenameOnly(filename)

			' Load the XrML file to the "rightsBlock" control.
			Using sr As New StreamReader(filename)
				_xrmlString = sr.ReadToEnd()
				rightsBlock.Text = _xrmlString
			End Using

			' Enable document menu controls.
			menuFilePublish.IsEnabled = True

			WriteStatus("Opened '" & _xrmlFilename & "'")
			WritePrompt("Click 'File | Publish...' to publish the document " & "package with the permissions specified in '" & _xrmlFilename & "'.")
			rightsBlockTitle.Text = "Rights - " & _xrmlFilename
			Return True
		End Function ' end:OpenXrML()


		' ----------------------------- CloseXrML ----------------------------
		''' <summary>
		'''   Closes the document currently displayed in
		'''   the DocumentViewer control.</summary>
		Public Sub CloseXrML()
			' If an Xrml file is open, close it.
			If _xrmlFilepath IsNot Nothing Then
				_xrmlFilepath = Nothing
				rightsBlock.Text = ""
				rightsBlockTitle.Text = "Rights"

				' Disable "File | Publish" when there's no XrML file.
				menuFilePublish.IsEnabled = False
				WriteStatus("Closed '" & _xrmlFilename & "'")
				_xrmlFilename = Nothing
			End If
		End Sub ' end:CloseXrML
		#End Region ' File|Rights...


		#Region "File|Publish..."
		' ---------------------------- OnPublish -----------------------------
		''' <summary>
		'''   Handles the File|Publish... menu selection to
		'''   write a digital rights encrypted document package.</summary>
		Private Sub OnPublish(ByVal sender As Object, ByVal e As EventArgs)
			' Create a "File Save" dialog positioned to the
			' "Content\" folder to write the encrypted content file to.
			Dim dialog As New WinForms.SaveFileDialog()
			dialog.InitialDirectory = GetContentFolder()
			dialog.Title = "Publish Rights Managed Content As"
			dialog.Filter = "Rights Managed content (*.protected)|*.protected"

			' Create a new content ".protected" file extension.
			dialog.FileName = _contentFilepath.Insert(_contentFilepath.Length, ".protected")

			' Show the "Save As" dialog. If the user clicks "Cancel", return.
			If dialog.ShowDialog() <> True Then
				Return
			End If

			' Extract the filename without path.
			_rmContentFilepath = dialog.FileName
			_rmContentFilename = FilenameOnly(_rmContentFilepath)

			WriteStatus("Publishing '" & _rmContentFilename & "'.")
			PublishRMContent(_contentFilepath, _xrmlFilepath, dialog.FileName)

		End Sub ' end:OnPublish()


		' ------------------------ PublishRMContent --------------------------
		''' <summary>
		'''   Writes an encrypted righted managed content file.</summary>
		''' <param name="contentFile">
		'''   The path and filename of the source content file.</param>
		''' <param name="xrmlFile">
		'''   The path and filename of the XrML rights management file.</param>
		''' <param name="encryptedFile">
		'''   The path and filename for writing the RM encrypted content.</param>
		''' <returns>
		'''   true if the encrypted package is written successfully;
		'''   otherwise false.</returns>
		Public Function PublishRMContent(ByVal contentFile As String, ByVal xrmlFile As String, ByVal encryptedFile As String) As Boolean
			Dim xrmlString As String

			' Extract individual filenames without the path.
			Dim contentFilename As String = FilenameOnly(contentFile)
			Dim xrmlFilename As String = FilenameOnly(xrmlFile)
			Dim encryptedFilename As String = FilenameOnly(encryptedFile)

			Try
				'<SnippetRmContPubUnsLic>
				WriteStatus("   Reading '" & xrmlFilename & "' permissions.")
				Try
					Dim sr As StreamReader = File.OpenText(xrmlFile)
					xrmlString = sr.ReadToEnd()
				Catch ex As Exception
					MessageBox.Show("ERROR: '" & xrmlFilename &"' open failed." & vbLf & "Exception: " & ex.Message, "XrML File Error", MessageBoxButton.OK, MessageBoxImage.Error)
					Return False
				End Try

				WriteStatus("   Building UnsignedPublishLicense")
				WriteStatus("       from '" & xrmlFilename & "'.")
				Dim unsignedLicense As New UnsignedPublishLicense(xrmlString)
				Dim author As ContentUser = unsignedLicense.Owner
				'</SnippetRmContPubUnsLic>

				WriteStatus("   Building secure environment.")
				Try
					'<SnippetRmContPubSecEnv>
					Dim applicationManifest As String = "<manifest></manifest>"
					If File.Exists("rpc.xml") Then
						Dim manifestReader As StreamReader = File.OpenText("rpc.xml")
						applicationManifest = manifestReader.ReadToEnd()
					End If

					If _secureEnv Is Nothing Then
						If SecureEnvironment.IsUserActivated(New ContentUser(_currentUserId, AuthenticationType.Windows)) Then
							_secureEnv = SecureEnvironment.Create(applicationManifest, New ContentUser(_currentUserId, AuthenticationType.Windows))
						Else
							_secureEnv = SecureEnvironment.Create(applicationManifest, AuthenticationType.Windows, UserActivationMode.Permanent)
						End If
					End If
					'</SnippetRmContPubSecEnv>
				Catch ex As RightsManagementException
					MessageBox.Show("ERROR: Failed to build secure environment." & vbLf & "Exception: " & ex.Message & vbLf & vbLf & ex.FailureCode.ToString() & vbLf & vbLf & ex.StackTrace, "Rights Management Exception", MessageBoxButton.OK, MessageBoxImage.Error)
					Return False
				End Try

				' If using Windows authentication and the Xrml owner name
				' does not match the current log-in name, show error message
				If (author.AuthenticationType = AuthenticationType.Windows) AndAlso (author.Name <> _currentUserId) Then
					MessageBox.Show("ERROR: The current user name does not " & "match the UnsignedPublishLicense owner." & vbLf & "Please check the owner <NAME> element contained in '" & xrmlFilename & "'" & vbLf & vbLf & "Current user log-in ID: " & _currentUserId & vbLf & "XrML UnsignedPublishLicense owner name: " & author.Name, "Incorrect Authentication Name", MessageBoxButton.OK, MessageBoxImage.Error)
				   Return False
				End If

				WriteStatus("   Signing the UnsignedPublishLicense" & vbLf & "       to create a signed PublishLicense.")
                Dim authorsUseLicense As UseLicense = Nothing
				Dim publishLicense As PublishLicense = unsignedLicense.Sign(_secureEnv, authorsUseLicense)

				' Save an XML version of the UseLicense.
				WriteStatus("   Saving UseLicense")
				Dim useLicenseFilepath As String = contentFile & ".UseLicense.xml"
				WriteStatus("       '" & FilenameOnly(useLicenseFilepath) & "'.")
				Dim useStream As New FileStream(useLicenseFilepath, FileMode.Create)
				Dim useWriter As New StreamWriter(useStream, System.Text.Encoding.ASCII)
				useWriter.WriteLine(authorsUseLicense.ToString())
				useWriter.Close()
				useStream.Close()

				' Save an XML version of the signed PublishLicense.
				WriteStatus("   Saving signed PublishLicense")
				Dim pubLicenseFilepath As String = contentFile & ".PublishLicense.xml"
				WriteStatus("       '" & FilenameOnly(pubLicenseFilepath) & "'.")
				Dim pubStream As New FileStream(pubLicenseFilepath, FileMode.Create)
				Dim pubWriter As New StreamWriter(pubStream, System.Text.Encoding.ASCII)
				pubWriter.WriteLine(publishLicense.ToString())
				pubWriter.Close()
				pubStream.Close()

				'<SnippetRmContPubEncrypt>
				WriteStatus("   Binding the author's UseLicense and")
				WriteStatus("       obtaining the CryptoProvider.")
				Using cryptoProvider As CryptoProvider = authorsUseLicense.Bind(_secureEnv)
					WriteStatus("   Writing encrypted content.")
					Using clearTextStream As Stream = File.OpenRead(contentFile)
						Using cryptoTextStream As Stream = File.OpenWrite(encryptedFile)
							' Write the length of the source content file
                            ' as the first four bytes of the encrypted file.
                            Dim expression As Int32
                            cryptoTextStream.Write(BitConverter.GetBytes(clearTextStream.Length), 0, Len(expression))

							' Allocate clearText buffer.
							Dim clearTextBlock(cryptoProvider.BlockSize - 1) As Byte

							' Encrypt clearText to cryptoText block by block.
							Do
								Dim readCount As Integer = ReliableRead(clearTextStream, clearTextBlock, 0, cryptoProvider.BlockSize)
								' readCount of zero is end of data.
								If readCount = 0 Then ' for
									Exit Do
								End If

								' Encrypt clearText to cryptoText.
								Dim cryptoTextBlock() As Byte = cryptoProvider.Encrypt(clearTextBlock)

								' Write cryptoText block.
								cryptoTextStream.Write(cryptoTextBlock, 0, cryptoTextBlock.Length)
							Loop
							WriteStatus("   Closing '" & encryptedFilename & "'.")
						End Using ' end:using (Stream cryptoTextStream =
					End Using ' end:using (Stream clearTextStream =
				End Using ' end:using (CryptoProvider cryptoProvider =
				WriteStatus("   Done - Content encryption complete.")
				'</SnippetRmContPubEncrypt>
			Catch ex As Exception
				MessageBox.Show("Exception: " & ex.Message & vbLf & vbLf & ex.GetType().ToString() & vbLf & vbLf & ex.StackTrace, "Runtime Exception", MessageBoxButton.OK, MessageBoxImage.Error)
				Return False
			End Try

			WritePrompt("See the RightsManagedContentViewer sample for " & "details on how to access rights managed content.")
			Return True
		End Function ' end:PublishRMContent()


		' ------------------ GetGetDefaultWindowsUserName() ------------------
		''' <summary>
		'''   Returns the email address of the current user.</summary>
		''' <returns>
		'''   The email address of the current user.</returns>
		Friend Shared Function GetDefaultWindowsUserName() As String
			' Get the identity of the currently logged in user.
			Dim wi As System.Security.Principal.WindowsIdentity
			wi = System.Security.Principal.WindowsIdentity.GetCurrent()

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
		#End Region ' File|Publish...


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


		' ---------------------------- WriteStatus ---------------------------
		''' <summary>
		'''   Adds a line of text to the statusBlock.</summary>
		''' <param name="status">
		'''   A line of text to add to the status TextBlock.</param>
		Public Sub WriteStatus(ByVal status As String)
			statusBlock.Text += status & vbLf
		End Sub


		' ---------------------------- WritePrompt ---------------------------
		''' <summary>
		'''   Writes a line of text to the prompt bar.</summary>
		''' <param name="prompt">
		'''   The line of text to write in the prompt bar.</param>
		Public Sub WritePrompt(ByVal prompt As String)
			promptBlock.Text = prompt
		End Sub


		' ---------------------------- FilenameOnly --------------------------
		''' <summary>
		'''   Returns the filename only from a given path and filename.</summary>
		''' <param name="filepath">
		'''   A path and filename.</param>
		''' <returns>
		'''   The filename with extension.</returns>
		Private Shared Function FilenameOnly(ByVal filepath As String) As String
			' Locate the index of the last backslash.
			Dim slashIndex As Integer = filepath.LastIndexOf("\"c)

			' If there is no backslash, return the original string.
			If slashIndex < 0 Then
				Return filepath
			End If

			' Remove all the characters through the last backslash.
			Return filepath.Remove(0, slashIndex + 1)
		End Function


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
		Private _xrmlFilepath As String = Nothing ' xrml path and filename.
		Private _xrmlFilename As String = Nothing ' xrml filename without path.
		Private _xrmlString As String = Nothing ' xrml string.
		Private _contentFilepath As String=Nothing ' content path and filename.
		Private _contentFilename As String=Nothing ' content filename without path.
		Private _rmContentFilepath As String=Nothing ' RM content path and filename.
		Private _rmContentFilename As String=Nothing ' RM content filename without path.
		Private Shared _secureEnv As SecureEnvironment = Nothing
		Private Shared _currentUserId As String = GetDefaultWindowsUserName()
		#End Region ' private fields


	End Class ' end:partial class Window1

End Namespace ' end:namespace SdkSample