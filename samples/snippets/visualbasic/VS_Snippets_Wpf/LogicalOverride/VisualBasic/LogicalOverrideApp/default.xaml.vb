Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports SDKSample

Namespace SDKSample

	Partial Public Class LogicalOverrideApp
		Private Sub AddLogicalElement(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim mybutton As New Button()
			mybutton.Content = "Happy birthday! " & Date.Now.TimeOfDay.ToString()
			CustomElement.SetSingleChild(mybutton)
		End Sub
	End Class
End Namespace


