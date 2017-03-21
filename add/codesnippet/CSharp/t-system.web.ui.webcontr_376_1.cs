        private void AddDropDownListAfterCurrentNode(SiteMapNodeItem item) {

            SiteMapNodeCollection childNodes = item.SiteMapNode.ChildNodes;

            // Only do this work if there are child nodes.
            if (childNodes != null) {

                // Add another PathSeparator after the CurrentNode.
                SiteMapNodeItem finalSeparator =
                    new SiteMapNodeItem(item.ItemIndex,
                                        SiteMapNodeItemType.PathSeparator);

                SiteMapNodeItemEventArgs eventArgs =
                    new SiteMapNodeItemEventArgs(finalSeparator);

                InitializeItem(finalSeparator);
                // Call OnItemCreated every time a SiteMapNodeItem is
                // created and initialized.
                OnItemCreated(eventArgs);

                // The pathSeparator does not bind to any SiteMapNode, so
                // do not call DataBind on the SiteMapNodeItem.
                item.Controls.Add(finalSeparator);

                // Create a DropDownList and populate it with the children of the
                // CurrentNode. There are no styles or templates that are applied
                // to the DropDownList control. If OnSelectedIndexChanged is raised,
                // the event handler redirects to the page selected.
                // The CurrentNode has child nodes.
                DropDownList ddList = new DropDownList();
                ddList.AutoPostBack = true;

                ddList.SelectedIndexChanged += new EventHandler(this.DropDownNavPathEventHandler);

                // Add a ListItem to the DropDownList for every node in the
                // SiteMapNodes collection.
                foreach (SiteMapNode node in childNodes) {
                    ddList.Items.Add(new ListItem(node.Title, node.Url));
                }

                item.Controls.Add(ddList);
            }
        }