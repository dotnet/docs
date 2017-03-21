    <asp:LinqDataSource ID="LinqDataSource1" runat="server" 
        ContextTypeName="AdventureWorksLTDataClassesDataContext"
        EnableDelete="True" EnableInsert="True" EnableUpdate="True" 
        TableName="SalesOrderDetails">
    </asp:LinqDataSource>

    <asp:GridView ID="GridView1" runat="server" 
        AutoGenerateColumns="False" 
        DataKeyNames="SalesOrderID,SalesOrderDetailID"
        DataSourceID="LinqDataSource1">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" 
                ShowEditButton="True" />
            <asp:BoundField DataField="SalesOrderID" 
                HeaderText="SalesOrderID" ReadOnly="True"
                SortExpression="SalesOrderID" />
            <asp:BoundField DataField="SalesOrderDetailID" 
                HeaderText="SalesOrderDetailID" InsertVisible="False"
                ReadOnly="True" SortExpression="SalesOrderDetailID" />
            <asp:BoundField DataField="OrderQty" 
                HeaderText="OrderQty" SortExpression="OrderQty" />
            <asp:BoundField DataField="ProductID" 
                HeaderText="ProductID" SortExpression="ProductID" />
            <asp:BoundField DataField="UnitPrice" 
                HeaderText="UnitPrice" SortExpression="UnitPrice" />
            <asp:BoundField DataField="ModifiedDate" 
                HeaderText="ModifiedDate" SortExpression="ModifiedDate" />
        </Columns>
    </asp:GridView>