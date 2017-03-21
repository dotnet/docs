        ' Initialize the _MaxIdleTime property
        Dim minTime As TimeSpan = TimeSpan.FromSeconds(30)
        Dim maxTime As TimeSpan = TimeSpan.FromMinutes(5)
        Dim _TimeSpanValidator = _
            New TimeSpanValidator(minTime, maxTime, False)

        _MaxIdleTime = New ConfigurationProperty( _
            "maxIdleTime", GetType(TimeSpan), _
            TimeSpan.FromMinutes(5), _
            TypeDescriptor.GetConverter(GetType(TimeSpan)), _
            _TimeSpanValidator, _
            ConfigurationPropertyOptions.IsRequired, _
            "[Description:This is the max idle time.]")