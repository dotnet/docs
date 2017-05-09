Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Documents

Namespace FlowDirection_layout
	''' <summary>
	''' Interaction logic for Window1.xaml
	''' </summary>

	Partial Public Class Window1
		Inherits Window
		' <Snippet_FlowDirection>
		Private Sub LR(ByVal sender As Object, ByVal e As RoutedEventArgs)
			tf1.FlowDirection = FlowDirection.LeftToRight
			txt1.Text = "FlowDirection is now " & tf1.FlowDirection
		End Sub
		Private Sub RL(ByVal sender As Object, ByVal e As RoutedEventArgs)
			tf1.FlowDirection = FlowDirection.RightToLeft
			txt1.Text = "FlowDirection is now " & tf1.FlowDirection
		End Sub
		' </Snippet_FlowDirection>
	End Class
End Namespace