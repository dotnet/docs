    ' Show how to use IsModified.
    ' This method modifies the port property
    ' of the url element named Microsoft and
    ' saves the modification to the configuration
    ' file. This in turn will cause the overriden
    ' UrlConfigElement.IsModified() mathod to be called. 
    Shared Sub ModifyElement()
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
            While elemEnum.MoveNext()
                If elements(i).Name = "Microsoft" Then
                    elements(i).Port = 1010
                    Dim [readOnly] As Boolean = _
                    elements(i).IsReadOnly()
                    Exit While
                End If
                i += 1
            End While

            If Not myUrlsSection.ElementInformation.IsLocked Then

                config.Save(ConfigurationSaveMode.Full)

                ' This to obsolete the MyUrls cached 
                ' section and read the updated version 
                ' from the configuration file.
                ConfigurationManager.RefreshSection("MyUrls")
            Else
                Console.WriteLine("Section was locked, could not update.")
            End If

        Catch err As ConfigurationErrorsException
            Console.WriteLine("[ModifyElement: {0}]", _
            err.ToString())
        End Try

    End Sub 'ModifyElement
