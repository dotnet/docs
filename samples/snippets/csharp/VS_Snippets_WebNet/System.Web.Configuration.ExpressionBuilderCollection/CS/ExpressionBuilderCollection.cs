// <Snippet1>
#region Using directives

using System;
using System.Configuration;
using System.Web.Configuration;

#endregion

namespace Samples.Aspnet.SystemWebConfiguration
{
  class UsingExpressionBuildCollection
  {
    static void Main(string[] args)
    {
      try
      {
        // Set the path of the config file.
        string configPath = "";

        // Get the Web application configuration object.
        Configuration config =
          WebConfigurationManager.OpenWebConfiguration(configPath);

        // Get the section related object.
        CompilationSection configSection =
          (CompilationSection)config.GetSection("system.web/compilation");

        // Display title and info.
        Console.WriteLine("ASP.NET Configuration Info");
        Console.WriteLine();

        // Display Config details.
        Console.WriteLine("File Path: {0}",
          config.FilePath);
        Console.WriteLine("Section Path: {0}",
          configSection.SectionInformation.Name);

        // <Snippet4>
        // <Snippet2>
        // Create a new ExpressionBuilder reference.
        ExpressionBuilder myExpressionBuilder =
          new ExpressionBuilder("myCustomExpression", "MyCustomExpressionBuilder");
        // </Snippet2>
        // <Snippet3>
        // Add an ExpressionBuilder to the configuration.
        configSection.ExpressionBuilders.Add(myExpressionBuilder);
        // </Snippet3>
        // </Snippet4>

        // Add an ExpressionBuilder to the configuration.
        ExpressionBuilder myExpressionBuilder2 =
          new ExpressionBuilder("myCustomExpression2", "MyCustomExpressionBuilder2");
        configSection.ExpressionBuilders.Add(myExpressionBuilder2);

        // Display the ExpressionBuilder count.
        Console.WriteLine("ExpressionBuilder Count: {0}",
          configSection.ExpressionBuilders.Count);

        // Display the ExpressionBuildersCollection details.
        int i = 1;
        int j = 1;
        foreach (ExpressionBuilder expressionBuilder in configSection.ExpressionBuilders)
        {
          Console.WriteLine();
          Console.WriteLine("ExpressionBuilder {0} Details:", i);
          Console.WriteLine("Type: {0}", expressionBuilder.ElementInformation.Type);
          Console.WriteLine("Source: {0}", expressionBuilder.ElementInformation.Source);
          Console.WriteLine("LineNumber: {0}", expressionBuilder.ElementInformation.LineNumber);
          Console.WriteLine("Properties Count: {0}", expressionBuilder.ElementInformation.Properties.Count);
          j = 1;
          foreach (PropertyInformation propertyItem in expressionBuilder.ElementInformation.Properties)
          {
            Console.WriteLine("Property {0} Name: {1}", j, propertyItem.Name);
            Console.WriteLine("Property {0} Value: {1}", j, propertyItem.Value);
            ++j;
          }
          ++i;
        }

        // <Snippet5>
        // Remove an ExpressionBuilder.
        configSection.ExpressionBuilders.RemoveAt
          (configSection.ExpressionBuilders.Count-1);
        // </Snippet5>

        // <Snippet6>
        // Remove an ExpressionBuilder.
        configSection.ExpressionBuilders.Remove("myCustomExpression");
        // </Snippet6>

        // Update if not locked.
        if (!configSection.SectionInformation.IsLocked)
        {
          config.Save();
          Console.WriteLine("** Configuration updated.");
        }
        else
        {
          Console.WriteLine("** Could not update, section is locked.");
        }
      }

      catch (Exception e)
      {
        // Unknown error.
        Console.WriteLine(e.ToString());
      }

      // Display and wait.
      Console.ReadLine();
    }
  }
}
// </Snippet1>