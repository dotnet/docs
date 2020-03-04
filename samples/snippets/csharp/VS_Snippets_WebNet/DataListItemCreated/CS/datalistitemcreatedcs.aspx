<!-- <Snippet1> -->

<%@ Page Language="C#" AutoEventWireup="True" %>
<%@ Import Namespace="System.Data" %>
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
   <script runat="server">
 
      ICollection CreateDataSource() 
      {
      
         // Create sample data for the DataList control.
         DataTable dt = new DataTable();
         DataRow dr;
 
         // Define the columns of the table.
         dt.Columns.Add(new DataColumn("IntegerValue", typeof(Int32)));
         dt.Columns.Add(new DataColumn("StringValue", typeof(String)));
         dt.Columns.Add(new DataColumn("CurrencyValue", typeof(double)));
 
         // Populate the table with sample values.
         for (int i = 0; i < 9; i++) 
         {
            dr = dt.NewRow();
 
            dr[0] = i;
            dr[1] = "Description for item " + i.ToString();
            dr[2] = 1.23 * (i + 1);
 
            dt.Rows.Add(dr);
         }
 
         DataView dv = new DataView(dt);
         return dv;

      }
 
 
      void Page_Load(Object sender, EventArgs e) 
      {

         // Load sample data only once, when the page is first loaded.
         if (!IsPostBack) 
         {
            ItemsList.DataSource = CreateDataSource();
            ItemsList.DataBind();
         }

      }

      void Item_Created(Object sender, DataListItemEventArgs e)
      {

         if (e.Item.ItemType == ListItemType.Item || 
             e.Item.ItemType == ListItemType.AlternatingItem)
         {

            // Retrieve the Label control in the current DataListItem.
            Label PriceLabel = (Label)e.Item.FindControl("PriceLabel");

            // Retrieve the text of the CurrencyColumn from the DataListItem
            // and convert the value to a Double.
            Double Price = Convert.ToDouble(
                ((DataRowView)e.Item.DataItem).Row.ItemArray[2].ToString());

            // Format the value as currency and redisplay it in the DataList.
            PriceLabel.Text = Price.ToString("c");

         }

      }
 
   </script>
 
<head runat="server">
    <title>DataList ItemCreated Example</title>
</head>
<body>
 
   <form id="form1" runat="server">

      <h3>DataList ItemCreated Example</h3>
 
      <asp:DataList id="ItemsList"
           BorderColor="black"
           CellPadding="5"
           CellSpacing="5"
           RepeatDirection="Vertical"
           RepeatLayout="Table"
           RepeatColumns="3"
           OnItemCreated="Item_Created"
           runat="server">

         <HeaderStyle BackColor="#aaaadd">
         </HeaderStyle>

         <AlternatingItemStyle BackColor="Gainsboro">
         </AlternatingItemStyle>

         <HeaderTemplate>

            List of items

         </HeaderTemplate>
               
         <ItemTemplate>

            Description: <br />
            <%# DataBinder.Eval(Container.DataItem, "StringValue") %>

            <br />

            Price: 
            <asp:Label id="PriceLabel"
                 runat="server"/>

         </ItemTemplate>
 
      </asp:DataList>
 
   </form>
 
</body>
</html>

<!-- </Snippet1> -->
