Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Shapes


Namespace TreeViewSnips
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>

	Partial Public Class Window1
		Inherits Window

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub InitializeTreeView(ByVal sender As Object, ByVal e As EventArgs)
			'<SnippetSelectedItem>
			Dim selectedTVI As TreeViewItem = CType(myTreeView.SelectedItem, TreeViewItem)
			'</SnippetSelectedItem>
			If myTreeView.SelectedValue Is Nothing Then
				'<SnippetSelectedValue>
				Dim selectedTVValue As TreeViewItem = CType(myTreeView.SelectedValue, TreeViewItem)
				'</SnippetSelectedValue>

				'<SnippetSelectedValuePath>
				Dim selectedTVValuePath As String = myTreeView.SelectedValuePath
				'</SnippetSelectedValuePath>

			End If
			'<SnippetIsExpanded>
			Employee1Data.IsExpanded = True
			'</SnippetIsExpanded>      
			'<SnippetIsSelected>
			EmployeeWorkDays.IsSelected = True
			'</SnippetIsSelected>      
			'<SnippetIsSelectionActive>
			Dim isEmployee1Active As Boolean = Employee1Data.IsSelectionActive
			'</SnippetIsSelectionActive> 
		End Sub
		'<SnippetSelectedValueChangedMethod>
		Private Sub SelectionChanged(ByVal sender As Object, ByVal e As RoutedPropertyChangedEventArgs(Of Object))
			'Perform actions when SelectedItem changes
			MessageBox.Show((CType(e.NewValue, TreeViewItem)).Header.ToString())
		End Sub
		'</SnippetSelectedValueChangedMethod>

		'<SnippetChooseWine>
		Private Sub GetSchedule(ByVal sender As Object, ByVal e As RoutedEventArgs)
			'Perform actions when a TreeViewItem
			'controls is selected
		End Sub
		'</SnippetChooseWine>

		'<SnippetChangeWineChoice>
		Private Sub SetSchedule(ByVal sender As Object, ByVal e As RoutedEventArgs)
			'Perform actions when a TreeViewItem
			'control becomes unselected
		End Sub
		'</SnippetChangeWineChoice>


		'<SnippetOnCollapsed>
		Private Sub OnCollapsed(ByVal sender As Object, ByVal e As RoutedEventArgs)
			'Perform actions when the TreeViewItem is collapsed
		End Sub
		'</SnippetOnCollapsed>

		'<SnippetOnExpanded>
		Private Sub OnExpanded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			'Perform actions when the TreeViewItem is expanded
		End Sub
		'</SnippetOnExpanded>

	End Class
End Namespace