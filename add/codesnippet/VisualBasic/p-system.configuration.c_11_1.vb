    ' Show how to use LockElements
    ' It locks and unlocks the urls element.
    Shared Sub LockElements()

        Try
            ' Get the current configuration file.
            Dim config _
            As System.Configuration.Configuration = _
            ConfigurationManager.OpenExeConfiguration( _
            ConfigurationUserLevel.None)

            ' Get the MyUrls section.
            Dim myUrlsSection As UrlsSection = _
            config.GetSection("MyUrls")

            If myUrlsSection Is Nothing Then
                Console.WriteLine("Failed to load UrlsSection.")
            Else
                ' Get MyUrls section LockElements collection.
                Dim lockElements _
                As ConfigurationLockCollection = _
                myUrlsSection.LockElements

                ' Get MyUrls section LockElements collection 
                ' enumerator.
                Dim lockElementEnum As IEnumerator = _
                lockElements.GetEnumerator()

                ' Position the collection index.
                lockElementEnum.MoveNext()

                If lockElements.Contains("urls") Then
                    ' Remove the lock on the urls element.
                    lockElements.Remove("urls")
                Else
                    ' Add the lock on the urls element.
                    lockElements.Add("urls")
                End If
                ' Save the change.
                config.Save(ConfigurationSaveMode.Full)
            End If

        Catch err As ConfigurationErrorsException
            Console.WriteLine("[LockElements: {0}]", _
            err.ToString())
        End Try

    End Sub 'LockElements
