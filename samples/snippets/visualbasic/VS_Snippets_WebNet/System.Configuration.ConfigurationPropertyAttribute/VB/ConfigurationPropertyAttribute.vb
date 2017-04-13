'<Snippet21>
Imports System
Imports System.Configuration

Public Class UsingConfigurationPropertyAttribute

    ' Create a custom section and save it in the 
    ' application configuration file.
    Private Shared Sub CreateCustomSection()
        Try

            ' Create a custom configuration section.
            Dim customSection As New UrlsSection()

            ' Get the current configuration file.
            Dim config As System.Configuration.Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)

            ' Add the custom section to the application
            ' configuration file.
            If config.Sections("CustomSection") Is Nothing Then
                config.Sections.Add("CustomSection", customSection)
            End If


            ' Save the application configuration file.
            customSection.SectionInformation.ForceSave = True
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
            Dim customSection As UrlsSection = TryCast(config.GetSection("CustomSection"), UrlsSection)
            Console.WriteLine("Reading custom section from the configuration file.")
            Console.WriteLine("Section name: {0}", customSection.Name)
            Console.WriteLine("Url: {0}", customSection.Url)
            Console.WriteLine("Port: {0}", customSection.Port)
            Console.WriteLine()
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

        Console.WriteLine("Press enter to exit.")

        Console.ReadLine()
    End Sub
End Class
'</Snippet21>