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