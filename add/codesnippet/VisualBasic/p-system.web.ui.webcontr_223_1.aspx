        <asp:DropDownList AutoPostBack="true" ID="DropDownList1" runat="server">
            <asp:ListItem Value="Sports"></asp:ListItem>
            <asp:ListItem Value="Garden"></asp:ListItem>
            <asp:ListItem Value="Auto"></asp:ListItem>
        </asp:DropDownList>
        <asp:LinqDataSource 
            ContextTypeName="ExampleDataContext" 
            TableName="Products" 
            AutoGenerateWhereClause="true"
            ID="LinqDataSource1" 
            runat="server">
            <WhereParameters>
                <asp:ControlParameter 
                    Name="Category" 
                    ControlID="DropDownList1" 
                    Type="String" />
            </WhereParameters>
        </asp:LinqDataSource>
        <asp:GridView 
            DataSourceID="LinqDataSource1"
            ID="GridView1" 
            runat="server">
        </asp:GridView>