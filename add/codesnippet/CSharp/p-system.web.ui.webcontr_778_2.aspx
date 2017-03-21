        <asp:DropDownList AutoPostBack="true" ID="DropDownList1" runat="server">
            <asp:ListItem Value="0"></asp:ListItem>
            <asp:ListItem Value="25"></asp:ListItem>
            <asp:ListItem Value="100"></asp:ListItem>
            <asp:ListItem Value="400"></asp:ListItem>
        </asp:DropDownList>
        <asp:LinqDataSource 
            ContextTypeName="ExampleDataContext" 
            TableName="Products" 
            Where="Price>@UserPrice"
            ID="LinqDataSource1" 
            runat="server">
            <WhereParameters>
                <asp:ControlParameter 
                    Name="UserPrice" 
                    DefaultValue="0" 
                    ControlID="DropDownList1" 
                    Type="Int32" />
            </WhereParameters>
        </asp:LinqDataSource>
        <asp:GridView 
            DataSourceID="LinqDataSource1"
            ID="GridView1" 
            runat="server">
        </asp:GridView>