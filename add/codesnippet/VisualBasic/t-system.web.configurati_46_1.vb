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

        ' Display Assemblies collection count.
        Console.WriteLine("Assemblies Count: {0}", _
         configSection.Assemblies.Count)

        ' Display AssemblyPostProcessorType property.
        Console.WriteLine("AssemblyPostProcessorType: {0}", _
         configSection.AssemblyPostProcessorType)

        ' Display Batch property.
        Console.WriteLine("Batch: {0}", _
         configSection.Batch)

        ' Set Batch property.
        configSection.Batch = True

        ' Display BatchTimeout property.
        Console.WriteLine("BatchTimeout: {0}", _
         configSection.BatchTimeout)

        ' Set BatchTimeout property.
        configSection.BatchTimeout = TimeSpan.FromMinutes(15)

        ' Display BuildProviders collection count.
        Console.WriteLine("BuildProviders collection count: {0}", _
         configSection.BuildProviders.Count)

        ' Display CodeSubDirectories property.
        Console.WriteLine("CodeSubDirectories: {0}", _
         configSection.CodeSubDirectories.Count)

        ' Display Compilers property.
        Console.WriteLine("Compilers: {0}", _
         configSection.Compilers.Count)

        ' Display Debug property.
        Console.WriteLine("Debug: {0}", _
         configSection.Debug)

        ' Set Debug property.
        configSection.Debug = False


        ' Display DefaultLanguage property.
        Console.WriteLine("DefaultLanguage: {0}", _
         configSection.DefaultLanguage)

        ' Set DefaultLanguage property.
        configSection.DefaultLanguage = "vb"

        ' Display Explicit property.
        Console.WriteLine("Explicit: {0}", _
         configSection.Explicit)

        ' Set Explicit property.
        configSection.Explicit = True

        ' Display ExpressionBuilders collection count.
        Console.WriteLine("ExpressionBuilders Count: {0}", _
         configSection.ExpressionBuilders.Count)

        ' Display MaxBatchGeneratedFileSize property.
        Console.WriteLine("MaxBatchGeneratedFileSize: {0}", _
         configSection.MaxBatchGeneratedFileSize)

        ' Set MaxBatchGeneratedFileSize property.
        configSection.MaxBatchGeneratedFileSize = 1000

        ' Display MaxBatchSize property.
        Console.WriteLine("MaxBatchSize: {0}", _
         configSection.MaxBatchSize)

        ' Set MaxBatchSize property.
        configSection.MaxBatchSize = 1000

        ' Display NumRecompilesBeforeAppRestart property.
        Console.WriteLine("NumRecompilesBeforeAppRestart: {0}", _
         configSection.NumRecompilesBeforeAppRestart)

        ' Set NumRecompilesBeforeAppRestart property.
        configSection.NumRecompilesBeforeAppRestart = 15

        ' Display Strict property.
        Console.WriteLine("Strict: {0}", _
         configSection.Strict)

        ' Set Strict property.
        configSection.Strict = False

        ' Display TempDirectory property.
        Console.WriteLine("TempDirectory: {0}", _
         configSection.TempDirectory)

        ' Set TempDirectory property.
        configSection.TempDirectory = "myTempDirectory"

        ' Display UrlLinePragmas property.
        Console.WriteLine("UrlLinePragmas: {0}", _
         configSection.UrlLinePragmas)

        ' Set UrlLinePragmas property.
        configSection.UrlLinePragmas = False

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