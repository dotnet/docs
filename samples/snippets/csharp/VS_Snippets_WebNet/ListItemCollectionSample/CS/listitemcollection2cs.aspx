<!-- <Snippet1> -->
<!-- This example demonstrates creating ListItemCollection objects, 
adding items to the collections, and removing items from the collections. -->
<!-- </Snippet1> -->

<!-- <Snippet2> -->
<!-- In the example, listBoxData ListItemCollection is used as the data 
source for a ListBox control called ListBox1, and the ddBoxData 
ListItemCollection is used as the data source for a DropDownList 
control called DropDownList1. --> 
<!-- </Snippet2> -->

<!-- <Snippet3> -->
<!-- To view this code snippet in a fully-working example, see the 
WebControl Class topic. -->

<!-- </Snippet3> --> 

<!-- <Snippet4> -->
<%@ Page language="C#" AutoEventWireup="true" %>
<%@ Import Namespace="System.Data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
    private void Page_Load(object sender, System.EventArgs e)
    {
        // If this isn't the first time the page is loaded in this session,
        // then don't recreate the DataTables.
        if (!IsPostBack)
        {
// <Snippet5>
            // Create a new ListItemCollection.
            ListItemCollection listBoxData = new ListItemCollection();
            // Add items to the collection.
            listBoxData.Add(new ListItem("apples"));
            listBoxData.Add(new ListItem("bananas"));
            listBoxData.Add(new ListItem("cherries"));
            listBoxData.Add("grapes");
            listBoxData.Add("mangos");
            listBoxData.Add("oranges");
            // Set the ListItemCollection as the data source for ListBox1.
            ListBox1.DataSource = listBoxData;
            ListBox1.DataBind();
//</Snippet5>

            // Create a new ListItemCollection.
            ListItemCollection ddBoxData = new ListItemCollection();
            // For now, just bind the data to the DropDownList.
            DropDownList1.DataSource = ddBoxData;
            DropDownList1.DataBind();
        }        
    }

    private void moveButton1_Click(object sender, System.EventArgs e)
    {
//<Snippet6>
        //Set the SelectedIndex to -1 so no items are selected.
        // The new item will be set as the selected item when it is added.
        DropDownList1.SelectedIndex = -1;
        // Add the selected item to DropDownList1.
        DropDownList1.Items.Add(ListBox1.SelectedItem);
        // Delete the selected item from ListBox1.
        ListBox1.Items.Remove(ListBox1.SelectedItem);
//</Snippet6>
    }

    private void moveButton2_Click(object sender, System.EventArgs e)
    {
        //Set the SelectedIndex to -1 so no items are selected.
        // The new item will be set as the selected item when it is added.
        ListBox1.SelectedIndex = -1;
        // Add the selected item to ListBox1.
        ListBox1.Items.Add(DropDownList1.SelectedItem);
        //Delete the selected item from DropDownList1.
        DropDownList1.Items.Remove(DropDownList1.SelectedItem);
    }
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
    <head>
    <title>ASP.NET Example</title>
</head>

    <body>
        <form id="form1" runat="server">
            <table cellpadding="6" border="0">
                <tr>
                    <td rowspan="2" valign="top">
                        <asp:ListBox id="ListBox1" runat="server" 
                            SelectionMode="Single" Width="100px">
                        </asp:ListBox>
                    </td>

                    <td>
                        <asp:Button id="moveButton1" runat="server" Text="Move -->"
                            Width="100px" OnClick="moveButton1_Click"></asp:Button>
                    </td>

                    <td rowspan="2" valign="top">
                        <asp:DropDownList Runat="server" ID="DropDownList1"
                            Width="100px">
                        </asp:DropDownList>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Button ID="moveButton2" Runat="server" Text="<-- Move"
                            Width="100px" onClick="moveButton2_Click"></asp:Button>
                    </td>
                </tr>
            </table>
        </form>
    </body>
</html>
<!-- </Snippet4> -->
