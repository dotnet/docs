        private MenuItemCollection menuItems;

        // Associate the MenuItemCollectionEditor with the Items. 
        [Editor(typeof(System.Web.UI.Design.WebControls.
            MenuItemCollectionEditor),
            typeof(UITypeEditor))]
        public MenuItemCollection Items
        {
            get
            {
                // If there is no menuItems collection, create it.
                if (menuItems == null)
                    menuItems = new MenuItemCollection();

                return menuItems;
            }
            set { menuItems = value; }
        } // Items