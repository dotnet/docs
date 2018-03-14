Imports System.Text

Namespace SDKSample
	''' <summary>
	''' Interaction logic for PageWithEvents2.xaml
	''' </summary>

	Partial Public Class PageWithEvents2
		Inherits Page
		Public Sub New()

			AddHandler Loaded, AddressOf PageWithEvents_Loaded
			AddHandler Unloaded, AddressOf PageWithEvents_Unloaded

			InitializeComponent()

			Console.WriteLine("PageWithEvents()2")
		End Sub

		Private Sub PageWithEvents_Unloaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Console.WriteLine("PageWithEvents_Unloaded2")
		End Sub

		Private Sub PageWithEvents_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Console.WriteLine("PageWithEvents_Loaded2")
		End Sub

	End Class
End Namespace