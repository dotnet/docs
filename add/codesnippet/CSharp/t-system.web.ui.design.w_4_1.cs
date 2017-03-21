        private MenuItemStyleCollection menuItemStyles;

        // Associate the MenuItemStyleCollectionEditor with the 
        // LevelMenuItemStyles. 
        [Editor(typeof(System.Web.UI.Design.WebControls.
            MenuItemStyleCollectionEditor),
            typeof(UITypeEditor))]
        public MenuItemStyleCollection LevelMenuItemStyles
        {
            get { return menuItemStyles; }
            set { menuItemStyles = value; }
        } // LevelMenuItemStyles