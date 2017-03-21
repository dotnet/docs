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