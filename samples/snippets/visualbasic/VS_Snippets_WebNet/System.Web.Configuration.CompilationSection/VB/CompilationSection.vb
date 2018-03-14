' <Snippet1>
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Configuration
Imports System.Web
Imports System.Web.Configuration

Namespace Samples.Aspnet.SystemWebConfiguration
  Class UsingRoleManagerSection
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

        ' <Snippet2>
        ' Display Assemblies collection count.
        Console.WriteLine("Assemblies Count: {0}", _
         configSection.Assemblies.Count)
        ' </Snippet2>

        ' <Snippet3>
        ' Display AssemblyPostProcessorType property.
        Console.WriteLine("AssemblyPostProcessorType: {0}", _
         configSection.AssemblyPostProcessorType)
        ' </Snippet3>

        ' <Snippet4>
        ' Display Batch property.
        Console.WriteLine("Batch: {0}", _
         configSection.Batch)

        ' Set Batch property.
        configSection.Batch = True
        ' </Snippet4>

        ' <Snippet5>
        ' Display BatchTimeout property.
        Console.WriteLine("BatchTimeout: {0}", _
         configSection.BatchTimeout)

        ' Set BatchTimeout property.
        configSection.BatchTimeout = TimeSpan.FromMinutes(15)
        ' </Snippet5>

        ' <Snippet6>
        ' Display BuildProviders collection count.
        Console.WriteLine("BuildProviders collection count: {0}", _
         configSection.BuildProviders.Count)
        ' </Snippet6>

        ' <Snippet7>
        ' Display CodeSubDirectories property.
        Console.WriteLine("CodeSubDirectories: {0}", _
         configSection.CodeSubDirectories.Count)
        ' </Snippet7>

        ' <Snippet8>
        ' Display Compilers property.
        Console.WriteLine("Compilers: {0}", _
         configSection.Compilers.Count)
        ' </Snippet8>

        ' <Snippet9>
        ' Display Debug property.
        Console.WriteLine("Debug: {0}", _
         configSection.Debug)

        ' Set Debug property.
        configSection.Debug = False

        ' </Snippet9>

        ' <Snippet10>
        ' Display DefaultLanguage property.
        Console.WriteLine("DefaultLanguage: {0}", _
         configSection.DefaultLanguage)

        ' Set DefaultLanguage property.
        configSection.DefaultLanguage = "vb"
        ' </Snippet10>

        ' <Snippet11>
        ' Display Explicit property.
        Console.WriteLine("Explicit: {0}", _
         configSection.Explicit)

        ' Set Explicit property.
        configSection.Explicit = True
        ' </Snippet11>

        ' <Snippet12>
        ' Display ExpressionBuilders collection count.
        Console.WriteLine("ExpressionBuilders Count: {0}", _
         configSection.ExpressionBuilders.Count)
        ' </Snippet12>

        ' <Snippet13>
        ' Display MaxBatchGeneratedFileSize property.
        Console.WriteLine("MaxBatchGeneratedFileSize: {0}", _
         configSection.MaxBatchGeneratedFileSize)

        ' Set MaxBatchGeneratedFileSize property.
        configSection.MaxBatchGeneratedFileSize = 1000
        ' </Snippet13>

        ' <Snippet14>
        ' Display MaxBatchSize property.
        Console.WriteLine("MaxBatchSize: {0}", _
         configSection.MaxBatchSize)

        ' Set MaxBatchSize property.
        configSection.MaxBatchSize = 1000
        ' </Snippet14>

        ' <Snippet15>
        ' Display NumRecompilesBeforeAppRestart property.
        Console.WriteLine("NumRecompilesBeforeAppRestart: {0}", _
         configSection.NumRecompilesBeforeAppRestart)

        ' Set NumRecompilesBeforeAppRestart property.
        configSection.NumRecompilesBeforeAppRestart = 15
        ' </Snippet15>

        ' <Snippet16>
        ' Display Strict property.
        Console.WriteLine("Strict: {0}", _
         configSection.Strict)

        ' Set Strict property.
        configSection.Strict = False
        ' </Snippet16>

        ' <Snippet17>
        ' Display TempDirectory property.
        Console.WriteLine("TempDirectory: {0}", _
         configSection.TempDirectory)

        ' Set TempDirectory property.
        configSection.TempDirectory = "myTempDirectory"
        ' </Snippet17>

        ' <Snippet18>
        ' Display UrlLinePragmas property.
        Console.WriteLine("UrlLinePragmas: {0}", _
         configSection.UrlLinePragmas)

        ' Set UrlLinePragmas property.
        configSection.UrlLinePragmas = False
        ' </Snippet18>

        ' <Snippet19>
        ' ExpressionBuilders Collection
        Dim i = 1
        Dim j = 1
        For Each expressionBuilder As ExpressionBuilder In configSection.ExpressionBuilders()
          Console.WriteLine()
          Console.WriteLine("ExpressionBuilder {0} Details:", i)
          Console.WriteLine("Type: {0}", expressionBuilder.ElementInformation.Type)
          Console.WriteLine("Source: {0}", expressionBuilder.ElementInformation.Source)
          Console.WriteLine("LineNumber: {0}", expressionBuilder.ElementInformation.LineNumber)
          Console.WriteLine("Properties Count: {0}", expressionBuilder.ElementInformation.Properties.Count)
          j = 1
          For Each propertyItem As PropertyInformation In expressionBuilder.ElementInformation.Properties
            Console.WriteLine("Property {0} Name: {1}", j, propertyItem.Name)
            Console.WriteLine("Property {0} Value: {1}", j, propertyItem.Value)
            j = j + 1
          Next
          i = i + 1
        Next
        ' </Snippet19>

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