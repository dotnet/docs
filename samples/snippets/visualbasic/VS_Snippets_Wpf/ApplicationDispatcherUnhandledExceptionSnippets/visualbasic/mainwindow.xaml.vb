Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Shapes


Namespace SDKSample
	Partial Public Class MainWindow
		Inherits Window
		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub raiseRecoverableException_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Throw New ArgumentNullException("Recoverable Exception")
		End Sub

		Private Sub raiseUnecoverableException_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Throw New DivideByZeroException("Unrecoverable Exception")
		End Sub
	End Class
End Namespace