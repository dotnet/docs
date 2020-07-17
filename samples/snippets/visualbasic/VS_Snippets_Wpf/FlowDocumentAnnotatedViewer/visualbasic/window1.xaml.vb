Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.IO
Imports System.Windows
Imports System.Windows.Annotations
Imports System.Windows.Annotations.Storage
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents

Namespace FlowDocumentAnnotatedViewer
	Partial Public Class MainWindow
		Inherits Window
		Private stream As Stream
		Private service As AnnotationService
		Private store As AnnotationStore
		Private info As IAnchorInfo

		Public Sub New()
			InitializeComponent()

			AddHandler Loaded, AddressOf MainWindow_Loaded
			AddHandler Closed, AddressOf MainWindow_Closed
		End Sub

		Private Sub MainWindow_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			' Load annotations store
			Me.stream = New FileStream("storage.xml", FileMode.OpenOrCreate)
			Me.service = New AnnotationService(Me.flowDocumentReader)
			Me.store = New XmlStreamStore(Me.stream)
			Me.store.AutoFlush = True
			Me.service.Enable(Me.store)

			' Detect when annotations are added or deleted
			AddHandler service.Store.StoreContentChanged, AddressOf AnnotationStore_StoreContentChanged

			' Bind to annotations in store
			BindToAnnotations(Me.store.GetAnnotations())
		End Sub

		Private Sub MainWindow_Closed(ByVal sender As Object, ByVal e As EventArgs)
			If Me.service IsNot Nothing AndAlso Me.service.IsEnabled Then
				Me.service.Disable()
				Me.stream.Close()
			End If
		End Sub

		Private Sub AnnotationStore_StoreContentChanged(ByVal sender As Object, ByVal e As StoreContentChangedEventArgs)
			' Bind to refreshed annotations store
			BindToAnnotations(Me.store.GetAnnotations())
		End Sub

		'<SnippetHandler>
		Private Sub annotationsListBox_SelectionChanged(ByVal sender As Object, ByVal e As SelectionChangedEventArgs)

			Dim comment As Annotation = TryCast((TryCast(sender, ListBox)).SelectedItem, Annotation)
			If comment IsNot Nothing Then
                ' service is an AnnotationService object
				' comment is an Annotation object
				info = AnnotationHelper.GetAnchorInfo(Me.service, comment)
				Dim resolvedAnchor As TextAnchor = TryCast(info.ResolvedAnchor, TextAnchor)
				Dim textPointer As TextPointer = CType(resolvedAnchor.BoundingStart, TextPointer)
				textPointer.Paragraph.BringIntoView()
			End If
		End Sub
		'</SnippetHandler>

		Private Sub BindToAnnotations(ByVal annotations As IList(Of Annotation))
			' Bind to annotations in store
			Me.annotationsListBox.DataContext = annotations

			' Sort annotations by creation time
			Dim sortDescription As New SortDescription()
			sortDescription.PropertyName = "CreationTime"
			sortDescription.Direction = ListSortDirection.Descending
			Dim view As ICollectionView = CollectionViewSource.GetDefaultView(Me.annotationsListBox.DataContext)
			view.SortDescriptions.Clear()
			view.SortDescriptions.Add(sortDescription)
		End Sub
	End Class
End Namespace