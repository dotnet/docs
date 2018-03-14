Namespace SDKSample
	Partial Public Class DialogOwnerWindow
		Inherits Window
		Public Sub New()
			InitializeComponent()

			AddHandler Loaded, AddressOf DialogOwnerWindow_Loaded
		End Sub

		Private Sub DialogOwnerWindow_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			'<SnippetCreateNWDialogBox>
			' Open a navigation window as a dialog box
			Dim dlg As New NavigationWindowDialogBox()
			dlg.Source = New Uri("HomePage.xaml", UriKind.Relative)
			dlg.Owner = Me
			dlg.ShowDialog()
			'</SnippetCreateNWDialogBox>
		End Sub
	End Class
End Namespace