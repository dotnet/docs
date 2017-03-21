    // Populate the permission's fields from XML.
    public override void FromXml(SecurityElement e)
    {
        m_specifiedAsUnrestricted = false;
        m_flags = 0;

        // If XML indicates an unrestricted permission, make this permission unrestricted.
        String s = (String)e.Attributes["Unrestricted"];
        if (s != null)
        {
            m_specifiedAsUnrestricted = Convert.ToBoolean(s);
            if (m_specifiedAsUnrestricted)
                m_flags = SoundPermissionState.PlayAnySound;
        }

        // If XML indicates a restricted permission, parse the flags.
        if (!m_specifiedAsUnrestricted)
        {
            s = (String)e.Attributes["Flags"];
            if (s != null)
            {
                m_flags = (SoundPermissionState)
                Convert.ToInt32(Enum.Parse(typeof(SoundPermission), s, true));
            }
        }
    }