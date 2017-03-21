    // A design-time data source view
    public class CustomDesignDataSourceView : DesignerDataSourceView
    {
        private ArrayList _data = null;

        public CustomDesignDataSourceView(
            CustomDataSourceDesigner owner, string viewName)
            : base(owner, viewName)
        {}

        // Get data for design-time display
        public override IEnumerable GetDesignTimeData(
            int minimumRows, out bool isSampleData)
        {
            if (_data == null)
            {
                // Create a set of design-time fake data
                _data = new ArrayList();
                for (int i = 1; i <= minimumRows; i++)
                {
                    _data.Add(new BookItem("ID_" + i.ToString(),
                        "Design-Time Title 0" + i.ToString()));
                }
            }
            isSampleData = true;
            return _data as IEnumerable;
        }

        public override IDataSourceViewSchema Schema
        {
            get { return new BookListViewSchema(); }
        }

        // Allow getting the record count
        public override bool CanRetrieveTotalRowCount
        {
            get { return true; }
        }
        // Do not allow deletions
        public override bool CanDelete
        {
            get { return false; }
        }
        // Do not allow insertions
        public override bool CanInsert
        {
            get { return false; }
        }
        // Do not allow updates
        public override bool CanUpdate
        {
            get { return false; }
        }
        // Do not allow paging
        public override bool CanPage
        {
            get { return false; }
        }
        // Do not allow sorting
        public override bool CanSort
        {
            get { return false; }
        }
    }