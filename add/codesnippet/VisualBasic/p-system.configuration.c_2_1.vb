    ' Show how to use LockAllElementsExcept.
    ' It locks and unlocks all the MyUrls elements 
    ' except urls.
    Shared Sub LockAllElementsExcept()

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
                Dim lockElementsExcept _
                As ConfigurationLockCollection = _
                myUrlsSection.LockAllElementsExcept

                ' Get MyUrls section LockElements collection 
                ' enumerator.
                Dim lockElementEnum As IEnumerator = _
                lockElementsExcept.GetEnumerator()

                ' Position the collection index.
                lockElementEnum.MoveNext()

                If lockElementsExcept.Contains("urls") Then
                    ' Remove the lock on all the ther elements.
                    lockElementsExcept.Remove("urls")
                    ' Add the lock on all the other elements 
                    ' but urls element.
                Else
                    lockElementsExcept.Add("urls")
                End If

                config.Save(ConfigurationSaveMode.Full)
            End If
        Catch err As ConfigurationErrorsException
            Console.WriteLine("[LockAllElementsExcept: {0}]", _
            err.ToString())
        End Try

    End Sub 'LockAllElementsExcept
