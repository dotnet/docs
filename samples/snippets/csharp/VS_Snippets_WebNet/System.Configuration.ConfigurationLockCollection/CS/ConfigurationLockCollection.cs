// <Snippet1>
#region Using directives

using System;
using System.Configuration;
using System.Web.Configuration;
using System.Collections;
using System.Text;

#endregion

namespace Samples.Aspnet.SystemWebConfiguration
{
  class UsingConfigurationLockCollection
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
        AnonymousIdentificationSection configSection =
          (AnonymousIdentificationSection)config.GetSection
          ("system.web/anonymousIdentification");

        // Display title and info.
        Console.WriteLine("Configuration Info");
        Console.WriteLine();

        // Display Config details.
        Console.WriteLine("File Path: {0}",
          config.FilePath);
        Console.WriteLine("Section Path: {0}",
          configSection.SectionInformation.Name);
        Console.WriteLine();

        // <Snippet2>
        // Create a ConfigurationLockCollection object.
        ConfigurationLockCollection lockedAttribList;
        lockedAttribList = configSection.LockAttributes;
        // </Snippet2>

        // <Snippet3>
        // Add an attribute to the lock collection.
        if (!lockedAttribList.Contains("enabled"))
        {
          lockedAttribList.Add("enabled");
        }
        // </Snippet3>
        if (!lockedAttribList.Contains("cookieless"))
        {
          lockedAttribList.Add("cookieless");
        }

        // <Snippet4>
        // Count property.
        Console.WriteLine("Collection Count: {0}",
         lockedAttribList.Count);
        // </Snippet4>

        // <Snippet5>
        // AttributeList method.
        Console.WriteLine("AttributeList: {0}",
         lockedAttribList.AttributeList);
        // </Snippet5>

        // <Snippet6>
        // Contains method.
        Console.WriteLine("Contains 'enabled': {0}",
         lockedAttribList.Contains("enabled"));
        // </Snippet6>

        // <Snippet7>
        // HasParentElements property.
        Console.WriteLine("HasParentElements: {0}",
         lockedAttribList.HasParentElements);
        // </Snippet7>

        // <Snippet8>
        // IsModified property.
        Console.WriteLine("IsModified: {0}",
         lockedAttribList.IsModified);
        // </Snippet8>

        // <Snippet9>
        // IsReadOnly method. 
        Console.WriteLine("IsReadOnly: {0}",
         lockedAttribList.IsReadOnly("enabled"));
        // </Snippet9>

        // <Snippet10>
        // Remove a configuration object 
        // from the collection.
        lockedAttribList.Remove("cookieless");
        // </Snippet10>

        // <Snippet11>
        // Clear the collection.
        lockedAttribList.Clear();
        // </Snippet11>

        // <Snippet12>
        // Create an ArrayList to contain
        // the property items of the configuration
        // section.
        ArrayList configPropertyAL = new ArrayList(lockedAttribList.Count);
        foreach (PropertyInformation propertyItem in
          configSection.ElementInformation.Properties)
        {
          configPropertyAL.Add(propertyItem.Name.ToString());
        }
        // Copy the elements of the ArrayList to a string array.
        String[] myArr = (String[])configPropertyAL.ToArray(typeof(string));
        // Create as a comma delimited list.
        string propList = string.Join(",", myArr);
        // Lock the items in the list.
        lockedAttribList.SetFromList(propList);
        // </Snippet12>
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