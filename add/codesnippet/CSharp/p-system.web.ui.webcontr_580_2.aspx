        <asp:LinqDataSource 
            ContextTypeName="ExampleDataContext" 
            TableName="Products" 
            GroupBy="Category"
            Select="new(Key as ProductCategory, 
                    Average(Price) as AvePrice)"
            ID="LinqDataSource1" 
            runat="server">
        </asp:LinqDataSource>
        <asp:GridView 
            AllowPaging="true"
            DataSourceID="LinqDataSource1"
            ID="GridView1" 
            runat="server">
        </asp:GridView>