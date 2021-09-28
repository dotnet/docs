Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Markup

Namespace SDKSample
	Partial Public Class HomePage
		Inherits Page
		Private Sub HomePageLoaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			PackageStub1()
		End Sub

		Public Sub PackageStub1()
			myTextBlock.Foreground = Brushes.Maroon

			' <SnippetFontPackageSnippet4>
			' The font resource reference includes the base Uri (application directory level),
			' and the file resource location, which is relative to the base Uri.
			myTextBlock.FontFamily = New FontFamily(New Uri("pack://application:,,,/"), "/pages/#Pericles Light")
			' </SnippetFontPackageSnippet4>
		End Sub
	End Class
End Namespace
