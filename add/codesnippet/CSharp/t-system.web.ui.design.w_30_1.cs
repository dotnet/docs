        private MenuItemBindingCollection localBindings;

        // Associate the MenuBindingsEditor with the DataBindings. 
        [Editor(typeof(System.Web.UI.Design.WebControls.MenuBindingsEditor),
            typeof(UITypeEditor))]
        public MenuItemBindingCollection DataBindings
        {
            get { return localBindings; }
            set { localBindings = value; }
        } // DataBindings