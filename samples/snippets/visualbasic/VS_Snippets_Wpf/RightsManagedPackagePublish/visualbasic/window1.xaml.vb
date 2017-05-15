' RightsManagedPackagePublish Sample - Window1.xaml.vb
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
			' If a document is currently open, check with the user
			' if it's ok to close it before opening a new one.
			If _xpsPackage IsNot Nothing Then
				Dim msg As String = "The currently open document needs to be closed before" & vbLf & "opening a new document.  Ok to close '" & _xpsDocumentName &"'?"
				Dim result As MessageBoxResult = MessageBox.Show(msg, "Close Current Document?", MessageBoxButton.OKCancel, MessageBoxImage.Question)

				' If the user did not click OK to close current
				' document, cancel the File | Open request.
				If (result <> MessageBoxResult.OK) Then
					Return
				End If

				' The user clicked OK, close the current document and continue.
				CloseDocument()
				CloseXrML()
			End If

			' Create a "File Open" dialog positioned to the
			' "Content\" folder containing the sample fixed document.
			Dim dialog As New WinForms.OpenFileDialog()
			dialog.InitialDirectory = GetContentFolder()
			dialog.CheckFileExists = True
			dialog.Filter = "XPS Document files (*.xps)|*.xps"

			' Show the "File Open" dialog.  If the user picks a file and
			' clicks "OK", load and display the specified XPS document.
			If dialog.ShowDialog() = True Then
				OpenDocument(dialog.FileName)
			End If

		End Sub ' end:OnOpen()


		' --------------------------- OpenDocument ---------------------------
		''' <summary>
		'''   Loads and displays a given XPS document file.</summary>
		''' <param name="filename">
		'''   The path and filename of the XPS document
		'''   to load and display.</param>
		''' <returns>
		'''   true if the document loads successfully; otherwise false.</returns>
		Public Function OpenDocument(ByVal filename As String) As Boolean
			' Save the document path and filename.
			_xpsDocumentPath = filename

			' Extract the document filename without the path.
			_xpsDocumentName = filename.Remove(0, filename.LastIndexOf("\"c)+1)

			_packageUri = New Uri(filename, UriKind.Absolute)
			Try
				_xpsDocument = New XpsDocument(filename, FileAccess.Read)
			Catch e1 As System.IO.FileFormatException
				Dim msg As String = filename & vbLf & vbLf & "The specified file " & "in not a valid unprotected XPS document." & vbLf & vbLf & "The file is possibly encrypted with rights management.  " & "Please see the RightsManagedPackageViewer" & vbLf & "sample that " & "shows how to access and view a rights managed XPS document."
				MessageBox.Show(msg, "Invalid File Format", MessageBoxButton.OK, MessageBoxImage.Error)
				Return False
			End Try

			' Get the document's PackageStore into which
			' new user annotations will be added and saved.
			_xpsPackage = PackageStore.GetPackage(_packageUri)
			If (_xpsPackage Is Nothing) OrElse (_xpsDocument Is Nothing) Then
				MessageBox.Show("Unable to get Package from file.")
				Return False
			End If

			' Get the FixedDocumentSequence from the open document.
			Dim fds As FixedDocumentSequence = _xpsDocument.GetFixedDocumentSequence()
			If fds Is Nothing Then
				Dim msg As String = filename & vbLf & vbLf & "The document package within the specified " & "file does not contain a FixedDocumentSequence."
				MessageBox.Show(msg, "Package Error")
				Return False
			End If

			' Load the FixedDocumentSequence to the DocumentViewer control.
			docViewer.Document = fds

			' Enable document menu controls.
			menuFileClose.IsEnabled = True
			menuFilePrint.IsEnabled = True
			menuFileRights.IsEnabled = True
			menuViewIncreaseZoom.IsEnabled = True
			menuViewDecreaseZoom.IsEnabled = True

			' Give the DocumentViewer focus.
			docViewer.Focus()

			WriteStatus("Opened '" & _xpsDocumentName & "'")
			WritePrompt("Click 'File | Rights...' to select an " & "eXtensible Rights Markup (XrML) permissions file.")
			Return True
		End Function ' end:OpenDocument()


		' ------------------- GetFixedDocumentSequenceUri --------------------
		''' <summary>
		'''   Returns the part URI of first FixedDocumentSequence
		'''   contained in the package.</summary>
		''' <returns>
		'''   The URI of first FixedDocumentSequence in the package,
		'''   or null if no FixedDocumentSequence is found.</returns>
		Private Function GetFixedDocumentSequenceUri() As Uri
			' Iterate through the package parts
			' to find first FixedDocumentSequence.
			For Each part As PackagePart In _xpsPackage.GetParts()
				If part.ContentType = _fixedDocumentSequenceContentType Then
					Return part.Uri
				End If
			Next part

			' Return null if a FixedDocumentSequence isn't found.
			Return Nothing
		End Function ' end:GetFixedDocumentSequenceUri()


		' --------------------------- GetPackage -----------------------------
		''' <summary>
		'''   Returns the XPS package contained within a given file.</summary>
		''' <param name="filename">
		'''   The path and name of the file containing the package.</param>
		''' <returns>
		'''   The package contained within the specifed file.</returns>
		Private Function GetPackage(ByVal filename As String) As Package
			Dim inputPackage As Package = Nothing

			' "filename" should be the full path and name of the file.
			Dim webRequest As WebRequest = System.Net.WebRequest.Create(filename)
			If webRequest IsNot Nothing Then
				Dim webResponse As WebResponse = webRequest.GetResponse()
				If webResponse IsNot Nothing Then
					Dim inputPackageStream As Stream = webResponse.GetResponseStream()
					If inputPackageStream IsNot Nothing Then
						inputPackage = Package.Open(inputPackageStream)
					End If
				End If
			End If

			Return inputPackage
		End Function ' end:GetPackage()


		'<SnippetRmPkgPubGetFixDoc>
		' ------------------------ GetFixedDocument --------------------------
		''' <summary>
		'''   Returns the fixed document at a given URI within
		'''   the currently open XPS package.</summary>
		''' <param name="fixedDocUri">
		'''   The URI of the fixed document to return.</param>
		''' <returns>
		'''   The fixed document at a given URI
		'''   within the current XPS package.</returns>
		Private Function GetFixedDocument(ByVal fixedDocUri As Uri) As FixedDocument
			Dim fixedDocument As FixedDocument = Nothing

			' Create the URI for the fixed document within the package. The URI
			' is used to set the Parser context so fonts & other items can load.
			Dim tempUri As New Uri(_xpsDocumentPath, UriKind.RelativeOrAbsolute)
			Dim parserContext As New ParserContext()
			parserContext.BaseUri = PackUriHelper.Create(tempUri)

			' Retreive the fixed document.
			Dim fixedDocPart As PackagePart = _xpsPackage.GetPart(fixedDocUri)
			If fixedDocPart IsNot Nothing Then
				Dim fixedObject As Object = XamlReader.Load(fixedDocPart.GetStream(), parserContext)
				If fixedObject IsNot Nothing Then
					fixedDocument = TryCast(fixedObject, FixedDocument)
				End If
			End If

			Return fixedDocument
		End Function ' end:GetFixedDocument()
		'</SnippetRmPkgPubGetFixDoc>
		#End Region ' File|Open...


		#Region "File|Close"
		' ----------------------------- OnClosed -----------------------------
		''' <summary>
		'''   Performs clean up when the application is closed.</summary>
		Private Overloads Sub OnClosed(ByVal sender As Object, ByVal e As EventArgs)
			CloseDocument()
		End Sub ' end:OnClosed()


		' ----------------------------- OnClose ------------------------------
		''' <summary>
		'''   Handles the user "File | Close" menu operation
		'''   to close the currently open document.</summary>
		Private Sub OnClose(ByVal target As Object, ByVal args As ExecutedRoutedEventArgs)
			CloseDocument()
		End Sub ' end:OnClose()


		' --------------------------- CloseDocument --------------------------
		''' <summary>
		'''   Closes the document currently displayed in
		'''   the DocumentViewer control.</summary>
		Public Sub CloseDocument()
			' Remove the document from the DocumentViewer control.
			docViewer.Document = Nothing

			' If the package is open, close it.
			If _xpsPackage IsNot Nothing Then
				_xpsPackage.Close()
				_xpsPackage = Nothing
			End If

			If _packageUri IsNot Nothing Then
				PackageStore.RemovePackage(_packageUri)
			End If

			' Disable document-related selections when there's no document.
			menuFileClose.IsEnabled = False
			menuFilePrint.IsEnabled = False
			menuViewIncreaseZoom.IsEnabled = False
			menuViewDecreaseZoom.IsEnabled = False
			WriteStatus("Closed '" & _xpsDocumentName & "'")
			WritePrompt("Click 'File | Open...' to select a file to open and view.")

			' Close the XrML file.
			CloseXrML()

		End Sub ' end:CloseDocument
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

			' Extract just the XrML filename without the path.
			_xrmlFilename = filename.Remove(0, filename.LastIndexOf("\"c) + 1)

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
			' "Content\" folder to write the encrypted package to.
			Dim dialog As New WinForms.SaveFileDialog()
			dialog.InitialDirectory = GetContentFolder()
			dialog.Title = "Publish Rights Managed Package As"
			dialog.Filter = "Rights Managed XPS package (*-RM.xps)|*-RM.xps"

			' Create a new package filename by prefixing
			' the document filename extension with "rm".
			dialog.FileName = _xpsDocumentPath.Insert(_xpsDocumentPath.LastIndexOf("."c), "-RM")

			' Show the "Save As" dialog. If the user clicks "Cancel", return.
			If dialog.ShowDialog() <> True Then
				Return
			End If

			' Extract the filename without path.
			_rmxpsPackagePath = dialog.FileName
			_rmxpsPackageName = _rmxpsPackagePath.Remove(0, _rmxpsPackagePath.LastIndexOf("\"c)+1)

			WriteStatus("Publishing '" & _rmxpsPackageName & "'.")
			PublishRMPackage(_xpsDocumentPath, _xrmlFilepath, dialog.FileName)

		End Sub ' end:OnPublish()


		' ------------------------ PublishRMPackage --------------------------
		''' <summary>
		'''   Writes an encrypted righted managed package.</summary>
		''' <param name="packageFilepath">
		'''   The path and filename of the source document package.</param>
		''' <param name="filename">
		'''   The path and filename of the XrML rights management file.</param>
		''' <param name="encryptedFilepath">
		'''   The path and filename for writing the RM encrypted package.</param>
		''' <returns>
		'''   true if the encrypted package is written successfully;
		'''   otherwise false.</returns>
		Public Function PublishRMPackage(ByVal packageFile As String, ByVal xrmlFile As String, ByVal encryptedFile As String) As Boolean
			Dim xrmlString As String

			' Extract individual filenames without the path.
			Dim packageFilename As String = packageFile.Remove(0, packageFile.LastIndexOf("\"c)+1)
			Dim xrmlFilename As String = xrmlFile.Remove(0, xrmlFile.LastIndexOf("\"c)+1)
			Dim encryptedFilename As String = encryptedFile.Remove(0, encryptedFile.LastIndexOf("\"c)+1)

			Try
				'<SnippetRmPkgPubUnPubLic>
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
				'</SnippetRmPkgPubUnPubLic>

				'<SnippetRmPkgBldSecEnv>
				WriteStatus("   Building secure environment.")
				Try
					'<SnippetRmPkgPubSecEnv>
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
					'</SnippetRmPkgPubSecEnv>
				Catch ex As RightsManagementException
					MessageBox.Show("ERROR: Failed to build secure environment." & vbLf & "Exception: " & ex.Message & vbLf & vbLf & ex.FailureCode.ToString() & vbLf & vbLf & ex.StackTrace, "Rights Management Exception", MessageBoxButton.OK, MessageBoxImage.Error)
					Return False
				End Try
				'</SnippetRmPkgBldSecEnv>

				' If using Windows authentication and the Xrml owner name
				' does not match the current log-in name, show error message
				If (author.AuthenticationType = AuthenticationType.Windows) AndAlso (author.Name <> _currentUserId) Then
					MessageBox.Show("ERROR: The current user name does not " & "match the UnsignedPublishLicense owner." & vbLf & "Please check the owner <NAME> element contained in '" & xrmlFilename & "'" & vbLf & vbLf & "Current user log-in ID: " & _currentUserId & vbLf & "XrML UnsignedPublishLicense owner name: " & author.Name, "Incorrect Authentication Name", MessageBoxButton.OK, MessageBoxImage.Error)
				   Return False
				End If

				'<SnippetRmPkgPubEncrypt>
				WriteStatus("   Signing the UnsignedPublishLicense" & vbLf & "       to build the PublishLicense.")
                Dim authorsUseLicense As UseLicense = Nothing
				Dim publishLicense As PublishLicense = unsignedLicense.Sign(_secureEnv, authorsUseLicense)

				WriteStatus("   Binding the author's UseLicense and")
				WriteStatus("       obtaining the CryptoProvider.")
				Dim cryptoProvider As CryptoProvider = authorsUseLicense.Bind(_secureEnv)

				WriteStatus("   Creating the EncryptedPackage.")
				Dim packageStream As Stream = File.OpenRead(packageFile)
				Dim ePackage As EncryptedPackageEnvelope = EncryptedPackageEnvelope.CreateFromPackage(encryptedFile, packageStream, publishLicense, cryptoProvider)

				WriteStatus("   Adding an author's UseLicense.")
				Dim rmi As RightsManagementInformation = ePackage.RightsManagementInformation
				rmi.SaveUseLicense(author, authorsUseLicense)

				ePackage.Close()
				WriteStatus("   Done - Package encryption complete.")

				WriteStatus("Verifying package encryption.")
				If EncryptedPackageEnvelope.IsEncryptedPackageEnvelope(encryptedFile) Then
					WriteStatus("   Confirmed - '" & encryptedFilename & "' is encrypted.")
				Else
					MessageBox.Show("ERROR: '" & encryptedFilename & "' is NOT ENCRYPTED.", "Encryption Error", MessageBoxButton.OK, MessageBoxImage.Error)
					WriteStatus("ERROR: '" & encryptedFilename & "' is NOT ENCRYPTED." & vbLf)
					Return False
				End If
				'</SnippetRmPkgPubEncrypt>
			Catch ex As Exception
				MessageBox.Show("Exception: " & ex.Message & vbLf & vbLf & ex.GetType().ToString() & vbLf & vbLf & ex.StackTrace, "Runtime Exception", MessageBoxButton.OK, MessageBoxImage.Error)
				Return False
			End Try

			WritePrompt("See the RightsManagedPackageViewer sample for details " & "on how to access the content of a rights managed package.")
			Return True
		End Function ' end:PublishRMPackage()


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


		' ------------------------- WriteStatus --------------------------
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


		' ----------------------------- OnPrint ------------------------------
		''' <summary>
		'''   Handles the user "File | Print" menu operation.</summary>
		Private Sub OnPrint(ByVal target As Object, ByVal args As ExecutedRoutedEventArgs)
			PrintDocument()
		End Sub ' end:OnClose()


		' -------------------------- PrintDocument ---------------------------
		''' <summary>
		'''   Prints the DocumentViewer's content and annotations.</summary>
		Public Sub PrintDocument()
			If docViewer Is Nothing Then
				Return
			End If
			docViewer.Print()

		End Sub ' end:PrintDocument()


		' ----------------------- DocViewer attribute ------------------------
		''' <summary>
		'''   Gets the current DocumentViewer.</summary>
        Public ReadOnly Property DocViewerProperty() As DocumentViewer
            Get
                Return docViewer '"docViewer" declared in Window1.xaml
            End Get
        End Property
		#End Region ' Utilities


		#Region "private fields"
		Private _xrmlFilepath As String = Nothing ' xrml path and filename.
		Private _xrmlFilename As String = Nothing ' xrml filename without path.
		Private _xrmlString As String = Nothing ' xrml string.
		Private _xpsDocumentPath As String=Nothing ' XPS doc path and filename.
		Private _xpsDocumentName As String=Nothing ' XPS doc filename without path.
		Private _rmxpsPackagePath As String=Nothing ' RM package path and filename.
		Private _rmxpsPackageName As String=Nothing ' RM package name without path.
		Private _packageUri As Uri ' XPS document path and filename URI.
		Private _xpsPackage As Package = Nothing ' XPS document package.
		Private _xpsDocument As XpsDocument ' XPS document within the package.
		Private Shared _secureEnv As SecureEnvironment = Nothing
		Private Shared _currentUserId As String = GetDefaultWindowsUserName()
		Private ReadOnly _fixedDocumentSequenceContentType As String = "application/vnd.ms-package.xps-fixeddocumentsequence+xml"
		#End Region ' private fields


	End Class ' end:partial class Window1

End Namespace ' end:namespace SdkSample