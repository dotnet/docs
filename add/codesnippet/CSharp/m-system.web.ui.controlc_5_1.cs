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