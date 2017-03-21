        Enter number of manufacturing days:
        <asp:TextBox Text="1" ID="TextBox1" runat="server"></asp:TextBox><br />
        <asp:Button ID="Button1" runat="server" Text="Refresh" /><br />
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" DataSourceID="LinqDataSource1">
            <Columns>
                <asp:boundfield DataField="Name" 
                    HeaderText="Name" 
                    ReadOnly="True" 
                    SortExpression="Name">
                </asp:boundfield>
                <asp:boundfield DataField="NumberToManufacture" 
                    HeaderText="Number to Manufacture" 
                    ReadOnly="True" 
                    SortExpression="NumberToManufacture">
                </asp:boundfield>
            </Columns>
        </asp:GridView>
        <asp:LinqDataSource 
            ContextTypeName="ExampleDataContext" 
            TableName="Products"
            Where="DaysToManufacture > 0 "
            Select="new (Name, @Days / DaysToManufacture As NumberToManufacture)" 
            ID="LinqDataSource1" 
            runat="server">
          <SelectParameters>
            <asp:ControlParameter 
                Type="Decimal" 
                Name="Days" 
                ControlID="TextBox1" 
                DefaultValue="1" />
          </SelectParameters>
        </asp:LinqDataSource>