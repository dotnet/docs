        // The CsvDataSourceView does not currently
        // permit update operations. You can modify or
        // extend this sample to do so.
        public override bool CanUpdate {
            get {
                return false;
            }
        }
        protected override int ExecuteUpdate(IDictionary keys, IDictionary values, IDictionary oldValues)
        {
            throw new NotSupportedException();
        }