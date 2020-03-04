<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>
<%@ Import Namespace="System.Data" %>
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>DataListCommandEventArgs Example</title>
<script language="c#" runat="server">
 
      ICollection CreateDataSource() 
      {
         
         DataTable dt = new DataTable();
         DataRow dr;
 
         // Create a DataTable.
         dt.Columns.Add(new DataColumn("IntegerValue", typeof(Int32)));
         dt.Columns.Add(new DataColumn("StringValue", typeof(string)));
         dt.Columns.Add(new DataColumn("DateTimeValue", typeof(DateTime)));
 
         // Create sample data.
         for (int i = 1; i <= 9; i++) 
         {
            dr = dt.NewRow();
            dr[0] = i;
            dr[1] = "Item " + i.ToString();
            dr[2] = DateTime.Now.ToShortTimeString();
            dt.Rows.Add(dr);
         }
          
 
         // Return a DataView to the DataTable.
         DataView dv = new DataView(dt);
         return dv;
         
      }
 
      void Page_Load(Object sender, EventArgs e) 
      {
         
         if (!IsPostBack)
            BindList();
 
      }
 
      void BindList() 
      {

         DataList1.DataSource = CreateDataSource();
         DataList1.DataBind();

      }
     
      void DataList_ItemCommand(object sender, DataListCommandEventArgs e) 
      {          
         if (((LinkButton)e.CommandSource).CommandName == "select")
            DataList1.SelectedIndex = e.Item.ItemIndex;
         
         BindList();
      }
 
   </script>
 
</head>
<body>
 
   <form id="form1" runat="server">

      <h3>DataListCommandEventArgs Example</h3>
 
      <asp:DataList id="DataList1"                                                
                    GridLines="Both"                                                       
                    OnItemCommand="DataList_ItemCommand"
                    runat="server">

         <HeaderTemplate>
            Items
         </HeaderTemplate>

         <ItemTemplate>
            <asp:LinkButton id="button1"
                            Text="Show details" 
                            CommandName="select" 
                            runat="server"/>
            <%# DataBinder.Eval(Container.DataItem, "StringValue") %>
         </ItemTemplate>

         <SelectedItemTemplate>
            Item:
            <%# DataBinder.Eval(Container.DataItem, "StringValue") %>
            <br />
            Order Date:
            <%# DataBinder.Eval(Container.DataItem, "DateTimeValue", "{0:d}") %>
            <br />
            Quantity:
            <%# DataBinder.Eval(Container.DataItem, "IntegerValue", "{0:N1}") %>
            <br />
         </SelectedItemTemplate>
 
      </asp:DataList>

   </form>
 
</body>
</html>
   
<!--</Snippet1>-->
