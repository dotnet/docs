        private TableRowCollection rows = null;

        // Associate the TableRowsCollectionEditor with the TestRows. 
        [EditorAttribute(typeof(System.Web.UI.Design.WebControls.
           TableRowsCollectionEditor),
           typeof(UITypeEditor))]
        public TableRowCollection TestRows
        {
            get { return rows; }
        } // TestRows