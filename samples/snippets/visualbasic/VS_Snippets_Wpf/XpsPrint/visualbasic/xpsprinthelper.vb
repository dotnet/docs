' XpsPrint SDK Sample - XpsPrintHelper.vb
' Copyright (c) Microsoft Corporation. All rights reserved.


Imports System.Collections.Generic
Imports System.IO
Imports System.IO.Packaging
Imports System.Printing
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Documents.Serialization
Imports System.Windows.Media
Imports System.Windows.Xps
Imports System.Windows.Xps.Packaging
Imports System.Windows.Xps.Serialization
Imports SDKSample


Namespace SDKSampleHelper
	' ----------------------- class AsyncSaveEventArgs -----------------------
	''' <summary>
	'''   Event arguments class for asynchronous print events.</summary>
	Public Class AsyncPrintEventArgs
		Inherits EventArgs
		Private _status As String
		Private _completed As Boolean

		Public ReadOnly Property Status() As String
			Get
				Return _status
			End Get
		End Property

		Public ReadOnly Property Completed() As Boolean
			Get
				Return _completed
			End Get
		End Property

		Public Sub New(ByVal status As String, ByVal completed As Boolean)
			_completed = completed
			_status = status
		End Sub
	End Class


	' ------------------------- class XpsPrintHelper -------------------------
	Public Class XpsPrintHelper
		Friend Delegate Sub AsyncPrintChangeHandler(ByVal printHelper As Object, ByVal asycnInformation As AsyncPrintEventArgs)

		Friend Event OnAsyncPrintChange As AsyncPrintChangeHandler

		#Region "Constructors"
		Public Sub New(ByVal contentPath As String)
			_wpfContent = New WPFContent(contentPath)
			_contentDir = contentPath
		End Sub
		#End Region ' Constructors

		#Region "Print Interface"
		' -------------------------- GetPrintDialog --------------------------
		''' <summary>
		'''   Displays a printer dialog that allows the
		'''   user to chose the printer to output to.</summary>
		''' <returns>
		'''   The print dialog with the results of the user selection;
		'''   or NULL if the user clicks "Cancel" to the dialog.</returns>
		Public Function GetPrintDialog() As PrintDialog
			Dim printDialog As PrintDialog = Nothing

			' Create a Print dialog.
			Dim dlg As New PrintDialog()

			' Show the printer dialog.  If the return is "true",
			' the user made a valid selection and clicked "Ok".
			If dlg.ShowDialog() = True Then
				printDialog = dlg ' return the dialog the user selections.
			End If

			Return printDialog
		End Function ' end:GetPrintDialog()


		' ------------------------- PrintSingleVisual ------------------------
		''' <summary>
		'''   Prints a single visual element.</summary>
		''' <param name="pq">
		'''   The print queue to print to.</param>
		''' <param name="async">
		'''   true to print asynchronously; false to print synchronously.</param>
		Public Sub PrintSingleVisual(ByVal pq As PrintQueue, ByVal async As Boolean)
			' Create a single visual element.
			Dim v As Canvas = _wpfContent.CreateFirstVisual(True)

			' Create a document writer to print to.
			Dim xdwPrint As XpsDocumentWriter = GetPrintXpsDocumentWriter(pq)

			' Transform the visual to fit the printer.
			Dim transformedVisual As Visual = PerformTransform(v, pq)

			' Print either asynchronously or synchronously.
			If async Then
				PrintVisualAsync(xdwPrint, transformedVisual)
			Else
				PrintVisual(xdwPrint, transformedVisual)
			End If
		End Sub


		' ----------------------- PrintMultipleVisuals -----------------------
		''' <summary>
		'''   Prints a collection of multiple visual elements.</summary>
		''' <param name="pq">
		'''   The print queue to print to.</param>
		''' <param name="async">
		'''   true to print asynchronously; false to print synchronously.</param>
		Public Sub PrintMultipleVisuals(ByVal pq As PrintQueue, ByVal async As Boolean)
			' Create a collection of visuals
			Dim vc As New List(Of Visual)()

			'Create Visuals
			Dim v As Visual
			v = _wpfContent.CreateFirstVisual(True)
			Dim transformedVisual As Visual = PerformTransform(v, pq)
			vc.Add(transformedVisual)

			v = _wpfContent.CreateSecondVisual(True)
			transformedVisual = PerformTransform(v, pq)
			vc.Add(transformedVisual)

			v = _wpfContent.CreateThirdVisual(True)
			transformedVisual = PerformTransform(v, pq)
			vc.Add(transformedVisual)

			' Retrieve Print Ticket from PrintQueue and
			' change the orientation to Landscape.
			Dim pt As PrintTicket = pq.UserPrintTicket
			pt.PageOrientation = PageOrientation.Landscape

			' Create an printing XPSDocumentWriter
			Dim xdwPrint As XpsDocumentWriter = GetPrintXpsDocumentWriter(pq)

			' Print either asynchronously or synchronously.
			If async Then
				PrintVisualsAsync(xdwPrint, vc)
			Else
				' Print content using helper function
				PrintVisuals(xdwPrint, vc)
			End If
		End Sub


		' ------------------ PrintSingleFlowContentDocument ------------------
		''' <summary>
		'''   Prints the content of a single flow document.</summary>
		''' <param name="pq">
		'''   The print queue to print to.</param>
		''' <param name="async">
		'''   true to print asynchronously; false to print synchronously.</param>
		Public Sub PrintSingleFlowContentDocument(ByVal pq As PrintQueue, ByVal async As Boolean)
			' Create a paginated flow document.
			Dim idp As DocumentPaginator = _wpfContent.CreateFlowDocument().DocumentPaginator

			' Create a document writer to print to.
			Dim xdwPrint As XpsDocumentWriter = GetPrintXpsDocumentWriter(pq)

			' Scale the paginated flow document to a visual for printing.
			Dim visual As Visual = _wpfContent.AdjustFlowDocumentToPage(idp, pq)

			' Print either asynchronously or synchronously.
			If async Then
				PrintVisual(xdwPrint, visual)
			Else
				PrintVisualAsync(xdwPrint, visual)
			End If
		End Sub


		' ------------------ PrintSingleFixedContentDocument -----------------
		''' <summary>
		'''   Prints the content of a single fixed document.</summary>
		''' <param name="pq">
		'''   The print queue to print to.</param>
		''' <param name="async">
		'''   true to print asynchronously; false to print synchronously.</param>
		Public Sub PrintSingleFixedContentDocument(ByVal pq As PrintQueue, ByVal async As Boolean)
			' Create a FixedDocument with associated PrintTicket.
			Dim fd As FixedDocument = _wpfContent.CreateFixedDocumentWithPages(pq)

			' Create a document writer to print to.
			Dim xdwPrint As XpsDocumentWriter = GetPrintXpsDocumentWriter(pq)

			' Print either asynchronously or synchronously.
			If async Then
				PrintSingleFixedContentDocumentAsync(xdwPrint, fd)
			Else
				PrintSingleFixedContentDocument(xdwPrint, fd)
			End If
		End Sub


		'<SnippetPrintMultipleFixedContentDocuments>

		' ---------------- PrintMultipleFixedContentDocuments ----------------
		''' <summary>
		'''   Prints the content of a multiple fixed document sequence.</summary>
		''' <param name="pq">
		'''   The print queue to print to.</param>
		''' <param name="async">
		'''   true to print asynchronously; false to print synchronously.</param>
		Public Sub PrintMultipleFixedContentDocuments(ByVal pq As PrintQueue, ByVal async As Boolean)
			' Create a multiple document FixedDocumentSequence.
			Dim fds As FixedDocumentSequence = _wpfContent.LoadFixedDocumentSequenceFromDocument()

			' Create a document writer to print to.
			Dim xdwPrint As XpsDocumentWriter = GetPrintXpsDocumentWriter(pq)

			' Set the event handler for creating print tickets for
			' each document within the fixed document sequence.
			AddHandler xdwPrint.WritingPrintTicketRequired, AddressOf MultipleFixedContentDocuments_WritingPrintTicketRequired
			_firstDocumentPrintTicket = 0

			' Print either asynchronously or synchronously.
			If async Then
				PrintMultipleFixedContentDocumentsAsync(xdwPrint, fds)
			Else
				PrintMultipleFixedContentDocuments(xdwPrint, fds)
			End If
		End Sub

		'</SnippetPrintMultipleFixedContentDocuments>


		' -------------------- PrintDocumentViewerContent --------------------
		''' <summary>
		'''   Prints the content displayed in a
		'''   given DocumentViewer control.</summary>
		''' <param name="dv">
		'''   The DocumentViewer content to print.</param>
		''' <param name="pq">
		'''   The print queue to print to.</param>
		''' <param name="async">
		'''   true to print asynchronously; false to print synchronously.</param>
		Public Sub PrintDocumentViewerContent(ByVal dv As DocumentViewer, ByVal pq As PrintQueue, ByVal async As Boolean)
			' Create a document writer for printing
			Dim xdwPrint As XpsDocumentWriter = GetPrintXpsDocumentWriter(pq)

			' Scale the DocumentViewer content for the printer.
			Dim idp As DocumentPaginator = dv.Document.DocumentPaginator
			Dim visual As Visual = _wpfContent.AdjustFlowDocumentToPage(idp, pq)

			' Print either asynchronously or synchronously.
			If async Then
				PrintVisual(xdwPrint, visual)
			Else
				PrintVisualAsync(xdwPrint, visual)
			End If
		End Sub

		#End Region ' Print Interface


		#Region "Synchronous Print Methods"

		' ------------------------- PrintVisualAsync -------------------------
		''' <summary>
		'''   Synchronously prints a given visual
		'''   to a specified document writer.</summary>
		''' <param name="xpsdw">
		'''   The document writer to output to.</param>
		''' <param name="v">
		'''   The visual to print.</param>
		Private Sub PrintVisual(ByVal xpsdw As XpsDocumentWriter, ByVal v As Visual)
			xpsdw.Write(v) ' Write visual to single page
		End Sub


		' --------------------------- PrintVisuals ---------------------------
		''' <summary>
		'''   Synchronously prints of a given list of
		'''   visuals to a specified document writer.</summary>
		''' <param name="xpsdw">
		'''   The document writer to output to.</param>
		''' <param name="vc">
		'''   The list of visuals to print.</param>
		Private Sub PrintVisuals(ByVal xpsdw As XpsDocumentWriter, ByVal vc As List(Of Visual))
			' Setup for writing multiple visuals
			Dim vToXpsD As VisualsToXpsDocument = CType(xpsdw.CreateVisualsCollator(), VisualsToXpsDocument)

			' Iterate through all visuals in the collection
			For Each v As Visual In vc
				vToXpsD.Write(v) 'Write each visual to single page
			Next v

			' End writing multiple visuals
			vToXpsD.EndBatchWrite()
		End Sub


		' ------------------ PrintSingleFlowContentDocument ------------------
		''' <summary>
		'''   Synchronously prints a given paginated flow
		'''   document to a specified document writer.</summary>
		''' <param name="xpsdw">
		'''   The document writer to output to.</param>
		''' <param name="idp">
		'''   The paginated flow document to print.</param>
		Private Sub PrintSingleFlowContentDocument(ByVal xpsdw As XpsDocumentWriter, ByVal idp As DocumentPaginator)
			xpsdw.Write(idp) ' Write the IDP as a document
		End Sub

		' ----------------- PrintSingleFixedContentDocument ------------------
		''' <summary>
		'''   Synchronously prints of a given fixed
		'''   document to a specified document writer.</summary>
		''' <param name="xpsdw">
		'''   The document writer to output to.</param>
		''' <param name="fd">
		'''   The fixed document to print.</param>
		Private Sub PrintSingleFixedContentDocument(ByVal xpsdw As XpsDocumentWriter, ByVal fd As FixedDocument)
			xpsdw.Write(fd) ' Write the FixedDocument as a document.
		End Sub


		' ---------------- PrintMultipleFixedContentDocuments ----------------
		''' <summary>
		'''   Synchronously prints multiple fixed documents from a given
		'''   FixedDocumentSequence to a specified DocumentWriter.</summary>
		''' <param name="xpsdw">
		'''   The document writer to output to.</param>
		''' <param name="fds">
		'''   The fixed document sequence to print.</param>
		Private Sub PrintMultipleFixedContentDocuments(ByVal xpsdw As XpsDocumentWriter, ByVal fds As FixedDocumentSequence)
			xpsdw.Write(fds) ' Write as a collection of documents.
		End Sub

		#End Region ' Synchronous Print Methods


		#Region "Asynchronous Print Methods"

		' ------------------------- PrintVisualAsync -------------------------
		''' <summary>
		'''   Initiates asynchronous output of a given
		'''   visual to a specified document writer.</summary>
		''' <param name="xpsdw">
		'''   The document writer to output to.</param>
		''' <param name="v">
		'''   The visual to print.</param>
		Private Sub PrintVisualAsync(ByVal xpsdw As XpsDocumentWriter, ByVal v As Visual)
			_xpsdwActive = xpsdw ' Save the active document writer.

			AddHandler xpsdw.WritingCompleted, AddressOf AsyncPrintCompleted

			xpsdw.WriteAsync(v) ' Write the visual to a single page.
		End Sub


		' ------------------------- PrintVisualsAsync ------------------------
		''' <summary>
		'''   Initiates asynchronous output of a given list of
		'''   visuals to a specified document writer.</summary>
		''' <param name="xpsdw">
		'''   The document writer to output to.</param>
		''' <param name="vc">
		'''   The list of visuals to print.</param>
		Private Sub PrintVisualsAsync(ByVal xpsdw As XpsDocumentWriter, ByVal vc As List(Of Visual))
			_xpsdwActive = xpsdw ' Save the active document writer.

			AddHandler xpsdw.WritingCompleted, AddressOf AsyncPrintCompleted

			AddHandler xpsdw.WritingProgressChanged, AddressOf AsyncPrintingProgress

			' Setup for writing multiple visuals
			Dim vToXpsD As VisualsToXpsDocument = CType(xpsdw.CreateVisualsCollator(), VisualsToXpsDocument)

			_batchProgress = 0
			_activeVtoXPSD = vToXpsD

			' Iterate through all visuals in the collection.
			For Each v As Visual In vc
				vToXpsD.WriteAsync(v) 'Write each visual to a single page.
			Next v
		End Sub


		' --------------- PrintSingleFlowContentDocumentAsync ----------------
		''' <summary>
		'''   Initiates asynchronous output of a given paginated
		'''   flow document to a specified document writer.</summary>
		''' <param name="xpsdw">
		'''   The document writer to output to.</param>
		''' <param name="idp">
		'''   The paginated flow document to print.</param>
		Private Sub PrintSingleFlowContentDocumentAsync(ByVal xpsdw As XpsDocumentWriter, ByVal idp As DocumentPaginator)
			_xpsdwActive = xpsdw ' Save the active document writer.

			AddHandler xpsdw.WritingCompleted, AddressOf AsyncPrintCompleted

			xpsdw.WriteAsync(idp) ' Write the IDP as a document.
		End Sub


		' --------------- PrintSingleFixedContentDocumentAsync ---------------
		''' <summary>
		'''   Initiates asynchronous print of a given fixed
		'''   document to a specified document writer.</summary>
		''' <param name="xpsdw">
		'''   The document writer to output to.</param>
		''' <param name="fd">
		'''   The fixed document to print.</param>
		Private Sub PrintSingleFixedContentDocumentAsync(ByVal xpsdw As XpsDocumentWriter, ByVal fd As FixedDocument)
			_xpsdwActive = xpsdw ' Save the active document writer.

			AddHandler xpsdw.WritingCompleted, AddressOf AsyncPrintCompleted

			xpsdw.WriteAsync(fd) ' Print the FixedDocument.
		End Sub


		' -------------- PrintMultipleFixedContentDocumentsAsync -------------
		''' <summary>
		'''   Initiates asynchronous print of multiple fixed documents from a
		'''   given FixedDocumentSequence to a specified DocumentWriter.</summary>
		''' <param name="xpsdw">
		'''   The document writer to output to.</param>
		''' <param name="fds">
		'''   The fixed document sequence to print.</param>
		Private Sub PrintMultipleFixedContentDocumentsAsync(ByVal xpsdw As XpsDocumentWriter, ByVal fds As FixedDocumentSequence)
			_xpsdwActive = xpsdw ' Save the active document writer.

			AddHandler xpsdw.WritingCompleted, AddressOf AsyncPrintCompleted

			AddHandler xpsdw.WritingProgressChanged, AddressOf AsyncPrintingProgress

			' Write the FixedDocumentSequence as a
			' collection of documents asynchronously.
			xpsdw.WriteAsync(fds)
		End Sub


		' ---------------------------- CancelAsync ---------------------------
		''' <summary>
		'''   Cancels the current asynchronous print opertion.</summary>
		Public Sub CancelAsync()
			_xpsdwActive.CancelAsync()
		End Sub

		#End Region ' Asynchronous Print Methods


		#Region "Async Event Handlers"

		' ------------------------ AsyncPrintCompleted -----------------------
		''' <summary>
		'''   Creates an "async operation complete" event handler
		'''   for print completion of a FixedDocumentSequence.</summary>
		Private Sub AsyncPrintCompleted(ByVal sender As Object, ByVal e As WritingCompletedEventArgs)
			Dim result As String = Nothing
			If e.Cancelled Then
				result = "Canceled"
			ElseIf e.Error IsNot Nothing Then
				result = "Error"
			Else
				result = "Asynchronous Print Completed"
			End If

			If OnAsyncPrintChangeEvent IsNot Nothing Then
				Dim asyncInfo As New AsyncPrintEventArgs(result, True)
				RaiseEvent OnAsyncPrintChange(Me, asyncInfo) ' update display status
			End If
		End Sub


		' ----------------------- AsyncPrintingProgress ----------------------
		''' <summary>
		'''   Creates an "async operation progress" event handler for tracking
		'''   the progress in printing a FixedDocumentSequence.</summary>
		Private Sub AsyncPrintingProgress(ByVal sender As Object, ByVal e As WritingProgressChangedEventArgs)
			_batchProgress += 1

			If OnAsyncPrintChangeEvent IsNot Nothing Then
				Dim progress As String = String.Format("{0} - {1}", e.WritingLevel.ToString(), e.Number.ToString())
				Dim asyncInfo As New AsyncPrintEventArgs(progress, False)
				RaiseEvent OnAsyncPrintChange(Me, asyncInfo) ' update display status
			End If

			' Will only called EndBatchWrite when serializing Multiple Visuals
			If _activeVtoXPSD IsNot Nothing AndAlso _batchProgress = 3 Then
				_activeVtoXPSD.EndBatchWrite()
			End If
		End Sub

		'<SnippetMultipleFixedContentDocuments_WritingPrintTicketRequired>

		' ----- MultipleFixedContentDocuments_WritingPrintTicketRequired -----
		''' <summary>
		'''   Creates a PrintTicket event handler for
		'''   printing a FixedDocumentSequence.</summary>
		Private Sub MultipleFixedContentDocuments_WritingPrintTicketRequired(ByVal sender As Object, ByVal e As WritingPrintTicketRequiredEventArgs)
			If e.CurrentPrintTicketLevel = PrintTicketLevel.FixedDocumentSequencePrintTicket Then
				' Create a PrintTicket for the FixedDocumentSequence. Any
				' PrintTicket setting specified at the FixedDocumentSequence
				' level will be inherited by lower level (i.e. FixedDocument or
				' FixedPage) unless there exists lower level PrintTicket that
				' sets the setting differently, in which case the lower level
				' PrintTicket setting will override the higher level setting.
				Dim ptFDS As New PrintTicket()
				ptFDS.PageOrientation = PageOrientation.Portrait
				ptFDS.Duplexing = Duplexing.TwoSidedLongEdge
				e.CurrentPrintTicket = ptFDS

			ElseIf e.CurrentPrintTicketLevel = PrintTicketLevel.FixedDocumentPrintTicket Then
				' <SnippetOutputColorAndPageOrientation>
				' Use different PrintTickets for different FixedDocuments.
				Dim ptFD As New PrintTicket()

				If _firstDocumentPrintTicket <= 1 Then
					' orientation.  Since the PrintTicket at the
					' FixedDocumentSequence level already specifies portrait
					' orientation, this FixedDocument can just inherit that
					' setting without having to set it again.
					ptFD.PageOrientation = PageOrientation.Portrait
					ptFD.OutputColor = OutputColor.Monochrome
					_firstDocumentPrintTicket += 1

				Else ' if (_firstDocumentPrintTicket > 1)
					' orientation.  Since the PrintTicket at the
					' FixedDocumentSequence level already specifies portrait
					' orientation, this FixedDocument needs to set its
					' PrintTicket with landscape orientation in order to
					' override the higher level setting.
					ptFD.PageOrientation = PageOrientation.Landscape
					ptFD.OutputColor = OutputColor.Color
				End If
				' </SnippetOutputColorAndPageOrientation>

				e.CurrentPrintTicket = ptFD
			End If ' end:else if (CurrentPrintTicketLevel==FixedDocumentPrintTicket)

			' Even though we don't show code for specifying PrintTicket for
			' the FixedPage level, the same inheritance-override logic applies
			' to FixedPage as well.

		End Sub

		'</SnippetMultipleFixedContentDocuments_WritingPrintTicketRequired>

		' -------------- CreateFixedDocumentSequencePrintTicket --------------
		''' <summary>
		'''   Creates a FixedDocumentSequence compatible PrintTicket.</summary>
		''' <returns>
		'''   A FixedDocumentSequence compatible PrintTicket.</returns>
		Private Function CreateFixedDocumentSequencePrintTicket() As PrintTicket
			' Create a local print server
			Dim ps As New LocalPrintServer()

			' Get the default print queue
			Dim pq As PrintQueue = ps.DefaultPrintQueue

			' Get the default user print ticket
			Dim pt As PrintTicket = pq.UserPrintTicket

			' Set Duplexing value for each document in the job
			pt.Duplexing = Duplexing.OneSided

			Return pt
		End Function ' end:CreateFixedDocumentSequencePrintTicket()


		' ------------------ CreateFixedDocumentPrintTicket ------------------
		''' <summary>
		'''   Creates a FixedDocument compatible PrintTicket.</summary>
		''' <param name="isLandscaped">
		'''   true to output in landscape; false to output in portrait.</param>
		''' <returns>
		'''   A FixedDocument compatible PrintTicket.</returns>
		Private Function CreateFixedDocumentPrintTicket(ByVal isLandscaped As Boolean) As PrintTicket
			' Create a local print server
			Dim ps As New LocalPrintServer()

			' Get the default print queue
			Dim pq As PrintQueue = ps.DefaultPrintQueue

			' Get the default user print ticket
			Dim pt As PrintTicket = pq.UserPrintTicket

			' Set Duplexing value for the document
			pt.Duplexing = Duplexing.TwoSidedLongEdge

			If isLandscaped Then
				pt.PageOrientation = PageOrientation.Landscape
			End If

			Return pt
		End Function ' end:CreateFixedDocumentPrintTicket()

		#End Region ' Async Event Handlers


		#Region "Helper Methods"

		'<SnippetPrintQueueSnip>
		' -------------------- GetPrintXpsDocumentWriter() -------------------
		''' <summary>
		'''   Returns an XpsDocumentWriter for the default print queue.</summary>
		''' <returns>
		'''   An XpsDocumentWriter for the default print queue.</returns>
		Private Function GetPrintXpsDocumentWriter() As XpsDocumentWriter
			' Create a local print server
			Dim ps As New LocalPrintServer()

			' Get the default print queue
			Dim pq As PrintQueue = ps.DefaultPrintQueue

			' Get an XpsDocumentWriter for the default print queue
			Dim xpsdw As XpsDocumentWriter = PrintQueue.CreateXpsDocumentWriter(pq)
			Return xpsdw
		End Function ' end:GetPrintXpsDocumentWriter()
		'</SnippetPrintQueueSnip>

		' --------------- GetPrintXpsDocumentWriter(PrintQueue) --------------
		''' <summary>
		'''   Returns an XpsDocumentWriter for a given print queue.</summary>
		''' <param name="pq">
		'''   The print queue to return the XpsDocumentWriter for.</param>
		''' <returns>
		'''   An XpsDocumentWriter for the given print queue.</returns>
		Private Function GetPrintXpsDocumentWriter(ByVal pq As PrintQueue) As XpsDocumentWriter
			Dim xpsdw As XpsDocumentWriter = PrintQueue.CreateXpsDocumentWriter(pq)
			Return xpsdw
		End Function ' end:GetPrintXpsDocumentWriter(PrintQueue)


		' -------------------- GetPrintXpsDocumentWriter() -------------------
		' <SnippetPageMediaSize>
		''' <summary>
		'''   Returns a scaled copy of a given visual transformed to
		'''   fit for printing to a specified print queue.</summary>
		''' <param name="v">
		'''   The visual to be printed.</param>
		''' <param name="pq">
		'''   The print queue to be output to.</param>
		''' <returns>
		'''   The root element of the transformed visual.</returns>
		Private Function PerformTransform(ByVal v As Visual, ByVal pq As PrintQueue) As Visual
			Dim root As New ContainerVisual()
			Const inch As Double = 96

			' Set the margins.
			Dim xMargin As Double = 1.25 * inch
			Dim yMargin As Double = 1 * inch

			Dim pt As PrintTicket = pq.UserPrintTicket
			Dim printableWidth As Double = pt.PageMediaSize.Width.Value
			Dim printableHeight As Double = pt.PageMediaSize.Height.Value

			Dim xScale As Double = (printableWidth - xMargin * 2) / printableWidth
			Dim yScale As Double = (printableHeight - yMargin * 2) / printableHeight

			root.Children.Add(v)
			root.Transform = New MatrixTransform(xScale, 0, 0, yScale, xMargin, yMargin)

			Return root
		End Function ' end:PerformTransform()
		' </SnippetPageMediaSize>


		#End Region ' Helper Methods


		#Region "Private Data"
		Private _batchProgress As Integer = 0
		Private _firstDocumentPrintTicket As Integer = 0
		Private _contentDir As String = Nothing
		Private _wpfContent As WPFContent = Nothing
		Private _activeVtoXPSD As VisualsToXpsDocument = Nothing
		Private _xpsdwActive As XpsDocumentWriter = Nothing
		#End Region ' Private Data

	End Class

End Namespace ' end:namespace SDKSampleHelper
