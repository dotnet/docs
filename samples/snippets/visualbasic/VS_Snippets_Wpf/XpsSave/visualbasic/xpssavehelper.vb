' XpsSave SDK Sample - XpsSaveHelper.vb
' Copyright (c) Microsoft Corporation. All rights reserved.


Imports System
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
Imports SDKSample


Namespace SDKSampleHelper
	' ------------------------- AsyncSaveEventArgs ------------------------
	''' <summary>
	'''   Event arg class for asynchronous save events.</summary>
	Public Class AsyncSaveEventArgs
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
	End Class ' end:class AsyncSaveEventArgs



	Public Class SaveHelper
		Friend Delegate Sub AsyncSaveChangeHandler(ByVal saveHelper As Object, ByVal asycnInformation As AsyncSaveEventArgs)

		Friend Event OnAsyncSaveChange As AsyncSaveChangeHandler


		#Region "Constructors"
		Public Sub New(ByVal contentPath As String)
			_xpfContent = New XPFContent(contentPath)
		End Sub
		#End Region ' Constructors


		#Region "Save Interface"
		Public Sub SaveSingleVisual(ByVal containerName As String, ByVal async As Boolean)
			' Create Visual
			Dim v As Visual = _xpfContent.CreateFirstVisual(True)

			' Create an saving XPSDocumentWriter.
			Dim xdwSave As XpsDocumentWriter = GetSaveXpsDocumentWriter(containerName)

			' Save content using helper function
			If async Then
				SaveVisualAsync(xdwSave, v)
			Else
				SaveVisual(xdwSave, v)
				' Close the pakcage
				_xpsDocument.Close()
			End If
		End Sub


		Public Sub SaveMultipleVisuals(ByVal containerName As String, ByVal async As Boolean)
			' Create a collection of visuals
			Dim vc As New List(Of Visual)()

			'Create Visuals
			vc.Add(_xpfContent.CreateFirstVisual(True))
			vc.Add(_xpfContent.CreateSecondVisual(True))
			vc.Add(_xpfContent.CreateThirdVisual(True))

			' Create a saving XPSDocumentWriter
			Dim xdwSave As XpsDocumentWriter = GetSaveXpsDocumentWriter(containerName)

			If async Then
				SaveVisualsAsync(xdwSave, vc)
			Else ' if (!async)
				' Save content using helper function
				SaveVisuals(xdwSave, vc)
				_xpsDocument.Close() ' Close the pakcage
			End If
		End Sub


		Public Sub SaveSingleFlowContentDocument(ByVal containerName As String, ByVal async As Boolean)
			' Create flow content
			Dim idp As DocumentPaginator = _xpfContent.CreateFlowDocument().DocumentPaginator

			' Create a saving XPSDocumentWriter
			' (temp file in current working directory).
			Dim xdwSave As XpsDocumentWriter = GetSaveXpsDocumentWriter(containerName)

			' Save content using helper function
			If async Then
				SaveSingleFlowContentDocumentAsync(xdwSave, idp)
			Else
				SaveSingleFlowContentDocument(xdwSave, idp)
				_xpsDocument.Close() ' Close the pakcage
			End If
		End Sub


		Public Sub SaveSingleFixedContentDocument(ByVal containerName As String, ByVal async As Boolean)
			' Create FixedDocument with associated PrintTicket
			Dim fd As FixedDocument = _xpfContent.CreateFixedDocumentWithPages()

			' Create a saving XPSDocumentWriter
			' (temp file in current working directory).
			Dim xdwSave As XpsDocumentWriter = GetSaveXpsDocumentWriter(containerName)

			If async Then
				SaveSingleFixedContentDocumentAsync(xdwSave, fd)
			Else
				SaveSingleFixedContentDocument(xdwSave, fd)
				_xpsDocument.Close() ' Close the package
			End If
		End Sub


		Public Sub SaveMultipleFixedContentDocuments(ByVal containerName As String, ByVal async As Boolean)
			' Create FixedDocumentSequence
			Dim fds As FixedDocumentSequence = _xpfContent.LoadFixedDocumentSequenceFromDocument()

			' Create a saving XPSDocumentWriter
			' (temp file in current working directory).
			Dim xdwSave As XpsDocumentWriter = GetSaveXpsDocumentWriter(containerName)

			If async Then
				SaveMultipleFixedContentDocumentsAsync(xdwSave, fds)
			Else
				' Save content using helper function
				SaveMultipleFixedContentDocuments(xdwSave, fds)
				' Close the pakcage
				_xpsDocument.Close()
			End If
		End Sub ' end:SaveMultipleFixedContentDocuments()

		' Save content displayed in a DocumentViewer Control
		Public Sub SaveDocumentViewerContent(ByVal dv As DocumentViewer, ByVal containerName As String, ByVal async As Boolean)
			If dv Is Nothing Then
				Return
			End If

			' Create an saving XPSDocumentWriter
			' (temp file in current working directory).
			Dim xdwSave As XpsDocumentWriter = GetSaveXpsDocumentWriter(containerName)

			If async Then
				SaveSingleFlowContentDocumentAsync(xdwSave, dv.Document.DocumentPaginator)
			Else
				' Access and Save DocumentViewer data
				SaveSingleFlowContentDocument(xdwSave, dv.Document.DocumentPaginator)
				_xpsDocument.Close() ' Close the package
			End If
		End Sub ' end:SaveDocumentViewerContent()

		#End Region

		#Region "Synchronous Save Methods"

		'<SnippetWriteToXpsWithVisual>
		Private Sub SaveVisual(ByVal xpsdw As XpsDocumentWriter, ByVal v As Visual)
			xpsdw.Write(v) ' Write visual to single page
		End Sub
		'</SnippetWriteToXpsWithVisual>


		'<SnippetCreateAndWriteToVisualsCollator>
		Private Sub SaveVisuals(ByVal xpsdw As XpsDocumentWriter, ByVal vc As List(Of Visual))
			' Setup for writing multiple visuals
			Dim vToXpsD As VisualsToXpsDocument = CType(xpsdw.CreateVisualsCollator(), VisualsToXpsDocument)

			' Iterate through all visuals in the collection
			For Each v As Visual In vc
				vToXpsD.Write(v) 'Write each visual to single page
			Next v

			' End writing multiple visuals
			vToXpsD.EndBatchWrite()
		End Sub
		'</SnippetCreateAndWriteToVisualsCollator>


		'<SnippetWriteToXpsWithDocumentPaginator>
		Private Sub SaveSingleFlowContentDocument(ByVal xpsdw As XpsDocumentWriter, ByVal docPaginator As DocumentPaginator)
			xpsdw.Write(docPaginator) ' Write the DocPaginator as a document.
		End Sub
		'</SnippetWriteToXpsWithDocumentPaginator>


		'<SnippetWriteToXpsWithFixedDocument>
		Private Sub SaveSingleFixedContentDocument(ByVal xpsdw As XpsDocumentWriter, ByVal fd As FixedDocument)
			xpsdw.Write(fd) ' Write the FixedDocument as a document.
		End Sub
		'</SnippetWriteToXpsWithFixedDocument>


		'<SnippetWriteToXpsWithFixedDocumentSequence>
		Private Sub SaveMultipleFixedContentDocuments(ByVal xpsdw As XpsDocumentWriter, ByVal fds As FixedDocumentSequence)
			' Write the FixedDocumentSequence as a collection of documents
			xpsdw.Write(fds)
		End Sub
		'</SnippetWriteToXpsWithFixedDocumentSequence>
		#End Region ' Synchronous Save Methods


		#Region "Asynchronous Save Methods"
		'<SnippetWriteAsyncToXpsWithVisual>
		Private Sub SaveVisualAsync(ByVal xpsdw As XpsDocumentWriter, ByVal v As Visual)
			_xpsdwActive = xpsdw

			AddHandler xpsdw.WritingCompleted, AddressOf AsyncSaveCompleted

			xpsdw.WriteAsync(v) ' Write visual to single page.
		End Sub
		'</SnippetWriteAsyncToXpsWithVisual>


		Private Sub SaveVisualsAsync(ByVal xpsdw As XpsDocumentWriter, ByVal vc As List(Of Visual))
			_xpsdwActive = xpsdw

			AddHandler xpsdw.WritingCompleted, AddressOf AsyncSaveCompleted

			AddHandler xpsdw.WritingProgressChanged, AddressOf AsyncSavingProgress

			' Setup for writing multiple visuals
			Dim vToXpsD As VisualsToXpsDocument = CType(xpsdw.CreateVisualsCollator(), VisualsToXpsDocument)

			_batchProgress = 0
			_activeVtoXPSD = vToXpsD

			' Iterate through all visuals in the collection
			For Each v As Visual In vc
				vToXpsD.WriteAsync(v) ' Write each visual to single page.
			Next v
		End Sub ' end:SaveVisualsAsync()


		'<SnippetWriteAsyncToXpsWithDocumentPaginator>
		Private Sub SaveSingleFlowContentDocumentAsync(ByVal xpsdw As XpsDocumentWriter, ByVal idp As DocumentPaginator)
			_xpsdwActive = xpsdw

			AddHandler xpsdw.WritingCompleted, AddressOf AsyncSaveCompleted

			' Write the IDP as a document.
			xpsdw.WriteAsync(idp)
		End Sub
		'</SnippetWriteAsyncToXpsWithDocumentPaginator>


		'<SnippetWriteAsyncToXpsWithFixedDocument>
		Private Sub SaveSingleFixedContentDocumentAsync(ByVal xpsdw As XpsDocumentWriter, ByVal fd As FixedDocument)
			_xpsdwActive = xpsdw

			AddHandler xpsdw.WritingCompleted, AddressOf AsyncSaveCompleted

			' Write the FixedDocument as a document.
			xpsdw.WriteAsync(fd)
		End Sub
		'</SnippetWriteAsyncToXpsWithFixedDocument>


		'<SnippetWritingEvents>
		'<SnippetWriteAsyncToXpsWithFixedDocumentSequence>
		Private Sub SaveMultipleFixedContentDocumentsAsync(ByVal xpsdw As XpsDocumentWriter, ByVal fds As FixedDocumentSequence)
			_xpsdwActive = xpsdw

			AddHandler xpsdw.WritingCompleted, AddressOf AsyncSaveCompleted

			AddHandler xpsdw.WritingProgressChanged, AddressOf AsyncSavingProgress

			' Write the FixedDocumentSequence as a
			' collection of documents asynchronously.
			xpsdw.WriteAsync(fds)
		End Sub
		'</SnippetWriteAsyncToXpsWithFixedDocumentSequence>


		' Cancel an async operation
		Public Sub CancelAsync()
			_xpsdwActive.CancelAsync()
		End Sub
		#End Region ' Asynchronous Save Methods


		#Region "Async Event Handlers"
		'
		' Create an "async operation complete" event handler
		' for saving a FixedDocumentSequence
		'
		Private Sub AsyncSaveCompleted(ByVal sender As Object, ByVal e As WritingCompletedEventArgs)
			Dim result As String
			If e.Cancelled Then
				result = "Canceled"
			ElseIf e.Error IsNot Nothing Then
				result = "Error"
			Else
				result = "Asynchronous operation Completed"
			End If

			' Close the pakcage
			_xpsDocument.Close()

			If OnAsyncSaveChangeEvent IsNot Nothing Then
				Dim asyncInfo As New AsyncSaveEventArgs(result, True)
				RaiseEvent OnAsyncSaveChange(Me, asyncInfo)
			End If
		End Sub

		'
		' Create an "async operation progress" event handler for
		' monitoring the progress of saving a FixedDocumentSequence.
		'
		Private Sub AsyncSavingProgress(ByVal sender As Object, ByVal e As WritingProgressChangedEventArgs)
			_batchProgress += 1

			If OnAsyncSaveChangeEvent IsNot Nothing Then
				Dim progress As String = String.Format("{0} - {1}", e.WritingLevel.ToString(), e.Number.ToString())
				Dim asyncInfo As New AsyncSaveEventArgs(progress, False)
				RaiseEvent OnAsyncSaveChange(Me, asyncInfo)
			End If

			' Call EndBatchWrite when serializing multiple visuals.
			If (_activeVtoXPSD IsNot Nothing) AndAlso (_batchProgress = 3) Then
				_activeVtoXPSD.EndBatchWrite()
			End If
		End Sub
		'</SnippetWritingEvents>
		#End Region ' Async Event Handlers


		Private Function GetSaveXpsDocumentWriter(ByVal containerName As String) As XpsDocumentWriter
			' Delete the file if it already exists
			File.Delete(containerName)

			' Create an XPS Document for saving

			'<SnippetCreateXpsDocumentWriter>

			_xpsDocument = New XpsDocument(containerName,FileAccess.ReadWrite)

			Dim xpsdw As XpsDocumentWriter = XpsDocument.CreateXpsDocumentWriter(_xpsDocument)

			'</SnippetCreateXpsDocumentWriter>

			Return xpsdw
		End Function

		#Region "Private Data"
		Private _batchProgress As Integer
		Private _xpfContent As XPFContent
		Private _activeVtoXPSD As VisualsToXpsDocument
		Private _xpsDocument As XpsDocument
		Private _xpsdwActive As XpsDocumentWriter
		#End Region ' Private Data

	End Class ' end:class SaveHelper

End Namespace ' end:namespace SDKSampleHelper

