Imports System
Imports System.Configuration
Imports System.Web.Configuration
Imports System.Collections
Imports System.Text

Namespace Samples.Aspnet.SystemWebConfiguration
  Class UsingConfigurationLockCollection
    Public Shared Sub Main()
      Try
        ' Set the path of the config file.
        Dim configPath As String = ""

        ' Get the Web application configuration object.
        Dim config As System.Configuration.Configuration = _
         WebConfigurationManager.OpenWebConfiguration(configPath)

        ' Get the section related object.
        Dim configSection As _
        AnonymousIdentificationSection = _
         CType(config.GetSection("system.web/anonymousIdentification"), _
         AnonymousIdentificationSection)

        ' Display title and info.
        Console.WriteLine("Configuration Info")
        Console.WriteLine()

        ' Display Config details.
        Console.WriteLine("File Path: {0}", _
          config.FilePath)
        Console.WriteLine("Section Path: {0}", _
          configSection.SectionInformation.Name)
        Console.WriteLine()

        ' Create a ConfigurationLockCollection object.
        Dim lockedAttribList As ConfigurationLockCollection
        lockedAttribList = configSection.LockAttributes

        ' Add an attribute to the lock collection.
        If Not (lockedAttribList.Contains("enabled")) Then
          lockedAttribList.Add("enabled")
        End If
        If Not (lockedAttribList.Contains("cookieless")) Then
          lockedAttribList.Add("cookieless")
        End If

        ' Count property.
        Console.WriteLine("Collection Count: {0}", _
         lockedAttribList.Count)

        ' AttributeList method.
        Console.WriteLine("AttributeList: {0}", _
         lockedAttribList.AttributeList)

        ' Contains method.
        Console.WriteLine("Contains 'enabled': {0}", _
         lockedAttribList.Contains("enabled"))

        ' HasParentElements property.
        Console.WriteLine("HasParentElements: {0}", _
         lockedAttribList.HasParentElements)

        ' IsModified property.
        Console.WriteLine("IsModified: {0}", _
         lockedAttribList.IsModified)

        ' IsReadOnly method. 
        Console.WriteLine("IsReadOnly: {0}", _
         lockedAttribList.IsReadOnly("enabled"))

        ' Remove a configuration object 
        ' from the collection.
        lockedAttribList.Remove("cookieless")

        ' Clear the collection.
        lockedAttribList.Clear()

        ' Create an ArrayList to contain
        ' the property items of the configuration
        ' section.
        Dim configPropertyAL As ArrayList = _
         New ArrayList(lockedAttribList.Count)
        For Each propertyItem As _
         PropertyInformation In _
         configSection.ElementInformation.Properties
          configPropertyAL.Add(propertyItem.Name.ToString())
        Next
        ' Copy the elements of the ArrayList to a string array.
        Dim myArr As [String]() = _
        CType(configPropertyAL.ToArray(GetType(String)), [String]())
        ' Create as a comma delimited list.
        Dim propList As String = String.Join(",", myArr)
        ' Lock the items in the list.
        lockedAttribList.SetFromList(propList)

      Catch e As Exception
        ' Validation failed.
        Console.WriteLine("Error: {0}", _
          e.Message.ToString())
      End Try

      ' Display and wait.
      Console.ReadLine()
    End Sub
  End Class
End Namespace