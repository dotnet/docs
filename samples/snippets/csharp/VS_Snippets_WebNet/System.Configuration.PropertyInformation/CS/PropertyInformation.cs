// <Snippet1>
#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Web;
using System.Web.Configuration;

#endregion

namespace Samples.ConfigurationExamples
{
  class UsingPropertyInformation
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

        // Display title.
        Console.WriteLine("Configuration PropertyInformation");
        Console.WriteLine("Section: anonymousIdentification");

        // Instantiate a new PropertyInformationCollection object.
        PropertyInformationCollection propCollection =
          configSection.ElementInformation.Properties;

        // Display Collection Count.
        Console.WriteLine("Collection Count: {0}", 
          propCollection.Count);

        // Display properties of elements 
        // of the PropertyInformationCollection.
        foreach (PropertyInformation propertyItem in propCollection)
        {
          Console.WriteLine();
          Console.WriteLine("Property Details:");

          // <Snippet8>
          // Display the Name property.
          Console.WriteLine("Name: {0}", propertyItem.Name);
          // </Snippet8>

          // <Snippet12>
          // Display the Value property.
          Console.WriteLine("Value: {0}", propertyItem.Value);
          // </Snippet12>

          // <Snippet2>
          // Display the DefaultValue property.
          Console.WriteLine("DefaultValue: {0}", 
            propertyItem.DefaultValue);
          // </Snippet2>

          // <Snippet10>
          // Display the Type property.
          Console.WriteLine("Type: {0}", propertyItem.Type);
          // </Snippet10>

          // <Snippet3>
          // Display the IsKey property.
          Console.WriteLine("IsKey: {0}", propertyItem.IsKey);
          // </Snippet3>

          // <Snippet4>
          // Display the IsLocked property.
          Console.WriteLine("IsLocked: {0}", propertyItem.IsLocked);
          // </Snippet4>

          // <Snippet5>
          // Display the IsModified property.
          Console.WriteLine("IsModified: {0}", propertyItem.IsModified);
          // </Snippet5>

          // <Snippet6>
          // Display the IsRequired property.
          Console.WriteLine("IsRequired: {0}", propertyItem.IsRequired);
          // </Snippet6>

          // <Snippet7>
          // Display the LineNumber property.
          Console.WriteLine("LineNumber: {0}", propertyItem.LineNumber);
          // </Snippet7>

          // <Snippet9>
          // Display the Source property.
          Console.WriteLine("Source: {0}", propertyItem.Source);
          // </Snippet9>

          // <Snippet11>
          // Display the Validator property.
          Console.WriteLine("Validator: {0}", propertyItem.Validator);
          // </Snippet11>

          // <Snippet13>
          // Display the ValueOrigin property.
          Console.WriteLine("ValueOrigin: {0}", propertyItem.ValueOrigin);
          // </Snippet13>
        }

        Console.WriteLine("");
        Console.WriteLine("Configuration - Accessing an Attribute");
        // <Snippet14>
        // Create EllementInformation object.
        ElementInformation elementInfo =
          configSection.ElementInformation;
        // Create a PropertyInformationCollection object.
        PropertyInformationCollection propertyInfoCollection =
          elementInfo.Properties;
        // Create a PropertyInformation object.
        PropertyInformation myPropertyInfo =
          propertyInfoCollection["enabled"];
        // Display the property value.
        Console.WriteLine
          ("anonymousIdentification Section - Enabled: {0}",
          myPropertyInfo.Value);
        // </Snippet14>
      }

      catch (Exception e)
      {
        // Error.
        Console.WriteLine(e.ToString());
      }

      // Display and wait.
      Console.ReadLine();
    }
  }
}
// </Snippet1>
