'<SnippetApplicationCODE>

Imports Microsoft.VisualBasic
Imports System ' STAThread
Imports System.Windows ' Application

Namespace SDKSample
	Public Class AppCode
		Inherits Application
		' Entry point method
		<STAThread>
		Public Shared Sub Main()
			Dim app As New AppCode()
			app.Run()
		End Sub
	End Class
End Namespace
'</SnippetApplicationCODE>