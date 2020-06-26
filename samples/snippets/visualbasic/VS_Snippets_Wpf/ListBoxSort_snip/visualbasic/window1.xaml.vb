Imports System.Collections.Generic
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Shapes
Imports System.ComponentModel


Namespace ListBoxSort_snip
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>

	Partial Public Class Window1
		Inherits System.Windows.Window

		Public Sub New()
			InitializeComponent()
		End Sub

		'<SnippetHowToCode>
		Private Sub OnClick(ByVal sender As Object, ByVal e As RoutedEventArgs)
'<SnippetSort>
			myListBox.Items.SortDescriptions.Add(New SortDescription("Content", ListSortDirection.Descending))
'</SnippetSort>
		End Sub
		'</SnippetHowToCode>

	End Class
End Namespace