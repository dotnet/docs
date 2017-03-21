        // Associates the DataSourceConverter with an object property.
        [TypeConverterAttribute(typeof(DataSourceConverter))]
        public object dataSource
        {
            get
            {
                return source;
            }
            set
            {
                source = value;
            }
        }
        private object source;