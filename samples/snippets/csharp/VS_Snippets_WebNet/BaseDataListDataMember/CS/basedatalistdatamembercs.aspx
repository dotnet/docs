<!-- <Snippet1> -->

<%@ Page Language="C#" AutoEventWireup="True" %>
<%@ Import Namespace = "System.Data"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">
    <title> BaseDataList DataMember Example </title>
<script runat="server">

      // Create sample data for the DataGrid control with two tables, 
      // Employee and Customer.
      DataSet CreateDataSet()
      {
    
         // Create a table to store employee values.
         DataTable EmployeeTable = new DataTable("Employee");
         DataRow TempDataRow;
   
         // Define the columns for the Employee table.
         EmployeeTable.Columns.Add(
            new DataColumn("EmployeeName", typeof(string)));
         EmployeeTable.Columns.Add(
            new DataColumn("EmployeeID", typeof(int)));

         // Populate the Employee table.
         for (int i=1; i<=5; i++) 
         {
            TempDataRow = EmployeeTable.NewRow();
            TempDataRow[0] = "Employee " + i.ToString();
            TempDataRow[1] = (i+1700);

            EmployeeTable.Rows.Add(TempDataRow);
         }

         // Create a table to store customer values.
         DataTable CustomerTable = new DataTable("Customer");

         // Define the columns for the Customer table.
         CustomerTable.Columns.Add(
            new DataColumn("CustomerName", typeof(string)));
         CustomerTable.Columns.Add(
            new DataColumn("CustomerID", typeof(int)));

         // Populate the Customer table.
         for (int i=1; i<=5; i++) 
         {
            TempDataRow = CustomerTable.NewRow();
            TempDataRow[0] = "Customer " + i.ToString();
            TempDataRow[1] = (i+1700);

            CustomerTable.Rows.Add(TempDataRow);
         }

         // Create a DataSet and add the Employee and Customer tables.
         DataSet ds = new DataSet();
         ds.Tables.Add(EmployeeTable);
         ds.Tables.Add(CustomerTable);

         return ds;

      }
             
      void Page_Load(Object sender, EventArgs e) 
      {

         // The data source only needs to be bound to the DataList  
         // control the first time the page is accessed.    
         if(!IsPostBack)
         {

            // Create the sample data for the DataList control.
            ItemsGrid.DataSource = CreateDataSet();

            // The data source in this example contains multiple tables. 
            // Specify which table to display in the DataList control. 
            ItemsGrid.DataMember = "Customer";

            // Bind the data source to the control.
            ItemsGrid.DataBind();

         }

      }

      void Index_Change(Object sender, EventArgs e) 
      {

         // Create the sample data for the DataList control.
         ItemsGrid.DataSource = CreateDataSet();

         // The data source in this example contains multiple tables. 
         // Specify which table to display in the DataList control 
         // based on the user's selection from the DropDownList control. 
         ItemsGrid.DataMember = SourceList.SelectedItem.Text;

         // Bind the data source to the control. 
         ItemsGrid.DataBind();

      }

   </script>

</head>
<body>

   <form id="form1" runat="server">

      <h3> BaseDataList DataMember Example </h3>
      
      <asp:DataGrid id="ItemsGrid"
           AutoGenerateColumns="True" 
           runat="server">

         <headerstyle backcolor="#00aaaa"/>
</asp:DataGrid>

      <br /><br />

      Select the data source: <br />

      <asp:DropDownList id="SourceList"
           AutoPostBack="True"
           OnSelectedIndexChanged="Index_Change"
           runat="server">

         <asp:Listitem Selected="True">Customer</asp:Listitem>
         <asp:Listitem>Employee</asp:Listitem>

      </asp:DropDownList>

   </form>
 
</body>

</html>

<!-- </Snippet1> -->
