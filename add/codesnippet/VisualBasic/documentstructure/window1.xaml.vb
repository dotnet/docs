' DocumentStructure SDK Sample - Window1.xaml.vb
' Copyright (c) Microsoft Corporation. All rights reserved.

Imports System.Windows.Xps.Packaging
Imports System.Xml
Imports System.IO
Imports System.IO.Packaging
Imports WinForms = Microsoft.Win32
Imports System.Windows.Forms


Namespace SdkSample
	''' <summary>
	'''   Interaction logic for Window1.xaml</summary>
	Partial Public Class Window1
		Inherits Window
		#Region "constructor"
		' ------------------------ Window1 constructor -----------------------
		Public Sub New()
			MyBase.New()
			InitializeComponent()

			ShowPrompt("Click 'File | Open...' and select the file " & "'Spec_withoutStructure.xps'.")
			ShowDescription(_descriptionString(0))
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
			dialog.Filter = "XPS Document files (*.xps)|*.xps|All (*.*)|*.*"

			' Show the "File Open" dialog.  If the user picks a file and
			' clicks "OK", load and display the specified XPS document.
			If dialog.ShowDialog() <> True Then
				Return
			End If

			' If the file is an XPS document, open it in the DocumentViewer.
			If dialog.FileName.EndsWith(".xps") Then
				OpenDocument(dialog.FileName)

			' If the file is a text document, show it in the desciption block.
			ElseIf dialog.FileName.EndsWith(".xaml") OrElse dialog.FileName.EndsWith(".xml") OrElse dialog.FileName.EndsWith(".txt") Then
				Using sr As New StreamReader(dialog.FileName)
					ShowDescriptionTitle(Filename(dialog.FileName))
					ShowDescription(sr.ReadToEnd(), TextWrapping.NoWrap)
				End Using ' end:using StreamReader(flush and close)
				ShowPrompt("")
			End If
		End Sub ' end:OnOpen()


		' --------------------------- OpenDocument ---------------------------
		''' <summary>
		'''   Opens a specified XPS document in given access mode.</summary>
		''' <param name="xpsFile">
		'''   The path and file name of the XPS document to open.</param>
		Private Function OpenDocument(ByVal xpsFile As String) As Boolean
			' Close the XpsDocument if it is currently open.
			If _xpsDocument IsNot Nothing Then
				CloseDocument()
			End If

			' Load and create an in-memory instance of the XPS document.
			ShowStatus("Opening '" & Filename(xpsFile) & "'.")
			_xpsDocument = New XpsDocument(xpsFile, FileAccess.Read)

			' Get the FixedDocumentSequence from the XPS document.
			Dim fds As FixedDocumentSequence = _xpsDocument.GetFixedDocumentSequence()
			If fds Is Nothing Then
				Dim msg As String = xpsFile & vbLf & vbLf & "The document package within the specified " & "file does not contain a FixedDocumentSequence."
                MessageBox.Show(msg, "Package Error")
				Return False
			End If

			' Load the FixedDocumentSequence to the DocumentViewer control.
			DocViewer.Document = fds

            Dim _filename As String = Window1.Filename(xpsFile).ToLower()
            If _filename.Equals("spec_withoutstructure.xps") Then
                ShowPrompt("Click 'File | Open...' and select the file " & "'Spec_withStructure.xps'.")
                ShowDescription(_descriptionString(2))
            ElseIf _filename.Equals("spec_withstructure.xps") Then
                ShowPrompt("Click 'File | Add Structure...'.")
                ShowDescription(_descriptionString(3) & _descriptionString(4))
            Else
                ShowPrompt("")
            End If

			_openedXpsFile = xpsFile
			menuFileClose.IsEnabled = True
			menuFilePrint.IsEnabled = True
			descriptionBlockTitle.Text = "Description"
			Me.Title = "DocumentStructure Sample - " & Window1.Filename(xpsFile)
			Return True
		End Function ' OpenDocument()
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


		' -------------------------- CloseDocument ---------------------------
		''' <summary>
		'''   Closes the document if its open.</summary>
		Private Sub CloseDocument()
			If _xpsDocument IsNot Nothing Then
				ShowStatus("Closing '" & Filename(_openedXpsFile) & "'.")
				_xpsDocument.Close()
				_xpsDocument = Nothing
				_openedXpsFile = Nothing
				DocViewer.Document = Nothing
			End If

			ShowPrompt("Click 'File | Open...' and select the file " & "'Spec_withoutStructure.xps'.")
			ShowDescription(_descriptionString(0))
			menuFilePrint.IsEnabled = False
			menuFileClose.IsEnabled = False
			Me.Title = "DocumentStructure Sample"
		End Sub ' end:CloseDocument
		#End Region ' File|Close


		#Region "File|Add Structure..."
		' -------------------------- OnAddStructure --------------------------
		''' <summary>
		'''   Handles the user File|Add Structure... menu option to
		'''   add structure elements to an unstructured XPS document.</summary>
		Private Sub OnAddStructure(ByVal sender As Object, ByVal e As EventArgs)

			' For the sample, always use "Spec_withoutStructure.xps"
			' as the source unstructured document file.
			Dim xpsUnstructuredFile As String = GetContentFolder() & "\Spec_withoutStructure.xps"

			' Create a "File Save" dialog positioned to the
			' "Content\" folder to write the new structured document to.
			Dim saveDialog As New WinForms.SaveFileDialog()
			saveDialog.OverwritePrompt = False
			saveDialog.InitialDirectory = GetContentFolder()
			saveDialog.Title = "Save New Structured XPS Document As"
			saveDialog.Filter = "XPS Documents (*.xps)|*.xps|All (*.*)|*.*"

			' Set a default XPS document filename.
			saveDialog.FileName = GetContentFolder() & "\Structured.xps"

			' Show the "File Save" dialog.  If the user picks a file and
			' clicks "OK", set it as the target ouput XPS structured file.
			If saveDialog.ShowDialog() <> True Then
				Return
			End If
			Dim xpsTargetFile As String = saveDialog.FileName

			' Add the document structure resource elements
			' to create a new structured XPS document.
			AddDocumentStructure(xpsUnstructuredFile, _fixedPageStructures, xpsTargetFile) ' target structured doc -  structure definitions -  source unstructured doc
		End Sub ' end:OnAddStructure()


		' ----------------------- AddDocumentStructure -----------------------
		''' <summary>
		'''   Writes a structured XPS document given an unstructured document 
		'''   and a file list of XAML document structure elements to add.</summary>
		''' <param name="xpsUnstructuredFile">
		'''   The path and filename of the unstructured XPS document.</param>
		''' <param name="xamlStructureFile">
		'''   A file list of XAML document structures to add.</param>
		''' <param name="xpsTargetFile">
		'''   The path and filename for the new structured
		'''    XPS document to write.</param>
		''' <remarks>
		'''   If xpsTargetFile exists, it is first deleted and
		'''   then a new structured XPS document written.</remarks>
		Private Sub AddDocumentStructure(ByVal xpsUnstructuredFile As String, ByVal xamlStructureFile() As String, ByVal xpsTargetFile As String) ' target structured XPS document -  structure definition resources -  source unstructured document
			' Close the current document if one is open.
			CloseDocument()

			ShowStatus(vbLf & "Creating new structured XPS" & vbLf & "       " & "document '" & Filename(xpsTargetFile) & "'.")

			' If the new target XPS file exists, prompt to confirm ok to replace.
            If File.Exists(xpsTargetFile) Then
                Dim result As MessageBoxResult = System.Windows.MessageBox.Show("'" & xpsTargetFile & "' already exists." &
                                                                 vbLf & "Do you want to delete and replace it?",
                                                                 "Ok to replace '" & Filename(xpsTargetFile) & "'?",
                                                                 MessageBoxButton.YesNo,
                                                                 MessageBoxImage.Question)
                If result <> MessageBoxResult.Yes Then
                    Return
                End If
                ShowStatus("   Deleting old '" & Filename(xpsTargetFile) & "'.")
                File.Delete(xpsTargetFile)
            End If

			ShowStatus("   Copying '" & Filename(xpsUnstructuredFile) & "'" & vbLf & "       to '" & Filename(xpsTargetFile) & "'.")
			File.Copy(xpsUnstructuredFile, xpsTargetFile)

			ShowStatus("   Opening '" & Filename(xpsTargetFile) & "'" & vbLf & "       (currently without structure).")
			'<SnippetDocStrucAddStructure>
			'<SnippetDocStrucXpsDocument>
			Dim xpsDocument As XpsDocument = Nothing
			Try
				xpsDocument = New XpsDocument(xpsTargetFile, FileAccess.ReadWrite)
			Catch e1 As System.IO.FileFormatException
				Dim msg As String = xpsUnstructuredFile & vbLf & vbLf & "The specified file " & "does not appear to be a valid XPS document."
                System.Windows.MessageBox.Show(msg, "Invalid File Format", MessageBoxButton.OK, MessageBoxImage.Error)
				ShowStatus("   Invalid XPS document format.")
				Return
			End Try
			'</SnippetDocStrucXpsDocument>

			'<SnippetDocStrucFixedDoc>
			ShowStatus("   Getting FixedDocumentSequenceReader.")
			Dim fixedDocSeqReader As IXpsFixedDocumentSequenceReader = xpsDocument.FixedDocumentSequenceReader

			ShowStatus("   Getting FixedDocumentReaders.")
			Dim fixedDocuments As ICollection(Of IXpsFixedDocumentReader) = fixedDocSeqReader.FixedDocuments

			ShowStatus("   Getting FixedPageReaders.")
			Dim enumerator As IEnumerator(Of IXpsFixedDocumentReader) = fixedDocuments.GetEnumerator()
			enumerator.MoveNext()
			Dim fixedPages As ICollection(Of IXpsFixedPageReader) = enumerator.Current.FixedPages


			' Add a document structure to each fixed page.
			Dim i As Integer = 0
			For Each fixedPageReader As IXpsFixedPageReader In fixedPages
				Dim pageStructure As XpsResource
				ShowStatus("   Adding page structure resource:" & vbLf & "       '" & Filename(_fixedPageStructures(i)) & "'")
				Try
					pageStructure = fixedPageReader.AddStoryFragment()
				Catch e2 As InvalidOperationException
                    System.Windows.MessageBox.Show(xpsUnstructuredFile & vbLf & vbLf & "Document structure cannot be added." & vbLf & vbLf & Filename(xpsUnstructuredFile) & " might already " & "contain an existing document structure.",
                                    "Cannot Add Document Structure",
                                    MessageBoxButton.OK,
                                    MessageBoxImage.Error)
					Exit For
				End Try

				' Copy the page structure to the new StoryFragment.
				WriteResource(pageStructure, _fixedPageStructures(i))
				i += 1
			Next fixedPageReader

			ShowStatus("   Saving and closing the new document." & vbLf)
			xpsDocument.Close()
			'</SnippetDocStrucFixedDoc>
			'</SnippetDocStrucAddStructure>

			' Open the new structured document.
			OpenDocument(xpsTargetFile)

			ShowDescription(_descriptionString(4) & _descriptionString(5))
			ShowPrompt(_descriptionString(5))
		End Sub ' end:AddDocumentStructure
		#End Region ' File|Add Structure...


		#Region "File|Print"
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
			If DocViewer Is Nothing Then
				Return
			End If
			DocViewer.Print()

		End Sub ' end:PrintDocument()
		#End Region ' File|Print


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
		'''   containing the content files for the sample.</summary>
		''' <returns>
		'''   The path to the sample "Content\" folder.</returns>
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


		' -------------------------- WriteResource ---------------------------
		Private Sub WriteResource(ByVal resource As XpsResource, ByVal filename As String)
			WriteStream(resource.GetStream(), filename)
		End Sub


		' --------------------------- WriteStream ----------------------------
		Private Sub WriteStream(ByVal stream As Stream, ByVal filename As String)
			Dim srcStream As New FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read)

			Dim buf(65535) As Byte
			Dim bytesRead As Integer

			Do
				bytesRead = srcStream.Read(buf, 0, 65536)
				stream.Write(buf, 0, bytesRead)
			Loop While bytesRead > 0

			srcStream.Close()
		End Sub ' end:WriteStream()


		' ------------------------- ShowPrompt(string) -----------------------
		''' <summary>
		'''   Writes a line of text to the prompt bar.</summary>
		''' <param name="prompt">
		'''   The line of text to write in the prompt bar.</param>
		Public Sub ShowPrompt(ByVal prompt As String)
			promptBlock.Text = prompt
		End Sub


		' ---------------------------- ShowStatus ----------------------------
		''' <summary>
		'''   Adds a line of text to the statusBlock.</summary>
		''' <param name="status">
		'''   A line of text to add to the status TextBlock.</param>
		Public Sub ShowStatus(ByVal status As String)
			statusBlock.Text += status & vbLf
		End Sub


		' ------------------------- ShowDescription -------------------------
		''' <summary>
		'''   Displays a string of text to the description block.</summary>
		Public Sub ShowDescription(ByVal description As String)
			descriptionBlock.Text = description
			descriptionBlock.TextWrapping = TextWrapping.Wrap
		End Sub


		' ------------------------- ShowDescription -------------------------
		''' <summary>
		'''   Displays a string of text to the description block.</summary>
		Public Sub ShowDescription(ByVal description As String, ByVal wrapStyle As TextWrapping)
			descriptionBlock.Text = description
			descriptionBlock.TextWrapping = wrapStyle
		End Sub


		' ----------------------- ShowDescriptionTitle -----------------------
		''' <summary>
		'''   Displays a string of text in the description title block.</summary>
		Public Sub ShowDescriptionTitle(ByVal title As String)
			descriptionBlockTitle.Text = title
		End Sub


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


		' ----------------------- DocViewer attribute ------------------------
		''' <summary>
		'''   Gets the current DocumentViewer.</summary>
		Public ReadOnly Property DocViewer() As DocumentViewer
			Get
                Return DdocViewer
			End Get
		End Property
		#End Region ' Utilities


		#Region "Private Fields"
		Private _openedXpsFile As String = Nothing ' XPS document path & filename.
		Private _xpsDocument As XpsDocument = Nothing ' current XpsDocument.

		' Document structure resource files.
		Private Shared _fixedPageStructures() As String = { "FixedPage1_structure.xaml", "FixedPage2_structure.xaml" }

		' Description block text strings.
		Private Shared _descriptionString() As String = { "The DocumentStructure example includes two sample XPS documents:" & vbLf & "    1.  Spec_withoutStructure.xps" & vbLf & "    2.  Spec_withStructure.xps" & vbLf & vbLf & "When you open each file note that the visual layout, " & "quality, and print output of both documents is exactly " & "the same - both documents fully conform to the open XML " & "Paper Specification (XPS).  Cutting and pasting information " & "from each document, however, is quite different." & vbLf & vbLf & "Click " & "'File | Open...', select the file " & "'Spec_withoutStructure.xps', and then click OK.", "Click 'File | Open...', select the file " & "'Spec_withoutStructure.xps', and then click OK.", "Within the 'Spec_withoutStructure.xps' document select a portion " & "of Table 1-1 and paste it into a blank Word or WordPad " & "document.  Notice that an XPS document without structure " & "elements pastes as plain text not as a formatted table." & vbLf & vbLf & "Next click 'File | Open...' and select " & "'Spec_withStructure.xps'.", "Select a portion of " & "Table 1-1 and paste it into the Word or WordPad document.  " & "Notice that a document with structure elements uses rich " & "text to paste the selection as styled table elements." & vbLf & vbLf & "Next click 'File | Add Structure...'" & vbLf & vbLf, "The Add Structure process copies 'Spec_withoutStructure.xps' " & "to a new file and then programatically adds to the new " & "document the two structure elements contained in:" & vbLf & "    -  " & "FixedPage1_structure.xaml" & vbLf & "    -  FixedPage2_structure.xaml" & vbLf & vbLf & "The resulting new XPS document is equivalent " & "to 'Spec_withStructure.xps'." & vbLf & vbLf, "Click 'File | Open...' and set 'Files of Type' to 'All' " & "to select a .xaml document structure resource file to view." }
			'Step 0
			'Step 1
			'Step 2
			'Step 3
			'Step 4
			'Step 5
		#End Region ' Private Fields

	End Class ' end:partial class Window1

End Namespace ' end:namespace SdkSample
