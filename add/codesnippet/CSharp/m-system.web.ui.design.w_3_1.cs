        // Generate the design-time markup.
        public override string GetDesignTimeHtml()
        {
            // Make the control more visible in the designer.  If the border 
            // style is None or NotSet, change the border to a blue dashed line. 
            MyLoginStatus myLoginStatusCtl = (MyLoginStatus)ViewControl;
            string markup = null;

            // Check if the border style should be changed.
            if (myLoginStatusCtl.BorderStyle == BorderStyle.NotSet ||
                myLoginStatusCtl.BorderStyle == BorderStyle.None)
            {
                BorderStyle oldBorderStyle = myLoginStatusCtl.BorderStyle;
                Color oldBorderColor = myLoginStatusCtl.BorderColor;

                // Set the design time properties and catch any exceptions.
                try
                {
                    myLoginStatusCtl.BorderStyle = BorderStyle.Dashed;
                    myLoginStatusCtl.BorderColor = Color.Blue;

                    // Call the base method to generate the markup.
                    markup = base.GetDesignTimeHtml();
                }
                catch (Exception ex)
                {
                    markup = GetErrorDesignTimeHtml(ex);
                }
                finally
                {
                    // It is not necessary to restore the border properties 
                    // to their original values because the ViewControl 
                    // was used to reference the associated control and the 
                    // UsePreviewControl was not overridden.  

                    // myLoginCtl.BorderStyle = oldBorderStyle;
                    // myLoginCtl.BorderColor = oldBorderColor;
                }
            }
            else
                // Call the base method to generate the markup.
                markup = base.GetDesignTimeHtml();

            return markup;

        } // GetDesignTimeHtml