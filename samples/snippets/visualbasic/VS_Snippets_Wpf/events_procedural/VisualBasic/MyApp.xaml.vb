﻿Imports System.Windows.Media.Animation
Imports System.IO


Namespace Microsoft.Samples.Animation.TimingBehaviors


	Partial Public Class MyApp
		Inherits Application

		Public Sub New()
			AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf CurrentDomain_UnhandledException

		End Sub


		Private Sub myAppStartup(ByVal sender As Object, ByVal e As StartupEventArgs)
			Dim myWindow As New Window()
			myWindow.Content = New SampleViewer()
			myWindow.Show()
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
