' <Snippet1>
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Configuration
Imports System.Web
Imports System.Web.Configuration

Namespace Samples.ConfigurationExamples
  Class UsingPropertyInformation
    Public Shared Sub Main()
      Try
        ' Set the path of the config file.
        Dim configPath As String = ""

        ' Get the Web application configuration object.
        Dim config As Configuration = _
          WebConfigurationManager.OpenWebConfiguration(configPath)

        ' Get the section related object.

        Dim configSection As AnonymousIdentificationSection = _
        CType(config.GetSection("system.web/anonymousIdentification"), _
        AnonymousIdentificationSection)

        ' Display title.
        Console.WriteLine("Configuration PropertyInformation")
        Console.WriteLine("Section: anonymousIdentification")

        ' Instantiate a new PropertyInformationCollection object.
        Dim propCollection As PropertyInformationCollection = _
         configSection.ElementInformation.Properties()

        ' Display Collection Count.
        Console.WriteLine("Collection Count: {0}", _
          propCollection.Count)

        ' Display properties of elements 
        ' of the PropertyInformationCollection.
        For Each propertyItem As PropertyInformation In propCollection
          Console.WriteLine()
          Console.WriteLine("Property Details:")

          ' <Snippet8>
          ' Display the Name property.
          Console.WriteLine("Name: {0}", propertyItem.Name)
          ' </Snippet8>

          ' <Snippet12>
          ' Display the Value property.
          Console.WriteLine("Value: {0}", propertyItem.Value)
          ' </Snippet12>

          ' <Snippet2>
          ' Display the DefaultValue property.
          Console.WriteLine("DefaultValue: {0}", _
            propertyItem.DefaultValue) _
          ' </Snippet2>

          ' <Snippet10>
          ' Display the Type property.
          Console.WriteLine("Type: {0}", propertyItem.Type)
          ' </Snippet10>

          ' <Snippet3>
          ' Display the IsKey property.
          Console.WriteLine("IsKey: {0}", propertyItem.IsKey)
          ' </Snippet3>

          ' <Snippet4>
          ' Display the IsLocked property.
          Console.WriteLine("IsLocked: {0}", propertyItem.IsLocked)
          ' </Snippet4>

          ' <Snippet5>
          ' Display the IsModified property.
          Console.WriteLine("IsModified: {0}", propertyItem.IsModified)
          ' </Snippet5>

          ' <Snippet6>
          ' Display the IsRequired property.
          Console.WriteLine("IsRequired: {0}", propertyItem.IsRequired)
          ' </Snippet6>

          ' <Snippet7>
          ' Display the LineNumber property.
          Console.WriteLine("LineNumber: {0}", propertyItem.LineNumber)
          ' </Snippet7>

          ' <Snippet9>
          ' Display the Source property.
          Console.WriteLine("Source: {0}", propertyItem.Source)
          ' </Snippet9>

          ' <Snippet11>
          ' Display the Validator property.
          Console.WriteLine("Validator: {0}", propertyItem.Validator)
          ' </Snippet11>

          ' <Snippet13>
          ' Display the ValueOrigin property.
          Console.WriteLine("ValueOrigin: {0}", propertyItem.ValueOrigin)
          ' </Snippet13>
        Next

        Console.WriteLine("")
        Console.WriteLine("Configuration - Accessing an Attribute")
        ' <Snippet14>
        ' Create EllementInformation object.
        Dim elementInfo As ElementInformation = _
        configSection.ElementInformation()
        ' Create a PropertyInformationCollection object.
        Dim propertyInfoCollection As PropertyInformationCollection = _
        elementInfo.Properties()
        ' Create a PropertyInformation object.
        Dim myPropertyInfo As PropertyInformation = _
          propertyInfoCollection("enabled")
        ' Display the property value.
        Console.WriteLine _
          ("anonymousIdentification Section - Enabled: {0}", _
          myPropertyInfo.Value)
        ' </Snippet14>

      Catch e As Exception
        ' Error.
        Console.WriteLine("Error: {0}", _
          e.Message.ToString())
      End Try

      ' Display and wait.
      Console.ReadLine()
    End Sub
  End Class
End Namespace
' </Snippet1>