' DocumentStructure SDK Sample - App.xaml.vb
' Copyright (c) Microsoft Corporation. All rights reserved.

Imports System.Xml
Imports System.Configuration
Imports System.Windows


Namespace SdkSample
	''' <summary>
	'''   Interaction logic for App.xaml</summary>
	Partial Public Class App
		Inherits Application
		Private Sub AppStartingUp(ByVal sender As Object, ByVal e As StartupEventArgs)
			Dim mainWindow As New Window1()
			mainWindow.Show()

		End Sub
	End Class
End Namespace