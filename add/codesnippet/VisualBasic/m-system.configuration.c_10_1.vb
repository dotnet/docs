    ' Show how to use IsReadOnly.
    ' It loops to see if the elements are read only. 
    Shared Sub ReadOnlyElements()
        Try
            ' Get the current configuration file.
            Dim config _
            As System.Configuration.Configuration = _
            ConfigurationManager.OpenExeConfiguration( _
            ConfigurationUserLevel.None)

            ' Get the MyUrls section.
            Dim myUrlsSection As UrlsSection = _
            config.GetSection("MyUrls")

            Dim elements As UrlsCollection = _
            myUrlsSection.Urls

            Dim elemEnum As IEnumerator = _
            elements.GetEnumerator()

            Dim i As Integer = 0
            Console.WriteLine(elements.Count.ToString())

            While elemEnum.MoveNext()
                Console.WriteLine("The element {0} is read only: {1}", _
                elements(i).Name, elements(i).IsReadOnly().ToString())
                i += 1
            End While
        Catch err As ConfigurationErrorsException
            Console.WriteLine("[ReadOnlyElements: {0}]", _
            err.ToString())
        End Try

    End Sub 'ReadOnlyElements
