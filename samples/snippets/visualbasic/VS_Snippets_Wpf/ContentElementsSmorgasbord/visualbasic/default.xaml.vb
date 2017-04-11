Imports Microsoft.VisualBasic
Imports System
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents
Imports System.Windows.Navigation

Namespace SDKSample
	Partial Public Class PropertiesOvw
		Inherits StackPanel
	  Private Sub NavTo1(ByVal sender As Object, ByVal args As RoutedEventArgs)
		Dim currentApp As Application = Application.Current
		Dim nw As NavigationWindow = TryCast(currentApp.Windows(0), NavigationWindow)
		nw.Source = New Uri("page1.xaml", UriKind.RelativeOrAbsolute)
	  End Sub
	  Private Sub NavTo2(ByVal sender As Object, ByVal args As RoutedEventArgs)
		Dim currentApp As Application = Application.Current
		Dim nw As NavigationWindow = TryCast(currentApp.Windows(0), NavigationWindow)
		nw.Source = New Uri("page2.xaml",UriKind.RelativeOrAbsolute)
	  End Sub
	  Private Sub NavTo3(ByVal sender As Object, ByVal args As RoutedEventArgs)
		Dim currentApp As Application = Application.Current
		Dim nw As NavigationWindow = TryCast(currentApp.Windows(0), NavigationWindow)
		nw.Source = New Uri("page3.xaml", UriKind.RelativeOrAbsolute)
	  End Sub
	  Private Sub NavTo4(ByVal sender As Object, ByVal args As RoutedEventArgs)
		  Me.browserFrame.Navigate(New Uri("page4.xaml#Fragment3", UriKind.RelativeOrAbsolute))
	  End Sub
	  '<SnippetFEBringIntoView>
	  Private Sub browserFrame_FragmentNavigation(ByVal sender As Object, ByVal e As FragmentNavigationEventArgs)
		  Dim content As Object = (CType(e.Navigator, ContentControl)).Content
		  Dim fragmentElement As FrameworkContentElement = TryCast(LogicalTreeHelper.FindLogicalNode(CType(content, DependencyObject), e.Fragment), FrameworkContentElement)
		  If fragmentElement IsNot Nothing Then
			  ' Go to fragment if found
			  fragmentElement.BringIntoView()
		  End If
		  e.Handled = True
	  End Sub
	  '</SnippetFEBringIntoView>
	End Class
End Namespace