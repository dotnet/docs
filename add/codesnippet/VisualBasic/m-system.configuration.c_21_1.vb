    ' Show how to use the GetSection(string) method.
    Public Shared Sub GetCustomSection()
        Try

            Dim customSection As CustomSection

            ' Get the current configuration file.
            Dim config As System.Configuration.Configuration = TryCast(ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None), Configuration)

            customSection = TryCast(config.GetSection("CustomSection"), CustomSection)

            Console.WriteLine("Section name: {0}", customSection.Name)
            Console.WriteLine("Url: {0}", customSection.Url)
            Console.WriteLine("Port: {0}", customSection.Port)

        Catch err As ConfigurationErrorsException
            Console.WriteLine("Using GetSection(string): {0}", err.ToString())
        End Try

    End Sub