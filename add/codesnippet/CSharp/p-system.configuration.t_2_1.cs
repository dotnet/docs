        [ConfigurationProperty("maxIdleTime",
            DefaultValue = "0:10:0",
            IsRequired = false)]
        [TimeSpanValidator(MinValueString = "0:0:30",
            MaxValueString = "5:00:0",
            ExcludeRange = false)]
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