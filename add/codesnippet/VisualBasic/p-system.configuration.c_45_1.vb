    ' Show how to use LockAttributes.
    ' It locks and unlocks all the urls elements.
    Shared Sub LockAttributes()

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
                    ' Get the current element.
                    Dim element As ConfigurationElement = _
                    myUrlsSection.Urls(i)

                    ' Get the lock attributes collection of 
                    ' the current element.
                    Dim lockAttributes _
                    As ConfigurationLockCollection = _
                    element.LockAttributes

                    ' Add or remove the lock on the attributes.
                    If lockAttributes.Contains("name") Then
                        lockAttributes.Remove("name")
                    Else
                        lockAttributes.Add("name")
                    End If
                    If lockAttributes.Contains("url") Then
                        lockAttributes.Remove("url")
                    Else
                        lockAttributes.Add("url")
                    End If
                    If lockAttributes.Contains("port") Then
                        lockAttributes.Remove("port")
                    Else
                        lockAttributes.Add("port")
                    End If

                    ' Get the locket attributes.
                    Dim lockedAttributes As String = _
                    lockAttributes.AttributeList()

                    Console.WriteLine("Element {0} Locked attributes list: {1}", _
                    i.ToString(), lockedAttributes)

                    i += 1

                    config.Save(ConfigurationSaveMode.Full)
                End While
            End If

        Catch e As ConfigurationErrorsException
            Console.WriteLine("[LockAttributes: {0}]", _
            e.ToString())
        End Try

    End Sub 'LockAttributes
