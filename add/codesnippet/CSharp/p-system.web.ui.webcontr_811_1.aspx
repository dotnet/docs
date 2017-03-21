        <!-- Retrieve and display data from array of string values -->
        <asp:LinqDataSource 
            ContextTypeName="MovieLibrary" 
            TableName="AvailableGenres" 
            ID="LinqDataSource1" 
            runat="server">
        </asp:LinqDataSource>
        <asp:DropDownList 
            DataSourceID="LinqDataSource1"
            runat="server" 
            ID="DropDownList1">
        </asp:DropDownList>
        
        <!-- Retrieve and display data from database -->
        <asp:LinqDataSource 
            ContextTypeName="ExampleDataContext" 
            TableName="Movies" 
            Select="Title"
            ID="LinqDataSource2" 
            runat="server">
        </asp:LinqDataSource>
        <asp:DropDownList 
            DataSourceID="LinqDataSource2"
            runat="server" 
            ID="DropDownList2">
        </asp:DropDownList>