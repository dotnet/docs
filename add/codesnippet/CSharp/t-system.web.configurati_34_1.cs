        // Get the Web application configuration.
        System.Configuration.Configuration configuration =
            WebConfigurationManager.OpenWebConfiguration("/aspnetTest");

        // Get the external JSON section.
        ScriptingJsonSerializationSection jsonSection =
            (ScriptingJsonSerializationSection)configuration.GetSection(
            "system.web.extensions/scripting/webServices/jsonSerialization");

        //Get the converters collection.
        ConvertersCollection converters =
            jsonSection.Converters;

        if ((converters != null) && converters.Count > 0)
        {
            // Get the first registered converter.
            Converter converterElement = converters[0];
        }