Imports System.Text

Namespace EditingCollectionsSnippets
	''' <summary>
	''' Interaction logic for ChangeItem.xaml
	''' </summary>
	Partial Public Class ChangeItemWindow
		Inherits Window
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Submit_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			DialogResult = True
			Close()
		End Sub
	End Class
End Namespace
