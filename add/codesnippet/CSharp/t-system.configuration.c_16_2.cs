
    // Define a custom section.
    public sealed class CustomSection :
        ConfigurationSection
    {

        public CustomSection() 
        {
           
        }

        [ConfigurationProperty("fileName", DefaultValue="   default.txt  ")]
        [TypeConverter(typeof(WhiteSpaceTrimStringConverter))]
        public String FileName
        {
            get
            {
                return (String)this["fileName"];
            }
            set
            {
                this["fileName"] = value;
            }
        }

        [ConfigurationProperty("maxIdleTime")]
        [TypeConverter(typeof(CustomizedTimeSpanMinutesConverter))]
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

        [ConfigurationProperty("timeDelay", 
            DefaultValue = "infinite")]
        [TypeConverter(typeof(InfiniteTimeSpanConverter))]
        public TimeSpan TimeDelay
        {
            get
            {
                return (TimeSpan)this["timeDelay"];
            }
            set
            {
                this["timeDelay"] = value;
            }
        }

        [ConfigurationProperty("cdStr", 
            DefaultValue = "str0, str1",
           IsRequired = true)]

        [TypeConverter(typeof(
            CommaDelimitedStringCollectionConverter))]
        public StringCollection CdStr
        {
            get
            {
                return (StringCollection)this["cdStr"];
            }

            set
            {
                this["cdStr"] = value;
            }
   
        }



        public enum Permissions
        {
            FullControl         = 0,
            Modify              = 1,
            ReadExecute         = 2,
            Read                = 3,
            Write               = 4,
            SpecialPermissions  = 5
        }

        [ConfigurationProperty("permission", DefaultValue = Permissions.Read)]
        public Permissions Permission
        {
            get
            {
                return (Permissions)this["permission"];
            }

            set
            {
                this["permission"] = value;
            }

        }

        
        [ConfigurationProperty("maxUsers", DefaultValue="infinite")]
        [TypeConverter(typeof(InfiniteIntConverter))]
        public int MaxUsers
        {
            get
            {
                return (int)this["maxUsers"];
            }
            set
            {
                this["maxUsers"] = value;
            }
        }

    }

}