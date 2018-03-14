<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>
<%@ Import Namespace="System.Data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>DataList SelectedItem Example</title>
<script language="C#" runat="server">

      public DataTable Cart;
      public DataView CartView;

      void Page_Load(Object sender, EventArgs e) 
      {
         if (Session["DL3_ShoppingCart"] == null) 
         {
            Cart = new DataTable();
            Cart.Columns.Add(new DataColumn("Qty", typeof(string)));
            Cart.Columns.Add(new DataColumn("Item", typeof(string)));
            Cart.Columns.Add(new DataColumn("Price", typeof(string)));
            Session["DL3_ShoppingCart"] = Cart;

            // First Load - Create some data.
            for (int i=1; i<=9; i++) 
            {
               DataRow dr = Cart.NewRow();
               dr[0] = ((i%2)+1).ToString();
               dr[1] = "Item " + i.ToString();
               dr[2] = (1.23 * (i+1)).ToString();
               Cart.Rows.Add(dr);
            }
         }
         else
            Cart = (DataTable)Session["DL3_ShoppingCart"];

         CartView = new DataView(Cart);
         CartView.Sort = "Item";
         if (!IsPostBack)
            BindList();
      }

      void BindList() 
      {
         DataList1.DataSource= CartView;
         DataList1.DataBind();
      }

      void DataList_ItemCommand(Object sender, DataListCommandEventArgs e) 
      {
         DataList1.SelectedIndex = e.Item.ItemIndex;
         BindList();
         Label4.Text = "You selected: "  + 
                       ((Label)DataList1.SelectedItem.FindControl("Label1")).Text;
      }

      void Button_Click(Object sender, EventArgs e)
      { 
         if (DataList1.SelectedItem != null)
         {
            DataList1.SelectedItem.ForeColor = System.Drawing.Color.Red;
         }
      }

   </script>

</head>
<body>

   <form id="form1" runat="server">

      <h3>DataList SelectedItem Example</h3>
      <p></p>
       
      <asp:DataList id="DataList1" runat="server"
           GridLines="Both"
           CellPadding="3"
           CellSpacing="0"           
           OnItemCommand="DataList_ItemCommand">

         <HeaderStyle BackColor="#aaaadd">
         </HeaderStyle>

         <AlternatingItemStyle BackColor="Gainsboro">
         </AlternatingItemStyle>

         <SelectedItemStyle BackColor="lightgreen">
         </SelectedItemStyle>

         <HeaderTemplate>

            Items

         </HeaderTemplate>
         
         <ItemTemplate>

            <asp:LinkButton id="button1" 
                 Text="Select" 
                 CommandName="select"
                 runat="server"/>
            <%# ((DataRowView)Container.DataItem)["Item"]  %>

         </ItemTemplate>
              
         <SelectedItemTemplate>

            Item:
            <asp:Label id="Label1" 
                 Text='<%# ((DataRowView)Container.DataItem)["Item"] %>' 
                 runat="server"/>

            <br />

            Quantity:
            <asp:Label id="Label2" 
                 Text='<%# ((DataRowView)Container.DataItem)["Qty"] %>' 
                 runat="server"/>

            <br />

            Price:
            <asp:Label id="Label3" 
                 Text='<%# DataBinder.Eval(Container.DataItem, "Price") %>' 
                 runat="server"/>

         </SelectedItemTemplate>

      </asp:DataList>

      <br /><br />

      <asp:Label id="Label4"
           runat="server"/>

      <br /><br />

      <asp:Button id="Button2"
           Text="Change Text to Red" 
           OnClick="Button_Click"
           runat="server"/>

   </form>

</body>
</html>

<!--</Snippet1>-->
