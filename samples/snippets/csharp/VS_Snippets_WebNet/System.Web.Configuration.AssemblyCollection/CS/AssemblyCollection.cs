// <Snippet1>
#region Using directives

using System;
using System.Configuration;
using System.Web.Configuration;

#endregion

namespace Samples.Aspnet.SystemWebConfiguration
{
  class UsingAssemblyCollection
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
        // Create a new assembly reference.
        AssemblyInfo myAssembly = 
          new AssemblyInfo("MyAssembly, Version=1.0.0000.0, " +
          "Culture=neutral, Public KeyToken=b03f5f7f11d50a3a");
        // </Snippet2>
        // <Snippet3>
        // Add an assembly to the configuration.
        configSection.Assemblies.Add(myAssembly);
        // </Snippet3>
        // </Snippet4>

        // Add a second assembly reference.
        AssemblyInfo myAssembly2 = new AssemblyInfo("MyAssembly2");
        configSection.Assemblies.Add(myAssembly2);

        // Assembly Collection
        int i = 1;
        int j = 1;
        foreach (AssemblyInfo assemblyItem in configSection.Assemblies)
        {
          Console.WriteLine();
          Console.WriteLine("Assemblies {0} Details:", i);
          Console.WriteLine("Type: {0}", assemblyItem.ElementInformation.Type);
          Console.WriteLine("Source: {0}", assemblyItem.ElementInformation.Source);
          Console.WriteLine("LineNumber: {0}", assemblyItem.ElementInformation.LineNumber);
          Console.WriteLine("Properties Count: {0}", 
            assemblyItem.ElementInformation.Properties.Count);
          j = 1;
          foreach (PropertyInformation propertyItem in assemblyItem.ElementInformation.Properties)
          {
            Console.WriteLine("Property {0} Name: {1}", j, propertyItem.Name);
            Console.WriteLine("Property {0} Value: {1}", j, propertyItem.Value);
            j++;
          }
          i++;
        }

        // <Snippet5>
        // Remove an assembly.
        configSection.Assemblies.Remove("MyAssembly, Version=1.0.0000.0, " +
          "Culture=neutral, Public KeyToken=b03f5f7f11d50a3a");
        // </Snippet5>

        // <Snippet6>
        // Remove an assembly.
        configSection.Assemblies.RemoveAt(configSection.Assemblies.Count - 1);
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