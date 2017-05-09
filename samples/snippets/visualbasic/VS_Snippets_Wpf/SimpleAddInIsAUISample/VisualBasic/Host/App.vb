Imports System
Imports System.Windows

Namespace Host
	''' <summary>
	''' A custom entry point method, Main(), is required to use LoaderOptimizationAttribute,
	''' which ensures that WPF assemblies are shared between the main application's appdomain
	''' and the subsequent appdomains that are created to host isolated add-ins. Using
	''' LoaderOptimizationAttribute dramatically improves performance; otherwise, each 
	''' add-in needs to load a complete set of WPF assemblies.
	''' </summary>
	Public Class App
		Inherits Application
		<STAThread, LoaderOptimization(LoaderOptimization.MultiDomainHost)>
		Public Shared Sub Main()
			Dim app As New App()
			app.Run()
		End Sub

		Protected Overrides Sub OnStartup(ByVal e As StartupEventArgs)
			MyBase.OnStartup(e)

			' Show main application window
			Dim mainWindow As New MainWindow()
			mainWindow.Show()
		End Sub
	End Class
End Namespace