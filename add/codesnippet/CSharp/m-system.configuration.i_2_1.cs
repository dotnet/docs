        [ConfigurationProperty("maxSize", DefaultValue = 1000,
            IsRequired = true)]
        [IntegerValidator()]
        public int MaxSize
        {
            get
            {
                return (int)this["maxSize"];
            }
            set
            {
                this["maxSize"] = value;
            }
        }