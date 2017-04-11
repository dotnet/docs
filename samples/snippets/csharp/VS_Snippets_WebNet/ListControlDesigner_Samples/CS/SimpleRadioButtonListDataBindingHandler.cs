// <snippet6>
using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Web.UI;
using System.Web.UI.Design.WebControls;

namespace Examples.CS.WebControls.Design
{
    // Derive the SimpleRadioButtonListDataBindingHandler.
    public class SimpleRadioButtonListDataBindingHandler : 
        ListControlDataBindingHandler
    {
        // <snippet7>
        // Override the DataBindControl. 
        public override void DataBindControl(IDesignerHost designerHost, 
            Control control)
        {
            // Create a reference, named dataSourceBinding, 
            // to the control DataSource binding.
            DataBinding dataSourceBinding = 
                ((IDataBindingsAccessor)control).DataBindings["DataSource"];

            // If the binding exists, create a reference to the
            // list control, clear its ListItemCollection, and then add
            // an item to the collection.
            if (! (dataSourceBinding == null))
            {
                SimpleRadioButtonList simpleControl = 
                    (SimpleRadioButtonList)control;

                simpleControl.Items.Clear();
                simpleControl.Items.Add("Data-bound Radio Button.");
            }
        } // DataBindControl
        // </snippet7>
    } // SimpleRadioButtonListDataBindingHandler
} // Examples.CS.WebControls.Design
// </snippet6>

