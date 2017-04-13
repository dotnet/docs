<%--<Snippet1>--%>
<%@ Import Namespace = "System.Data"  %>
<%@ Page language="c#" AutoEventWireup="true"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">    
// The following example creates a DataSource as a DataView.
// The DataView is bound to a DataList that is displayed using an
// ItemTemplate. When the page is first loaded, the program uses the 
// CopyTo method to copy the entire data source to an Array and then 
// displays that data.

ICollection CreateDataSource()
{
    DataTable myDataTable = new DataTable();
    DataRow myDataRow;

    myDataTable.Columns.Add(new DataColumn("EmployeeName", typeof(string)));
    myDataTable.Columns.Add(new DataColumn("EmployeeID", typeof(long)));
    for (int i = 0; i < 3; i++)
    {
        myDataRow = myDataTable.NewRow();
        myDataRow[0] = "somename" + i.ToString();
        myDataRow[1] = (i+1000);
        myDataTable.Rows.Add(myDataRow);
    }
    DataView dataView = new DataView(myDataTable);
    return dataView;
}

// <Snippet2>
void Page_Load(Object sender, EventArgs e)
{
    if (!IsPostBack)
    {
        // Bind the DataView to the DataSource.
        myDataList.DataSource = CreateDataSource();
        myDataList.DataBind();
        // Create a Array to hold the DataSource.
        System.Array myArray = Array.CreateInstance(typeof(DataListItem),
            myDataList.Items.Count);
        // Copy the DataSource to an Array.
        myDataList.Items.CopyTo(myArray,0);
        PrintValues(myArray);
    }
}

// Prints each element in the Array onto the label lblAllItems1.
public void PrintValues(Array myArr)
{
    DataListItem currentItem;
    System.Collections.IEnumerator myEnumerator = myArr.GetEnumerator();
    while (myEnumerator.MoveNext())
    {
        currentItem = (DataListItem)myEnumerator.Current;
        lblAllItems1.Text += "<br /><br />" + 
            ((Label)(currentItem.Controls[1])).Text;
    }
}

// Event handler method for show button.
void show_Click(Object sender,EventArgs e)
{
    // Get the underlying DataListItemCollection from the DataList object.
    DataListItemCollection myDataListItemCollection = myDataList.Items;
    // Display the read-only properties.
    Response.Write("<b>The Total number of items are " + 
        myDataListItemCollection.Count + "</b>");
    Response.Write("<br /><b>The ReadOnly property of the " + 
        "DataListItemCollection is always" + 
        myDataListItemCollection.IsReadOnly + "</b>");
    Response.Write("<br /><b>The IsSynchronized property of the " +
        "DataListItemCollection is always " +
        myDataListItemCollection.IsSynchronized + "</b>");
    myDataListItemCollection = null;
}
// </Snippet2>

// <Snippet5>
void allItems_Click(Object sender,EventArgs e)
{
    IEnumerator dataListEnumerator;
    DataListItem currentItem;
    lblAllItems.Text = "";
    // Get an enumerator to traverse the DataListItemCollection.
    dataListEnumerator = myDataList.Items.GetEnumerator();
    while(dataListEnumerator.MoveNext())
    {
        currentItem = (DataListItem)dataListEnumerator.Current;
        // Display the current DataListItem onto the label.
        lblAllItems.Text += ((Label)(currentItem.Controls[1])).Text + " ";
    }
}
// </Snippet5>

// <Snippet6>
void itemSelected(Object sender,EventArgs e)
{
    // Get the underlying DataListItemCollection from the DataList object.
    DataListItemCollection myDataListItemCollection = myDataList.Items;
    // Get the index of the selected radio button in the RadioButtonList.
    int index = Convert.ToInt16(listItemNo.SelectedItem.Value);
    // Get the DataListItem corresponding to index from DataList.
    // SyncRoot is used to make access to the DataListItemCollection 
    // in a thread-safe manner It returns the object that invoked it. 
    DataListItem currentItem = 
        ((DataListItemCollection)(myDataListItemCollection.SyncRoot))[index];
    // Display the selected DataListItem onto a label.
    lblDisplay.Text = "<b>DataListItem" + index + " is : "
        + ((Label)(currentItem.Controls[1])).Text;
    currentItem = null;
    myDataListItemCollection = null;
}
// </Snippet6>

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>
        DataListItemCollection Example
    </title>
</head>
<body>
<form runat="server" id="Form1">
    <h3>
        DataListItemCollection Example
    </h3>
    <table>
        <tr>
            <td>
                <asp:datalist id="myDataList" runat="server" Font-Size="8pt" 
                    Font-Names="Verdana" BorderColor="black" CellSpacing="5"
                    CellPadding="10" GridLines="Horizontal">
                    <HeaderStyle BackColor="#aaaadd"></HeaderStyle>
                    <HeaderTemplate>
                        EmployeeName EmployeeID
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Label id="label1" runat="server"
                            Text='<%# DataBinder.Eval(Container.DataItem, "EmployeeName") %>'>
                        </asp:Label>
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <%# DataBinder.Eval(Container.DataItem, "EmployeeID")%>
                    </ItemTemplate>
                </asp:datalist>
            </td>
            <td>
                <asp:label id="lblAllItems1" 
                    Text="The following items <br /> are copied to the array: " 
                    Runat="server" ForeColor="blue" Font-Bold="true" 
                    AssociatedControlID="listItemNo">
                    The following items <br /> are copied to the array:
                </asp:label>
            </td>
            <td>
                &nbsp;&nbsp;&nbsp; <b>Show Items:</b>
                <asp:RadioButtonList ID="listItemNo" 
                    OnSelectedIndexChanged="itemSelected" AutoPostBack="true" 
                    Runat="server">
                    <asp:ListItem Value="0" Text="0"></asp:ListItem>
                    <asp:ListItem Value="1" Text="1"></asp:ListItem>
                    <asp:ListItem Value="2" Text="2"></asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td>
                <asp:Label ID="lblDisplay" Runat="server" />
            </td>
        </tr>
    </table>
    <p>
        <asp:button id="show" onclick="show_Click" Runat="server" 
             Font-Bold="True" Text="DataList Information" />
        <asp:button id="allitems" onclick="allItems_Click" Runat="server" 
            Font-Bold="True" Text="Show All DataListItems" />
    </p>
    <p>
        <b>All DataList items will be shown here:</b>
        <asp:label id="lblAllItems" Runat="server" ForeColor="blue" />
    </p>
</form>
</body>
</html>
<%--</Snippet1>--%>
