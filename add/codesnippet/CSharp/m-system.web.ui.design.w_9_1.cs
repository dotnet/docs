        // Generate the design-time markup.
        public override string GetDesignTimeHtml()
        {
            // Make the control more visible in the designer.  If the border 
            // style is None or NotSet, change the border to an orange dotted line. 
            MyMenu myMenuCtl = (MyMenu)ViewControl;
            string markup = null;

            // Check if the border style should be changed.
            if (myMenuCtl.BorderStyle == BorderStyle.NotSet ||
                myMenuCtl.BorderStyle == BorderStyle.None)
            {
                BorderStyle oldBorderStyle = myMenuCtl.BorderStyle;
                Color oldBorderColor = myMenuCtl.BorderColor;

                // Set the design-time properties and catch any exceptions.
                try
                {
                    myMenuCtl.BorderStyle = BorderStyle.Dotted;
                    myMenuCtl.BorderColor = Color.FromArgb(0xFF7F00);

                    // Call the base method to generate the markup.
                    markup = base.GetDesignTimeHtml();
                }
                catch (Exception ex)
                {
                    markup = GetErrorDesignTimeHtml(ex);
                }
                finally
                {
                    // Restore the properties to their original settings.
                    myMenuCtl.BorderStyle = oldBorderStyle;
                    myMenuCtl.BorderColor = oldBorderColor;
                }
            }
            else
                // Call the base method to generate the markup.
                markup = base.GetDesignTimeHtml();

            return markup;

        } // GetDesignTimeHtml