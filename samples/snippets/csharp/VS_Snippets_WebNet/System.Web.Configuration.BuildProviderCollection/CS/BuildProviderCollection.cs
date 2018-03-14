// <Snippet1>
#region Using directives

using System;
using System.Configuration;
using System.Web.Configuration;

#endregion

namespace Samples.Aspnet.SystemWebConfiguration
{
  class UsingBuildProviderCollection
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
          (CompilationSection)config.GetSection
          ("system.web/compilation");

        // Display title and info.
        Console.WriteLine("ASP.NET Configuration Info");
        Console.WriteLine();

        // Display Config details.
        Console.WriteLine("File Path: {0}",
          config.FilePath);
        Console.WriteLine("Section Path: {0}",
          configSection.SectionInformation.Name);

        // Display BuildProviderCollection count.
        Console.WriteLine("BuildProviderCollection count: {0}",
          configSection.BuildProviders.Count);

        // <Snippet4>
        // <Snippet2>
        // Create a new BuildProvider.
        BuildProvider myBuildProvider =
          new BuildProvider(".myres",
          "System.Web.Compilation.ResourcesBuildProvider");
        // </Snippet2>

        // <Snippet3>
        // Add an BuildProvider to the collection.
        configSection.BuildProviders.Add(myBuildProvider);
        // </Snippet3>
        // </Snippet4>

        // Create a second BuildProvider.
        BuildProvider myBuildProvider2 =
          new BuildProvider(".myres2",
          "System.Web.Compilation.ResourcesBuildProvider");

        // Add an BuildProvider to the collection.
        configSection.BuildProviders.Add(myBuildProvider2);

        // BuildProvider Collection
        int i = 1;
        int j = 1;
        foreach (BuildProvider BuildProviderItem in
          configSection.BuildProviders)
        {
          Console.WriteLine();
          Console.WriteLine("BuildProviders {0} Details:", i);
          Console.WriteLine("Type: {0}",
            BuildProviderItem.ElementInformation.Type);
          Console.WriteLine("Source: {0}",
            BuildProviderItem.ElementInformation.Source);
          Console.WriteLine("LineNumber: {0}",
            BuildProviderItem.ElementInformation.LineNumber);
          Console.WriteLine("Properties Count: {0}",
            BuildProviderItem.ElementInformation.Properties.Count);
          j = 1;
          foreach (PropertyInformation propertyItem in
            BuildProviderItem.ElementInformation.Properties)
          {
            Console.WriteLine("Property {0} Name: {1}", j,
              propertyItem.Name);
            Console.WriteLine("Property {0} Value: {1}", j,
              propertyItem.Value);
            j++;
          }
          i++;
        }

        // <Snippet5>
        // Remove a BuildProvider.
        configSection.BuildProviders.Remove(".myres2");
        // </Snippet5>

        // <Snippet6>
        // Remove an BuildProvider.
        configSection.BuildProviders.RemoveAt(
          configSection.BuildProviders.Count - 1);
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