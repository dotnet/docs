Imports Microsoft.VisualBasic
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data

Namespace BindingGroupSnippets
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>
	Partial Public Class Window1
		Inherits Window
		Public Sub New()
			InitializeComponent()

		End Sub

		'<SnippetWindowLogic>

		'<SnippetCommitEdit>
		Private Sub Submit_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			If stackPanel1.BindingGroup.CommitEdit() Then
				MessageBox.Show("Item submitted")
				stackPanel1.BindingGroup.BeginEdit()
			End If


		End Sub
		'</SnippetCommitEdit>

		'<SnippetErrorHandler>
		' This event occurs when a ValidationRule in the BindingGroup
		' or in a Binding fails.
		Private Sub ItemError(ByVal sender As Object, ByVal e As ValidationErrorEventArgs)
			If e.Action = ValidationErrorEventAction.Added Then
				MessageBox.Show(e.Error.ErrorContent.ToString())

			End If
		End Sub
		'</SnippetErrorHandler>

		'<SnippetBeginEdit>
		Private Sub stackPanel1_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			' Set the DataContext to a PurchaseItem object.
			' The BindingGroup and Binding objects use this as
			' the source.
			stackPanel1.DataContext = New PurchaseItem()

			' Begin an edit transaction that enables
			' the object to accept or roll back changes.
			stackPanel1.BindingGroup.BeginEdit()
		End Sub
		'</SnippetBeginEdit>

		'<SnippetCancelEdit>
		Private Sub Cancel_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			' Cancel the pending changes and begin a new edit transaction.
			stackPanel1.BindingGroup.CancelEdit()
			stackPanel1.BindingGroup.BeginEdit()
		End Sub
		'</SnippetCancelEdit>

		'</SnippetWindowLogic>

	End Class
End Namespace
