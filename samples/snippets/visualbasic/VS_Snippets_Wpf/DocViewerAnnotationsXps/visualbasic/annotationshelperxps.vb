' DocViewerAnnotationsXps SDK Sample - AnnotationsHelperXps.vb
' Copyright (c) Microsoft Corporation. All rights reserved.

Imports System.Text
Imports System.Windows.Annotations.Storage
Imports System.IO
Imports System.Windows.Annotations
Imports System.IO.Packaging

Namespace SDKSample
	' ====================== class AnnotationsHelperXps ======================
	''' <summary>
	'''   Provides helper methods for creating and storing user annotations
	'''   within an XML file stored in an XPS document container.</summary>
	Public Class AnnotationsHelperXps

		' ------------- AnnotationsHelperXps default constructor -------------
		''' <summary>
		'''   Initializes a new instance of the class.</summary>
		Public Sub New()
		End Sub


		' --------- AnnotationsHelperXps DocumentViewer constructor ----------
		''' <summary>
		'''   Initializes a new instance of the AnnotationsHelperXps
		'''   class with a given target DocumentViewer.</summary>
		Public Sub New(ByVal dv As DocumentViewer)
			_docViewer = dv
		End Sub


		' --------------------- DocViewer Getter/Setter ----------------------
		''' <summary>
		'''   Sets and gets the DocumentViewer control that
		'''   contains the content to be annotated.</summary>
		Public Property DocViewer() As DocumentViewer
			Set(ByVal value As DocumentViewer)
					_docViewer = value
			End Set
			Get
					Return _docViewer
			End Get
		End Property


		' ---------------------------- SetSource -----------------------------
		''' <summary>
		'''   Sets the source document packageURI
		'''   and FixedDocumentSequence URI.</summary>
		''' <param name="packageUri">
		'''   The URI path and filename of the XPS document container.</param>
		''' <param name="rootUri">
		'''   The URI of the root FixedDocumentSequence in the package.</param>
		''' <remarks>
		'''     SetSource must be called first before
		'''     calling StartAnnotations().</remarks>
		Public Sub SetSource(ByVal packageUri As Uri, ByVal rootUri As Uri)
			_packageUri = packageUri
			_rootUri = rootUri
		End Sub


		'<SnippetStartStopAnnotations>
		'<SnippetStartAnnotations>
		' ------------------------- StartAnnotations -------------------------
		''' <summary>
		'''   Enables annotations processing and
		'''   displays viewable annotations.</summary>
		''' <remarks>
		'''     SetSource must be called first before
		'''     calling StartAnnotations().</remarks>
		Public Sub StartAnnotations()
			If _docViewer Is Nothing Then
				Throw New InvalidOperationException("Required DocumentViewer control has not been specified.")
			End If

			If (_packageUri Is Nothing) OrElse (_rootUri Is Nothing) Then
				Throw New InvalidOperationException("Required SetSource() has not been called.")
			End If

			' If there is no AnnotationService yet, create one.
			If _annotService Is Nothing Then
				' Get the annotations data stream from the XPS container.
				_annotStream = GetAnnotationPart(_rootUri).GetStream()

				' Create the AnnotationService.
				_annotService = New AnnotationService(_docViewer)

				' Enable the service with the annotation data stream.
				_annotService.Enable(New XmlStreamStore(_annotStream))

			' Else if the annotationService exists but is not enabled, enable it.
			ElseIf Not _annotService.IsEnabled Then
				_annotService.Enable(_annotService.Store)
			End If

		End Sub ' end:StartAnnotations()
		'</SnippetStartAnnotations>


		'<SnippetStopAnnotations>
		' -------------------------- StopAnnotations -------------------------
		''' <summary>
		'''   Disables annotations processing and hides annotations.</summary>
		Public Sub StopAnnotations()
			' If the AnnotationStore is active, flush and close it.
			If (_annotService IsNot Nothing) AndAlso _annotService.IsEnabled Then
				_annotService.Store.Flush()
				_annotStream.Flush()
				_annotStream.Close()
			End If

			' If the AnnotationService is active, shut it down.
			If _annotService IsNot Nothing Then
				If _annotService.IsEnabled Then
					_annotService.Disable()
				End If
				_annotService = Nothing
			End If
		End Sub ' end:StopAnnotations()
		'</SnippetStopAnnotations>
		'</SnippetStartStopAnnotations>


		'<SnippetDocViewAnnXpsDocPaginator>
		' ------------------ GetAnnotationDocumentPaginator ------------------
		''' <summary>
		'''   Returns a paginator for printing annotations.</summary>
		''' <param name="fds">
		'''   The FixedDocumentSequence containing
		'''   the annotations to print.</param>
		''' <returns>
		'''   An paginator for printing the document's annotations.</returns>
		Public Function GetAnnotationDocumentPaginator(ByVal fds As FixedDocumentSequence) As AnnotationDocumentPaginator
			Return New AnnotationDocumentPaginator(fds.DocumentPaginator, _annotService.Store)
		End Function
		'</SnippetDocViewAnnXpsDocPaginator>


		' ------------------------ GetAnnotationsPart ------------------------
		''' <summary>
		'''   Returns the part within an XPS document
		'''   for storing user annotations.</summary>
		''' <param name="documentUri">
		'''   The URI of the FixedDocumentSequence
		'''   within the package to annotate.</param>
		''' <returns>
		'''   The package part containing existing user annotations
		'''   and for storing new annotations.</returns>
		''' <remarks>
		'''   If the document package does not as yet contain an annotations
		'''   part, a new empty one is created and returned.</remarks>
		Private Function GetAnnotationPart(ByVal documentUri As Uri) As PackagePart
			' Open the document package.
			Dim package As Package = PackageStore.GetPackage(_packageUri)
			If package Is Nothing Then
				Throw New InvalidOperationException("The document package '" & _packageUri.ToString() & "' does not exist.")
			End If

			' Get the FixedDocumentSequence part from the package.
			Dim docPart As PackagePart = package.GetPart(documentUri)

			' Search through all the document relationships to find the
			' annotations relationship part (or null, of there is none).
			Dim annotRel As PackageRelationship = Nothing
			For Each rel As PackageRelationship In docPart.GetRelationshipsByType(_annotRelsType)
				annotRel = rel
			Next rel

			' If annotations relationship does not exist, create a new
			' annotations part along with a relationship part for it.
			Dim annotPart As PackagePart = Nothing
			If annotRel Is Nothing Then
				' Create a new Annotations part.
				annotPart = package.CreatePart(PackUriHelper.CreatePartUri(New Uri(_annotFile, UriKind.Relative)), _annotContentType)
				' Create a new relationship that points to the Annotations part.
				docPart.CreateRelationship(annotPart.Uri, TargetMode.Internal, _annotRelsType)

			' If an annotations relationship exists,
			' get the annotations part that it references.
			Else ' if (annotRel != null)
				annotPart = package.GetPart(annotRel.TargetUri)
				If annotPart Is Nothing Then
                    Throw New InvalidOperationException("The Annotations part referenced by the Annotations " & "Relationship TargetURI '" & annotRel.TargetUri.ToString() & "' could not be found.")
				End If
			End If

			Return annotPart
		End Function ' end:GetAnnotationPart()


		#Region "private variables"

		' Application's DocumentViewer control.
		Private _docViewer As DocumentViewer = Nothing

		' URI path and filename of the document container.
		Private _packageUri As Uri = Nothing

		' URI of the document's FixedDocumentSequence part within the package.
		Private _rootUri As Uri = Nothing

		' URI of the annotations XML filestore part within the package.
		Private _annotFile As String = "/Annotations.xml"

		Private _annotService As AnnotationService = Nothing ' AnnotationService
		Private _annotStream As Stream = Nothing ' Annotation IO stream

		' Annotations Relationship part type
		Private ReadOnly _annotRelsType As String = "http://schemas.microsoft.com/xps/2005/06/annotations"

		' Annotations Content part type
		Private ReadOnly _annotContentType As String = "application/vnd.ms-package.annotations+xml"

		#End Region ' private variables

	End Class ' end:class AnnotationsHelperXps

End Namespace ' end:namespace SDKSample
