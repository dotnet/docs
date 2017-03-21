        public override SecurityElement ToXml()
        {
            // Use the SecurityElement class to encode the permission to XML.
            SecurityElement esd = new SecurityElement("IPermission");
            String name = typeof( NameIdPermission).AssemblyQualifiedName;
            esd.AddAttribute("class", name);
            esd.AddAttribute("version", "1.0");

            // The following code for unrestricted permission is only included as an example for
            // permissions that allow the unrestricted state. It is of no value for this permission.
            if (m_Unrestricted)
            {
                esd.AddAttribute("Unrestricted", true.ToString());
            }
            if (m_Name != null) esd.AddAttribute( "Name", m_Name );
            return esd;
        }