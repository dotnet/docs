        ' Get the Web application configuration.
        Dim configuration As System.Configuration.Configuration = _
            WebConfigurationManager.OpenWebConfiguration("/aspnetTest")

        ' Get the external JSON section.
        Dim jsonSection As ScriptingJsonSerializationSection = _
            CType(configuration.GetSection( _
                "system.web.extensions/scripting/webServices/jsonSerialization"), _
                ScriptingJsonSerializationSection)

        'Get the converters collection.
        Dim converters As ConvertersCollection = _
            jsonSection.Converters

        If Not (converters Is Nothing) AndAlso _
            converters.Count > 0 Then
            ' Get the first registered converter.
            Dim converterElement As Converter = converters(0)
        End If