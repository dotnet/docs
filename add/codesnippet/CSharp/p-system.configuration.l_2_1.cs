        [ConfigurationProperty("maxUsers", DefaultValue = (long)10000,
            IsRequired = false)]
        [LongValidator(MinValue = 1, MaxValue = 10000000,
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