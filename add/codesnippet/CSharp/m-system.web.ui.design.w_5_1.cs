        // Generate the design-time markup.
        public override string GetDesignTimeHtml()
        {
            // Get a reference to the control or a copy of the control.
            MyHiddenField myHF = (MyHiddenField)ViewControl;

            // Create a placeholder that displays the control value.
            string markup = CreatePlaceHolderDesignTimeHtml(
                 "Value: \"" + myHF.Value.ToString() + "\"" );

            return markup;

        } // GetDesignTimeHtml