    ' Show how to use LockAllAttributesExcept.
    ' It locks and unlocks all urls elements 
    ' except the port.
    Shared Sub LockAllAttributesExcept()

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

                Dim elemEnum As IEnumerator = _
                myUrlsSection.Urls.GetEnumerator()

                Dim i As Integer = 0
                While elemEnum.MoveNext()

                    ' Get current element.
                    Dim element _
                    As ConfigurationElement = _
                    myUrlsSection.Urls(i)

                    ' Get current element lock all attributes.
                    Dim lockAllAttributesExcept _
                    As ConfigurationLockCollection = _
                    element.LockAllAttributesExcept

                    ' Add or remove the lock on all attributes 
                    ' except port.
                    If lockAllAttributesExcept.Contains("port") Then
                        lockAllAttributesExcept.Remove("port")
                    Else
                        lockAllAttributesExcept.Add("port")
                    End If

                    Dim lockedAttributes As String = _
                    lockAllAttributesExcept.AttributeList()

                    Console.WriteLine("Element {0} Locked attributes list: {1}", _
                    i.ToString(), lockedAttributes)

                    i += 1

                    config.Save(ConfigurationSaveMode.Full)
                End While
            End If


        Catch e As ConfigurationErrorsException
            Console.WriteLine("[LockAllAttributesExcept: {0}]", _
            e.ToString())
        End Try

    End Sub 'LockAllAttributesExcept
