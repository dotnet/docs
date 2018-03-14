// SimpleRadioButtonListDesigner.cs
// <snippet1>
using System;
using System.ComponentModel;
using System.Drawing;
using System.Diagnostics;
using System.Web.UI.WebControls;
using System.Web.UI.Design.WebControls;

namespace Examples.CS.WebControls.Design
{
    // Create the SimpleRadioButtonListDesigner, which provides
    // design-time support for a custom list class.
    public class SimpleRadioButtonListDesigner : ListControlDesigner
    {
        SimpleRadioButtonList simpleRadioButtonList;
        bool changedDataSource;

        // <snippet2>
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
        // </snippet2>

        // <snippet3>
        public override void Initialize(IComponent component)
        {
            // Ensure that only a SimpleRadioButtonList can be 
            // created in this designer.
            Debug.Assert( 
                component is SimpleRadioButtonList, 
                "An invalid SimpleRadioButtonList control was initialized.");

            simpleRadioButtonList = (SimpleRadioButtonList)component;
            base.Initialize(component);
        } // Initialize
        // </snippet3>

        // <snippet4>
        // If the data source changes, set a boolean variable.
        public override void OnDataSourceChanged()
        {
            changedDataSource = true;
        } // OnDataSourceChanged
        // </snippet4>
    } // SimpleRadioButtonListDesigner
} // Examples.CS.WebControls.Design
// </snippet1>

