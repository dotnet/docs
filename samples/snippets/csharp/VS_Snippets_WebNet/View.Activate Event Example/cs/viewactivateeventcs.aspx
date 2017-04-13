<!-- <Snippet1> -->

<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>View.Activate Event Example</title>

    <script runat="server">

        protected void Index_Changed(object sender, EventArgs e)
        {
            // Set the active view to
            // the view selected by the user.
            String str = ViewListBox.SelectedItem.Text;
            switch (str)
            {
                case "DefaultView":
                    MultiView1.SetActiveView(DefaultView);
                    break;
                case "NewsView":
                    MultiView1.SetActiveView(NewsView);
                    break;
                case "ShoppingView":
                    MultiView1.SetActiveView(ShoppingView);
                    break;
            }
        }

        // The handler for the DefaultView's Activate event.
        protected void DefaultView_Activate(object sender, EventArgs e)
        {
            // Notify the user that the event was raised.
            ActivateLabel.Text = "The Activate event was raised for the DefaultView.";
        }

        // The handler for the DefaultView's Deactivate event.
        protected void DefaultView_Deactivate(object sender, EventArgs e)
        {
            // Notify the user that the event was raised.
            DeactivateLabel.Text = "The Deactivate event was raised for the DefaultView.";
        }

        // The handler for the ShoppingView's Activate event.
        protected void ShoppingView_Activate(object sender, EventArgs e)
        {
            // Notify the user that the event was raised.
            ActivateLabel.Text = "The Activate event was raised for the ShoppingView.";
        }

        // The handler for the ShoppingView's Deactivate event.
        protected void ShoppingView_Deactivate(object sender, EventArgs e)
        {
            // Notify the user that the event was raised.
            DeactivateLabel.Text = "The Deactivate event was raised for the ShoppingView.";
        }

        // The handler for the NewsView's Activate event.
        protected void NewsView_Activate(object sender, EventArgs e)
        {
            // Notify the user that the event was raised.
            ActivateLabel.Text = "The Activate event was raised for the NewsView.";
        }
        // The handler for the NewsView's Deactivate event.
        protected void NewsView_Deactivate(object sender, EventArgs e)
        {
            // Notify the user that the event was raised.
            DeactivateLabel.Text = "The Deactivate event was raised for the NewsView.";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MultiView1.SetActiveView(DefaultView);
            }
        }
    </script>

</head>
<body>
    <form id="Form1" runat="server">
        <h3>
            View Activate and Deactivate Events Example</h3>
        <h4>
            Select a view to display in a MultiView control:</h4>
        <asp:ListBox ID="ViewListBox" Rows="1" SelectionMode="Single" AutoPostBack="True"
            OnSelectedIndexChanged="Index_Changed" runat="Server">
            <asp:ListItem Value="0">DefaultView</asp:ListItem>
            <asp:ListItem Value="1">NewsView</asp:ListItem>
            <asp:ListItem Value="2">ShoppingView</asp:ListItem>
        </asp:ListBox><br />
        <br />
        <hr />
        <asp:MultiView ID="MultiView1" runat="Server">
            <asp:View ID="DefaultView" OnActivate="DefaultView_Activate" OnDeactivate="DefaultView_Deactivate"
                runat="Server">
                <asp:Panel ID="DefaultPanel1" Width="250px" BackColor="#C0C0FF" BorderColor="#404040"
                    BorderStyle="Double" runat="Server">
                    <asp:Label ID="DefaultLabel1" Font-Bold="true" Font-Size="20" Text="The Default View"
                        runat="Server" AssociatedControlID="DefaultView">
                    </asp:Label>
                </asp:Panel>
            </asp:View>
            <asp:View ID="NewsView" OnActivate="NewsView_Activate" OnDeactivate="NewsView_Deactivate"
                runat="Server">
                <asp:Panel ID="NewsPanel1" Width="250px" BackColor="#C0FFC0" BorderColor="#404040"
                    BorderStyle="Double" runat="Server">
                    <asp:Label ID="NewsLabel1" Font-Bold="true" Font-Size="20" Text="The News View" runat="Server"
                        AssociatedControlID="NewsView">                    
                    </asp:Label>
                </asp:Panel>
            </asp:View>
            <asp:View ID="ShoppingView" OnActivate="ShoppingView_Activate" OnDeactivate="ShoppingView_Deactivate"
                runat="Server">
                <asp:Panel ID="ShoppingPanel1" Width="250px" BackColor="#FFFFC0" BorderColor="#404040"
                    BorderStyle="Double" runat="Server">
                    <asp:Label ID="ShoppingLabel1" Font-Bold="true" Font-Size="20" Text="The Shopping View"
                        runat="Server" AssociatedControlID="ShoppingView">
                    </asp:Label>
                </asp:Panel>
            </asp:View>
        </asp:MultiView><br />
        <br />
        <asp:Label ID="ActivateLabel" BackColor="#ffff66" runat="Server">
        </asp:Label><br />
        <asp:Label ID="DeactivateLabel" BackColor="#ffff66" runat="Server">
        </asp:Label>
    </form>
</body>
</html>
<!--</Snippet1>-->
