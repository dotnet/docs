        // The CsvDataSourceView does not currently
        // permit insertion of a new record. You can
        // modify or extend this sample to do so.
        public override bool CanInsert {
            get {
                return false;
            }
        }
        protected override int ExecuteInsert(IDictionary values)
        {
            throw new NotSupportedException();
        }