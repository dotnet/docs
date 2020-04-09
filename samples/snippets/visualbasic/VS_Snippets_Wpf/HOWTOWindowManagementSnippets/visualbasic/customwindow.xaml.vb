Namespace HOWTOWindowManagementSnippets
	Partial Public Class CustomWindow
		Inherits Window
		Public Sub New()
			InitializeComponent()

			'<SnippetSettingMainWindowInCodeCODEBEHIND>
			Dim mainWindow As New NotTheFirstWindow()
			Application.Current.MainWindow = mainWindow
			'</SnippetSettingMainWindowInCodeCODEBEHIND>


			'<SnippetGetAllWindows>
			For Each window As Window In Application.Current.Windows
			  Console.WriteLine(window.Title)
			Next window
			'</SnippetGetAllWindows>
		End Sub
	End Class
End Namespace