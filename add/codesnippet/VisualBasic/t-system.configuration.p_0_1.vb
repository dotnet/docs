        ' Create EllementInformation object.
        Dim elementInfo As ElementInformation = _
        configSection.ElementInformation()
        ' Create a PropertyInformationCollection object.
        Dim propertyInfoCollection As PropertyInformationCollection = _
        elementInfo.Properties()
        ' Create a PropertyInformation object.
        Dim myPropertyInfo As PropertyInformation = _
          propertyInfoCollection("enabled")
        ' Display the property value.
        Console.WriteLine _
          ("anonymousIdentification Section - Enabled: {0}", _
          myPropertyInfo.Value)