<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Filter Demo</title>
</head>
<body>
<%-- <Snippet1> --%>
    <form id="form1" runat="server">

      <asp:TextBox ID="FromTextBox" runat="server"></asp:TextBox>
      <asp:TextBox ID="ToTextBox" runat="server"></asp:TextBox>
      <asp:Button ID="Button1" runat="server" Text="Button" />

      <asp:LinqDataSource ID="LinqDataSource1" 
          ContextTypeName=" FilterDemo.AdventureworksDataContext"  
          runat="server" TableName="Products">
      </asp:LinqDataSource>

      <asp:QueryExtender runat="server"  
          TargetControlID="LinqDataSource1">

      <asp:RangeExpression DataField="ListPrice"  
          MinType="Inclusive" MaxType="Exclusive">
      <asp:ControlParameter ControlID="FromTextBox" />
      <asp:ControlParameter ControlID="ToTextBox" />
      </asp:RangeExpression>
  </asp:QueryExtender>

  <asp:GridView ID="GridView1" runat="server"    
      DataSourceID="LinqDataSource1" AllowPaging="True" >
  </asp:GridView>

  </form>
<%-- </Snippet1>--%>
</body>
</html>



