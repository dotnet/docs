<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>
<%@ Import Namespace="System.Data" %>
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
   <script language = "C#" runat="server">
 
      ICollection CreateDataSource() 
      {
         DataTable dt = new DataTable();
         DataRow dr;
 
         dt.Columns.Add(new DataColumn("StringValue", typeof(string)));
  
         for (int i = 0; i < 10; i++) 
         {
            dr = dt.NewRow();
            dr[0] = "Item " + i.ToString();
            dt.Rows.Add(dr);
         }
 
         DataView dv = new DataView(dt);
         return dv;
      }
 
      void Page_Load(Object sender, EventArgs e) 
      {
         if (!IsPostBack) 
         {
            DataList1.DataSource = CreateDataSource();
            DataList1.DataBind();
         }
      }
 
      void Button_Click(Object sender, EventArgs e)
      { 
         if (DataList1.Items.Count > 0)
         {
            Label1.Text = "The Items collection contains: <br />";

            foreach(DataListItem item in DataList1.Items)
            {
        
               Label1.Text += ((DataBoundLiteralControl)item.Controls[0]).Text +
                              "<br />";
            }
         }
      } 
 
   </script>
 
<head runat="server">
    <title>DataList Items Example</title>
</head>
<body>
 
   <form id="form1" runat="server">

      <h3>DataList Items Example</h3>
 
      <asp:DataList id="DataList1" runat="server"
           BorderColor="black"
           CellPadding="3"
           Font-Names="Verdana"
           Font-Size="8pt">

         <HeaderStyle BackColor="#aaaadd">
         </HeaderStyle>

         <AlternatingItemStyle BackColor="Gainsboro">
         </AlternatingItemStyle>

         <HeaderTemplate>

            Items

         </HeaderTemplate>
               
         <ItemTemplate>

            <%# DataBinder.Eval(Container.DataItem, "StringValue") %>

         </ItemTemplate>
 
      </asp:DataList>

        <br /><br />

      <asp:Button id="Button1"
           Text="Display Contents of Items Collection"
           OnClick="Button_Click"
           runat="server"/>
 
      <br /><br />

      <asp:Label id="Label1"
           runat="server"/>
 
   </form>
 
</body>
</html>
   
<!--</Snippet1>-->
