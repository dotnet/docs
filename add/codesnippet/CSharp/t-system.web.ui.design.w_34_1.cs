        private TableCellCollection cells = null;

        // Associate the TableCellsCollectionEditor with the TestCells. 
        [EditorAttribute(typeof(System.Web.UI.Design.WebControls.
            TableCellsCollectionEditor),
            typeof(UITypeEditor))]
        public TableCellCollection TestCells
        {
            get { return cells; }
        } // TestCells