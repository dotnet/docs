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
         dt.Columns.Add(new DataColumn("ImageValue", typeof(String)));
 
         // Populate the table with sample values.
         for (int i = 0; i < 9; i++) 
         {
            dr = dt.NewRow();
 
            dr[0] = i;
            dr[1] = "Description for item " + i.ToString();
            dr[2] = 1.23 * (i + 1);
            dr[3] = "Image" + i.ToString() + ".jpg";
 
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
 
   </script>
 
<head runat="server">
    <title>DataList AlternatingItemTemplate Example</title>
</head>
<body>
 
   <form id="form1" runat="server">

      <h3>DataList AlternatingItemTemplate Example</h3>
 
      <asp:DataList id="ItemsList"
           BorderColor="black"
           CellPadding="5"
           CellSpacing="5"
           RepeatDirection="Vertical"
           RepeatLayout="Table"
           RepeatColumns="3"
           ShowFooter="True"
           runat="server">

         <HeaderStyle BackColor="#aaaadd">
         </HeaderStyle>

         <ItemStyle BackColor="Silver">
         </ItemStyle>

         <AlternatingItemStyle BackColor="DarkGray">
         </AlternatingItemStyle>

         <HeaderTemplate>

            List of items

         </HeaderTemplate>
               
         <ItemTemplate>

            Description: <br />
            <%# DataBinder.Eval(Container.DataItem, "StringValue") %>

            <br />

            Price: <%# DataBinder.Eval(Container.DataItem, "CurrencyValue", "{0:c}") %>

            <br />

            <asp:Image id="ProductImage" 
                 AlternateText='<%# DataBinder.Eval(Container.DataItem, "StringValue") %>' 
                 ImageUrl='<%# DataBinder.Eval(Container.DataItem, "ImageValue") %>'
                 runat="server"/>

         </ItemTemplate>

         <AlternatingItemTemplate>

            <asp:Image id="ProductImage" 
                 AlternateText='<%# DataBinder.Eval(Container.DataItem, "StringValue") %>' 
                 ImageUrl='<%# DataBinder.Eval(Container.DataItem, "ImageValue") %>'
                 runat="server"/>

            <br />

            Description: <br />
            <%# DataBinder.Eval(Container.DataItem, "StringValue") %>

            <br />

            Price: <%# DataBinder.Eval(Container.DataItem, "CurrencyValue", "{0:c}") %>       

         </AlternatingItemTemplate>
 
      </asp:DataList>
 
   </form>
 
</body>
</html>

<!-- </Snippet1> -->
