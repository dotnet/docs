using System;
using System.Collections;
using System.Web;
using System.Web.UI;

namespace TemplateControlSamples {

    [
        ParseChildren(true)
    ]
    public class Repeater1 : Control, INamingContainer {

        private ITemplate   _itemTemplate   = null;
        private ICollection _dataSource     = null;

        public ICollection DataSource {
            get {
               return _dataSource;
            }
            set {
               _dataSource = value;
            }
        }

        [
            TemplateContainer(typeof(RepeaterItem))
        ]
        public ITemplate ItemTemplate {
            get {
               return _itemTemplate;
            }
            set {
               _itemTemplate = value;
            }
        }

        // <snippet1>
        // Override to prevent LiteralControls from being added as children.
        protected override void AddParsedSubObject(object o) {
        }
        // </snippet1>

        // <snippet2>
        // Override to create repeated items.
        protected override void CreateChildControls() {
            object o = ViewState["NumItems"];
            if (o != null) {
               // Clear any existing child controls.
               Controls.Clear();

               int numItems = (int)o;
               for (int i=0; i < numItems; i++) {
                  // Create an item.
                  RepeaterItem item = new RepeaterItem(i, null);
                  // Initialize the item from the template.
                  ItemTemplate.InstantiateIn(item);
                  // Add the item to the ControlCollection.
                  Controls.Add(item);
               }
            }
        }
        // </snippet2>

        // <snippet3>
        // Override to create the repeated items from the DataSource.
        protected override void OnDataBinding(EventArgs e) {
            base.OnDataBinding(e);

            if (DataSource != null) {
                // Clear any existing child controls.
                Controls.Clear();
                // Clear any previous view state for the existing child controls.
                ClearChildViewState();

                // Iterate over the DataSource, creating a new item for each data item.
                IEnumerator dataEnum = DataSource.GetEnumerator();
                int i = 0;
                while(dataEnum.MoveNext()) {

                    // Create an item.
                    RepeaterItem item = new RepeaterItem(i, dataEnum.Current);
                    // Initialize the item from the template.
                    ItemTemplate.InstantiateIn(item);
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
        // </snippet3>
    }
}
