<%@ Page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html  >
  <head id="Head1" runat="server">
    <title>GridView Example</title>
</head>
<body>
    <form id="form1" runat="server">

      <h3>GridView Example</h3>

      <!-- <Snippet1> -->
      <asp:sqldatasource id="CustomersSource"
        selectcommand="SELECT CustomerID, CompanyName, FirstName, LastName FROM SalesLT.Customer"
        connectionstring="<%$ ConnectionStrings:AWLTConnectionString %>" 
        runat="server"/>

      <asp:gridview id="CustomersGridView" 
        datasourceid="CustomersSource" 
        autogeneratecolumns="False"
        emptydatatext="No data available." 
        allowpaging="True" 
        runat="server" DataKeyNames="CustomerID">
          <Columns>
              <asp:BoundField DataField="CustomerID" HeaderText="CustomerID" 
                  InsertVisible="False" ReadOnly="True" SortExpression="CustomerID" />
              <asp:BoundField DataField="CompanyName" HeaderText="CompanyName" 
                  SortExpression="CompanyName" />
              <asp:BoundField DataField="FirstName" HeaderText="FirstName" 
                  SortExpression="FirstName" />
              <asp:BoundField DataField="LastName" HeaderText="LastName" 
                  SortExpression="LastName" />
          </Columns>
      </asp:gridview>
      <!-- </Snippet1> -->
    </form>
  </body>
</html>