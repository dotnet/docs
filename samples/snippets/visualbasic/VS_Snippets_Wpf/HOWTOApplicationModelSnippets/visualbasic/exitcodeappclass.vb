Namespace SDKSample
	Friend Class ExitCodeAppClass
		Inherits Application
		Protected Overrides Sub OnExit(ByVal e As ExitEventArgs)
			'<SnippetShutdownExitCode>
			Application.Current.Shutdown(11)
			'</SnippetShutdownExitCode>

			'<SnippetGetExitCode>
			Dim exitCode As Integer = e.ApplicationExitCode
			'</SnippetGetExitCode>

			'<SnippetSetExitCode>
			e.ApplicationExitCode = 11
			'</SnippetSetExitCode>
		End Sub
	End Class
End Namespace
