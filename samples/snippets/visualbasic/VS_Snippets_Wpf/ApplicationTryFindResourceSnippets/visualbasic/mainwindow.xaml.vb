Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media.Imaging

Namespace ApplicationTryFindResourceSnippets

  Partial Public Class MainWindow
	  Inherits Window
	Public Sub New()
	  InitializeComponent()
	End Sub
	'<SnippetApplicationCallTryFindResourceCODEBEHIND1>    
	Private Sub tryFindResourceButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
	  Dim resource As Object = Application.Current.TryFindResource("ApplicationResource")
	  ' If resource found, do something with it
	  If resource IsNot Nothing Then
		'</SnippetApplicationCallTryFindResourceCODEBEHIND1>
		'<SnippetApplicationCallTryFindResourceCODEBEHIND2>
	  End If
	End Sub
	'</SnippetApplicationCallTryFindResourceCODEBEHIND2>
  End Class
End Namespace