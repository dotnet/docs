Imports System.Collections.Generic
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes

Namespace ResourcesSample
	''' <summary>
	''' Interaction logic for UriClassSnippetPage.xaml
	''' </summary>

	Partial Public Class UriClassSnippetPage
		Inherits Page
		Public Sub New()
			InitializeComponent()

		End Sub

		Private Sub bob(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim userProvidedUriTextBox As New TextBox()
			userProvidedUriTextBox.Text = "pack://application:,,,/File.xaml"
			Dim uri As New Uri(userProvidedUriTextBox.Text, UriKind.RelativeOrAbsolute) ' RelativeOrAbsoluteAbsolute
			Me.NavigationService.Navigate(uri)
		End Sub

	End Class
End Namespace