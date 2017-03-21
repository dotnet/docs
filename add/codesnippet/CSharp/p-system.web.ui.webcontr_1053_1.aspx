        <asp:LinqDataSource 
            ContextTypeName="ExampleDataContext" 
            TableName="Products" 
            EnableUpdate="true"
            EnableInsert="true"
            ID="LinqDataSource1" 
            runat="server">
            <UpdateParameters>
              <asp:Parameter Name="Category" DefaultValue="Miscellaneous" />
            </UpdateParameters>
            <InsertParameters>
              <asp:Parameter Name="Category" DefaultValue="Miscellaneous" />
            </InsertParameters>
        </asp:LinqDataSource>
        <asp:GridView 
            DataSourceID="LinqDataSource1"
            ID="GridView1" 
            runat="server">
        </asp:GridView>