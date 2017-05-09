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

      void Selection_Change(Object sender, EventArgs e)
      {

         // Set the background color for the heading and footer sections
         // of the DataList control.
         ItemsList.HeaderStyle.BackColor = 
             System.Drawing.Color.FromName(List.SelectedItem.Value);
         ItemsList.FooterStyle.BackColor = 
             System.Drawing.Color.FromName(List.SelectedItem.Value);

      }
 
   </script>
 
<head runat="server">
    <title>DataList HeaderStyle and FooterStyle Example</title>
</head>
<body>
 
   <form id="form1" runat="server">

      <h3>DataList HeaderStyle and FooterStyle Example</h3>

      Select a background color for the header and footer sections.

      <br /><br />
 
      <asp:DataList id="ItemsList"
           BorderColor="black"
           CellPadding="5"
           CellSpacing="5"
           RepeatDirection="Vertical"
           RepeatLayout="Table"
           RepeatColumns="3"
           ShowFooter="True"
           runat="server">

         <HeaderStyle BackColor="White">
         </HeaderStyle>

         <FooterStyle BackColor="White">
         </FooterStyle>

         <AlternatingItemStyle BackColor="Gainsboro">
         </AlternatingItemStyle>

         <HeaderTemplate>

            List of items

         </HeaderTemplate>

         <FooterTemplate>

            <asp:Image id="FooterImage"
                 GenerateEmptyAlternateText='true' 
                 ImageUrl='FooterImage.jpg'
                 runat="server"/>

         </FooterTemplate>
               
         <ItemTemplate>

            Description: <br />
            <%# DataBinder.Eval(Container.DataItem, "StringValue") %>

            <br />

            Price: <%# DataBinder.Eval(Container.DataItem, "CurrencyValue", "{0:c}") %>

            <br />

            <asp:Image id="ProductImage"
                 AlternatingText='<%# DataBinder.Eval(Container.DataItem, "StringValue") %>' 
                 ImageUrl='<%# DataBinder.Eval(Container.DataItem, "ImageValue") %>'
                 runat="server"/>

         </ItemTemplate>
 
      </asp:DataList>

      <hr />

      Header and footer BackColor: <br /> 

      <asp:DropDownList id="List"
           AutoPostBack="True"
           OnSelectedIndexChanged="Selection_Change"
           runat="server">

         <asp:ListItem Selected="True" Value="White"> White </asp:ListItem>
         <asp:ListItem Value="Silver"> Silver </asp:ListItem>
         <asp:ListItem Value="DarkGray"> Dark Gray </asp:ListItem>
         <asp:ListItem Value="Khaki"> Khaki </asp:ListItem>
         <asp:ListItem Value="DarkKhaki"> Dark Khaki </asp:ListItem>

      </asp:DropDownList>
 
   </form>
 
</body>
</html>

<!-- </Snippet1> -->
