    // Produce XML from the permission's fields.
    public override SecurityElement ToXml()
    {
        // These first three lines create an element with the required format.
        SecurityElement e = new SecurityElement("IPermission");
        // Replace the double quotation marks (��) with single quotation marks (��)
        // to remain XML compliant when the culture is not neutral.
        e.AddAttribute("class", GetType().AssemblyQualifiedName.Replace('\"', '\''));
        e.AddAttribute("version", "1");

        if (!m_specifiedAsUnrestricted)
            e.AddAttribute("Flags", Enum.Format(typeof(SoundPermissionState), m_flags, "G"));
        else
            e.AddAttribute("Unrestricted", "true");
        return e;
    }