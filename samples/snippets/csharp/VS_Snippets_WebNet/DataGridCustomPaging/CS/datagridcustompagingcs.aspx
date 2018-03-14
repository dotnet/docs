<!-- <Snippet1> -->
<%@ Page Language="C#" AutoEventWireup="True" %>
<%@ Import Namespace="System.Data" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >

   <script runat="server">

      // Normally, an entire data source is loaded in the DataGrid control, 
      // which can take up a lot of resources. This example uses custom 
      // paging, which loads only the segment of data needed to fill a
      // single page. In order to query for the appropriate segment of
      // data, the index of the first item displayed on a page must be
      // tracked as the user navigates between pages.
      int startIndex = 0;

      ICollection CreateDataSource() 
      {

         // Create sample data for the DataGrid control.
         DataTable dt = new DataTable();
         DataRow dr;

         // Define the columns of the table.
         dt.Columns.Add(new DataColumn("IntegerValue", typeof(Int32)));
         dt.Columns.Add(new DataColumn("StringValue", typeof(string)));
         dt.Columns.Add(new DataColumn("DateTimeValue", typeof(string)));
         dt.Columns.Add(new DataColumn("BoolValue", typeof(bool)));

         // Populate the table with sample values. When using custom paging,
         // a query should only return enough data to fill a single page, 
         // beginning at the start index.
         for (int i = startIndex; i < (startIndex + MyDataGrid.PageSize); i++) 
         {
             dr = dt.NewRow();

             dr[0] = i;
             dr[1] = "Item " + i.ToString();
             dr[2] = DateTime.Now.ToShortDateString();
             dr[3] = (i % 2 != 0) ? true : false;

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

            // Set the virtual item count, which specifies the total number
            // items displayed in the DataGrid control when custom paging
            // is used.
            MyDataGrid.VirtualItemCount = 200;

            // Retrieve the segment of data to display on the page from the
            // data source and bind it to the DataGrid control.
            BindGrid();

         }

      }

      void MyDataGrid_Page(Object sender, DataGridPageChangedEventArgs e) 
      {

         // For the DataGrid control to navigate to the correct page when
         // paging is allowed, the CurrentPageIndex property must be updated
         // programmatically. This process is usually accomplished in the
         // event-handling method for the PageIndexChanged event.

         // Set CurrentPageIndex to the page the user clicked.
         MyDataGrid.CurrentPageIndex = e.NewPageIndex;

         // Calculate the index of the first item to display on the page 
         // using the current page index and the page size.
         startIndex = MyDataGrid.CurrentPageIndex * MyDataGrid.PageSize;

         // Retrieve the segment of data to display on the page from the 
         // data source and bind it to the DataGrid control.
         BindGrid();

      }

      void BindGrid() 
      {

         MyDataGrid.DataSource = CreateDataSource();
         MyDataGrid.DataBind();

      }

   </script>

<head runat="server">
    <title> DataGrid Custom Paging Example </title>
</head>
<body>

   <form id="form1" runat="server">
 
      <h3> DataGrid Custom Paging Example </h3>

      <asp:DataGrid id="MyDataGrid" 
           AllowCustomPaging="True" 
           AllowPaging="True" 
           PageSize="10" 
           OnPageIndexChanged="MyDataGrid_Page" 
           runat="server">

         <HeaderStyle BackColor="Navy" 
                      ForeColor="White" 
                      Font-Bold="True" />

         <PagerStyle Mode="NumericPages" 
                     HorizontalAlign="Right" />

      </asp:DataGrid>

   </form>

</body>
</html>

<!-- </Snippet1> -->
