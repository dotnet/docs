    // Populate the permission's fields from XML.
public:
    virtual void FromXml(SecurityElement^ element) override
    {
        specifiedAsUnrestricted = false;
        stateFlags = (SoundPermissionState)0;

        // If XML indicates an unrestricted permission, 
        // make this permission unrestricted.
        String^ attributeString = 
            (String^) element->Attributes["Unrestricted"];
        if (attributeString != nullptr)
        {
            specifiedAsUnrestricted = Convert::ToBoolean(attributeString);
            if (specifiedAsUnrestricted)
            {
                stateFlags = SoundPermissionState::PlayAnySound;
            }
        }

        // If XML indicates a restricted permission, parse the flags.
        if (!specifiedAsUnrestricted)
        {
            attributeString = (String^) element->Attributes["Flags"];
            if (attributeString != nullptr)
            {
                stateFlags = (SoundPermissionState) Convert::ToInt32(
                    Enum::Parse(SoundPermissionState::typeid, 
                    attributeString, true));
            }
        }
    }