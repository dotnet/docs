Imports System.Collections.Generic
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes

Namespace SDKSample
	''' <summary>
	''' Interaction logic for Page1.xaml
	''' </summary>

	Partial Public Class Page1
		Inherits System.Windows.Controls.Page

		Public Sub New()
			InitializeComponent()

			AddHandler saveButton.Click, AddressOf saveButton_Click
		End Sub

		Private Sub saveButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
            Dim fileHandling As New FileHandlingGraceful()
			fileHandling.Save()
		End Sub

	End Class
End Namespace