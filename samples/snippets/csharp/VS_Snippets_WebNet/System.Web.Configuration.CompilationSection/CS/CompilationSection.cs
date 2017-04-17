// <Snippet1>
#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Web;
using System.Web.Configuration;

#endregion

namespace Samples.Aspnet.SystemWebConfiguration
{
  class UsingCompilationSection
  {
    static void Main(string[] args)
    {
      try
      {
        // Set the path of the config file.
        string configPath = "";

        // Get the Web application configuration object.
        Configuration config = WebConfigurationManager.OpenWebConfiguration(configPath);

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

        // <Snippet2>
        // Display Assemblies collection count.
        Console.WriteLine("Assemblies Count: {0}",
          configSection.Assemblies.Count);
        // </Snippet2>

        // <Snippet3>
        // Display AssemblyPostProcessorType property.
        Console.WriteLine("AssemblyPostProcessorType: {0}", 
          configSection.AssemblyPostProcessorType);
        // </Snippet3>

        // <Snippet4>
        // Display Batch property.
        Console.WriteLine("Batch: {0}", configSection.Batch);

        // Set Batch property.
        configSection.Batch = true;
        // </Snippet4>

        // <Snippet5>
        // Display BatchTimeout property.
        Console.WriteLine("BatchTimeout: {0}",
          configSection.BatchTimeout);

        // Set BatchTimeout property.
        configSection.BatchTimeout = TimeSpan.FromMinutes(15);
        // </Snippet5>

        // <Snippet6>
          // Display BuildProviders collection count.
          Console.WriteLine("BuildProviders collection Count: {0}",
          configSection.BuildProviders.Count);
        // </Snippet6>

        // <Snippet7>
          // Display CodeSubDirectories collection count.
          Console.WriteLine("CodeSubDirectories Count: {0}",
        configSection.CodeSubDirectories.Count);
        // </Snippet7>

        // <Snippet8>
        // Display Compilers collection count.
        Console.WriteLine("Compilers Count: {0}",
        configSection.Compilers.Count);
        // </Snippet8>

        // <Snippet9>
        // Display Debug property.
        Console.WriteLine("Debug: {0}",
          configSection.Debug);

        // Set Debug property.
        configSection.Debug = false;
        // </Snippet9>

        // <Snippet10>
        // Display DefaultLanguage property.
        Console.WriteLine("DefaultLanguage: {0}",
          configSection.DefaultLanguage);

        // Set DefaultLanguage property.
        configSection.DefaultLanguage = "vb";
        // </Snippet10>

        // <Snippet11>
        // Display Explicit property.
        Console.WriteLine("Explicit: {0}",
          configSection.Explicit);

        // Set Explicit property.
        configSection.Explicit = true;
        // </Snippet11>

        // <Snippet12>
        // Display ExpressionBuilders collection count.
        Console.WriteLine("ExpressionBuilders Count: {0}",
          configSection.ExpressionBuilders.Count);
        // </Snippet12>

        // <Snippet13>
        // Display MaxBatchGeneratedFileSize property.
        Console.WriteLine("MaxBatchGeneratedFileSize: {0}", 
          configSection.MaxBatchGeneratedFileSize);

        // Set MaxBatchGeneratedFileSize property.
        configSection.MaxBatchGeneratedFileSize = 1000;
        // </Snippet13>

        // <Snippet14>
        // Display MaxBatchSize property.
        Console.WriteLine("MaxBatchSize: {0}", 
          configSection.MaxBatchSize);

        // Set MaxBatchSize property.
        configSection.MaxBatchSize = 1000;
        // </Snippet14>

        // <Snippet15>
        // Display NumRecompilesBeforeAppRestart property.
        Console.WriteLine("NumRecompilesBeforeAppRestart: {0}", 
          configSection.NumRecompilesBeforeAppRestart);

        // Set NumRecompilesBeforeAppRestart property.
        configSection.NumRecompilesBeforeAppRestart = 15;
        // </Snippet15>

        // <Snippet16>
        // Display Strict property.
        Console.WriteLine("Strict: {0}", 
          configSection.Strict);

        // Set Strict property.
        configSection.Strict = false;
        // </Snippet16>

        // <Snippet17>
        // Display TempDirectory property.
        Console.WriteLine("TempDirectory: {0}", configSection.TempDirectory);

        // Set TempDirectory property.
        configSection.TempDirectory = "myTempDirectory";
        // </Snippet17>

        // <Snippet18>
        // Display UrlLinePragmas property.
        Console.WriteLine("UrlLinePragmas: {0}", 
          configSection.UrlLinePragmas);

        // Set UrlLinePragmas property.
        configSection.UrlLinePragmas = false;
        // </Snippet18>

        // ExpressionBuilders Collection
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
            j++;
          }
          i++;
        }

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

      // Display and wait
      Console.ReadLine();
    }
  }
}
// </Snippet1>