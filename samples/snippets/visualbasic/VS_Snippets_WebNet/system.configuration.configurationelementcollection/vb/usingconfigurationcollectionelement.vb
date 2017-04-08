' <Snippet31>
Imports System.Configuration
Imports System.Text

Friend Class UsingConfigurationCollectionElement

    ' Create a custom section and save it in the 
    ' application configuration file.
    Private Shared Sub CreateCustomSection()
        Try

            ' Get the current configuration file.
            Dim config As System.Configuration.Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)

            ' Add the custom section to the application
            ' configuration file.
            Dim myUrlsSection As UrlsSection = CType(config.Sections("MyUrls"), UrlsSection)

            If myUrlsSection Is Nothing Then
                '  The configuration file does not contain the
                ' custom section yet. Create it.
                myUrlsSection = New UrlsSection()

                config.Sections.Add("MyUrls", myUrlsSection)

                ' Save the application configuration file.
                myUrlsSection.SectionInformation.ForceSave = True
                config.Save(ConfigurationSaveMode.Modified)
            Else
                If myUrlsSection.Urls.Count = 0 Then

                    ' The configuration file contains the
                    ' custom section but its element collection is empty.
                    ' Initialize the collection. 
                    Dim url As New UrlConfigElement()
                    myUrlsSection.Urls.Add(url)

                    ' Save the application configuration file.
                    myUrlsSection.SectionInformation.ForceSave = True
                    config.Save(ConfigurationSaveMode.Modified)
                End If
            End If


            Console.WriteLine("Created custom section in the application configuration file: {0}", config.FilePath)
            Console.WriteLine()

        Catch err As ConfigurationErrorsException
            Console.WriteLine("CreateCustomSection: {0}", err.ToString())
        End Try

    End Sub

    Private Shared Sub ReadCustomSection()
        Try
            ' Get the application configuration file.
            Dim config As System.Configuration.Configuration = TryCast(ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None), Configuration)

            ' Read and display the custom section.
            Dim myUrlsSection As UrlsSection = TryCast(config.GetSection("MyUrls"), UrlsSection)

            If myUrlsSection Is Nothing Then
                Console.WriteLine("Failed to load UrlsSection.")
            Else
                Console.WriteLine("Collection elements contained in the custom section collection:")
                For i As Integer = 0 To myUrlsSection.Urls.Count - 1
                    Console.WriteLine("   Name={0} URL={1} Port={2}", myUrlsSection.Urls(i).Name, myUrlsSection.Urls(i).Url, myUrlsSection.Urls(i).Port)
                Next i
            End If

        Catch err As ConfigurationErrorsException
            Console.WriteLine("ReadCustomSection(string): {0}", err.ToString())
        End Try

    End Sub

    ' Add an element to the custom section collection.
    ' This function uses the ConfigurationCollectionElement Add method.
    Private Shared Sub AddCollectionElement()
        Try

            ' Get the current configuration file.
            Dim config As System.Configuration.Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)


            ' Get the custom configuration section.
            Dim myUrlsSection As UrlsSection = TryCast(config.GetSection("MyUrls"), UrlsSection)


            ' Add the element to the collection in the custom section.
            If config.Sections("MyUrls") IsNot Nothing Then
                Dim urlElement As New UrlConfigElement()
                urlElement.Name = "Microsoft"
                urlElement.Url = "http://www.microsoft.com"
                urlElement.Port = 8080

                ' Use the ConfigurationCollectionElement Add method
                ' to add the new element to the collection.
                myUrlsSection.Urls.Add(urlElement)


                ' Save the application configuration file.
                myUrlsSection.SectionInformation.ForceSave = True
                config.Save(ConfigurationSaveMode.Modified)


                Console.WriteLine("Added collection element to the custom section in the configuration file: {0}", config.FilePath)
                Console.WriteLine()
            Else
                Console.WriteLine("You must create the custom section first.")
            End If

        Catch err As ConfigurationErrorsException
            Console.WriteLine("AddCollectionElement: {0}", err.ToString())
        End Try

    End Sub

    ' Remove element from the custom section collection.
    ' This function uses one of the ConfigurationCollectionElement 
    ' overloaded Remove methods.
    Private Shared Sub RemoveCollectionElement()
        Try

            ' Get the current configuration file.
            Dim config As System.Configuration.Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)


            ' Get the custom configuration section.
            Dim myUrlsSection As UrlsSection = TryCast(config.GetSection("MyUrls"), UrlsSection)


            ' Remove the element from the custom section.
            If config.Sections("MyUrls") IsNot Nothing Then
                Dim urlElement As New UrlConfigElement()
                urlElement.Name = "Microsoft"
                urlElement.Url = "http://www.microsoft.com"
                urlElement.Port = 8080

                ' Use one of the ConfigurationCollectionElement Remove 
                ' overloaded methods to remove the element from the collection.
                myUrlsSection.Urls.Remove(urlElement)


                ' Save the application configuration file.
                myUrlsSection.SectionInformation.ForceSave = True
                config.Save(ConfigurationSaveMode.Full)


                Console.WriteLine("Removed collection element from he custom section in the configuration file: {0}", config.FilePath)
                Console.WriteLine()
            Else
                Console.WriteLine("You must create the custom section first.")
            End If

        Catch err As ConfigurationErrorsException
            Console.WriteLine("RemoveCollectionElement: {0}", err.ToString())
        End Try

    End Sub

    ' Remove the collection of elements from the custom section.
    ' This function uses the ConfigurationCollectionElement Clear method.
    Private Shared Sub ClearCollectionElements()
        Try

            ' Get the current configuration file.
            Dim config As System.Configuration.Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)


            ' Get the custom configuration section.
            Dim myUrlsSection As UrlsSection = TryCast(config.GetSection("MyUrls"), UrlsSection)


            ' Remove the collection of elements from the section.
            If config.Sections("MyUrls") IsNot Nothing Then
                myUrlsSection.Urls.Clear()


                ' Save the application configuration file.
                myUrlsSection.SectionInformation.ForceSave = True
                config.Save(ConfigurationSaveMode.Full)


                Console.WriteLine("Removed collection of elements from he custom section in the configuration file: {0}", config.FilePath)
                Console.WriteLine()
            Else
                Console.WriteLine("You must create the custom section first.")
            End If

        Catch err As ConfigurationErrorsException
            Console.WriteLine("ClearCollectionElements: {0}", err.ToString())
        End Try

    End Sub

    Public Shared Sub UserMenu()
        Dim applicationName As String = Environment.GetCommandLineArgs()(0) & ".exe"
        Dim buffer As New StringBuilder()

        buffer.AppendLine("Application: " & applicationName)
        buffer.AppendLine("Make your selection.")
        buffer.AppendLine("?    -- Display help.")
        buffer.AppendLine("Q,q  -- Exit the application.")
        buffer.Append("1    -- Create a custom section that")
        buffer.AppendLine(" contains a collection of elements.")
        buffer.Append("2    -- Read the custom section that")
        buffer.AppendLine(" contains a collection of custom elements.")
        buffer.Append("3    -- Add a collection element to")
        buffer.AppendLine(" the custom section.")
        buffer.Append("4    -- Remove a collection element from")
        buffer.AppendLine(" the custom section.")
        buffer.Append("5    -- Clear the collection of elements from")
        buffer.AppendLine(" the custom section.")

        Console.Write(buffer.ToString())
    End Sub

    ' Obtain user's input and provide
    ' feedback.
    Shared Sub Main(ByVal args() As String)
        ' Define user selection string.
        Dim selection As String

        ' Get the name of the application.
        Dim appName As String = Environment.GetCommandLineArgs()(0)

        ' Get user selection.
        Do

            UserMenu()
            Console.Write("> ")
            selection = Console.ReadLine()
            If selection <> String.Empty Then
                Exit Do
            End If
        Loop

        Do While selection.ToLower() <> "q"
            ' Process user's input.
            Select Case selection
                Case "1"
                    ' Create a custom section and save it in the 
                    ' application configuration file.
                    CreateCustomSection()

                Case "2"
                    ' Read the custom section from the
                    ' application configuration file.
                    ReadCustomSection()

                Case "3"
                    ' Add a collection element to the
                    ' custom section.
                    AddCollectionElement()

                Case "4"
                    ' Remove a collection element from the
                    ' custom section.
                    RemoveCollectionElement()

                Case "5"
                    ' Clear the collection of elements from the
                    ' custom section.
                    ClearCollectionElements()

                Case Else
                    UserMenu()
            End Select
            Console.Write("> ")
            selection = Console.ReadLine()
        Loop
    End Sub
End Class
' </Snippet31>