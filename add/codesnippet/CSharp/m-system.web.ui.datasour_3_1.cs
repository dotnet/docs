        // Return a strongly typed view for the current data source control.
        private CsvDataSourceView view = null;
        protected override DataSourceView GetView(string viewName) {
            if (null == view) {
                view = new CsvDataSourceView(this, String.Empty);
            }
            return view;
        }