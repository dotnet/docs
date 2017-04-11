'<SnippetLocBamlChangeCultureCODEBEHIND>

Imports System.Windows ' Application
Imports System.Globalization ' CultureInfo
Imports System.Threading ' Thread

Namespace SDKSample
	Partial Public Class App
		Inherits Application
		Public Sub New()
			' Change culture under which this application runs
			Dim ci As New CultureInfo("fr-CA")
			Thread.CurrentThread.CurrentCulture = ci
			Thread.CurrentThread.CurrentUICulture = ci
		End Sub
	End Class
End Namespace
'</SnippetLocBamlChangeCultureCODEBEHIND>