Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Shapes
Imports System.Windows.Navigation



Namespace FrameSnips
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>

	Partial Public Class Window1
		Inherits Page

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub InitializeFrameSnip(ByVal sender As Object, ByVal e As EventArgs)
			'<SnippetFrameSource>
			myFrame.Source = New Uri("http://www.msn.com")
			'</SnippetFrameSource>
		End Sub

		Private i As Integer = 0
		Private Sub onClick(ByVal sender As Object, ByVal args As RoutedEventArgs)
			i += 1
		  '<SnippetFrameNavigateSetup>  
			Dim myStackPanel As New StackPanel()
			Dim myButton As New Button()
			myButton.Content = "Press me"
			myStackPanel.Children.Add(myButton)
		  '</SnippetFrameNavigateSetup>  

		  '<SnippetFrameNavigateObject>       
			myFrame.Navigate(myStackPanel)
		  '</SnippetFrameNavigateObject>

			'<SnippetFrameNavigateObjectObject>   
			myFrame.Navigate(myStackPanel, myFrame)
			'</SnippetFrameNavigateObjectObject>  

		   '<SnippetFrameNavigateUri>   
		   myFrame.Navigate(New Uri("http://www.yahoo.com"))
		   '</SnippetFrameNavigateUri>  

	   '<SnippetFrameNavigateUriObject>
			myFrame.Navigate(New Uri("http://www.yahoo.com"),myFrame)
		   '</SnippetFrameNavigateUriObject>


		   '<SnippetFrameNavigateRefresh>
		   myFrame.Refresh()
		   '</SnippetFrameNavigateRefresh>
		End Sub

		Private Sub onNavigated(ByVal sender As Object, ByVal args As NavigationEventArgs)

		End Sub


	End Class
End Namespace