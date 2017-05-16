' <Snippet1>
Imports System
Imports System.Configuration
Imports System.Web.Configuration

Namespace Samples.Aspnet.SystemWebConfiguration
  Class UsingBuildProviderCollection
    Public Shared Sub Main()
      Try
        ' Set the path of the config file.
        Dim configPath As String = ""

        ' Get the Web application configuration object.
        Dim config As System.Configuration.Configuration = _
         WebConfigurationManager.OpenWebConfiguration(configPath)

        ' Get the section related object.
        Dim configSection As _
         System.Web.Configuration.CompilationSection = _
         CType(config.GetSection("system.web/compilation"), _
         System.Web.Configuration.CompilationSection)

        ' Display title and info.
        Console.WriteLine("ASP.NET Configuration Info")
        Console.WriteLine()

        ' Display Config details.
        Console.WriteLine("File Path: {0}", _
         config.FilePath)
        Console.WriteLine("Section Path: {0}", _
         configSection.SectionInformation.Name)

        ' Display BuildProviderCollection count.
        Console.WriteLine("BuildProviderCollection count: {0}", _
          configSection.BuildProviders.Count)

        ' <Snippet4>
        ' <Snippet2>
        ' Create a new BuildProvider.
        Dim myBuildProvider As BuildProvider = _
          New BuildProvider(".myres", _
          "System.Web.Compilation.ResourcesBuildProvider")
        ' </Snippet2>

        ' <Snippet3>
        ' Add an BuildProvider to the collection.
        configSection.BuildProviders.Add(myBuildProvider)
        ' </Snippet3>
        ' </Snippet4>

        ' Create a second BuildProvider.
        Dim myBuildProvider2 As BuildProvider = _
          New BuildProvider(".myres2", _
          "System.Web.Compilation.ResourcesBuildProvider")

        ' Add an BuildProvider to the collection.
        configSection.BuildProviders.Add(myBuildProvider2)

        ' BuildProvider Collection
        Dim i = 1
        Dim j = 1
        For Each BuildProviderItem As _
          BuildProvider In configSection.BuildProviders
          Console.WriteLine()
          Console.WriteLine("BuildProvider {0} Details:", i)
          Console.WriteLine("Type: {0}", _
            BuildProviderItem.ElementInformation.Type)
          Console.WriteLine("Source: {0}", _
            BuildProviderItem.ElementInformation.Source)
          Console.WriteLine("LineNumber: {0}", _
            BuildProviderItem.ElementInformation.LineNumber)
          Console.WriteLine("Properties Count: {0}", _
            BuildProviderItem.ElementInformation.Properties.Count)
          j = 1
          For Each propertyItem As PropertyInformation In _
            BuildProviderItem.ElementInformation.Properties
            Console.WriteLine("Property {0} Name: {1}", j, _
              propertyItem.Name)
            Console.WriteLine("Property {0} Value: {1}", j, _
              propertyItem.Value)
            j = j + 1
          Next
          i = i + 1
        Next

        ' <Snippet5>
        ' Remove an BuildProvider.
        configSection.BuildProviders.Remove(".myres2")
        ' </Snippet5>

        ' <Snippet6>
        ' Remove an BuildProvider.
        configSection.BuildProviders.RemoveAt( _
          configSection.BuildProviders.Count - 1)
        ' </Snippet6>

        ' Update if not locked.
        If Not configSection.SectionInformation.IsLocked Then
          config.Save()
          Console.WriteLine("** Configuration updated.")
        Else
          Console.WriteLine("** Could not update, section is locked.")
        End If

      Catch e As Exception
        ' Unknown error.
        Console.WriteLine(e.ToString())
      End Try

      ' Display and wait
      Console.ReadLine()
    End Sub
  End Class
End Namespace
' </Snippet1>