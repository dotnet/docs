        // Associates the DataBindingCollectionConverter 
        // with a DataBindingCollection property.
        [TypeConverterAttribute(typeof(DataBindingCollectionConverter))]
        public DataBindingCollection dataBindings
        {
            get
            {
                return bindings;
            }
            set
            {
                bindings = value;
            }
        }
        private DataBindingCollection bindings;