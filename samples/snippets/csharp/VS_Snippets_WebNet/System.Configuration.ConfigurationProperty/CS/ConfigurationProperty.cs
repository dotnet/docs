// <Snippet1>
using System;
using System.Configuration;
using System.Collections;
using System.ComponentModel;

namespace ConfigurationPropertyExample
{
    // Define a custom section.
    // Shows how to use the ConfigurationProperty
    // class when defining a custom section.
    public sealed class CustomSection : ConfigurationSection
    {
        // The collection (property bag) that contains 
        // the section properties.
        private static ConfigurationPropertyCollection _Properties;

        // The FileName property.
        private static ConfigurationProperty _FileName;

        // The Alias property.
        private static ConfigurationProperty _Alias;

        // The MaxUsers property.
        private static ConfigurationProperty _MaxUsers;

        // The MaxIdleTime property.
        private static ConfigurationProperty _MaxIdleTime;

        // CustomSection constructor.
        static CustomSection()
        {
            // <Snippet2>
            // Initialize the _FileName property
            _FileName =
                new ConfigurationProperty("fileName",
                typeof(string), "default.txt");
            // </Snippet2>

            // <Snippet3>
            // Initialize the _MaxUsers property
            _MaxUsers =
                new ConfigurationProperty("maxUsers",
                typeof(long), (long)1000,
                ConfigurationPropertyOptions.None);
            // </Snippet3>

            // <Snippet4>
            // Initialize the _MaxIdleTime property
            TimeSpan minTime = TimeSpan.FromSeconds(30);
            TimeSpan maxTime = TimeSpan.FromMinutes(5);

            ConfigurationValidatorBase _TimeSpanValidator =
                new TimeSpanValidator(minTime, maxTime, false);

            _MaxIdleTime =
                new ConfigurationProperty("maxIdleTime",
                typeof(TimeSpan), TimeSpan.FromMinutes(5),
                TypeDescriptor.GetConverter(typeof(TimeSpan)),
                _TimeSpanValidator,
                ConfigurationPropertyOptions.IsRequired,
                "[Description:This is the max idle time.]");
            // </Snippet4>

            // Initialize the _Alias property
            _Alias =
                new ConfigurationProperty("alias",
                typeof(string), "alias.txt");

            // Initialize the Property collection.
            _Properties = new ConfigurationPropertyCollection();
            _Properties.Add(_FileName);
            _Properties.Add(_Alias);
            _Properties.Add(_MaxUsers);
            _Properties.Add(_MaxIdleTime);
        }

        // Return the initialized property bag
        // for the configuration element.
        protected override ConfigurationPropertyCollection Properties
        {
            get
            {
                return _Properties;
            }
        }

        // Clear the property.
        public void ClearCollection()
        {
            Properties.Clear();
        }

        // Remove an element from the property collection.
        public void RemoveCollectionElement(string elName)
        {
            Properties.Remove(elName);
        }

        // Get the property collection enumerator.
        public IEnumerator GetCollectionEnumerator()
        {
            return (Properties.GetEnumerator());
        }

        [StringValidator(InvalidCharacters = " ~!@#$%^&*()[]{}/;'\"|\\",
            MinLength = 1, MaxLength = 60)]
        public string FileName
        {
            get
            {
                return (string)this["fileName"];
            }
            set
            {
                this["fileName"] = value;
            }
        }

        [StringValidator(InvalidCharacters = " ~!@#$%^&*()[]{}/;'\"|\\",
            MinLength = 1, MaxLength = 60)]
        public string Alias
        {
            get
            {
                return (string)this["alias"];
            }
            set
            {
                this["alias"] = value;
            }
        }

        [LongValidator(MinValue = 1, MaxValue = 1000000,
            ExcludeRange = false)]
        public long MaxUsers
        {
            get
            {
                return (long)this["maxUsers"];
            }
            set
            {
                this["maxUsers"] = value;
            }
        }

        public TimeSpan MaxIdleTime
        {
            get
            {
                return (TimeSpan)this["maxIdleTime"];
            }
            set
            {
                this["maxIdleTime"] = value;
            }
        }
    }
}
// </Snippet1>

//More sample code.
namespace ConfigurationPropertyExample
{
    public sealed class TestingCustomSection
    {
        // <Snippet30>
        // Define a custom section programmatically.
        static void CreateSection()
        {
            try
            {
                CustomSection customSection;

                // Get the current configuration file.
                System.Configuration.Configuration config =
                        ConfigurationManager.OpenExeConfiguration(
                        ConfigurationUserLevel.None);

                // Create the section entry  
                // in the <configSections> and the 
                // related target section in <configuration>.
                // Call it "CustomSection2" since the file in this 
                // example already has "CustomSection".
                if (config.Sections["CustomSection"] == null)
                {
                    customSection = new CustomSection();
                    config.Sections.Add("CustomSection2", customSection);
                    customSection.SectionInformation.ForceSave = true;
                    config.Save(ConfigurationSaveMode.Full);
                }
            }
            catch (ConfigurationErrorsException err)
            {
                Console.WriteLine(err.ToString());
            }
        }
        // </Snippet30>

        // Get the property characteristics.
        // Shows how to use the property.
        static void GetPropertyCharacteristics()
        {
            // Initialize the MaxIdleTime property.
            ConfigurationProperty _MaxIdleTime;
            TimeSpan minTime = TimeSpan.FromSeconds(30);
            TimeSpan maxTime = TimeSpan.FromMinutes(5);
            ConfigurationValidatorBase _TimeSpanValidator =
                new TimeSpanValidator(minTime, maxTime, false);

            _MaxIdleTime =
                new ConfigurationProperty("maxIdleTime",
                typeof(TimeSpan), TimeSpan.FromMinutes(5),
                TypeDescriptor.GetConverter(typeof(TimeSpan)),
                _TimeSpanValidator,
                ConfigurationPropertyOptions.IsRequired,
                "[Description:This is the max idle time.]");

            Console.WriteLine("[Display MaxIdleTime properties]");

            // <Snippet5>
            string converter = _MaxIdleTime.Converter.ToString();
            Console.WriteLine("MaxIdleTime coverter: {0}", converter);
            // </Snippet5>

            // <Snippet6>
            string defaultValue = _MaxIdleTime.DefaultValue.ToString();
            Console.WriteLine("MaxIdleTime default value: {0}",
                              defaultValue);
            // </Snippet6>

            // <Snippet7>
            string isKey = _MaxIdleTime.IsKey.ToString();
            Console.WriteLine("MaxIdleTime is key: {0}", isKey);
            // </Snippet7>

            // <Snippet8>
            string isRequired = _MaxIdleTime.IsRequired.ToString();
            Console.WriteLine("MaxIdleTime is required: {0}", isRequired);
            // </Snippet8>

            // <Snippet9>
            string name = _MaxIdleTime.Name;
            Console.WriteLine("MaxIdleTime name: {0}", name);
            // </Snippet9>

            // <Snippet10>
            string type = _MaxIdleTime.Type.ToString();
            Console.WriteLine("MaxIdleTime type: {0}", type);
            // </Snippet10>

            // <Snippet11>
            string description = _MaxIdleTime.Description;
            Console.WriteLine("MaxIdleTime description: {0}", description);
            // </Snippet11>

            // <Snippet12>
            string validator = _MaxIdleTime.Validator.ToString();
            Console.WriteLine("MaxIdleTime validator: {0}", validator);
            // </Snippet12>

        }

        public static void Main(string[] args)
        {
            Console.WriteLine("[Create a custom section]");
            CreateSection();
            Console.WriteLine("[Read section characteristics]");
            GetPropertyCharacteristics();
            Console.ReadLine();
        }

    }
}