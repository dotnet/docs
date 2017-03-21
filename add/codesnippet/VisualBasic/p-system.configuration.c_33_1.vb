    Shared Sub GetKeys()

        Try
            Dim config _
            As System.Configuration.Configuration = _
            ConfigurationManager.OpenExeConfiguration( _
            ConfigurationUserLevel.None)

            Dim sections _
            As ConfigurationSectionCollection = _
            config.Sections


            Dim key As String
            For Each key In sections.Keys


                Console.WriteLine("Key value: {0}", key)
            Next key


        Catch err As ConfigurationErrorsException
            Console.WriteLine(err.ToString())
        End Try
    End Sub 'GetKeys

