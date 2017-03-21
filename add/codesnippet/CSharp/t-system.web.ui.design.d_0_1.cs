        // Associates the DataFieldConverter with a string property.
        [TypeConverterAttribute(typeof(DataMemberConverter))]
        public string dataField
        {
            get
            {
                return field;
            }
            set
            {
                field = value;
            }
        }
        private string field;