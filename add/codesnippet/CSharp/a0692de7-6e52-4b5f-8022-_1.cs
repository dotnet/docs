            // Initialize the _MaxUsers property
            _MaxUsers =
                new ConfigurationProperty("maxUsers",
                typeof(long), (long)1000,
                ConfigurationPropertyOptions.None);