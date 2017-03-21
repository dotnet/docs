    [
    ToolboxData("<{0}:MyCustomHierarchicalControl runat=server> </{0}:MyCustomHierarchicalControl>")
    ] 
    public class MyCustomHierarchicalControl : TreeView 
	{        
        private object _dataSource;

        [TypeConverter(typeof(HierarchicalDataSourceConverter))]
        public override object DataSource
        {
            get
            {
                return _dataSource;
            }
            set
            {
                if (value != null) 
                {
                    ValidateDataSource(value);
                }
                _dataSource = value;
                OnDataPropertyChanged();
            }
        }

        // Define rest of custom control implementation.
        // ...

	}