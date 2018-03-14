' XpsSyncAsyncSave SDK Sample - Application.xaml.vb
' Copyright (c) Microsoft Corporation. All rights reserved. 


Imports System.Windows

Namespace SDKSample
	''' <summary>
	'''   Interaction logic for App.xaml</summary>
	Partial Public Class App
		Inherits Application
		Private Sub AppStartup(ByVal sender As Object, ByVal args As StartupEventArgs)
			Dim mainWindow As New Window1()
			mainWindow.Show()
		End Sub
	End Class
End Namespace