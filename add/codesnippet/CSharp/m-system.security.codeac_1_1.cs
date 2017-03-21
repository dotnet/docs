       public override void FromXml(SecurityElement e)
        {
            // The following code for unrestricted permission is only included as an example for
            // permissions that allow the unrestricted state. It is of no value for this permission.
            String elUnrestricted = e.Attribute("Unrestricted");
            if (null != elUnrestricted)
            {
                m_Unrestricted = bool.Parse(elUnrestricted);
                return;
            }

            String elName = e.Attribute( "Name" );
            m_Name = elName == null ? null : elName;
        }