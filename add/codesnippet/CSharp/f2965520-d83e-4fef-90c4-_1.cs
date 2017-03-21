        // Generate the design-time markup.
        public override string GetDesignTimeHtml(DesignerRegionCollection regions)
        {
            // Make the control more visible in the designer.   
            // Enclose the markup in a table with an orange border. 
            const string openTableMarkup =
                "<table><tr><td style=\"border:4 solid #FF7F00;\">";
            const string closeTableMarkup = "</td></tr></table>";

            // Call the base method to generate the markup.
            string markup = base.GetDesignTimeHtml(regions);

            return openTableMarkup + markup + closeTableMarkup;

        } // GetDesignTimeHtml