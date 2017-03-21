
        public enum Permissions
        {
            FullControl         = 0,
            Modify              = 1,
            ReadExecute         = 2,
            Read                = 3,
            Write               = 4,
            SpecialPermissions  = 5
        }

        [ConfigurationProperty("permission", DefaultValue = Permissions.Read)]
        public Permissions Permission
        {
            get
            {
                return (Permissions)this["permission"];
            }

            set
            {
                this["permission"] = value;
            }

        }