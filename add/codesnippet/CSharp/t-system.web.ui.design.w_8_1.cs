        private SubMenuStyleCollection subMenuStyles;

        // Associate the SubMenuStyleCollectionEditor with the 
        // LevelSubMenuStyles. 
        [Editor(typeof(System.Web.UI.Design.WebControls.
            SubMenuStyleCollectionEditor),
            typeof(UITypeEditor))]
        public SubMenuStyleCollection LevelSubMenuStyles
        {
            get { return subMenuStyles; }
            set { subMenuStyles = value; }
        } // LevelSubMenuStyles