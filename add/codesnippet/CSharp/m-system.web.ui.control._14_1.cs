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