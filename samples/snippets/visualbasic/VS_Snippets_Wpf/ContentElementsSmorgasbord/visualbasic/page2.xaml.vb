Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports DemoDev

Namespace SDKSample
	Partial Public Class Page2
		Inherits FlowDocument
		Private Sub ConnectFastZoom(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim fz As New FastZoom()
			fz.Attach(CType(FindName("ExplodeThis"), FrameworkContentElement))
		End Sub
	End Class
End Namespace
