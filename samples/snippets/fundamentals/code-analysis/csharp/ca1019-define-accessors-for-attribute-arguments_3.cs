        [GoodCustomAttribute("ThisIsSomeMandatoryData", OptionalData = "ThisIsSomeOptionalData")]
        public string MyProperty
        {
            get { return myProperty; }
            set { myProperty = value; }
        }

        [GoodCustomAttribute("ThisIsSomeMoreMandatoryData")]
        public string MyOtherProperty
        {
            get { return myOtherProperty; }
            set { myOtherProperty = value; }
        }