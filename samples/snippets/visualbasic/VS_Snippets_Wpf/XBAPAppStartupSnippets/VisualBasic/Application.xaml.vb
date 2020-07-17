'<SnippetStartupXBAPCODEBEHIND>

Imports System.Windows
Imports System.Windows.Navigation

Namespace SDKSample
	Partial Public Class App
		Inherits Application
		Private Sub App_Startup(ByVal sender As Object, ByVal e As StartupEventArgs)
			CType(Me.MainWindow, NavigationWindow).Navigate(New Uri("HomePage.xaml", UriKind.Relative))
		End Sub
	End Class
End Namespace
'</SnippetStartupXBAPCODEBEHIND>

