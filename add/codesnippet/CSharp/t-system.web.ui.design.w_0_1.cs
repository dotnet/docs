        private DataGridColumnCollection columns = null;

        // Associate the DataGridColumnCollectionEditor with the TestColumns. 
        [EditorAttribute(typeof(System.Web.UI.Design.WebControls.
           DataGridColumnCollectionEditor),
           typeof(UITypeEditor))]
        public DataGridColumnCollection TestColumns
        {
            get { return columns; }
        } // TestColumns