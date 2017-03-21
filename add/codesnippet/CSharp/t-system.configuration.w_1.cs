        [ConfigurationProperty("fileName", DefaultValue="   default.txt  ")]
        [TypeConverter(typeof(WhiteSpaceTrimStringConverter))]
        public String FileName
        {
            get
            {
                return (String)this["fileName"];
            }
            set
            {
                this["fileName"] = value;
            }
        }