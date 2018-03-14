Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Media

Namespace SDKSample
	Partial Public Class FEFindName
'<SnippetFind>
		Private Sub Find(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim wantedNode As Object = stackPanel.FindName("dog")
			If TypeOf wantedNode Is TextBlock Then
				' Following executed if Text element was found.
				Dim wantedChild As TextBlock = TryCast(wantedNode, TextBlock)
				wantedChild.Foreground = Brushes.Blue
			End If
		End Sub
'</SnippetFind>
	End Class
End Namespace
