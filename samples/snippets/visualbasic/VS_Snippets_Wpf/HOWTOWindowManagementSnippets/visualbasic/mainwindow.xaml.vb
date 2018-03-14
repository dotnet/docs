Namespace HOWTOWindowManagementSnippets
	Partial Public Class MainWindow
		Inherits Window

		Public Sub New()
			InitializeComponent()

			'<SnippetOpenNewWindowCODE>
			Dim window As New CustomWindow()
			window.Show() ' Returns immediately
			'</SnippetOpenNewWindowCODE>

			'<SnippetOpenNewDialogBoxCODE>
			Dim dialogBox As New CustomDialogBox()
			dialogBox.ShowDialog() ' Returns when dialog box has closed
			'</SnippetOpenNewDialogBoxCODE>

			'<SnippetGetDialogResultCODE>
			Dim dialogBoxWithResult As New DialogBoxWithResult()
			' Open dialog box and retrieve dialog result when ShowDialog returns
			Dim dialogResult? As Boolean = dialogBoxWithResult.ShowDialog()
			Select Case dialogResult
				Case True
					' User accepted dialog box
				Case False
					' User canceled dialog box
				Case Else
					' Indeterminate
			End Select
			'</SnippetGetDialogResultCODE>

			'<SnippetSetWindowSizeToContentPropertyCODE>

			' Manually alter window height and width
			Me.SizeToContent = SizeToContent.Manual

			' Automatically resize width relative to content
			Me.SizeToContent = SizeToContent.Width

			' Automatically resize height relative to content
			Me.SizeToContent = SizeToContent.Height

			' Automatically resize height and width relative to content
			Me.SizeToContent = SizeToContent.WidthAndHeight
			'</SnippetSetWindowSizeToContentPropertyCODE>
		End Sub

	End Class
End Namespace