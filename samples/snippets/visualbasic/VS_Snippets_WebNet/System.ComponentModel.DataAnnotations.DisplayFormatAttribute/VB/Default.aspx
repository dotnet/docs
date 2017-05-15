<!-- <Snippet10> -->
<%@ Page Language="VB" AutoEventWireup="true" 
CodeFile="Default.aspx.vb" 
Inherits="Default" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="~/Site.css" rel="stylesheet" type="text/css" />
</head>
<body>
     <h2>Example: <%=Title%></h2>
     
     <!-- Enable dynamic behavior -->
    <asp:DynamicDataManager ID="DynamicDataManager1" runat="server"
         AutoLoadForeignKeys="true" />
   
        
    <form id="form1" runat="server">
    
        <!-- Capture validation exceptions -->
        <asp:DynamicValidator ID="ValidatorID" ControlToValidate="GridView1" 
            runat="server" /> 
   
        <asp:GridView ID="GridView1" 
            runat="server" 
            DataSourceID="GridDataSource" 
            AutoGenerateColumns="false"  
            AutoGenerateEditButton="true"
            AllowPaging="true"
            PageSize="10"
            AllowSorting="true">
            <Columns>
                <asp:DynamicField DataField="Name" />
                <asp:DynamicField DataField="Size" />
                <asp:DynamicField DataField="StandardCost" />
                <asp:DynamicField DataField="SellStartDate" />
            </Columns>
       </asp:GridView>
    </form>
    
    <!-- Connect to the database -->
    <asp:LinqDataSource ID="GridDataSource" runat="server"  
        TableName="Products" EnableUpdate="true"
        ContextTypeName="AdventureWorksLTDataContext">
    </asp:LinqDataSource>
</body>
</html>
<!-- </Snippet10> -->