        private ParameterCollection selectParams;

        // Associate the ParameterCollectionEditor with the SelectParameters. 
        [Editor(typeof(System.Web.UI.Design.WebControls.
            ParameterCollectionEditor),
            typeof(UITypeEditor))]
        public ParameterCollection SelectParameters
        {
            get
            {
                // If there is no selectParams collection, create it.
                if (selectParams == null)
                    selectParams = new ParameterCollection();

                return selectParams;
            }
            set { selectParams = value; }
        } // SelectParameters