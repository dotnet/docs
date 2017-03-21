    Shared Sub GetEnumerator()

        Try
            Dim config _
            As System.Configuration.Configuration = _
            ConfigurationManager.OpenExeConfiguration( _
            ConfigurationUserLevel.None)

            Dim sections _
            As ConfigurationSectionCollection = _
            config.Sections

            Dim secEnum _
            As IEnumerator = sections.GetEnumerator()

            Dim i As Integer = 0
            While secEnum.MoveNext()
                Dim setionName _
                As String = sections.GetKey(i)
                Console.WriteLine( _
                "Section name: {0}", setionName)
                i += 1
            End While
        Catch err As ConfigurationErrorsException
            Console.WriteLine(err.ToString())
        End Try
    End Sub 'GetEnumerator
