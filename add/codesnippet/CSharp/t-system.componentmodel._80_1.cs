        // This property exists only to demonstrate the 
        // PasswordPropertyText attribute. When this control 
        // is attached to a PropertyGrid control, the returned 
        // string will be displayed with obscuring characters
        // such as asterisks. This property has no other effect.
        [Category("Security")]
        [Description("Demonstrates PasswordPropertyTextAttribute.")]
        [PasswordPropertyText(true)]
        public string Password
        {
            get
            {
                return "This is a demo password.";
            }
        }