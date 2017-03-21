        <asp:DropDownList AutoPostBack="true" ID="DropDownList1" runat="server">
            <asp:ListItem Value="Category"></asp:ListItem>
            <asp:ListItem Value="Price"></asp:ListItem>
        </asp:DropDownList>
        <asp:LinqDataSource 
            ContextTypeName="ExampleDataContext" 
            TableName="Products" 
            AutoGenerateOrderByClause="true"
            ID="LinqDataSource1" 
            runat="server">
            <OrderByParameters>
              <asp:ControlParameter
                 ControlID="DropDownList1" 
                 Type="String" />
            </OrderByParameters>
        </asp:LinqDataSource>
        <asp:GridView 
            DataSourceID="LinqDataSource1"
            ID="GridView1" 
            runat="server">
        </asp:GridView>