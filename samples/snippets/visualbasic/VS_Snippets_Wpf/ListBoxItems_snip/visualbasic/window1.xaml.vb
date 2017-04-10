Imports System
Imports System.ComponentModel
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports System.Windows.Data

Namespace ListBox_Index
	Partial Public Class Window1
		Inherits Window
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub OnSelectionChanged(ByVal sender As Object, ByVal e As RoutedEventArgs)
			'<SnippetSelectorSelectedIndex>
			If lb.SelectedIndex = 0 Then
				Item.Content = "Index 0"
			'</SnippetSelectorSelectedIndex>
			ElseIf lb.SelectedIndex = 1 Then
				Item.Content = "Index 1"
			ElseIf lb.SelectedIndex = 2 Then
				Item.Content = "Index 2"
			ElseIf lb.SelectedIndex = 3 Then
				Item.Content = "Index 3"
			End If
		End Sub

		'<SnippetSelectorSelected>
		Private Sub OnSelected(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Item.Content = (CType(sender, ListBoxItem)).Name & " was selected."
		End Sub
		'</SnippetSelectorSelected>

		'<SnippetSelectorUnselected>
		Private Sub OnUnselected(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Item.Content = (CType(sender, ListBoxItem)).Name & " was unselected."
		End Sub
		'</SnippetSelectorUnselected>

	End Class
End Namespace