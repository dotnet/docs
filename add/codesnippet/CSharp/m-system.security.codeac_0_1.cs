        public override IPermission Copy()
        {
            string name = m_Name;
            return new  NameIdPermission( name );
        }