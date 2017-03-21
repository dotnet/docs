        [ConfigurationProperty("maxAttempts", DefaultValue = 101,
            IsRequired = true)]
        [IntegerValidator(MinValue = 1, MaxValue = 100,
            ExcludeRange = true)]
        public int MaxAttempts
        {
            get
            {
                return (int)this["maxAttempts"];
            }
            set
            {
                this["maxAttempts"] = value;
            }
        }