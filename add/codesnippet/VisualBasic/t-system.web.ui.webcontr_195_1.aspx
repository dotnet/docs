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