<!-- <Snippet1> -->

<%@ Page Language="C#" AutoEventWireup="True" %>
<%@ Import Namespace="System.Data" %>
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
   <script runat="server">
 
      ICollection CreateDataSource()
      {
      
         // Create a Random object to mix up the order of items in the
         // sample data.
         Random Rand_Num = new Random();

         // Create sample data for the DataGrid control.
         DataTable dt = new DataTable();
         DataRow dr;
 
         // Define the columns of the table.
         dt.Columns.Add(new DataColumn("IntegerValue", typeof(Int32)));
         dt.Columns.Add(new DataColumn("StringValue", typeof(String)));
         dt.Columns.Add(new DataColumn("CurrencyValue", typeof(Double)));
 
         // Populate the table with sample values.
         for (int i=0; i<=8; i++) 
         {

            dr = dt.NewRow();
 
            dr[0] = i;
            dr[1] = "Item " + Rand_Num.Next(1, 15).ToString();
            dr[2] = 1.23 * Rand_Num.Next(1, 15);
 
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
         
            ItemsGrid.DataSource = CreateDataSource();
            ItemsGrid.DataBind();
         
         }

      }

      void Check_Change(Object sender, EventArgs e)
      {
   
         // Show or hide the header depending on the user's selection.
         if (ShowHeaderCheckBox.Checked)
         {

            ItemsGrid.ShowHeader = true;

         }
         else
         {

            ItemsGrid.ShowHeader = false;

         }

         // Show or hide the footer depending on the user's selection.
         if (ShowFooterCheckBox.Checked)
         {

            ItemsGrid.ShowFooter = true;

         }
         else
         {

            ItemsGrid.ShowFooter = false;

         }

      }

   </script>
 
<head runat="server">
    <title>DataGrid ShowHeader and ShowFooter Example</title>
</head>
<body>
 
   <form id="form1" runat="server">
 
      <h3>DataGrid ShowHeader and ShowFooter Example</h3>

      Select whether to show or hide the header and footer sections
      in the DataGrid control.

      <br /><br />
 
      <b>Product List</b>
 
      <asp:DataGrid id="ItemsGrid"
           BorderColor="black"
           BorderWidth="1"
           CellPadding="3"
           ShowHeader="True"
           ShowFooter="True"
           AutoGenerateColumns="False"
           runat="server">

         <HeaderStyle BackColor="#00aaaa">
         </HeaderStyle>

         <FooterStyle BackColor="#00aaaa">
         </FooterStyle>

         <Columns>

            <asp:BoundColumn DataField="IntegerValue" 
                 SortExpression="IntegerValue"
                 HeaderText="Item"/>

            <asp:BoundColumn DataField="StringValue"
                 SortExpression="StringValue" 
                 HeaderText="Description"/>

            <asp:BoundColumn DataField="CurrencyValue" 
                 HeaderText="Price"
                 SortExpression="CurrencyValue"
                 DataFormatString="{0:c}">

               <ItemStyle HorizontalAlign="Right">
               </ItemStyle>

            </asp:BoundColumn>

         </Columns> 
 
      </asp:DataGrid>

      <hr />

      <asp:CheckBox id="ShowHeaderCheckBox"
           Text="Show header"
           AutoPostBack="True"
           Checked="True"
           OnCheckedChanged="Check_Change"
           runat="server"/>

      &nbsp;&nbsp

      <asp:CheckBox id="ShowFooterCheckBox"
           Text="Show footer"
           AutoPostBack="True"
           Checked="True"
           OnCheckedChanged="Check_Change"
           runat="server"/>
 
   </form>
 
</body>
</html>

<!-- </Snippet1> -->