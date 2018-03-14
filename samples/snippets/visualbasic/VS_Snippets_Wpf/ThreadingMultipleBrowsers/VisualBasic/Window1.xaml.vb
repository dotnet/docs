'<SnippetThreadingMultiBrowserCodeBehind>

Imports System
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Threading
Imports System.Threading


Namespace SDKSamples
	Partial Public Class Window1
		Inherits Window

		Public Sub New()
			MyBase.New()
			InitializeComponent()
		End Sub

		Private Sub OnLoaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
		   placeHolder.Source = New Uri("http://www.msn.com")
		End Sub

		Private Sub Browse(ByVal sender As Object, ByVal e As RoutedEventArgs)
			placeHolder.Source = New Uri(newLocation.Text)
		End Sub

		'<SnippetThreadingMultiBrowserNewWindow>
		Private Sub NewWindowHandler(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim newWindowThread As New Thread(New ThreadStart(AddressOf ThreadStartingPoint))
			newWindowThread.SetApartmentState(ApartmentState.STA)
			newWindowThread.IsBackground = True
			newWindowThread.Start()
		End Sub
		'</SnippetThreadingMultiBrowserNewWindow>

		'<SnippetThreadingMultiBrowserThreadStart>
		Private Sub ThreadStartingPoint()
			Dim tempWindow As New Window1()
            tempWindow.Show()
            System.Windows.Threading.Dispatcher.Run()
		End Sub
		'</SnippetThreadingMultiBrowserThreadStart>
	End Class
End Namespace
'</SnippetThreadingMultiBrowserCodeBehind>