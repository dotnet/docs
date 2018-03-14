<!-- <Snippet1> -->

<%@ Page Language="C#" AutoEventWireup="True" %>
<%@ Import Namespace="System.Data" %>
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
   <script runat="server">
 
      ICollection CreateDataSource() 
      {
      
         // Create sample data for the DataGrid control.
         DataTable dt = new DataTable();
         DataRow dr;
 
         // Define the columns of the table.
         dt.Columns.Add(new DataColumn("IntegerValue", typeof(Int32)));
         dt.Columns.Add(new DataColumn("StringValue", typeof(string)));
         dt.Columns.Add(new DataColumn("CurrencyValue", typeof(double)));
         dt.Columns.Add(new DataColumn("BooleanValue", typeof(bool)));
 
         // Populate the table with sample values.
         for (int i = 0; i < 5; i++) 
         {
            dr = dt.NewRow();
 
            dr[0] = i;
            dr[1] = "Item " + i.ToString();
            dr[2] = 1.23 * (i + 1);
            dr[3] = false;
 
            dt.Rows.Add(dr);
         }

         // To persist the data source between posts to the server, store
         // it in session state.  
         Session["Source"] = dt;
 
         DataView dv = new DataView(dt);
         return dv;

      }
 
      void Page_Load(Object sender, EventArgs e) 
      {
 
         // Load sample data only once, when the page is first loaded.
         if (!IsPostBack) 
         {
            // Make sure to set the header text before binding the data to 
            // the DataGrid control; otherwise, the change will not appear 
            // until the next time the page is refreshed.
            ItemsGrid.Columns[0].HeaderText = "Item";

            ItemsGrid.DataSource = CreateDataSource();
            ItemsGrid.DataBind();
         }

      }

      void Button_Click(Object sender, EventArgs e) 
      {

         double subtotal = 0.0;

         // Update the data source with the user's selection and 
         // calculate the subtotal.
         DataTable dt = UpdateSource(ref subtotal);

         // Display the subtotal in the footer section of the third column.
         ItemsGrid.Columns[2].FooterText = 
             "Subtotal: " + subtotal.ToString("c");

         // Create a DataView and bind it to the DataGrid control.
         DataView dv = new DataView(dt);
         ItemsGrid.DataSource = dv;
         ItemsGrid.DataBind();

      }

      // This version of UpdateSource updates the data source and 
      // calculates the subtotal.
      DataTable UpdateSource(ref double subtotal)
      {

         // Retrieve the data table from session state.
         DataTable dt = (DataTable)Session["Source"];

         // Iterate through the Items collection and update the data source
         // with the user's selections. If an item is selected, add the
         // amount of the item to the subtotal.
         foreach (DataGridItem item in ItemsGrid.Items)
         {

            // Retrieve the SelectCheckBox CheckBox control from the 
            // specified item (row) in the DataGrid control.
            CheckBox selection = (CheckBox)item.FindControl("SelectCheckBox");

            if (selection != null)
            {

               // Update the BooleanValue field with the value of the check box.
               dt.Rows[item.ItemIndex][3] = selection.Checked;

               // Add the value of the item to the subtotal if the item is
               // selected.
               if (selection.Checked)
               {
                  subtotal += 
                      Convert.ToDouble(item.Cells[2].Text.Substring(1));
               }

            }

         }

         // Save the data source.
         Session["Source"] = dt;

         return dt;

      }

      // This version of UpdateSource updates the data source only.
      DataTable UpdateSource()
      {

         // Retrieve the data table from session state.
         DataTable dt = (DataTable)Session["Source"];

         // Iterate through the Items collection and update the data source
         // with the user's selections. If an item is selected, add the
         // amount of the item to the subtotal.
         foreach (DataGridItem item in ItemsGrid.Items)
         {

            // Retrieve the SelectCheckBox CheckBox control from the 
            // specified item (row) in the DataGrid control.
            CheckBox selection = (CheckBox)item.FindControl("SelectCheckBox");

            if (selection != null)
            {

               // Update the BooleanValue field with the value of the check box.
               dt.Rows[item.ItemIndex][3] = selection.Checked;

            }

         }

         // Save the data source.
         Session["Source"] = dt;

         return dt;

      }

      void Selection_Change(Object sender, EventArgs e)
      {

         // Set the image for the header section of the first column in
         // the DataGrid control.
         ItemsGrid.Columns[0].HeaderImageUrl = List.SelectedItem.Value;

         // Create a DataView and bind it to the DataGrid control. This 
         // will refresh the DataGrid control with the updated header image.
         DataView dv = new DataView(UpdateSource());
         ItemsGrid.DataSource = dv;
         ItemsGrid.DataBind();

      }

   </script>
 
<head runat="server">
    <title>DataGridColumn HeaderImageUrl Example</title>
</head>
<body>
 
   <form id="form1" runat="server">
 
      <h3>DataGridColumn HeaderImageUrl Example</h3>

      Select an image for the header section of the first column.

      <br /><br />
 
      <b>Product List</b>
 
      <asp:DataGrid id="ItemsGrid"
           BorderColor="black"
           BorderWidth="1"
           CellPadding="3"
           ShowFooter="True"
           AutoGenerateColumns="False"
           runat="server">

         <HeaderStyle BackColor="#00aaaa">
         </HeaderStyle>

         <FooterStyle BackColor="#00aaaa">
         </FooterStyle>

         <Columns>

            <asp:BoundColumn DataField="IntegerValue"
                 HeaderImageUrl="image1.jpg"/>

            <asp:BoundColumn DataField="StringValue"
                 HeaderImageUrl="image2.jpg"/>

            <asp:BoundColumn DataField="CurrencyValue" 
                 DataFormatString="{0:c}"
                 HeaderImageUrl="image3.jpg">

               <ItemStyle HorizontalAlign="Right">
               </ItemStyle>

            </asp:BoundColumn>

            <asp:TemplateColumn
                 HeaderImageUrl="image4.jpg">

               <ItemTemplate>

                  <asp:CheckBox id="SelectCheckBox"
                       Text="Add to Cart"
                       Checked='<%# DataBinder.Eval(Container.DataItem, "BooleanValue") %>'
                       runat="server"/>

               </ItemTemplate>

            </asp:TemplateColumn>
 
         </Columns> 
 
      </asp:DataGrid>

      <br /><br />

      <asp:Button id="SubmitButton"
           Text="Submit"
           OnClick = "Button_Click"
           runat="server"/>
       
      <hr />

      Header image for first column: <br /> 

      <asp:DropDownList id="List"
           AutoPostBack="True"
           OnSelectedIndexChanged="Selection_Change"
           runat="server">

         <asp:ListItem Selected="True" Value="image1.jpg"> Image 1 </asp:ListItem>
         <asp:ListItem Value="image2.jpg"> Image 2 </asp:ListItem>
         <asp:ListItem Value="image3.jpg"> Image 3 </asp:ListItem>
         <asp:ListItem Value="image4.jpg"> Image 4 </asp:ListItem>

      </asp:DropDownList>
 
   </form>
 
</body>
</html>

<!-- </Snippet1> -->