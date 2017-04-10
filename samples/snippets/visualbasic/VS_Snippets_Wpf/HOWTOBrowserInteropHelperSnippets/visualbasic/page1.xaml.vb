Imports System.Text
Imports System.Windows.Interop

Namespace BrowserInteropHelperSnippet
  Partial Public Class Page1
	  Inherits Page

	Public Sub New()
	  InitializeComponent()
	End Sub

	Protected Overrides Sub OnInitialized(ByVal e As EventArgs)
	  MyBase.OnInitialized(e)

	  '<SnippetIsBrowserHostedCODE>
	  ' Detect if browser hosted
	  If BrowserInteropHelper.IsBrowserHosted Then
		  ' Note: can only inspect BrowserInteropHelper.Source property if page is browser-hosted.
		  Me.dataTextBlock.Text = "Is Browser Hosted: " & BrowserInteropHelper.Source.ToString()
	  Else
		  Me.dataTextBlock.Text = "Is not browser hosted"
	  End If
	  '</SnippetIsBrowserHostedCODE>
	End Sub
  End Class
End Namespace