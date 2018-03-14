'<SnippetAddInCodeBehind>

Imports System.AddIn
Imports System.Windows

Imports AddInViews

Namespace WPFAddIn1
	''' <summary>
	''' Implements the add-in by deriving from WPFAddInView
	''' </summary>
	<AddIn("WPF Add-In 1")>
	Partial Public Class AddInUI
		Inherits WPFAddInView
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub clickMeButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			MessageBox.Show("Hello from WPFAddIn1")
		End Sub
	End Class
End Namespace
'</SnippetAddInCodeBehind>