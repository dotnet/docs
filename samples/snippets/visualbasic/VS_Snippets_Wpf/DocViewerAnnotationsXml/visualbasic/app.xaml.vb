' DocViewerAnnotationsXml SDK Sample - app.xaml.vb
' Copyright (c) Microsoft Corporation. All rights reserved.

Imports System.Windows

Namespace SDKSample
	' ========================== partial class app =========================
	''' <summary>
	'''   Interaction logic for app.xaml</summary>
	Partial Public Class app
		Inherits Application
		' ---------------------------- AppStartup ----------------------------
		''' <summary>
		'''   Initializes the application and opens the
		'''   display window when the program is started.</summary>
		Private Sub AppStartup(ByVal sender As Object, ByVal args As StartupEventArgs)
			' Create the application window (as defined in Window1.xaml).
			_window1 = New Window1()
			_window1.Show()
		End Sub


		Private _window1 As Window1 = Nothing ' application main window

	End Class

End Namespace ' end:namespace SDKSample
