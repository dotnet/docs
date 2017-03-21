        private ListItemCollection items = null;

        // Associate the ListItemsCollectionEditor with the ListItems. 
        [EditorAttribute(typeof(System.Web.UI.Design.WebControls.
           ListItemsCollectionEditor),
           typeof(UITypeEditor))]
        public ListItemCollection ListItems
        {
            get { return items; }
        } // ListItems