' XpsPrint SDK Sample - Window1.xaml.vb
' Copyright (c) Microsoft Corporation. All rights reserved. 


Imports System.IO
Imports System.IO.Packaging
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Xps.Packaging
Imports System.Printing
Imports Microsoft.Win32
Imports SDKSampleHelper


Namespace SDKSample
	' ------------------------- partial class Window1 ------------------------
	''' <summary>
	'''   Provides interaction logic for Window1.xaml user interface.</summary>
	Partial Public Class Window1
		Inherits Window
		' --------------------------- Constructor ----------------------------
		''' <summary>
		'''   Default constructor.</summary>
		Public Sub New()
			_contentDir = GetContentFolder()
			InitializeComponent()
		End Sub


		' ------------------------- GetContentFolder -------------------------
		''' <summary>
		'''   Locates and returns the path to the "\Content" folder
		'''   containing the content for the sample.</summary>
		''' <returns>
		'''   The path to the sample "\Content" folder.</returns>
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

			' If there's a "\Content" subfolder, that's what we want.
			If Directory.Exists(contentDir & "\Content") Then
				contentDir = contentDir & "\Content"
			End If

			' Return the "Content\" folder (or the "current"
			' directory if we're executing somewhere else).
			Return contentDir
		End Function ' end:GetContentFolder()


		' --------------------------- WindowLoaded ---------------------------
		''' <summary>
		'''   Called when the windows is initially loaded to display.</summary>
		Private Sub WindowLoaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			currentMode = eGuiMode.SingleVisual
            cbMode.SelectedIndex = CInt(currentMode)
		End Sub


		' ----------------------- ContentDir getter --------------------------
		''' <summary>
		'''   Gets the string to the \Content directory.</summary>
		Public ReadOnly Property ContentDir() As String
			Get
					Return _contentDir
			End Get
		End Property


		#Region "Button Event Handlers"
		' -------------------------- OnBtnSaveClick --------------------------
		''' <summary>
		'''   Called when the "Save (synchronous)" button is clicked.</summary>
		Private Sub OnBtnPrintClick(ByVal sender As Object, ByVal e As RoutedEventArgs)
			ButtonHelperPrint(False)
		End Sub


		' ----------------------- OnBtnSaveAsyncClick ------------------------
		''' <summary>
		'''   Called when the "Save (asynchronous)" button is clicked.</summary>
		Private Sub OnBtnPrintAsyncClick(ByVal sender As Object, ByVal e As RoutedEventArgs)
			ButtonHelperPrint(True)
		End Sub


		' ------------------------ ButtonHelperPrint -------------------------
		''' <summary>
		'''   Saves the current DocumentViewer content either
		'''   synchronously (waiting for completion) or
		'''   asynchronously (not waiting for completion).</summary>
		''' <param name="async">
		'''   true to save asynchronously; false to save synchronously.</param>
		Private Sub ButtonHelperPrint(ByVal async As Boolean)
			' Display Printer dialog for user to
			' choose the printer to output to.
			Dim printHelper As New XpsPrintHelper(_contentDir)
			Dim printDialog As PrintDialog = printHelper.GetPrintDialog()
			If printDialog Is Nothing Then
				Return 'user selected cancel
			End If

			Dim printQueue As PrintQueue = printDialog.PrintQueue

			If async Then
				_printHelper = printHelper

				'Make progress controls visible
				AsyncPrintLabel.Visibility = Visibility.Visible
				AsyncPrintProgress.Visibility = Visibility.Visible
				AsyncPrintStatus.Visibility = Visibility.Visible

				'register for async archiving events
				AddHandler _printHelper.OnAsyncPrintChange, AddressOf AsyncPrintEvent

				AsyncPrintProgress.Value = 10
				AsyncPrintStatus.Text = "Async Print Initiated"

				UIEnabled(False, False, True)
			End If ' end:if (async)

			' Print the DocumentViewer's current content.
			Select Case currentMode
				Case eGuiMode.SingleVisual
					printHelper.PrintSingleVisual(printQueue, async)
					Exit Select
				Case eGuiMode.MultipleVisuals
					printHelper.PrintMultipleVisuals(printQueue, async)
					Exit Select
				Case eGuiMode.SingleFlowDocument
					printHelper.PrintSingleFlowContentDocument(printQueue, async)
					Exit Select
				Case eGuiMode.SingleFixedDocument
					printHelper.PrintSingleFixedContentDocument(printQueue, async)
					Exit Select
				Case eGuiMode.MultipleFixedDocuments
					printHelper.PrintMultipleFixedContentDocuments(printQueue, async)
					Exit Select
			End Select ' end:switch (currentMode)
		End Sub


		' ------------------------- OnBtnCancelClick -------------------------
		''' <summary>
		'''   Called when the asynchronous save
		'''   "Cancel" button is clicked.</summary>
		Private Sub OnBtnCancelClick(ByVal sender As Object, ByVal e As RoutedEventArgs)
			_printHelper.CancelAsync()
		End Sub

		#End Region ' Button Event Handlers


		' -------------------------- AsyncPrintEvent -------------------------
		''' <summary>
		'''   Called as the asynchronous save proceeds.</summary>
		''' <param name="saveHelper"></param>
		''' <param name="asyncInformation">
		'''   Progress information about the asynchronous save.</param>
	   Private Sub AsyncPrintEvent(ByVal printHelper As Object, ByVal asyncInformation As AsyncPrintEventArgs)
			If asyncInformation.Completed Then
				AsyncPrintStatus.Text = asyncInformation.Status
				AsyncPrintProgress.Value = 100

				MessageBox.Show(asyncInformation.Status, "Completed")

				'Hide async controls
				AsyncPrintLabel.Visibility = Visibility.Hidden
				AsyncPrintProgress.Visibility = Visibility.Hidden
				AsyncPrintStatus.Visibility = Visibility.Hidden

				'Enabled print buttons, and disable the cancel button
				UIEnabled(True, True, False)
			Else
				AsyncPrintStatus.Text = asyncInformation.Status
				AsyncPrintProgress.Value += 5
			End If
	   End Sub


		' -------------------- GetContainerPathFromDialog --------------------
		''' <summary>
		'''   Dislays a Save As... dialog for the user to choose the path and
		'''   container (file) name to save the document content to.</summary>
		''' <returns></returns>
		Private Function GetContainerPathFromDialog() As String
			Dim saveFileDialog As New SaveFileDialog()

			saveFileDialog.Filter = "XPS document files (*.xps)|*.xps"
			saveFileDialog.FilterIndex = 1

			If saveFileDialog.ShowDialog() = True Then
				Return saveFileDialog.FileName
			Else
				Return Nothing
			End If
		End Function ' end:GetContainerPathFromDialog()


		' ---------------------------- UIEnabled -----------------------------
		''' <summary>
		'''   Enables or disables the "Save synchronous", "Save
		'''   asynchronous", and "Cancel" user buttons.</summary>
		''' <param name="bSave">
		'''   true to enable "Save synchronous"; false to disable.</param>
		''' <param name="bSaveAsync">
		'''   true to enable "Save asynchronous"; false to disable.</param>
		''' <param name="bCancel"></param>
		'''   true to enable the "Cancel" button; false to disable.</param>
		Private Sub UIEnabled(ByVal bPrint As Boolean, ByVal bPrintAsync As Boolean, ByVal bCancel As Boolean)
			' Set button state
			btnPrint.IsEnabled = bPrint
			btnPrintAsync.IsEnabled = bPrintAsync
			btnCancelAsync.IsEnabled = bCancel

			Me.ApplyTemplate()
		End Sub


		' -------------------------- OnCbModeChange --------------------------
		''' <summary>
		'''   Handles user changes to the combobox selection.</summary>
		''' <param name="sender">
		'''   The sender initiating the event.</param>
		''' <param name="e">
		'''   The event args.</param>
		Private Sub OnCbModeChange(ByVal sender As Object, ByVal e As RoutedEventArgs)
			' Update window mode based on user selection
			UpdateUI(CType(cbMode.SelectedIndex, eGuiMode))
		End Sub


		' ------------------------------ UpdateUI ----------------------------
		''' <summary>
		'''   Updates UI based on the combobox selected GUI mode change.</summary>
		''' <param name="mode">
		'''   The new user selected content mode for the DocumentViewer.</param>
		Private Sub UpdateUI(ByVal mode As eGuiMode)
			currentMode = mode

			Select Case mode
				Case eGuiMode.SingleVisual
					LoadDocumentViewer(_contentDir & "\ViewOneVisual.xps")
					UIEnabled(True, True, False)

				Case eGuiMode.MultipleVisuals
					LoadDocumentViewer(_contentDir & "\ViewMultipleVisuals.xps")
					UIEnabled(True, True, False)

				Case eGuiMode.SingleFlowDocument
					LoadDocumentViewer(_contentDir & "\ViewFlowDocument.xps")
					UIEnabled(True, True, False)

				Case eGuiMode.SingleFixedDocument
					LoadDocumentViewer(_contentDir & "\ViewFixedDocument.xps")
					UIEnabled(True, True, False)

				Case eGuiMode.MultipleFixedDocuments
					LoadDocumentViewer(_contentDir & "\ViewFixedDocumentSequence.xps")
					UIEnabled(True, True, False)
			End Select
		End Sub


		' ------------------------- LoadDocumentViewer -----------------------
		''' <summary>
		'''   Loads content from a file to a DocumentViewer control.</summary>
		''' <param name="xpsFilename">
		'''   The path and name of the XPS file to
		'''   load to the DocumentViewer control.</param>
		''' <remarks>
		'''   Exception handling should be added if the xpsFilename may not be
		'''   valid or if the FixedDocumentSequence contained in the file is
		'''   incorrect.  (In this sample the files are hardcoded.)</remarks>
		Private Sub LoadDocumentViewer(ByVal xpsFilename As String)
			' Save a reference to the currently open XPS package.
			Dim oldXpsPackage As XpsDocument = _xpsPackage

			' Open the package for the new XPS document.
			_xpsPackage = New XpsDocument(xpsFilename, FileAccess.Read, CompressionOption.NotCompressed)

			' Get the FixedDocumentSequence from the package.
			Dim fixedDocumentSequence As FixedDocumentSequence = _xpsPackage.GetFixedDocumentSequence()

			' Set the new FixedDocumentSequence as
			' the DocumentViewer's paginator source.
			docViewer.Document = TryCast(fixedDocumentSequence, IDocumentPaginatorSource)

			' If there was an old XPS package, close it now that
			' DocumentViewer no longer needs to access it.
			If oldXpsPackage IsNot Nothing Then
				oldXpsPackage.Close()
			End If

			' Leave the new _xpsPackage open for DocumentViewer
			' to access additional required resources.

		End Sub


		#Region "Private Members"

		' Helper class to support cancelling async print.
		Private _printHelper As XpsPrintHelper = Nothing

		Private _xpsPackage As XpsDocument = Nothing ' Reference to the XPS package.

		Private _contentDir As String ' Path to the \Content directory

		Private currentMode As eGuiMode ' Current DocumentViewer content mode

		Private Enum eGuiMode ' DocumentViewer content mode enumerations
			SingleVisual
			MultipleVisuals
			SingleFlowDocument
			SingleFixedDocument
			MultipleFixedDocuments
		End Enum

		#End Region 'Private Members


	End Class

End Namespace ' end:namespace SDKSample
