        [ConfigurationProperty("alias", DefaultValue = "anotherName.txt",
            IsRequired = true, IsKey = false)]
        [StringValidator()]
        public string Alias
        {
            get
            {
                return (string)this["alias"];
            }
            set
            {
                this["alias"] = value;
            }
        }