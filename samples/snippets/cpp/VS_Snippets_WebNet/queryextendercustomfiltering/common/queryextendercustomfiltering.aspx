<%-- <Snippet1> --%>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Custom Filter</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <asp:LinqDataSource ID="LinqDataSource1" runat="server" 
        ContextTypeName="AdventureWorksDataContext" EntityTypeName="" 
        TableName="Products">
    </asp:LinqDataSource>
    
    <asp:QueryExtender ID="QueryExtender1" runat="server" TargetControlID="LinqDataSource1">
        <asp:CustomExpression OnQuerying="FilterProducts"></asp:CustomExpression>
    </asp:QueryExtender>

    <asp:GridView ID="GridView1" runat="server"  
        DataSourceID="LinqDataSource1"   
        DataKeyNames="ProductID"  AllowPaging="True">
    </asp:GridView>
    </form>
</body>
</html>
<%-- </Snippet1>--%>

