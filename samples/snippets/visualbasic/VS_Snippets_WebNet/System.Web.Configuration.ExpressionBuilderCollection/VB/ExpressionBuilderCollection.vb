' <Snippet1>
Imports System
Imports System.Configuration
Imports System.Web.Configuration

Namespace Samples.Aspnet.SystemWebConfiguration
  Class UsingExpressionBuildCollection
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
        ' Create a new ExpressionBuilder reference.
        Dim myExpressionBuilder As ExpressionBuilder = _
          New ExpressionBuilder("myCustomExpression", "MyCustomExpressionBuilder")
        ' </Snippet2>
        ' <Snippet3>
        ' Add an ExpressionBuilder to the configuration.
        configSection.ExpressionBuilders.Add(myExpressionBuilder)
        ' </Snippet3>
        ' </Snippet4>

        ' Add an ExpressionBuilder to the configuration.
        Dim myExpressionBuilder2 As ExpressionBuilder = _
         New ExpressionBuilder("myCustomExpression2", "MyCustomExpressionBuilder2")
        configSection.ExpressionBuilders.Add(myExpressionBuilder2)

        ' Display the ExpressionBuilder count.
        Console.WriteLine("ExpressionBuilder Count: {0}", _
          configSection.ExpressionBuilders.Count)

        ' Display the ExpressionBuildersCollection details.
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

        ' <Snippet5>
        ' Remove an ExpressionBuilder.
        configSection.ExpressionBuilders.RemoveAt _
         (configSection.ExpressionBuilders.Count - 1)
        ' </Snippet5>

        ' <Snippet6>
        ' Remove an ExpressionBuilder.
        configSection.ExpressionBuilders.Remove("myCustomExpression")
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