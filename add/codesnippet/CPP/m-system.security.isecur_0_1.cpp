    // Produce XML from the permission's fields.
public:
    virtual SecurityElement^ ToXml() override
    {
        // These first three lines create an element with the required format.
        SecurityElement^ element = gcnew SecurityElement("IPermission");
        // Replace the double quotation marks () 
        // with single quotation marks ()
        // to remain XML compliant when the culture is not neutral.
        element->AddAttribute("class", 
            GetType()->AssemblyQualifiedName->Replace('\"', '\''));
        element->AddAttribute("version", "1");

        if (!specifiedAsUnrestricted)
        {
            element->AddAttribute("Flags", 
                Enum::Format(SoundPermissionState::typeid, stateFlags, "G"));
        }   
        else
        {
            element->AddAttribute("Unrestricted", "true");
        }
        return element;
    }