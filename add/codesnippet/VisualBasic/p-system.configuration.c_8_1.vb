    Shared Sub GetItems()

        Try
            Dim config _
            As System.Configuration.Configuration = _
            ConfigurationManager.OpenExeConfiguration( _
            ConfigurationUserLevel.None)

            Dim sections _
            As ConfigurationSectionCollection = _
            config.Sections


            Dim section1 As ConfigurationSection = _
            sections.Item("runtime")

            Dim section2 As ConfigurationSection = _
            sections.Item(0)

            Console.WriteLine("Section1: {0}", _
            section1.SectionInformation.Name)

            Console.WriteLine("Section2: {0}", _
            section2.SectionInformation.Name)

        Catch err As ConfigurationErrorsException
            Console.WriteLine(err.ToString())
        End Try
    End Sub 'GetItems

