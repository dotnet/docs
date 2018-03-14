//<Snippet1>
using System;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TemplateControlSamples
{
    [ParseChildren(true)]
    public class CustomRepeater : Repeater
    {

        // Override to prevent LiteralControls from being added as children.
        protected override void AddParsedSubObject(object o)
        {
        }

        // Override to create repeated items.
        protected override void CreateChildControls()
        {
            object o = ViewState["NumItems"];
            if (o != null)
            {
                // Clear any existing child controls.
                Controls.Clear();

                int numItems = (int)o;
                for (int i = 0; i < numItems; i++)
                {
                    // Create an item.
                    RepeaterItem item = new RepeaterItem(i, ListItemType.Item);
                    // Initialize the item from the template.
                    ItemTemplate.InstantiateIn(item);
                    // Add the item to the ControlCollection.
                    Controls.Add(item);
                }
            }
        }

        // Override to create the repeated items from the DataSource.
        protected override void OnDataBinding(EventArgs e)
        {
            base.OnDataBinding(e);
            if (DataSource != null)
            {
                // Iterate over an ICollection DataSource, creating a new item for each data item.
                IEnumerator dataEnum = ((ICollection)base.DataSource).GetEnumerator();
                int i = 0;
                while (dataEnum.MoveNext())
                {
                    // Create an item.
                    RepeaterItem item = new RepeaterItem(i, ListItemType.Item);
                    item.DataItem = dataEnum.Current;
                    // Initialize the item from the template.
                    ItemTemplate.InstantiateIn(this);
                    // Add the item to the ControlCollection.
                    Controls.Add(item);

                    i++;
                }

                // Prevent child controls from being created again.
                ChildControlsCreated = true;
                // Store the number of items created in view state for postback scenarios.
                ViewState["NumItems"] = i;
            }
        }
    }
}
//</Snippet1>
