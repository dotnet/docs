// CustomHyperLinkDesigner.cs
// <snippet4>
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.Design;
using System.Web.UI.Design.WebControls;
using System.ComponentModel.Design;

namespace Examples.CS.WebControls.Design
{
    // <snippet1>
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
    // </snippet1>

    // <snippet2>
    // Derive a class from the HyperLinkDataBindingHandler. It will 
    // resolve  data binding for the CustomHyperlink at design time.
    public class CustomHyperLinkDataBindingHandler : 
        HyperLinkDataBindingHandler
    {
        // Override the DataBindControl to set property values in  
        // the DataBindingCollection at design time.
        public override void DataBindControl(IDesignerHost designerHost, 
            Control control)
        {
            DataBindingCollection bindings = 
                ((IDataBindingsAccessor)control).DataBindings;
            DataBinding imageBinding = bindings["ImageUrl"];

               // If Text is empty, supply a default value.
            if (!(imageBinding == null))
            {
                CustomHyperLink hype = (CustomHyperLink)control;
                hype.ImageUrl = "Image URL.";
            }

            // Call the base method to bind the control.
            base.DataBindControl(designerHost, control);
        } // DataBindControl
    } // CustomHyperLinkDataBindingHandler
    // </snippet2>
} // Examples.CS.WebControls.Design
// </snippet4>

