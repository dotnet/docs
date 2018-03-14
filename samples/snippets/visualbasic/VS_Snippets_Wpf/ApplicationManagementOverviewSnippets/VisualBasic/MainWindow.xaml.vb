Imports Microsoft.VisualBasic
Imports System.Windows

Namespace SDKSample
	Public Class App
		Inherits Application
	End Class

	Partial Public Class MainWindow
		Inherits Window
		Public Sub New()
			InitializeComponent()

			'<SnippetGetCurrentAppCODE>
			' Get current application
            Dim current As Application = App.Current
			'</SnippetGetCurrentAppCODE>

			'<SnippetGetSTCurrentAppCODE>
			' Get strongly-typed current application
            Dim appCurrent As App = CType(App.Current, App)
			'</SnippetGetSTCurrentAppCODE>
		End Sub
	End Class
End Namespace