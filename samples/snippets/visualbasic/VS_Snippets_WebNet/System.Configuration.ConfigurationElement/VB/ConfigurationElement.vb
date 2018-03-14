' Contains the Main function to allow the
' example to be run as a console application.

' <Snippet151>
' Set Assembly name to ConfigurationElement
' and set Root namespace to Samples.AspNet
Imports System
Imports System.Configuration
Imports System.Collections

Class TestConfigurationElement
    ' Entry point for console application that reads the 
    ' app.config file and writes to the console the 
    ' URLs in the custom section.
    Shared Sub Main(ByVal args() As String)
        ' Get the current configuration file.
        Dim config As System.Configuration.Configuration = _
            ConfigurationManager.OpenExeConfiguration( _
            ConfigurationUserLevel.None)

        ' Get the MyUrls section.
        Dim myUrlsSection As UrlsSection = _
            config.GetSection("MyUrls")

        If myUrlsSection Is Nothing Then
            Console.WriteLine("Failed to load UrlsSection.")
        Else
            Console.WriteLine("The 'simple' element of app.config:")
            Console.WriteLine("  Name={0} URL={1} Port={2}", _
                myUrlsSection.Simple.Name, _
                myUrlsSection.Simple.Url, _
                myUrlsSection.Simple.Port)
            Console.WriteLine("The urls collection of app.config:")
            Dim i As Integer
            For i = 0 To myUrlsSection.Urls.Count - 1
                Console.WriteLine("  Name={0} URL={1} Port={2}", _
                i, myUrlsSection.Urls(i).Name, _
                myUrlsSection.Urls(i).Url, _
                myUrlsSection.Urls(i).Port)
            Next i
        End If
        Console.ReadLine()
    End Sub
End Class
' </Snippet151>

' Putting remaining methods into a separate class so that the
' above snippet can be complete.
' To test one of these methods, uncomment the appropriate 
' line(s) and move it or them into the Main method above.
'GetProperties();
'LockItem();
'LockAllAttributesExcept();
'LockAttributes();
'LockElements();
'LockAllElementsExcept();
'ModifyElement();
'ReadOnlyElements();
'AddClearRemoveElementName();
'UsingElementInformation.GetElementValidator();
'UsingSectionInformation.UnProtectSection();
Class TestConfigurationElement2
    ' <Snippet1>
    ' Create a section whose name is 
    ' MyUrls that contains a nested collection as 
    ' defined by the UrlsSection class.
    Shared Sub CreateSection()
        Dim sectionName As String = "MyUrls"

        Try

            ' Get the current configuration file.
            Dim config _
            As System.Configuration.Configuration = _
            ConfigurationManager.OpenExeConfiguration( _
            ConfigurationUserLevel.None)

            Dim urlsSection As UrlsSection

            ' Create the section whose name
            ' attribute isMyUrls in 
            ' <configSections>.
            ' Also, create the related target section 
            ' MyUrls in <configuration>.
            If config.Sections(sectionName) Is Nothing Then
                urlsSection = New UrlsSection()

                ' Change the default values of 
                ' the simple element.
                urlsSection.Simple.Name = "Contoso"
                urlsSection.Simple.Url = "http://www.contoso.com"
                urlsSection.Simple.Port = 8080

                config.Sections.Add(sectionName, urlsSection)
                urlsSection.SectionInformation.ForceSave = True
                config.Save(ConfigurationSaveMode.Full)
            End If
        Catch e As ConfigurationErrorsException
            Console.WriteLine("[CreateSection: {0}]", e.ToString())
        End Try

    End Sub 'CreateSection

    ' </Snippet1>


    Shared Sub AddClearRemoveElementName()

        Try

            ' Get the current configuration file.
            Dim config _
            As System.Configuration.Configuration = _
            ConfigurationManager.OpenExeConfiguration( _
            ConfigurationUserLevel.None)

            ' Get the configuration section MyUrls.
            Dim myUrlsSection As UrlsSection = _
            config.Sections("MyUrls")

            ' Get the configuration element collection.
            Dim elements As UrlsCollection = _
            myUrlsSection.Urls

            Console.WriteLine("Default Add name: {0}", _
            elements.AddElementName)
            Console.WriteLine("Default Remove name: {0}", _
            elements.RemoveElementName)
            Console.WriteLine("Default Clear name: {0}", _
            elements.ClearElementName)

        Catch e As ConfigurationErrorsException
            Console.WriteLine("[AddElementName: {0}]", _
            e.ToString())
        End Try

    End Sub 'AddClearRemoveElementName


    ' <Snippet2> 
    ' Show the use of Properties.
    ' It displays the ConfigurationElement 
    ' properties.
    Shared Sub GetProperties()

        Try
            ' Get the current configuration file.
            Dim config _
            As System.Configuration.Configuration = _
            ConfigurationManager.OpenExeConfiguration( _
            ConfigurationUserLevel.None)

            ' Get the configuration section MyUrls.
            Dim myUrlsSection As UrlsSection = _
            config.Sections("MyUrls")

            ' Get the configuration element collection.
            Dim elements As UrlsCollection = _
            myUrlsSection.Urls

            Dim elemEnum As IEnumerator = _
            elements.GetEnumerator()

            Dim i As Integer = 0
            While elemEnum.MoveNext()
                ' Get the current element configuration
                ' property collection.
                Dim properties _
                As PropertyInformationCollection = _
                elements(i).ElementInformation.Properties

                ' Display the current configuration 
                ' element properties.
                Dim proprty As PropertyInformation
                For Each proprty In properties
                    Console.WriteLine("Name: {0}" + _
                    vbTab + "Default: {1}" + _
                    vbTab + "Required: {2}", _
                    [proprty].Name, [proprty].DefaultValue, _
                    [proprty].IsRequired.ToString())
                Next proprty
            End While

        Catch e As ConfigurationErrorsException
            Console.WriteLine("[GetProperties: {0}]", _
            e.ToString())
        End Try

    End Sub 'GetProperties

    ' </Snippet2> 

    ' <Snippet3> 
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

    ' </Snippet3> 


    ' <Snippet4> 
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

    ' </Snippet4> 

    ' <Snippet5> 
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

    ' </Snippet5> 

    ' <Snippet6>
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

    ' </Snippet6>


    ' <Snippet7>
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

    ' </Snippet7>

    ' Remove a UrlConfigElement from the collection.
    Shared Sub RemoveElement(ByVal name As String, _
    ByVal url As String, ByVal port As Integer)

        ' Get the current configuration file.
        Dim config _
        As System.Configuration.Configuration = _
        ConfigurationManager.OpenExeConfiguration( _
        ConfigurationUserLevel.None)

        ' Get the MyUrls section.
        Dim myUrlsSection As UrlsSection = _
        config.GetSection("MyUrls")

        Dim urls As UrlsCollection = _
        myUrlsSection.Urls

        Dim element _
        As New UrlConfigElement(name, url, port)

        If Not myUrlsSection.ElementInformation.IsLocked Then

            myUrlsSection.Urls.Remove(element)

            config.Save(ConfigurationSaveMode.Minimal)

            ' This to obsolete the cached section and
            ' read the new updated one.
            ConfigurationManager.RefreshSection("MyUrls")
        Else
            Console.WriteLine("Section was locked, could not update.")
        End If

    End Sub 'RemoveElement


    ' <Snippet8> 
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

    ' </Snippet8> 


    ' <Snippet9> 
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

    ' </Snippet9> 

End Class 'TestConfigurationElement 
