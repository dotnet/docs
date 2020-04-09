Imports System.Text

Namespace SDKSample
	''' <summary>
	''' Interaction logic for PageWithEvents.xaml
	''' </summary>

	Partial Public Class PageWithEvents
		Inherits Page
		Public Sub New()

			AddHandler Loaded, AddressOf PageWithEvents_Loaded
			AddHandler Unloaded, AddressOf PageWithEvents_Unloaded

			InitializeComponent()

			Console.WriteLine("PageWithEvents()")
		End Sub

		Private Sub PageWithEvents_Unloaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Console.WriteLine("PageWithEvents_Unloaded")
		End Sub

		Private Sub PageWithEvents_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Console.WriteLine("PageWithEvents_Loaded")
		End Sub

	End Class
End Namespace