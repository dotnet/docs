<%-- <Snippet1> --%>
<%@ Page Language="C#" AutoEventWireup="true"  
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:AWLTConnectionString %>" 
            SelectCommand="SELECT ProductID, Name, ProductNumber, 
                ListPrice, Weight, ModifiedDate FROM SalesLT.Product">
        </asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" 
            AutoGenerateColumns="False" 
            DataKeyNames="ProductID" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="ProductID" 
                    HeaderText="ProductID" 
                    InsertVisible="False" ReadOnly="True" 
                    SortExpression="ProductID" 
                    DataFormatString="{0:D6}" />
                <asp:BoundField DataField="Name" 
                    HeaderText="Name" 
                    SortExpression="Name" 
                    DataFormatString="{0}" />
                <asp:BoundField DataField="ProductNumber" 
                    HeaderText="ProductNumber" 
                    SortExpression="ProductNumber" 
                    DataFormatString= "#{0}" />
                <asp:BoundField DataField="ListPrice" 
                    HeaderText="ListPrice" 
                    SortExpression="ListPrice"
                    DataFormatString="{0:C}" />
                <asp:BoundField DataField="Weight" 
                    HeaderText="Weight" 
                    SortExpression="Weight" 
                    DataFormatString="{0:F3}" />
                <asp:BoundField DataField="ModifiedDate" 
                    HeaderText="ModifiedDate" 
                    SortExpression="ModifiedDate" 
                    DataFormatString="{0:d}" />
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
<%-- </Snippet1> --%>
