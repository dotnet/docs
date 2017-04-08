<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Filter Demo</title>
</head>
<body>
<%--<Snippet1>--%>
<form id="form1" runat="server">
  Make More: <asp:CheckBox ID="MakeCheckBox" runat="server" />

  <asp:LinqDataSource ID="LinqDataSource1"  
      ContextTypeName="FilterDemo.AdventureWorksDataContext"  
      TableName="Products" runat="server"> 
  </asp:LinqDataSource>

  <asp:QueryExtender runat="server"    
      TargetControlID="LinqDataSource1">
    <asp:PropertyExpression>
      <asp:ControlParameter ControlID="MakeCheckBox" Name="MakeFlag" />
    </asp:PropertyExpression>
  </asp:QueryExtender>

  <asp:GridView ID="GridView1" runat="server"  
      DataSourceID="LinqDataSource1" AllowPaging="True"    
      DataKeyNames="ProductID>
  </asp:GridView>
</form>
<%--</Snippet1>--%>
</body>
</html>



