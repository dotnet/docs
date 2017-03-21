        <asp:LinqDataSource 
            ContextTypeName="ExampleDataContext" 
            TableName="Products"            
            Select="new(Name, Price * (1 - @Discount) As OnlinePrice)"
            OnSelecting="LinqDataSource_Selecting" 
            ID="LinqDataSource1" 
            runat="server">
        </asp:LinqDataSource>
        <asp:GridView 
            DataSourceID="LinqDataSource1" 
            ID="GridView1" 
            runat="server">
        </asp:GridView>