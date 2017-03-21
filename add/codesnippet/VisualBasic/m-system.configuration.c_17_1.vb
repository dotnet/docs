    Shared Sub GetSection()

        Try
            Dim customSection _
            As CustomSection = _
            ConfigurationManager.GetSection( _
            "CustomSection")

            If customSection Is Nothing Then
                Console.WriteLine("Failed to load CustomSection.")
            Else
                ' Display section information
                Console.WriteLine("Defaults:")
                Console.WriteLine("File Name:       {0}", _
                customSection.FileName)
                Console.WriteLine("Max Users:       {0}", _
                customSection.MaxUsers)
                Console.WriteLine("Max Idle Time:   {0}", _
                customSection.MaxIdleTime)
            End If


        Catch err As ConfigurationErrorsException
            Console.WriteLine(err.ToString())
        End Try
    End Sub 'GetSection
