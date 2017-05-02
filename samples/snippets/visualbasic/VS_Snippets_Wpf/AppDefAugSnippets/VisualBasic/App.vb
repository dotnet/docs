'<SnippetAppDefAugCODE1>

Imports Microsoft.VisualBasic
Imports System
Imports System.Windows

Namespace SDKSample
	Public Class App
		Inherits Application
		Public Sub New()
		End Sub
		<STAThread>
		Public Shared Sub Main()
			' Create new instance of application subclass
			Dim app As New App()

			' Code to register events and set properties that were
			' defined in XAML in the application definition
			app.InitializeComponent()

			' Start running the application
			app.Run()
		End Sub

		Public Sub InitializeComponent()
			'</SnippetAppDefAugCODE1>
			'<SnippetAppDefAugCODE2>
		End Sub
	End Class
End Namespace
'</SnippetAppDefAugCODE2>
