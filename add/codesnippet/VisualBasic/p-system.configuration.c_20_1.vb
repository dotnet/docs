    ' Show how to set LockItem
    ' It adds a new UrlConfigElement to 
    ' the collection.
    Shared Sub LockItem()
        Dim name As String = "Contoso"
        Dim url As String = "http://www.contoso.com/"
        Dim port As Integer = 8080

        Try
            ' Get the current configuration file.
            Dim config _
            As System.Configuration.Configuration = _
            ConfigurationManager.OpenExeConfiguration( _
            ConfigurationUserLevel.None)

            ' Get the MyUrls section.
            Dim myUrls As UrlsSection = _
            config.Sections("MyUrls")


            ' Create the new  element.
            Dim newElement _
            As New UrlConfigElement(name, url, port)

            ' Set its lock.
            newElement.LockItem = True

            ' Save the new element to the 
            ' configuration file.
            If Not myUrls.ElementInformation.IsLocked Then

                myUrls.Urls.Add(newElement)

                config.Save(ConfigurationSaveMode.Full)

                ' This is used to obsolete the cached 
                ' section and read the updared version 
                ' from the configuration file.
                ConfigurationManager.RefreshSection("MyUrls")
            Else
                Console.WriteLine("Section was locked, could not update.")
            End If

        Catch e As ConfigurationErrorsException
            Console.WriteLine("[LockItem: {0}]", _
            e.ToString())
        End Try

    End Sub 'LockItem
