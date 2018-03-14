' <Snippet31>
Imports System.Configuration


Friend Class UsingConfigurationCollectionAttribute

	' Create a custom section and save it in the 
	' application configuration file.
	Private Shared Sub CreateCustomSection()
		Try

			' Create a custom configuration section.
			Dim myUrlsSection As New UrlsSection()

			' Get the current configuration file.
            Dim config As System.Configuration.Configuration =
                ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)

			' Add the custom section to the application
			' configuration file.
			If config.Sections("MyUrls") Is Nothing Then
				config.Sections.Add("MyUrls", myUrlsSection)
			End If


			' Save the application configuration file.
			myUrlsSection.SectionInformation.ForceSave = True
			config.Save(ConfigurationSaveMode.Modified)

			Console.WriteLine("Created custom section in the application configuration file: {0}", config.FilePath)
			Console.WriteLine()

		Catch err As ConfigurationErrorsException
			Console.WriteLine("CreateCustomSection: {0}", err.ToString())
		End Try

	End Sub

	Private Shared Sub ReadCustomSection()
		Try
			' Get the application configuration file.
			Dim config As System.Configuration.Configuration = TryCast(ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None), Configuration)

			' Read and display the custom section.
			Dim myUrlsSection As UrlsSection = TryCast(ConfigurationManager.GetSection("MyUrls"), UrlsSection)

			If myUrlsSection Is Nothing Then
				Console.WriteLine("Failed to load UrlsSection.")
			Else
				Console.WriteLine("URLs defined in app.config:")
				For i As Integer = 0 To myUrlsSection.Urls.Count - 1
					Console.WriteLine("  Name={0} URL={1} Port={2}", myUrlsSection.Urls(i).Name, myUrlsSection.Urls(i).Url, myUrlsSection.Urls(i).Port)
				Next i
			End If
        Catch err As ConfigurationErrorsException
            Console.WriteLine("ReadCustomSection(string): {0}", err.ToString())
		End Try

	End Sub

	Shared Sub Main(ByVal args() As String)

		' Get the name of the application.
		Dim appName As String = Environment.GetCommandLineArgs()(0)

		' Create a custom section and save it in the 
		' application configuration file.
		CreateCustomSection()

		' Read the custom section saved in the
		' application configuration file.
		ReadCustomSection()

        Console.WriteLine()
        Console.WriteLine("Enter any key to exit.")

		Console.ReadLine()
	End Sub
End Class
' </Snippet31>