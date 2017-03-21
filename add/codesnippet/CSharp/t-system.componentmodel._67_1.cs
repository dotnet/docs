        // This property exists only to demonstrate the 
        // DisplayName attribute. When this control 
        // is attached to a PropertyGrid control, the
        // property will be appear as "RenamedProperty"
        // instead of "MisnamedProperty".
        [Description("Demonstrates DisplayNameAttribute.")]
        [DisplayName("RenamedProperty")]
        public bool MisnamedProperty
        {
            get
            {
                return true;
            }
        }