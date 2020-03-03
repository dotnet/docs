<!-- <Snippet1> -->

<%@ Page Language="VB" AutoEventWireup="True" %>
<%@ Import Namespace = "System.Data"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">
    <title> BaseDataList DataMember Example </title>
<script runat="server">

      ' Create sample data for the DataGrid control with two tables,
      ' Employee and Customer.
      Function CreateDataSet() As DataSet
    
         ' Create a table to store employee values.
         Dim EmployeeTable As DataTable = New DataTable("Employee")
         Dim TempDataRow As DataRow
   
         ' Define the columns for the Employee table.
         EmployeeTable.Columns.Add( _
            New DataColumn("EmployeeName", GetType(String)))
         EmployeeTable.Columns.Add( _
            New DataColumn("EmployeeID", GetType(Integer)))

         ' Populate the Employee table.
         Dim i As Integer

         For i=1 To 5 
         
            TempDataRow = EmployeeTable.NewRow()
            TempDataRow(0) = "Employee " & i.ToString()
            TempDataRow(1) = (i+1700)

            EmployeeTable.Rows.Add(TempDataRow)

         Next

         ' Create a table to store customer values.
         Dim CustomerTable As DataTable = New DataTable("Customer")

         ' Define the columns for the Customer table.
         CustomerTable.Columns.Add( _
            New DataColumn("CustomerName", GetType(String)))
         CustomerTable.Columns.Add( _
            New DataColumn("CustomerID", GetType(Integer)))

         ' Populate the Customer table.
         For i=1 To 5  

            TempDataRow = CustomerTable.NewRow()
            TempDataRow(0) = "Customer " & i.ToString()
            TempDataRow(1) = (i+1700)

            CustomerTable.Rows.Add(TempDataRow)
         
         Next

         ' Create a DataSet and add the Employee and Customer tables.
         Dim ds As DataSet = New DataSet()
         ds.Tables.Add(EmployeeTable)
         ds.Tables.Add(CustomerTable)

         Return ds

      End Function
             
      Sub Page_Load(sender As Object, e As EventArgs) 

         ' The data source only needs to be bound to the DataList  
         ' control the first time the page is accessed.    
         If Not IsPostBack Then

            ' Create the sample data for the DataList control.
            ItemsGrid.DataSource = CreateDataSet()

            ' The data source in this example contains multiple tables.  
            ' Specify which table to display in the DataList control. 
            ItemsGrid.DataMember = "Customer"

            ' Bind the data source to the control.
            ItemsGrid.DataBind()

         End If

      End Sub

      Sub Index_Change(sender As Object, e As EventArgs) 

         ' Create the sample data for the DataList control.
         ItemsGrid.DataSource = CreateDataSet()

         ' The data source in this example contains multiple tables. 
         ' Specify which table to display in the DataList control 
         ' based on the user's selection from the DropDownList control. 
         ItemsGrid.DataMember = SourceList.SelectedItem.Text

         ' Bind the data source to the control. 
         ItemsGrid.DataBind()

      End Sub

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
