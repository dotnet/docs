        // Generate the design-time markup.
        const string capTag = "caption";
        const string trOpen = "tr><td colspan=2 align=center";
        const string trClose = "td></tr";

        public override string GetDesignTimeHtml()
        {
            // Make the full extent of the control more visible in the designer.
            // If the border style is None or NotSet, change the border to
            // a wide, blue, dashed line. Include the caption within the border.
            MyDetailsView myDV = (MyDetailsView)Component;
            string markup = null;
            int charX;

            // Check if the border style should be changed.
            if (myDV.BorderStyle == BorderStyle.NotSet ||
                myDV.BorderStyle == BorderStyle.None)
            {
                BorderStyle oldBorderStyle = myDV.BorderStyle;
                Unit oldBorderWidth = myDV.BorderWidth;
                Color oldBorderColor = myDV.BorderColor;

                // Set design-time properties and catch any exceptions.
                try
                {
                    myDV.BorderStyle = BorderStyle.Dashed;
                    myDV.BorderWidth = Unit.Pixel(3);
                    myDV.BorderColor = Color.Blue;

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
                    myDV.BorderStyle = oldBorderStyle;
                    myDV.BorderWidth = oldBorderWidth;
                    myDV.BorderColor = oldBorderColor;
                }
            }
            else
                // Call the base method to generate the markup.
                markup = base.GetDesignTimeHtml();

            // Look for a <caption> tag.
            if ((charX = markup.IndexOf(capTag)) > 0)
            {
                // Replace the first caption with 
                // "tr><td colspan=2 align=center".
                markup = markup.Remove(charX,
                    capTag.Length).Insert(charX, trOpen);

                // Replace the second caption with "td></tr".
                if ((charX = markup.IndexOf(capTag, charX)) > 0)
                    markup = markup.Remove(charX,
                        capTag.Length).Insert(charX, trClose); 
            }
            return markup;

        } // GetDesignTimeHtml