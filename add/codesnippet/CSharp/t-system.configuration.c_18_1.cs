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
            // Initialize the _FileName property
            _FileName =
                new ConfigurationProperty("fileName",
                typeof(string), "default.txt");

            // Initialize the _MaxUsers property
            _MaxUsers =
                new ConfigurationProperty("maxUsers",
                typeof(long), (long)1000,
                ConfigurationPropertyOptions.None);

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