<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    How many rows to display on this page:<br />
    <asp:DropDownList 
          AutoPostBack="true" 
          ID="rowsToDisplay" 
          runat="server" 
          onselectedindexchanged="rowsToDisplay_SelectedIndexChanged">
        <asp:ListItem Value="5"></asp:ListItem>
        <asp:ListItem Value="10" Selected="True"></asp:ListItem>
        <asp:ListItem Value="20"></asp:ListItem>
    </asp:DropDownList> 
    
    <asp:ObjectDataSource 
        SelectCountMethod="GetEmployeeCount" 
        EnablePaging="true" 
        TypeName="CustomerLogic" 
        SelectMethod="GetSubsetOfEmployees"
        MaximumRowsParameterName="maxRows"
        StartRowIndexParameterName="startRows"
        ID="ObjectDataSource1" 
        runat="server">
    </asp:ObjectDataSource>
    
    <asp:GridView 
        DataSourceID="ObjectDataSource1" 
        AllowPaging="true" 
        ID="GridView1" 
        runat="server">
    </asp:GridView>
    
    </div>
    </form>
</body>
</html>