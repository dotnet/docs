' RightsManagedPackagePublish SDK Sample - Application.xaml.vb
' Copyright (c) Microsoft Corporation. All rights reserved.


Imports System
Imports System.Diagnostics
Imports System.Windows
Imports System.Windows.Input


Namespace SdkSample
	' =========================== partial class App ==========================
	''' <summary>
    '''   Interaction logic for Application.xaml</summary>
	Partial Public Class App
		Inherits Application
		' ---------------------------- AppStartup ----------------------------
		''' <summary>
		'''   Initializes the application and opens the
		'''   display window when the program is started.</summary>
		Private Sub AppStartUp(ByVal sender As Object, ByVal e As StartupEventArgs)
			' Create the application window (as defined in Window1.xaml).
			_appWindow = New Window1()
			_appWindow.Show()
		End Sub ' end:AppStartup()


		Private _appWindow As Window1 = Nothing ' application main window

	End Class ' end:partial class App

End Namespace ' end:namespace SdkSample
