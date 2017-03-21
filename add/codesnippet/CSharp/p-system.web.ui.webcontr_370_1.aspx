      <asp:ListBox
        id ="ListBox1"
        runat="server"
        DataSourceID="SqlDataSource1"
        DataValueField="EmployeeID"
        DataTextField="LastName" />
    
<!-- Use a query string that includes empId=1 -->
    
<!-- Security Note: The SqlDataSource uses a QueryStringParameter,
     Security Note: which does not perform validation of input from the client.
     Security Note: To validate the value of the QueryStringParameter, handle the Selecting event. -->

      <asp:SqlDataSource
        id="SqlDataSource1"
        runat="server"
        ConnectionString="<%$ ConnectionStrings:MyNorthwind %>"
        SelectCommand="Select EmployeeID, LastName From Employees where EmployeeID = @empId">
        <SelectParameters>
          <asp:QueryStringParameter Name="empId" QueryStringField="empId" />
        </SelectParameters>
      </asp:SqlDataSource>