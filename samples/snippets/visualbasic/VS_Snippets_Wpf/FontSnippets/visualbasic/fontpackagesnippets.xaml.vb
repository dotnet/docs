Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media

Namespace SDKSample
	Partial Public Class FontPackageSnippets
		Inherits Page
		Private Sub FontPackageSnippetsLoaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			PackageStub6()
		End Sub

		Public Sub PackageStub1()
			myTextBlock.Foreground = Brushes.Maroon

			' <SnippetFontPackageSnippet2>
			' The font resource reference includes the base URI reference (application directory level),
			' and a relative URI reference.
			myTextBlock.FontFamily = New FontFamily(New Uri("pack://application:,,,/"), "./resources/#Pericles Light")
			' </SnippetFontPackageSnippet2>
		End Sub

		Public Sub PackageStub2()
			myTextBlock.Foreground = Brushes.Maroon

			' <SnippetFontPackageSnippet5>
			' The base URI reference can include an application subdirectory.
			myTextBlock.FontFamily = New FontFamily(New Uri("pack://application:,,,/resources/"), "./#Pericles Light")
			' </SnippetFontPackageSnippet5>
		End Sub

		Public Sub PackageStub3()
			myTextBlock.Foreground = Brushes.Maroon

			' <SnippetFontPackageSnippet6>
			' Create a new FontFamily object, using an absolute URI reference.
			myTextBlock.FontFamily = New FontFamily("file:///d:/MyFonts/#Pericles Light")
			' </SnippetFontPackageSnippet6>
		End Sub

				Public Sub PackageStub4()
			myTextBlock.Foreground = Brushes.Maroon

			' <SnippetFontPackageSnippet7>
			' Create a new FontFamily object, using a base URI reference and a relative URI reference.
			myTextBlock.FontFamily = New FontFamily(New Uri("file:///d:/MyFonts/"), "./#Pericles Light")
			' </SnippetFontPackageSnippet7>
				End Sub

		Public Sub PackageStub5()
			myTextBlock.Foreground = Brushes.Teal

			' <SnippetFontPackageSnippet9>
			' Create a new FontFamily object, using a font in the system fonts collection.
			myTextBlock.FontFamily = New FontFamily("Comic Sans MS")

			' The value of baseUri is null.
			Dim baseUri As Uri = myTextBlock.FontFamily.BaseUri

			' Create a new FontFamily object, using an absolute URI reference.
			myTextBlock.FontFamily = New FontFamily("file:///d:/MyFonts/#Pericles Light")

			' The value of baseUri is null.
			baseUri = myTextBlock.FontFamily.BaseUri

			' Create a new FontFamily object, using a base URI reference and a relative URI reference.
			myTextBlock.FontFamily = New FontFamily(New Uri("pack://application:,,,/resources/"), "./#Pericles Light")

			' The value of baseUri.AbsoluteUri is "pack://application:,,,/resources/".
			baseUri = myTextBlock.FontFamily.BaseUri
			' </SnippetFontPackageSnippet9>
		End Sub

		Public Sub PackageStub6()
			myTextBlock.Foreground = Brushes.SlateBlue

			' <SnippetFontPackageSnippet10>
			' Create a new FontFamily object, using a base URI reference and a relative URI reference.
			myTextBlock.FontFamily = New FontFamily(New Uri("pack://application:,,,/resources/"), "./#Pericles Light")

			' The value of baseUri.AbsoluteUri is "pack://application:,,,/resources/".
			Dim baseUri As Uri = myTextBlock.FontFamily.BaseUri

			' The value of source is "./#Pericles Light".
			Dim source As String = myTextBlock.FontFamily.Source
			' </SnippetFontPackageSnippet10>
		End Sub
	End Class
End Namespace
