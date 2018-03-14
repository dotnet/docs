Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media.Imaging

Namespace ApplicationFindResourceSnippets

  Partial Public Class MainWindow
	  Inherits Window
	Public Sub New()
	  InitializeComponent()
	End Sub
	'<SnippetApplicationCallFindResourceCODEBEHIND>    
	Private Sub findResourceButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
	  Try
		Dim resource As Object = Application.Current.FindResource("UnfindableResource")
	  Catch ex As ResourceReferenceKeyNotFoundException
		MessageBox.Show("Resource not found.")
	  End Try
	End Sub
	'</SnippetApplicationCallFindResourceCODEBEHIND>
  End Class
End Namespace