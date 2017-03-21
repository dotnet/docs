    // Define a custom section.
    // The CustomSection type allows to define a custom section 
    // programmatically.
    public sealed class CustomSection : 
        ConfigurationSection
    {
        // The collection (property bag) that contains 
        // the section properties.
        private static ConfigurationPropertyCollection _Properties;
        
        // Internal flag to disable 
        // property setting.
        private static bool _ReadOnly;

        // The FileName property.
        private static readonly ConfigurationProperty _FileName =
            new ConfigurationProperty("fileName", 
            typeof(string),"default.txt", 
            ConfigurationPropertyOptions.IsRequired);

        // The MaxUsers property.
        private static readonly ConfigurationProperty _MaxUsers =
            new ConfigurationProperty("maxUsers", 
            typeof(long), (long)1000, 
            ConfigurationPropertyOptions.None);
        
        // The MaxIdleTime property.
        private static readonly ConfigurationProperty _MaxIdleTime =
            new ConfigurationProperty("maxIdleTime", 
            typeof(TimeSpan), TimeSpan.FromMinutes(5), 
            ConfigurationPropertyOptions.IsRequired);

        // CustomSection constructor.
        public CustomSection()
        {
            // Property initialization
            _Properties = 
                new ConfigurationPropertyCollection();

            _Properties.Add(_FileName);
            _Properties.Add(_MaxUsers);
            _Properties.Add(_MaxIdleTime);
       }

      
        // This is a key customization. 
        // It returns the initialized property bag.
        protected override ConfigurationPropertyCollection Properties
        {
            get
            {
                return _Properties;
            }
        }


        private new bool IsReadOnly
        {
            get
            {
                return _ReadOnly;
            }
        }

        // Use this to disable property setting.
        private void ThrowIfReadOnly(string propertyName)
        {
            if (IsReadOnly)
                throw new ConfigurationErrorsException(
                    "The property " + propertyName + " is read only.");
        }


        // Customizes the use of CustomSection
        // by setting _ReadOnly to false.
        // Remember you must use it along with ThrowIfReadOnly.
        protected override object GetRuntimeObject()
        {
            // To enable property setting just assign true to
            // the following flag.
            _ReadOnly = true;
            return base.GetRuntimeObject();
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
                // With this you disable the setting.
                // Remember that the _ReadOnly flag must
                // be set to true in the GetRuntimeObject.
                ThrowIfReadOnly("FileName");
                this["fileName"] = value;
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

        [TimeSpanValidator(MinValueString = "0:0:30",
            MaxValueString = "5:00:0",
            ExcludeRange = false)]
        public TimeSpan MaxIdleTime
        {
            get
            {
                return  (TimeSpan)this["maxIdleTime"];
            }
            set
            {
                this["maxIdleTime"] = value;
            }
        }
       
        
    }