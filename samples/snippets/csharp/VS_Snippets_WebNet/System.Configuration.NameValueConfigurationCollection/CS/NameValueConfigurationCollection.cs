// <Snippet1>
#region Using directives

using System;
using System.Configuration;
using System.Web.Configuration;
using System.Collections;
using System.Text;

#endregion

namespace Samples.AspNet
{
    class UsingNameValueConfigurationCollection
    {
        static void Main(string[] args)
        {
            try
            {
                // Set the path of the config file.
                // Make sure that you have a Web site on the
                // same server called TestConfig.
                string configPath = "/TestConfig";

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
                // Create a NameValueConfigurationCollection object.
                NameValueConfigurationCollection myNameValConfigCollection =
                  new NameValueConfigurationCollection();
                // </Snippet2>

                // <Snippet3>
                foreach (PropertyInformation propertyItem in
                  configSection.ElementInformation.Properties)
                {
                    // Assign  domain name.
                    if (propertyItem.Name == "domain")
                        propertyItem.Value = "MyDomain";

                    if (propertyItem.Value != null)
                    {
                        // Enable SSL for cookie exchange.
                        if (propertyItem.Name == "cookieRequireSSL")
                            propertyItem.Value = true;

                        NameValueConfigurationElement nameValConfigElement =
                            new NameValueConfigurationElement
                                (propertyItem.Name.ToString(), propertyItem.Value.ToString());

                        // Add a NameValueConfigurationElement
                        // to the collection.
                        myNameValConfigCollection.Add(nameValConfigElement);
                       
                    }
                }
                // </Snippet3>

                // <Snippet4>
                // Count property.
                Console.WriteLine("Collection Count: {0}",
                 myNameValConfigCollection.Count);
                // </Snippet4>

                // <Snippet5>
                // Item property.
                Console.WriteLine("Value of property 'enabled': {0}",
                 myNameValConfigCollection["enabled"].Value);
                // </Snippet5>

                // Display the contents of the collection.
                foreach (NameValueConfigurationElement configItem
                  in myNameValConfigCollection)
                {
                    Console.WriteLine();
                    Console.WriteLine("Configuration Details:");
                    Console.WriteLine("Name: {0}", configItem.Name);
                    Console.WriteLine("Value: {0}", configItem.Value);
                }

                // Assign the domain calue.
                configSection.Domain = myNameValConfigCollection["domain"].Value;
                // Assign the SSL required value.
                if (myNameValConfigCollection["cookieRequireSSL"].Value == "true")
                    configSection.CookieRequireSSL = true;

                // <Snippet6>
                // Remove domain from the collection.
                NameValueConfigurationElement myConfigElement =
                    myNameValConfigCollection["domain"];
                // Remove method.
                myNameValConfigCollection.Remove(myConfigElement);
                // </Snippet6>

                // Save changes to the configuration file.
                // This modifies the Web.config of the TestConfig site.
                config.Save(ConfigurationSaveMode.Minimal, true);

                // <Snippet7>
                // Clear the collection.
                myNameValConfigCollection.Clear();
                // </Snippet7>
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