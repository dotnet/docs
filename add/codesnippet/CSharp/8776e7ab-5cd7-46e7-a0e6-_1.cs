        // Generate the design-time markup for the control when an error occurs.
        protected override string GetErrorDesignTimeHtml(Exception ex) 
        {
            // Write the error message text in red, bold.
            string errorRendering =
                "<span style=\"font-weight:bold; color:Red; \">" +
                ex.Message + "</span>";

            return CreatePlaceHolderDesignTimeHtml(errorRendering);
        } // GetErrorDesignTimeHtml