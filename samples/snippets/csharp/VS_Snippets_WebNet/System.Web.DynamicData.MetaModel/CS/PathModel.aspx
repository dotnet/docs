<!-- <Snippet1> -->
<%@ Page Language="C#" AutoEventWireup="true" 
CodeFile="PathModel.aspx.cs" 
Inherits="PathModel" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Path Model</title>
</head>
<body>
    <asp:DynamicDataManager ID="DynamicDataManager1" runat="server"
        AutoLoadForeignKeys="true" />
    
    <h3>GetActionPath</h3>
       
    <form id="form1" runat="server">
        <asp:GridView ID="GridDataSource1" runat="server"
        AutoGenerateColumns="false"
        DataSourceID="LinqDataSource1"
        AllowPaging="true">
        <Columns>
        <asp:TemplateField>
          <ItemTemplate>
            <asp:HyperLink ID="HyperLink1" runat="server" 
            NavigateUrl="<%#EvaluateActionPath()%>">ListDetails</asp:HyperLink>
          </ItemTemplate>
         </asp:TemplateField>
          <asp:DynamicField DataField="FirstName" />
          <asp:DynamicField DataField="LastName" />
        </Columns>
      </asp:GridView>

        <asp:LinqDataSource ID="LinqDataSource1" runat="server" 
        TableName="Customers"
        ContextTypeName="AdventureWorksLTDataContext" >
      </asp:LinqDataSource>
    </form>
</body>

</html>

<!-- </Snippet1> -->