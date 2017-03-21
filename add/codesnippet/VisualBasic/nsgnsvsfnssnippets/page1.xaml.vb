Imports System.Text

Namespace NSGNSvsFNSSnippets
	''' <summary>
	''' Interaction logic for Page1.xaml
	''' </summary>

	Partial Public Class Page1
		Inherits Page
		Public Sub New()
			InitializeComponent()
			AddHandler Me.Loaded, Sub()
				Dim ns As NavigationService = NavigationService.GetNavigationService(Me.childFrame)
				Dim bob As Object = ns
			End Sub
		End Sub

	End Class
End Namespace