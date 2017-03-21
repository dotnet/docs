Imports System.Text

Namespace SDKSample
	Partial Public Class RoutedEventHandle
		Inherits StackPanel
		Private eventstr As New StringBuilder()
	  Private Sub NavTo2(ByVal sender As Object, ByVal args As RoutedEventArgs)
		Dim currentApp As Application = Application.Current
		Dim nw As NavigationWindow = TryCast(currentApp.Windows(0), NavigationWindow)
		nw.Source = New Uri("page2.xaml",UriKind.RelativeOrAbsolute)
	  End Sub
'<SnippetSimpleHandlerA>      
	  Private Sub b1SetColor(ByVal sender As Object, ByVal args As RoutedEventArgs)
		'logic to handle the Click event
'</SnippetSimpleHandlerA>

'<SnippetSimpleHandlerB>
	  End Sub
'</SnippetSimpleHandlerB>
'<SnippetGroupButtonCodeBehind>
	  Private Sub CommonClickHandler(ByVal sender As Object, ByVal e As RoutedEventArgs)
		Dim feSource As FrameworkElement = TryCast(e.Source, FrameworkElement)
		Select Case feSource.Name
		  Case "YesButton"
			' do something here ...
		  Case "NoButton"
			' do something ...
		  Case "CancelButton"
			' do something ...
		End Select
		e.Handled=True
	  End Sub
'</SnippetGroupButtonCodeBehind>
'<SnippetAddHandlerCode>
	   Private Sub MakeButton()
			Dim b2 As New Button()
			b2.AddHandler(Button.ClickEvent, New RoutedEventHandler(AddressOf Onb2Click))
	   End Sub
		Private Sub Onb2Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			'logic to handle the Click event     
		End Sub
'</SnippetAddHandlerCode>
'<SnippetAddHandlerPlusEquals>
		Private Sub MakeButton2()
		  Dim b2 As New Button()
		  AddHandler b2.Click, AddressOf Onb2Click2
		End Sub
		Private Sub Onb2Click2(ByVal sender As Object, ByVal e As RoutedEventArgs)
		  'logic to handle the Click event     
		End Sub
'</SnippetAddHandlerPlusEquals>
	End Class
End Namespace