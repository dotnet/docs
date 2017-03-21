        // Override the InitializeItem method to add a PathSeparator
        // and DropDownList to the current node.
        protected override void InitializeItem(SiteMapNodeItem item) {

            // The only node that must be handled is the CurrentNode.
            if (item.ItemType == SiteMapNodeItemType.Current)
            {
                HyperLink hLink = new HyperLink();

                // No Theming for the HyperLink.
                hLink.EnableTheming = false;
                // Enable the link of the SiteMapPath is enabled.
                hLink.Enabled = this.Enabled;

                // Set the properties of the HyperLink to
                // match those of the corresponding SiteMapNode.
                hLink.NavigateUrl = item.SiteMapNode.Url;
                hLink.Text        = item.SiteMapNode.Title;
                if (ShowToolTips) {
                    hLink.ToolTip = item.SiteMapNode.Description;
                }

                // Apply styles or templates to the HyperLink here.
                // ...
                // ...

                // Add the item to the Controls collection.
                item.Controls.Add(hLink);

                AddDropDownListAfterCurrentNode(item);
            }
            else {
                base.InitializeItem(item);
            }
        }