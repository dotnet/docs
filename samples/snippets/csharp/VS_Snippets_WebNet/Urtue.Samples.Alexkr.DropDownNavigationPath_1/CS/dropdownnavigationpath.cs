namespace Samples.AspNet {
// <Snippet1>
    using System;
    using System.Collections;
    using System.ComponentModel;
    using System.Security.Permissions;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;


    // The DropDownNavigationPath is a class that extends the SiteMapPath
    // control and renders a DropDownList after the CurrentNode. The
    // DropDownList displays a list of pages found further down the site map
    // hierarchy from the current one. Selecting an item in the DropDownList
    // redirects to that page.
    //
    // For simplicity, the DropDownNavigationPath assumes the
    // RootToCurrent PathDirection, and does not apply styles
    // or templates the current node.
    //
    [AspNetHostingPermission(SecurityAction.Demand, Level=AspNetHostingPermissionLevel.Minimal)]
    public class DropDownNavigationPath : SiteMapPath {
// <Snippet2>
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
// </Snippet2>
// <Snippet3>
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
// </Snippet3>

        // The sender is the DropDownList.
        private void DropDownNavPathEventHandler(object sender,EventArgs e) {
            DropDownList ddL = sender as DropDownList;

            // Redirect to the page the user chose.
            if (Context != null)
                Context.Response.Redirect(ddL.SelectedValue);
        }
    }
// </Snippet1>
}