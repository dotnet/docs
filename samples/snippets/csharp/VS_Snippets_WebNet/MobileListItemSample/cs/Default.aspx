<!-- <Snippet1> -->
<%@ Page Language="C#" 
    Inherits="System.Web.UI.MobileControls.MobilePage" %>
<%@ Register TagPrefix="mobile" 
    Namespace="System.Web.UI.MobileControls" 
    Assembly="System.Web.Mobile" %>

<script runat="server">
    public void Page_Load(Object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Label1.Text = "Select an item";

            // Create and fill an array list.
            ArrayList listValues = new ArrayList();
            listValues.Add("One");
            listValues.Add("Two");
            listValues.Add("Three");

            // Bind the array to the list.
            SelList1.DataSource = listValues;
            SelList1.DataBind();

            // Set the SelectType.
            SelList1.SelectType =
                System.Web.UI.MobileControls.ListSelectType.Radio;
        }
        else
        {
            if (SelList1.SelectedIndex > -1)
            {
                // To show the selection, use the Selection property.
                Label1.Text = "Your selection is " +
                    SelList1.Selection;

                // Or, show the selection by using 
                // the MobileListItemCollection class.
                // Get the index of the selected item
                int idx = SelList1.SelectedIndex;
                Label2.Text = "You have selected " +
                    SelList1.Items[idx].Text;

                // Insert a copy of the selected item
                MobileListItem mi = SelList1.Selection;
                Label3.Text = "The index of your selection is " + 
                    mi.Index.ToString();
                SelList1.Items.Insert(idx, 
                    new MobileListItem(mi.Text + " Copy"));
            }
            else
            {
                Label1.Text = "No items selected";
            }
        }
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
    <mobile:form id="form1" runat="server">
        <mobile:Label id="Label1" runat="server" 
            Text="Show a list" />
        <mobile:Label id="Label2" runat="server" />
        <mobile:Label id="Label3" runat="server" />
        <mobile:SelectionList runat="server" 
            id="SelList1" />
        <mobile:Command id="Command1" runat="server" 
            Text=" OK " />
    </mobile:form>
</body>
</html>
<!-- </Snippet1> -->
