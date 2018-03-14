//<Snippet1>
using System;
using System.Configuration;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Reflection;

namespace Samples.AspNet
{
    // Define a custom configuration.
    public class CustomConfiguration
    {

   

        public CustomConfiguration()
        {
            
        }


        // Define a custom section.
        public class CustomSection : ConfigurationSection
        {

            const string configString = "aString";

            const string configInteger = "anInteger";

            const string configTimeout = "aTimeout";

            
            [ConfigurationProperty(CustomSection.configString,

                DefaultValue = "default")]

            public string aString
            {

                get { return (string)base[CustomSection.configString]; }

                set { base[CustomSection.configString] = value; }

            }



            [ConfigurationProperty(CustomSection.configInteger,

                DefaultValue = 1)]

            public int anInteger
            {

                get { return (int)base[CustomSection.configInteger]; }

                set { base[CustomSection.configInteger] = value; }

            }



            [ConfigurationProperty(CustomSection.configTimeout)]

            public TimeSpan aTimeout
            {

                get { return (TimeSpan)base[CustomSection.configTimeout]; }

                set { base[CustomSection.configTimeout] = value; }

            }

        }


        // Create a custom section and save it in the
        // application configuration file.
        public void CreateCustomSection()
        {

            Configuration config =
                WebConfigurationManager.OpenWebConfiguration("/ConfigSite");

            CustomSection section =
                config.Sections["CustomSection"] as CustomSection;

            if (section == null)
            {

                // Create section and add it to the configuration.
                section = new CustomSection();
                config.Sections.Add("CustomSection", section);

            }

            // Assign configuration settings.
            section.aTimeout = 
                TimeSpan.FromSeconds(DateTime.Now.Second);

            section.anInteger = 1500;

            section.aString = "Hello World";


            // Save the changes.

            config.Save();

        }

        // Get the custom section stored in 
        // the configuration file.
        public string GetCustomSection()
        {


            Configuration config =
                WebConfigurationManager.OpenWebConfiguration("/ConfigSite");

            
            CustomSection section =
                config.Sections["CustomSection"] as CustomSection;


            string currentSection = string.Empty;

            if (section != null)
            {
                currentSection = HttpContext.Current.Server.HtmlEncode(
                    section.SectionInformation.GetRawXml());     
                
            }
            else
                currentSection = "CustomSection does not exist";

            return currentSection;
        }
    }

}
//</Snippet1>