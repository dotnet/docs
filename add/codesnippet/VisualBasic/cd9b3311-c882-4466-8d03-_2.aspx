        <asp:LinqDataSource 
          ContextTypeName="ExampleDataContext" 
          TableName="Products" 
          EnableInsert="true" 
          ID="LinqDataSource1" 
          runat="server">
        </asp:LinqDataSource>
        <asp:DetailsView 
          DataSourceID="LinqDataSource1" 
          AllowPaging="true" 
          ID="DetailsView1" 
          runat="server">
        </asp:DetailsView>
        New product name:<br />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <asp:button ID="Button1" 
          Text="Add new product with default values" 
          runat="server" 
		  onclick="Add_Click" />