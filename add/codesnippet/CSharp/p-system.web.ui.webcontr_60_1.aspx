        <asp:Literal ID="Literal1" runat="server"></asp:Literal> Total Records
        <br />
        <asp:LinqDataSource 
          AutoPage="true"
          ID="LinqDataSource1" 
          runat="server" 
          ContextTypeName="ExampleDataContext" 
          TableName="Customers" 
          onselected="LinqDataSource1_Selected">
        </asp:LinqDataSource>
        <asp:GridView 
          ID="GridView1" 
          runat="server" 
          AllowPaging="true" 
          AutoGenerateColumns="True" 
          DataKeyNames="CustomerID" 
          DataSourceID="LinqDataSource1">
        </asp:GridView>