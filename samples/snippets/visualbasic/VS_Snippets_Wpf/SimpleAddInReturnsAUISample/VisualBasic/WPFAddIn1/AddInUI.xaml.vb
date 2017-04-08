'<SnippetAddInUICodeBehind>

Imports System.Windows ' MessageBox, RoutedEventArgs
Imports System.Windows.Controls ' UserControl

Namespace WPFAddIn1
	Partial Public Class AddInUI
		Inherits UserControl
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub clickMeButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			MessageBox.Show("Hello from WPFAddIn1")
		End Sub
	End Class
End Namespace
'</SnippetAddInUICodeBehind>