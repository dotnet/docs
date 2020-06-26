'<SnippetAddInUICodeBehind>

Imports System.Windows
Imports System.Windows.Controls

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