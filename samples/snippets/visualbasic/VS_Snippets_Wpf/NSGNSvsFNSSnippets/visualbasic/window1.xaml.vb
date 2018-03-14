Imports System.Text

'<SnippetNSFrameDiffCODE1>
Imports System.Windows.Controls
Imports System.Windows.Navigation
'</SnippetNSFrameDiffCODE1>

Namespace NSGNSvsFNSSnippets
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>

	Partial Public Class Window1
		Inherits Window

		Public Sub New()
			InitializeComponent()

'<SnippetNSFrameDiffCODE2>
' Get the NavigationService owned by the Frame
Dim frameNS As NavigationService = Me.frame.NavigationService

' Get the NavigationService for the navigation host that navigated
' to the content in which the Frame is hosted
Dim navigationHostNS As NavigationService = NavigationService.GetNavigationService(Me.frame)
'</SnippetNSFrameDiffCODE2>
		End Sub

	End Class
End Namespace