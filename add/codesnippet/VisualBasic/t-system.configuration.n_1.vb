Imports System
Imports System.Configuration
Imports System.Web
Imports System.Collections
Imports System.Text


Namespace Samples.AspNet
    Class UsingNameValueConfigurationCollection
        Public Shared Sub Main(ByVal args As String())
            Try
                ' Set the path of the config file. 
                ' Make sure that you have a Web site on the
                ' same server called TestConfig.
                Dim configPath As String = "/TestConfig"

                ' Get the Web application configuration object.
                Dim config As Configuration = _
                System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration(configPath)

                ' Get the section related object.
                Dim configSection _
                As System.Web.Configuration.AnonymousIdentificationSection = _
                DirectCast(config.GetSection("system.web/anonymousIdentification"),  _
                System.Web.Configuration.AnonymousIdentificationSection)

                ' Display title and info.
                Console.WriteLine("Configuration Info")
                Console.WriteLine()

                ' Display Config details.
                Console.WriteLine("File Path: {0}", config.FilePath)
                Console.WriteLine("Section Path: {0}", configSection.SectionInformation.Name)
                Console.WriteLine()

                ' Create a NameValueConfigurationCollection object.
                Dim myNameValConfigCollection As New NameValueConfigurationCollection()

                For Each propertyItem As PropertyInformation In configSection.ElementInformation.Properties
                    ' Assign  domain name.
                    If propertyItem.Name = "domain" Then
                        propertyItem.Value = "MyDomain"
                    End If

                    If propertyItem.Value <> Nothing Then
                        ' Enable SSL for cookie exchange.
                        If propertyItem.Name = "cookieRequireSSL" Then
                            propertyItem.Value = True
                        End If

                        Dim nameValConfigElement As New NameValueConfigurationElement(propertyItem.Name.ToString(), propertyItem.Value.ToString())

                        ' Add a NameValueConfigurationElement
                        ' to the collection.

                        myNameValConfigCollection.Add(nameValConfigElement)
                    End If
                Next

                ' Count property.
                Console.WriteLine("Collection Count: {0}", myNameValConfigCollection.Count)

                ' Item property.
                Console.WriteLine("Value of property 'enabled': {0}", myNameValConfigCollection("enabled").Value)

                ' Display the contents of the collection.
                For Each configItem As NameValueConfigurationElement In myNameValConfigCollection
                    Console.WriteLine()
                    Console.WriteLine("Configuration Details:")
                    Console.WriteLine("Name: {0}", configItem.Name)
                    Console.WriteLine("Value: {0}", configItem.Value)
                Next

                ' Assign the domain calue.
                configSection.Domain = myNameValConfigCollection("domain").Value
                ' Assign the SSL required value.
                If myNameValConfigCollection("cookieRequireSSL").Value = "true" Then
                    configSection.CookieRequireSSL = True
                End If

                ' Remove domain from the collection.
                Dim myConfigElement As NameValueConfigurationElement = myNameValConfigCollection("domain")
                ' Remove method.
                myNameValConfigCollection.Remove(myConfigElement)

                ' Save changes to the configuration file.
                ' This modifies the Web.config of the TestConfig site.
                config.Save(ConfigurationSaveMode.Minimal, True)

                ' Clear the collection.
                myNameValConfigCollection.Clear()
            Catch e As Exception

                ' Unknown error.
                Console.WriteLine(e.ToString())
            End Try

            ' Display and wait.
            Console.ReadLine()
        End Sub
    End Class
End Namespace