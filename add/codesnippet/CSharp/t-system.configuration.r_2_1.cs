        [ConfigurationProperty("alias2", DefaultValue = "alias.txt",
            IsRequired = true, IsKey = false)]
        [RegexStringValidator(@"\w+\S*")]
        public string Alias2
        {
            get
            {
                return (string)this["alias2"];
            }
            set
            {
                this["alias2"] = value;
            }
        }