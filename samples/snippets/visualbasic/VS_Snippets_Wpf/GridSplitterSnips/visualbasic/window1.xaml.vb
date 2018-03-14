Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Shapes
Imports System.Windows.Navigation

Namespace GridSplitterSnips
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>

	Partial Public Class Window1
		Inherits Page

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub InitializeGridSplitterSnip(ByVal sender As Object, ByVal e As EventArgs)
			Dim myGridSplitter As New GridSplitter()
			Grid.SetRow(myGridSplitter,6)
			Grid.SetColumn(myGridSplitter,6)
			'<SnippetDragIncrement>
			myGridSplitter.DragIncrement = 10
			'</SnippetDragIncrement>

			'<SnippetKeyboardIncrement>
			myGridSplitter.KeyboardIncrement = 25
			'</SnippetKeyboardIncrement>

			'<SnippetResizeDirection>
			myGridSplitter.ResizeDirection = GridResizeDirection.Columns
			'</SnippetResizeDirection>

			'<SnippetResizeBehavior>
			myGridSplitter.ResizeBehavior = GridResizeBehavior.CurrentAndNext
			'</SnippetResizeBehavior>

			'<SnippetShowsPreview>
			myGridSplitter.ShowsPreview = True
			'</SnippetShowsPreview>

			'<SnippetGridSplitterSimpleExample>
			 Dim mySimpleGridSplitter As New GridSplitter()
			 Grid.SetColumn(mySimpleGridSplitter, 0)
			 mySimpleGridSplitter.Background = Brushes.Blue
			 mySimpleGridSplitter.HorizontalAlignment = HorizontalAlignment.Right
			 mySimpleGridSplitter.VerticalAlignment = VerticalAlignment.Stretch
			 mySimpleGridSplitter.Width = 5
			'</SnippetGridSplitterSimpleExample>

		End Sub

	End Class
End Namespace