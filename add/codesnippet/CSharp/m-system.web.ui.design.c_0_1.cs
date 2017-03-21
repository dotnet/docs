        // Generate the design-time markup for the control when an error occurs.
        protected override string GetErrorDesignTimeHtml(Exception e) 
        {
            // Write the error message text in red, bold.
            string errorRendering =
                "<span style=\"font-weight:bold; color:Red; \">" +
                e.Message + "</span>";

            return CreatePlaceHolderDesignTimeHtml(errorRendering);
        } // GetErrorDesignTimeHtml