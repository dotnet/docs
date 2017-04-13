' DocViewerAnnotationsXml SDK Sample - Window1.xaml.vb
' Copyright (c) Microsoft Corporation. All rights reserved.

Imports System.Net
Imports System.IO
Imports System.IO.Packaging
Imports System.Printing
Imports System.Windows.Annotations
Imports System.Windows.Annotations.Storage
Imports System.Windows.Markup
Imports System.Windows.Xps
Imports System.Windows.Xps.Packaging
Imports System.Windows
Imports WinForms = System.Windows.Forms
Imports System.Windows.Controls


Namespace SDKSample
	' ========================= partial class Window1 ========================
	''' <summary>
	''' Interaction logic for Window1.xaml</summary>
	Partial Public Class Window1
		Inherits Window
		' ------------------------ Window1 constructor -----------------------
		Public Sub New()
			InitializeComponent()
		End Sub


		' ------------------------------ OnOpen ------------------------------
		''' <summary>
		'''   Handles the user "File | Open" menu operation.</summary>
		Private Sub OnOpen(ByVal target As Object, ByVal args As ExecutedRoutedEventArgs)
			' If a document is currently open, check with the user
			' if it's ok to close it before opening a new one.
			If _xpsPackage IsNot Nothing Then
				Dim msg As String = "The currently open document needs to be closed before" & vbLf & "opening a new document.  Ok to close the current document?"
				Dim result As MessageBoxResult = MessageBox.Show(msg, "Close Current Document?", MessageBoxButton.OKCancel, MessageBoxImage.Question)

				' If the user did not click OK to close current
				' document, cancel the File | Open request.
				If (result <> MessageBoxResult.OK) Then
					Return
				End If

				' The user clicked OK, close the current document and continue.
				CloseDocument()
			End If

			' Create a "File Open" dialog positioned to the
			' "Content\" folder containing the sample fixed document.
			Dim dialog As New WinForms.OpenFileDialog()
			dialog.InitialDirectory = GetContentFolder()
			dialog.CheckFileExists = True
			dialog.Filter = "XPS Document files (*.xps)|*.xps"

			' Show the "File Open" dialog.  If the user picks a file and
			' clicks "OK", load and display the specified XPS document.
			If dialog.ShowDialog() = WinForms.DialogResult.OK Then
				OpenDocument(dialog.FileName)
			End If

		End Sub ' end:OnOpen()


		' --------------------------- OpenDocument ---------------------------
		''' <summary>
		'''   Loads, displays, and enables user annotations
		'''   a given XPS document file.</summary>
		''' <param name="filename">
		'''   The path and filename of the XPS document
		'''   to load, display, and annotate.</param>
		''' <returns>
        '''   true if the document loads successfully, otherwise false.</returns>
		Public Function OpenDocument(ByVal filename As String) As Boolean
			' Load an XPS document into a DocumentViewer
			' and enable user Annotations.
			_xpsDocumentPath = filename

			_packageUri = New Uri(filename, UriKind.Absolute)
			Try
				_xpsDocument = New XpsDocument(filename, FileAccess.Read)
			Catch e1 As UnauthorizedAccessException
				Dim msg As String = filename & vbLf & vbLf & "The specified file is Read-Only which " & "prevents storing user annotations."
				MessageBox.Show(msg, "Read-Only file", MessageBoxButton.OK, MessageBoxImage.Error)
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
			menuViewAnnotations.IsEnabled = True
			menuViewIncreaseZoom.IsEnabled = True
			menuViewDecreaseZoom.IsEnabled = True

			' Enable user annotations on the document.
			Dim fixedDocumentSeqUri As Uri = GetFixedDocumentSequenceUri()
			If menuViewAnnotations.IsChecked Then
				StartAnnotations()
			End If

			' Give the DocumentViewer focus.
			docViewer.Focus()

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


		' ------------------------- GetContentFolder -------------------------
		''' <summary>
		'''   Locates and returns the path to the "Content\" folder
		'''   containing the fixed document for the sample.</summary>
		''' <returns>
		'''   The path to the fixed document "Content\" folder.</returns>
		Private Function GetContentFolder() As String
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


		'<SnippetDocViewXmlStartStopAnnotat>
		'<SnippetDocViewXmlStartAnnotations>
		' ------------------------ StartAnnotations --------------------------
		''' <summary>
		'''   Enables annotations and displays all that are viewable.</summary>
		Private Sub StartAnnotations()
			' If there is no AnnotationService yet, create one.
			If _annotService Is Nothing Then
				' docViewer is a document viewing control named in Window1.xaml.
				_annotService = New AnnotationService(docViewer)
			End If

			' If the AnnotationService is currently enabled, disable it.
			If _annotService.IsEnabled = True Then
				_annotService.Disable()
			End If

			' Open a stream to the file for storing annotations.
			_annotStream = New FileStream(_annotStorePath, FileMode.OpenOrCreate, FileAccess.ReadWrite)

			' Create an AnnotationStore using the file stream.
			_annotStore = New XmlStreamStore(_annotStream)

			' Enable the AnnotationService using the new store.
			_annotService.Enable(_annotStore)
		End Sub ' end:StartAnnotations()
		'</SnippetDocViewXmlStartAnnotations>


		'<SnippetDocViewXmlStopAnnotations>
		' ------------------------ StopAnnotations ---------------------------
		''' <summary>
		'''   Disables annotation processing and hides all annotations.</summary>
		Private Sub StopAnnotations()
			' If the AnnotationStore is active, flush and close it.
			If _annotStore IsNot Nothing Then
				_annotStore.Flush()
				_annotStream.Flush()
				_annotStream.Close()
				_annotStore = Nothing
			End If

			' If the AnnotationService is active, shut it down.
			If _annotService IsNot Nothing Then
				If _annotService.IsEnabled Then
					_annotService.Disable() ' Disable the AnnotationService.
					_annotService = Nothing
				End If
			End If
		End Sub ' end:StopAnnotations()
		'</SnippetDocViewXmlStopAnnotations>
		'</SnippetDocViewXmlStartStopAnnotat>


		' ------------------------------ OnExit ------------------------------
		''' <summary>
		'''   Handles the user File|Exit menu selection to
		'''   shutdown and exit the application.</summary>
		Private Sub OnExit(ByVal sender As Object, ByVal e As EventArgs)
			Close() ' invokes OnClosed()
		End Sub ' end:OnExit()


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
			' Stop and close annotations.
			StopAnnotations()

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
			menuViewAnnotations.IsEnabled = False
			menuViewIncreaseZoom.IsEnabled = False
			menuViewDecreaseZoom.IsEnabled = False
		End Sub ' end:CloseDocument


		' ----------------------------- OnPrint ------------------------------
		''' <summary>
		'''   Handles the user "File | Print" menu operation.</summary>
		Private Sub OnPrint(ByVal target As Object, ByVal args As ExecutedRoutedEventArgs)
			PrintDocument()
		End Sub ' end:OnClose()


		' -------------------------- PrintDocument ---------------------------
		''' <summary>
		'''   Prints the DocumentViewer's content and annotations.</summary>
		''' <remarks>
		Public Sub PrintDocument()
			If docViewer Is Nothing Then
				Return ' DocumentViewer has not been initialized yet.
			End If

			' If Annotations are disabled, use normal DocuementViewer.Print()
			If menuViewAnnotations.IsChecked = False Then
				docViewer.Print()

			' If Annotations are enabled, print showing the annotations.
			Else ' if (menuViewAnnotations.IsChecked && (_annotHelper != null))
				Dim prntDialog As New PrintDialog()
				If CBool(prntDialog.ShowDialog()) Then
					' XpsDocumentWriter.Write() may change the current
					' directory to "My Documents" or another user selected
					' directory for storing the print document.  Save the
					' current directory and restore it after calling xdw.Write().
					Dim docDir As String = Directory.GetCurrentDirectory()

					' Create and XpsDocumentWriter for the selected printer.
					Dim xdw As XpsDocumentWriter = PrintQueue.CreateXpsDocumentWriter(prntDialog.PrintQueue)

					' Print the document with annotations.
					Try
						xdw.Write(GetAnnotationDocumentPaginator(_xpsDocument.GetFixedDocumentSequence()))
					Catch e1 As PrintingCanceledException
						' If in the PrintDialog the user chooses a file-based
						' output, such as the "MS Office Document Image Writer",
						' the user confirms or specifies the actual output
						' filename when the xdw.write operation executes.
						' If the user clicks "Cancel" in the filename
						' dialog a PrintingCanceledException is thrown
						' which we catch here and ignore.

					End Try

					' Restore the original document directory to "current".
					Directory.SetCurrentDirectory(docDir)
				End If
			End If
		End Sub ' end:PrintDocument()


		' -------------------------- ShowAnnotations -------------------------
		''' <summary>
		'''   Enables and displays user annotations.</summary>
		Private Sub ShowAnnotations(ByVal sender As Object, ByVal e As EventArgs)
			If menuViewAnnotations.IsEnabled AndAlso menuViewAnnotations.IsChecked Then
				StartAnnotations()
			End If
		End Sub


		' ------------------------- HideAnnotations --------------------------
		''' <summary>
		'''   Disables and hides user annotations.</summary>
		Private Sub HideAnnotations(ByVal sender As Object, ByVal e As EventArgs)
			StopAnnotations()
		End Sub


		' ------------------ GetAnnotationDocumentPaginator ------------------
		''' <summary>
		'''   Returns a paginator for printing annotations.</summary>
		''' <param name="fds">
		'''   The FixedDocumentSequence containing
		'''   the annotations to print.</param>
		''' <returns>
		'''   An paginator for printing the document's annotations.</returns>
		Public Function GetAnnotationDocumentPaginator(ByVal fds As FixedDocumentSequence) As AnnotationDocumentPaginator
			Return New AnnotationDocumentPaginator(fds.DocumentPaginator, _annotStore)
		End Function


		#Region "private fields"

		Private _xpsDocumentPath As String ' XPS document path and filename.
		Private _packageUri As Uri ' XPS document path and filename URI.
		Private _xpsPackage As Package = Nothing ' XPS document package.
		Private _xpsDocument As XpsDocument ' XPS document within the package.
		Private _annotService As AnnotationService = Nothing
		Private _annotStream As FileStream = Nothing
		Private _annotStore As XmlStreamStore = Nothing
		Private ReadOnly _annotStorePath As String = "annotations.xml"
		Private _xpsFile As String = String.Empty

		Private ReadOnly _fixedDocumentSequenceContentType As String = "application/vnd.ms-package.xps-fixeddocumentsequence+xml"

		#End Region 'private fields

	End Class ' end:partial class Window1

End Namespace ' end:namespace SDKSample
