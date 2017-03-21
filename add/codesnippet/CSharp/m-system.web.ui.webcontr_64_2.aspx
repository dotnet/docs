      <asp:ListBox
        id ="ListBox2"
        runat="server"
        DataSourceID="AccessDataSource1"
        DataValueField="EmployeeID"
        DataTextField="LastName" />

      <asp:AccessDataSource
        id="AccessDataSource1"
        runat="server"
        DataFile="Northwind.mdb"
        SelectCommand="Select EmployeeID, LastName From Employees where EmployeeID = ?" />
      