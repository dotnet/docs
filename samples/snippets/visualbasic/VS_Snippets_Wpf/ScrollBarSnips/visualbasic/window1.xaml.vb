Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Controls.Primitives

Namespace ScrollBarSnips
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>

	Partial Public Class Window1
		Inherits Window

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub InitializeScrollBar(ByVal sender As Object, ByVal e As EventArgs)

            'Dim ScrollActive As Boolean = myScrollBar.IsEnabledCore
            'MessageBox.Show(ScrollActive.ToString())
			'<SnippetOrientation>
			myScrollBar.Orientation = Orientation.Horizontal
			'</SnippetOrientation>

			'<SnippetTrack>
			Dim myScrollBarTrack As New Track()
			myScrollBarTrack = myScrollBar.Track
			'</SnippetTrack>

			'<SnippetViewport>
			myScrollBarViewport.ViewportSize = 10
			'</SnippetViewport>

		   '<SnippetCreateScrollBar>
		   Dim aScrollBar As New ScrollBar()
		   aScrollBar.Orientation = Orientation.Vertical
		   aScrollBar.Width = 200
		   AddHandler aScrollBar.Scroll, AddressOf OnScroll
		   aScrollBar.Minimum = 0
		   aScrollBar.Maximum = 50
			'</SnippetCreateScrollBar>

		End Sub


		'<SnippetScrollHandler>
		Private Sub OnScroll(ByVal sender As Object, ByVal e As RoutedEventArgs)
		   'Things to do when the Scroll event occurs
		End Sub
		'</SnippetScrollHandler>

	End Class
End Namespace