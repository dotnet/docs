        <asp:LinqDataSource 
            ContextTypeName="ExampleDataContext" 
            TableName="Products" 
            Where="Price > 50"
            ID="LinqDataSource1" 
            runat="server">
        </asp:LinqDataSource>
        <asp:GridView 
            DataSourceID="LinqDataSource1"
            ID="GridView1" 
            runat="server">
        </asp:GridView>