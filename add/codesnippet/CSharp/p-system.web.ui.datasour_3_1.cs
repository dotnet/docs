        // The CsvDataSourceView does not currently
        // permit deletion. You can modify or extend
        // this sample to do so.
        public override bool CanDelete {
            get {
                return false;
            }
        }
        protected override int ExecuteDelete(IDictionary keys, IDictionary values)
        {
            throw new NotSupportedException();
        }