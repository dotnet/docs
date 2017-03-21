        // Associates the DataMemberConverter with a string property.
        [TypeConverterAttribute(typeof(DataMemberConverter))]
        public string dataMember
        {
            get
            {
                return member;
            }
            set
            {
                member = value;
            }
        }
        private string member;