    // Derive the CustomHyperLinkDesigner from the HyperLinkDesigner.
    public class CustomHyperLinkDesigner : HyperLinkDesigner
    {
        // Override the GetDesignTimeHtml to set the CustomHyperLink Text 
        // property so that it displays at design time.
        public override string GetDesignTimeHtml()
        {
            CustomHyperLink hype = (CustomHyperLink)Component;
            string designTimeMarkup = null;

            // Save the original Text and note if it is empty.
            string text = hype.Text;
            bool noText = (text.Trim().Length == 0);

            try
            {
                // If the Text is empty, supply a default value.
                if (noText)
                    hype.Text = "Click here.";

                // Call the base method to generate the markup.
                designTimeMarkup = base.GetDesignTimeHtml();
            }
            catch (Exception ex)
            {
                // If an error occurs, generate the markup for an error message.
                designTimeMarkup = GetErrorDesignTimeHtml(ex);
            }
            finally
            {
                // Restore the original value of the Text, if necessary.
                if (noText)
                    hype.Text = text;
            }

            // If the markup is empty, generate the markup for a placeholder.
            if(designTimeMarkup == null || designTimeMarkup.Length == 0)
                designTimeMarkup = GetEmptyDesignTimeHtml();

            return designTimeMarkup;
        } // GetDesignTimeHtml
    } // CustomHyperLinkDesigner