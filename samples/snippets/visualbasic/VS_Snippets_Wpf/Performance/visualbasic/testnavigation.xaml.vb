Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Navigation
Imports System.ComponentModel

Namespace SDKSample
	Partial Public Class TestNavigation
		Inherits Page
		Private navWindow As NavigationWindow

		Private Sub Init(ByVal sender As Object, ByVal e As EventArgs)
			navWindow = CType(MyApp.Current.MainWindow, NavigationWindow)
		End Sub

		' <SnippetPerformanceSnippet14>
		Private Sub buttonGoToUri(ByVal sender As Object, ByVal args As RoutedEventArgs)
			navWindow.Source = New Uri("NewPage.xaml", UriKind.RelativeOrAbsolute)
		End Sub

		Private Sub buttonGoNewObject(ByVal sender As Object, ByVal args As RoutedEventArgs)
			Dim nextPage As New NewPage()
			nextPage.InitializeComponent()
			navWindow.Content = nextPage
		End Sub
		' </SnippetPerformanceSnippet14>

	End Class
End Namespace