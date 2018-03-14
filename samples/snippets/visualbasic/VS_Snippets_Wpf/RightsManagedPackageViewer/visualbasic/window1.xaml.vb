' RightsManagedPackageViewer Sample - Window1.xaml.vb
' Copyright (c) Microsoft Corporation. All rights reserved.


Imports System
Imports System.Collections.ObjectModel
Imports System.IO
Imports System.IO.Packaging
Imports System.Net
Imports System.Security.RightsManagement
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Markup
Imports System.Windows.Xps.Packaging
Imports System.Security.Permissions
Imports System.Xml
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
			' "Content\" folder containing the sample fixed document.
			Dim dialog As New WinForms.OpenFileDialog()
			dialog.InitialDirectory = GetContentFolder()
			dialog.CheckFileExists = True
			dialog.Filter = "XPS Document files (*.xps)|*.xps"

			' Show the "File Open" dialog.  If the user picks a file and
			' clicks "OK", load and display the specified XPS document.
			If dialog.ShowDialog() = True Then
				CloseDocument() ' Close current document if open.
				_xpsFile = dialog.FileName ' Save the path and file name.

				' Check to see if the document is encrypted.
				' If encrypted, use OpenEncryptedDocument().
				If EncryptedPackageEnvelope.IsEncryptedPackageEnvelope(_xpsFile) Then
					OpenEncryptedDocument(_xpsFile)

				' Otherwise open as a normal document.
				Else
					OpenDocument(_xpsFile)
				End If
			End If
		End Sub ' end:OnOpen()


		'<SnippetRmPkgViewOpenDoc>
		' --------------------------- OpenDocument ---------------------------
		''' <summary>
		'''   Loads and displays a given XPS document file.</summary>
		''' <param name="filename">
		'''   The path and file name of the XPS
		'''   document to load and display.</param>
		''' <returns>
		'''   true if the document loads successfully; otherwise false.</returns>
		Public Function OpenDocument(ByVal xpsFile As String) As Boolean
			' Check to see if the document is encrypted.
			' If encrypted, use OpenEncryptedDocument().
			If EncryptedPackageEnvelope.IsEncryptedPackageEnvelope(xpsFile) Then
				Return OpenEncryptedDocument(xpsFile)
			End If

			' Document is not encrypted, open normally.
			ShowStatus("Opening '" & Filename(xpsFile) & "'")

			_packageUri = New Uri(xpsFile, UriKind.Absolute)
			Try
				_xpsDocument = New XpsDocument(xpsFile, FileAccess.Read)
			Catch ex As System.IO.FileFormatException
				MessageBox.Show(xpsFile & vbLf & vbLf & "The file " & "is not a valid XPS document." & vbLf & vbLf & "Exception: " & ex.Message & vbLf & vbLf & ex.GetType().ToString() & vbLf & vbLf & ex.StackTrace, "Invalid File Format", MessageBoxButton.OK, MessageBoxImage.Error)
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
				MessageBox.Show(xpsFile & vbLf & vbLf & "The document package within " & "the specified file does not contain a " & "FixedDocumentSequence.", "Package Error")
				Return False
			End If

			' Load the FixedDocumentSequence to the DocumentViewer control.
            DocViewerProperty.Document = fds

			' Enable document menu controls.
			menuFileClose.IsEnabled = True
			menuFilePrint.IsEnabled = True
			menuViewIncreaseZoom.IsEnabled = True
			menuViewDecreaseZoom.IsEnabled = True

			' Give the DocumentViewer focus.
			docViewer.Focus()

			Me.Title = "RightsManagedPackageViewer SDK Sample - " & Filename(xpsFile)
			Return True
		End Function ' end:OpenDocument()
		'</SnippetRmPkgViewOpenDoc>


		' ---------------------- OpenEncryptedDocument -----------------------
		''' <summary>
		'''   Loads and displays a given encrypted XPS document file.</summary>
		''' <param name="xpsFile">
		'''   The path and filename of the encrypted XPS
		'''   document to load and display.</param>
		''' <returns>
		'''   true if the document loads successfully; otherwise false.</returns>
		<SecurityPermissionAttribute(SecurityAction.Demand, Flags := SecurityPermissionFlag.UnmanagedCode)>
		Public Function OpenEncryptedDocument(ByVal xpsFile As String) As Boolean
			' Check to see if the document is encrypted.
			' If not encrypted, use OpenDocument().
			If Not EncryptedPackageEnvelope.IsEncryptedPackageEnvelope(xpsFile) Then
				Return OpenDocument(xpsFile)
			End If

			ShowStatus("Opening encrypted '" & Filename(xpsFile) & "'")

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

				'<SnippetRmPkgViewSecEnv>
				ShowStatus("   Initiating SecureEnvironment as user: " & vbLf & "       " & currentUserId & " [" & _authentication & "]")
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
					'''_secureEnv = SecureEnvironment.Create(applicationManifest,
					'''     a_authentication, UserActivationMode.Temporary)
				End If
				ShowStatus("   Created SecureEnvironment for user:" & vbLf & "       " & _secureEnv.User.Name & " [" & _secureEnv.User.AuthenticationType & "]")
				'</SnippetRmPkgViewSecEnv>

				'<SnippetRmPkgViewOpenPkg>
				ShowStatus("   Opening the encrypted Package.")
				Dim ePackage As EncryptedPackageEnvelope = EncryptedPackageEnvelope.Open(xpsFile, FileAccess.ReadWrite)
				Dim rmi As RightsManagementInformation = ePackage.RightsManagementInformation

				ShowStatus("   Looking for an embedded UseLicense for user:" & vbLf & "       " & currentUserId & " [" & _authentication & "]")
				Dim useLicense As UseLicense = rmi.LoadUseLicense(New ContentUser(currentUserId, _authentication))

				Dim grants As ReadOnlyCollection(Of ContentGrant)
				If useLicense Is Nothing Then
					ShowStatus("   No Embedded UseLicense found." & vbLf & "       " & "Attempting to acqure UseLicnese" & vbLf & "       " & "from the PublishLicense.")
					Dim pubLicense As PublishLicense = rmi.LoadPublishLicense()

					ShowStatus("   Referral information:")

					If pubLicense.ReferralInfoName Is Nothing Then
						ShowStatus("       Name: (null)")
					Else
						ShowStatus("       Name: " & pubLicense.ReferralInfoName)
					End If

					If pubLicense.ReferralInfoUri Is Nothing Then
						ShowStatus("    Uri: (null)")
					Else
						ShowStatus("    Uri: " & pubLicense.ReferralInfoUri.ToString())
					End If

					useLicense = pubLicense.AcquireUseLicense(_secureEnv)
					If useLicense Is Nothing Then
						ShowStatus("   User DOES NOT HAVE RIGHTS" & vbLf & "       " & "to access this document!")
						Return False
					End If
				End If ' end:if (useLicense == null)
				ShowStatus("   UseLicense acquired.")
				'</SnippetRmPkgViewOpenPkg>

				'<SnippetRmPkgViewBind>
				ShowStatus("   Binding UseLicense with the SecureEnvironment" & vbLf & "       to obtain the CryptoProvider.")
				rmi.CryptoProvider = useLicense.Bind(_secureEnv)

				ShowStatus("   Obtaining BoundGrants.")
				grants = rmi.CryptoProvider.BoundGrants

				' You can access the Package via GetPackage() at this point.

				rightsBlock.Text = "GRANTS LIST" & vbLf & "-----------" & vbLf
				For Each grant As ContentGrant In grants
					rightsBlock.Text &= "USER  :" & grant.User.Name & " [" & grant.User.AuthenticationType & "]" & vbLf
					rightsBlock.Text &= "RIGHT :" & grant.Right.ToString()+vbLf
					rightsBlock.Text &= "    From:  " & grant.ValidFrom & vbLf
					rightsBlock.Text &= "    Until: " & grant.ValidUntil & vbLf
				Next grant
				'</SnippetRmPkgViewBind>

				'<SnippetRmPkgViewDecrypt>
				If rmi.CryptoProvider.CanDecrypt = True Then
					ShowStatus("   Decryption granted.")
				Else
					ShowStatus("   CANNOT DECRYPT!")
				End If

				ShowStatus("   Getting the Package from" & vbLf & "      the EncryptedPackage.")
				_xpsPackage = ePackage.GetPackage()
				If _xpsPackage Is Nothing Then
					MessageBox.Show("Unable to get Package.")
					Return False
				End If

				' Set a PackageStore Uri reference for the encrypted stream.
				' ("sdk://packLocation" is a pseudo URI used by
				'  PackUriHelper.Create to define the parserContext.BaseURI
				'  that XamlReader uses to access the encrypted data stream.)
				Dim packageUri As New Uri("sdk://packLocation", UriKind.Absolute)
				' Add the URI package
				PackageStore.AddPackage(packageUri, _xpsPackage)
				' Determine the starting part for the package.
				Dim startingPart As PackagePart = GetPackageStartingPart(_xpsPackage)

				' Set the DocViewer.Document property.
				ShowStatus("   Opening in DocumentViewer.")
				Dim parserContext As New ParserContext()
				parserContext.BaseUri = PackUriHelper.Create(packageUri, startingPart.Uri)
				parserContext.XamlTypeMapper = XamlTypeMapper.DefaultMapper
                DocViewerProperty.Document = TryCast(XamlReader.Load(startingPart.GetStream(), parserContext), IDocumentPaginatorSource)

				' Enable document menu controls.
				menuFileClose.IsEnabled = True
				menuFilePrint.IsEnabled = True
				menuViewIncreaseZoom.IsEnabled = True
				menuViewDecreaseZoom.IsEnabled = True

				' Give the DocumentViewer focus.
                DocViewerProperty.Focus()
				'</SnippetRmPkgViewDecrypt> 
				' end:try
			Catch ex As Exception
				MessageBox.Show("Exception: " & ex.Message & vbLf & vbLf & ex.GetType().ToString() & vbLf & vbLf & ex.StackTrace, "Exception", MessageBoxButton.OK, MessageBoxImage.Error)
				Return False
			End Try

			Me.Title = "RightsManagedPackageViewer SDK Sample - " & Filename(xpsFile) & " (encrypted)"
			Return True
		End Function ' end:OpenEncryptedDocument()

		Private Shared PackageURI As String = "http://schemas.microsoft.com/xps/2005/06/fixedrepresentation"
		Private Shared Function GetPackageStartingPart(ByVal package As Package) As PackagePart
			Dim startingPartRelationship As PackageRelationship = Nothing

			For Each rel As PackageRelationship In package.GetRelationshipsByType(PackageURI)
				startingPartRelationship = rel
			Next rel

			If startingPartRelationship IsNot Nothing Then
				Dim startPartUri As Uri = PackUriHelper.CreatePartUri(startingPartRelationship.TargetUri)

				If package.PartExists(startPartUri) Then
					Return (package.GetPart(startPartUri))
				Else
					Return Nothing
				End If
			End If
			Return Nothing
		End Function

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
			Dim tempUri As New Uri(_xpsFile, UriKind.RelativeOrAbsolute)
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


		'<SnippetRmPkgViewCloseDoc>
		' --------------------------- CloseDocument --------------------------
		''' <summary>
		'''   Closes the document currently displayed in
		'''   the DocumentViewer control.</summary>
		Public Sub CloseDocument()
			If _xpsFile IsNot Nothing Then
				ShowStatus("Closing '" & Filename(_xpsFile) & "'")
                DocViewerProperty.Document = Nothing
				_xpsFile = Nothing
			End If

			' If the package is open, close it.
			If _xpsPackage IsNot Nothing Then
				_xpsPackage.Close()
				_xpsPackage = Nothing
			End If

			' The package is closed, remove it from the store.
			If _packageUri IsNot Nothing Then
				PackageStore.RemovePackage(_packageUri)
				_packageUri = Nothing
			End If

			' Disable document-related selections when there's no document.
			menuFileClose.IsEnabled = False
			menuFilePrint.IsEnabled = False
			menuViewIncreaseZoom.IsEnabled = False
			menuViewDecreaseZoom.IsEnabled = False
			Me.Title = "RightsManagedPackageViewer SDK Sample"
			ShowPrompt("Click 'File | Open...' to select a file to open and view.")
			rightsBlock.Text = ""

		End Sub ' end:CloseDocument
		'</SnippetRmPkgViewCloseDoc>
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
		Private _xpsFile As String=Nothing ' XPS doc path and filename.
		Private _packageUri As Uri ' XPS document path and filename URI.
		Private _xpsPackage As Package = Nothing ' XPS document package.
		Private _xpsDocument As XpsDocument ' XPS document within the package.
		Private _authentication As AuthenticationType = AuthenticationType.Windows
		Private Shared _secureEnv As SecureEnvironment = Nothing
		Private Shared _currentUserId As String = GetDefaultWindowsUserName()
		Private ReadOnly _fixedDocumentSequenceContentType As String = "application/vnd.ms-package.xps-fixeddocumentsequence+xml"
		#End Region ' private fields


	End Class ' end:partial class Window1

End Namespace ' end:namespace SdkSample