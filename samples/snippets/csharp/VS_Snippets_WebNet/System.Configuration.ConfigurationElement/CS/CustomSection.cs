// File name: CustomSection.cs
// Allowed snippet tags range: [71 - 79].

//<Snippet71>
using System;
using System.Configuration;
using System.Collections;


namespace Samples.AspNet
{
    // Define a custom section containing an individual
    // element and a collection of elements.
    public class UrlsSection : ConfigurationSection
    {
        // <Snippet72>
        [ConfigurationProperty("name", 
            DefaultValue = "MyFavorites",
            IsRequired = true, 
            IsKey = false)]
        [StringValidator(InvalidCharacters = 
            " ~!@#$%^&*()[]{}/;'\"|\\",
            MinLength = 1, MaxLength = 60)]
        public string Name
        {

            get
            {
                return (string)this["name"];
            }
            set
            {
                this["name"] = value;
            }

        }
        // </Snippet72>

        // Declare an element (not in a collection) of the type
        // UrlConfigElement. In the configuration
        // file it corresponds to <simple .... />.
        [ConfigurationProperty("simple")]
        public UrlConfigElement Simple
        {
            get
            {
                UrlConfigElement url =
                (UrlConfigElement)base["simple"];
                return url;
            }
        }

        // Declare a collection element represented 
        // in the configuration file by the sub-section
        // <urls> <add .../> </urls> 
        // Note: the "IsDefaultCollection = false" 
        // instructs the .NET Framework to build a nested 
        // section like <urls> ...</urls>.
        [ConfigurationProperty("urls",
            IsDefaultCollection = false)]
        public UrlsCollection Urls
        {
            get
            {
                UrlsCollection urlsCollection =
                (UrlsCollection)base["urls"];
                return urlsCollection;
            }
        }


        //<Snippet73>
        protected override void DeserializeSection(
            System.Xml.XmlReader reader)
        {
            base.DeserializeSection(reader);
            // You can add custom processing code here.
        }
        //</Snippet73>

        //<Snippet74>
        protected override string SerializeSection(
            ConfigurationElement parentElement,
            string name, ConfigurationSaveMode saveMode)
        {
            string s =
                base.SerializeSection(parentElement,
                name, saveMode);
            // You can add custom processing code here.
            return s;
        }
        //</Snippet74>

    }
}
//</Snippet71>
