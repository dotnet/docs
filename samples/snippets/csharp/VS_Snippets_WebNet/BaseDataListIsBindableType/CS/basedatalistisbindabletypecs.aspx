<!-- <Snippet1> -->

<%@ Page Language="C#" AutoEventWireup="True" %>
<%@ Import Namespace="System.Data" %>
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
   <script runat="server">
 
      DataView CreateDataSource() 
      {
      
         // Create sample data for the DataGrid control.
         DataTable dt = new DataTable();
         DataRow dr;
 
         // Define the columns of the table.
         dt.Columns.Add(new DataColumn("IntegerValue", typeof(Int32)));
         dt.Columns.Add(new DataColumn("StringValue", typeof(string)));
         dt.Columns.Add(new DataColumn("CurrencyValue", typeof(double)));
 
         // Populate the table with sample values.
         for (int i = 0; i < 9; i++) 
         {
            dr = dt.NewRow();
 
            dr[0] = i;
            dr[1] = "Item " + i.ToString();
            dr[2] = 1.23 * (i + 1);
 
            dt.Rows.Add(dr);
         }
 
         DataView dv = new DataView(dt);
         return dv;
      }
 
      void Page_Load(Object sender, EventArgs e) 
      {
 
         // Load sample data only once when the page is first loaded.
         if (!IsPostBack) 
         {

            // Retrieve sample data.
            DataView Source = CreateDataSource();


            // Bind the data source to the DataGrid control if each column  
            // in the data source contains a data type that is compatible  
            // with the DataGrid; otherwise, display an error message. 
            if(ValidateSourceTypes(Source))
            {

               ItemsGrid.DataSource = Source;
               ItemsGrid.DataBind();

            }
            else
            {

               Message.Text = "The data source is not compatible with the DataGrid control.";

            }

         }

      }

      bool ValidateSourceTypes(DataView Source)
      {
       
         // Test the data type of each column in the data source to make 
         // sure it is compatible with the DataGrid control.

         // Initialize the success flag to true.
         bool Success = true;

         // Iterate through each column of the data source and test the 
         // data type for compatibility with the DataGrid control. 
         foreach(DataColumn column in Source.Table.Columns)
         {
            if(!BaseDataList.IsBindableType(column.DataType))
            {
               Success = false;
            }
         }

         return Success;

      }

   </script>
 
<head runat="server">
    <title>BaseDataList IsBindableType Example</title>
</head>
<body>
 
   <form id="form1" runat="server">
 
      <h3>BaseDataList IsBindableType Example</h3>
 
      <asp:DataGrid id="ItemsGrid"
           BorderColor="black"
           BorderWidth="1"
           CellPadding="3"
           GridLines="Both"
           AutoGenerateColumns="true"
           runat="server">

         <HeaderStyle BackColor="#00aaaa">
         </HeaderStyle> 
 
      </asp:DataGrid>

      <br /><br />

      <asp:Label id="Message" 
           runat="server"/>       

   </form>
 
</body>
</html>

<!-- </Snippet1> -->
