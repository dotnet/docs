        // Create the markup to display the control on the design surface. 
        public override string GetDesignTimeHtml()
        {
            string designTimeMarkup = null;

            // Create variables to access the control
            // item collection and back color.
            ListItemCollection items = simpleRadioButtonList.Items;
            Color oldBackColor = simpleRadioButtonList.BackColor;

            // Check the property values and render the markup
            // on the design surface accordingly.
            try
            {
                if (oldBackColor == Color.Empty)
                    simpleRadioButtonList.BackColor = Color.Gainsboro;

                if (changedDataSource)
                    items.Add("Updated to a new data source: " + 
                        DataSource + ".");

                // Call the base method to generate the markup.
                designTimeMarkup = base.GetDesignTimeHtml();
            }
            catch (Exception ex)
            {
                // Catch any exceptions that occur.
                designTimeMarkup = GetErrorDesignTimeHtml(ex);
            }
            finally
            {
                // Set the properties back to their original state.
                simpleRadioButtonList.BackColor = oldBackColor;
                items.Clear();
            }

            return designTimeMarkup;
        } // GetDesignTimeHtml