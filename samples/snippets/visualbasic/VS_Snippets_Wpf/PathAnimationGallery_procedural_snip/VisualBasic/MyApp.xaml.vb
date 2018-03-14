Imports System
Imports System.Windows
Imports System.Windows.Navigation
Imports System.Windows.Controls
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.IO


Namespace SDKSample


	Partial Public Class MyApp
		Inherits Application

		Private Sub myAppStartup(ByVal sender As Object, ByVal e As StartupEventArgs)
			AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf CurrentDomain_UnhandledException
			Dim myNavigationWindow As New NavigationWindow()
			myNavigationWindow.Navigate(New SampleViewer())
			myNavigationWindow.Show()
		End Sub


		Private Sub CurrentDomain_UnhandledException(ByVal sender As Object, ByVal args As UnhandledExceptionEventArgs)

			Try
				Dim wr As New StreamWriter("error.txt")
				wr.Write(args.ExceptionObject.ToString())
				wr.Close()

			Catch

			End Try


			MessageBox.Show("Unhandled exception: " & args.ExceptionObject.ToString())
		End Sub

	End Class


End Namespace
