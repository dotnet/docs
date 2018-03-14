<!-- System.Web.UI.Control.NamingContainer-->
<!-- The following example demonstrates the 'NamingContainer' property of the
class 'Control'.In this sample, a Datasource is attatched to a Datalist and the UniqueIDs and 
NamingContainer values of the rows of Datalist are displayed.
-->
<!-- <Snippet1>-->
<% @ Import Namespace = "System.Data"  %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
   <head>
    <title>
            Control NamingContainer Example
         </title>
<script language="C#" runat="server">
      // Build the DataSource.
      ICollection CreateDataSource()
      {
         DataTable myDataTable = new DataTable();
         DataRow myDataRow;
         myDataTable.Columns.Add(new DataColumn("EmployeeName", typeof(string)));
         for (int i = 0; i < 10; i++) 
         {
            myDataRow = myDataTable.NewRow();
            myDataRow[0] = "somename" + i.ToString();
            myDataTable.Rows.Add(myDataRow);
         }
         DataView myDataView = new DataView(myDataTable);
         return myDataView;
      }

      void Page_Load(Object sender, EventArgs e) 
      {
         if (!IsPostBack) 
         {
            // Bind 'DataView' to the DataSource.
            myDataList.DataSource = CreateDataSource();
            myDataList.DataBind();
         }
         // Attach EventHandler for SelectedIndexChanged event.
         myDataList.SelectedIndexChanged += new EventHandler(selectedItemChanged);
      }

      // Handler function for 'SelectedIndexChanged' event.
      void selectedItemChanged(Object sender,EventArgs e)
      {
         DataListItem myCurrentItem = myDataList.SelectedItem;
         Control myNamingContainer = myCurrentItem.Controls[0].NamingContainer;
         // Display the NamingContainer.
         myLabel1.Text = "The NamingContainer is : " + myNamingContainer.UniqueID;
         // Display the UniqueID.
         myLabel2.Text = "The UniqueID is : " + ((Control)(myCurrentItem.Controls[0])).UniqueID;
      }      

    </script>
   </head>
   <body>
      <form runat="server" id="Form1">
         <h3>
            Control NamingContainer Example
         </h3>
         <h4>
            Click an item to view it's Naming Container and UniqueID
         </h4>
         <asp:Label ID="myLabel1" Runat="server"></asp:Label>
         <br />
         <asp:Label ID="myLabel2" Runat="server"></asp:Label>
         <br />
         <asp:DataList id="myDataList" runat="server" BorderColor="black">
            <HeaderStyle BackColor="#aaaadd"></HeaderStyle>
            <SelectedItemStyle BackColor="lightgreen"></SelectedItemStyle>
            <HeaderTemplate>
               EmployeeName
            </HeaderTemplate>
            <ItemTemplate>
               <asp:LinkButton id="button1" Text='<%# DataBinder.Eval(Container.DataItem, "EmployeeName") %>' CommandName="select" runat="server" />
               &nbsp;&nbsp;&nbsp;&nbsp;
            </ItemTemplate>
         </asp:DataList>
      </form>
   </body>
</html>
<!-- </Snippet1>-->