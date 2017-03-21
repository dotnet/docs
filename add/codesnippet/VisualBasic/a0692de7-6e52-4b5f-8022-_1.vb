        ' Initialize the _MaxUsers property
        _MaxUsers = New ConfigurationProperty( _
            "maxUsers", GetType(Long), 1000L, _
            ConfigurationPropertyOptions.None)