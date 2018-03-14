' <Snippet1>
Imports System
Imports System.Configuration
Imports System.Web.Configuration

Namespace Samples.Aspnet.SystemWebConfiguration
  Class UsingAssemblyCollection
    Public Shared Sub Main()
      Try
        ' Set the path of the config file.
        Dim configPath As String = ""

        ' Get the Web application configuration object.
        Dim config As System.Configuration.Configuration = _
         WebConfigurationManager.OpenWebConfiguration(configPath)

        ' Get the section related object.
        Dim configSection As System.Web.Configuration.CompilationSection = _
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

        ' <Snippet4>
        ' <Snippet2>
        ' Create a new assembly reference.
        Dim myAssembly As AssemblyInfo = New AssemblyInfo("MyAssembly, " + _
        "Version=1.0.0000.0, Culture=neutral, Public KeyToken=b03f5f7f11d50a3a")
        ' </Snippet2>
        ' <Snippet3>
        ' Add an assembly to the configuration.
        configSection.Assemblies.Add(myAssembly)
        ' </Snippet3>
        ' </Snippet4>

        ' Add a second assembly reference.
        Dim myAssembly2 As AssemblyInfo = New AssemblyInfo("MyAssembly2")
        configSection.Assemblies.Add(myAssembly2)

        ' Assembly Collection
        Dim i = 1
        Dim j = 1
        For Each assemblyItem As AssemblyInfo In configSection.Assemblies
          Console.WriteLine()
          Console.WriteLine("Assemblies {0} Details:", i)
          Console.WriteLine("Type: {0}", assemblyItem.ElementInformation.Type)
          Console.WriteLine("Source: {0}", assemblyItem.ElementInformation.Source)
          Console.WriteLine("LineNumber: {0}", assemblyItem.ElementInformation.LineNumber)
          Console.WriteLine("Properties Count: {0}", assemblyItem.ElementInformation.Properties.Count)
          j = 1
          For Each propertyItem As PropertyInformation In assemblyItem.ElementInformation.Properties
            Console.WriteLine("Property {0} Name: {1}", j, propertyItem.Name)
            Console.WriteLine("Property {0} Value: {1}", j, propertyItem.Value)
            j = j + 1
          Next
          i = i + 1
        Next

        ' <Snippet5>
        ' Remove an assembly.
        configSection.Assemblies.Remove("MyAssembly, Version=1.0.0000.0, " + _
          "Culture=neutral, Public KeyToken=b03f5f7f11d50a3a")
        ' </Snippet5>

        ' <Snippet6>
        ' Remove an assembly.
        configSection.Assemblies.RemoveAt(configSection.Assemblies.Count - 1)
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