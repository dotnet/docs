Namespace NavigateWithTreeWalker
	Friend NotInheritable Class Program
		''' <summary>
		''' The main entry point for the application.
		''' </summary>
		Private Sub New()
		End Sub
		<STAThread>
		Shared Sub Main()
			Application.EnableVisualStyles()
			Application.Run(New NavigationWithTreeWalker())
		End Sub
	End Class
End Namespace