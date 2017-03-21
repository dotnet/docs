        // Generate the design-time markup for the control 
        // when the template is empty.
        protected override string GetEmptyDesignTimeHtml()
        {
            string noElements = "Contains no menu items.";

            return CreatePlaceHolderDesignTimeHtml(noElements);
        } // GetEmptyDesignTimeHtml