<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Filter Demo</title>
</head>
<body>
<%--<Snippet1>--%>
<form id="form1" runat="server">
  Search: <asp:TextBox ID="SearchTextBox" runat="server" />
  <div>
  <asp:Button ID="Button1" runat="server" Text="Search"  />
  </div>

  <asp:LinqDataSource ID="LinqDataSource1"  
       ContextTypeName="AdventureWorksDataContext"  
       TableName="Products" runat="server"> 
  </asp:LinqDataSource>

  <asp:QueryExtender runat="server" 
       TargetControlID="LinqDataSource1">
    <asp:SearchExpression SearchType="StartsWith" DataFields="Name" >
      <asp:ControlParameter ControlID="SearchTextBox" />
    </asp:SearchExpression>
  </asp:QueryExtender>

  <asp:GridView ID="GridView1" runat="server"  
      DataSourceID="LinqDataSource1" AllowPaging="True" >
  </asp:GridView>
</form>



<%--</Snippet1>--%>
</body>
</html>



