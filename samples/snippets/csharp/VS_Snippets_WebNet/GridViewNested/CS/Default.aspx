<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" Trace="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MarcGelNorthwind %>"
            SelectCommand="SELECT [CustomerID], [CompanyName] FROM [Customers]"></asp:SqlDataSource>
    
    </div>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            DataKeyNames="CustomerID" DataSourceID="SqlDataSource1" OnRowDataBound="GridView1_RowDataBound">
            <Columns>
                <asp:BoundField DataField="CustomerID" HeaderText="CustomerID" ReadOnly="True" SortExpression="CustomerID" />
                <asp:BoundField DataField="CompanyName" HeaderText="CompanyName" SortExpression="CompanyName" />
                <asp:TemplateField HeaderText="Orders">
                    <ItemTemplate>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:MarcGelNorthwind %>"
                            SelectCommand="SELECT [OrderID], [OrderDate] FROM [Orders] WHERE ([CustomerID] = @CustomerID)">
                            <SelectParameters>
                                <asp:Parameter Name="CustomerID" Type="String" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False"
                            DataSourceID="SqlDataSource2" DataKeyNames="OrderID">
                            <Columns>
                                <asp:BoundField DataField="OrderID" HeaderText="OrderID" InsertVisible="False" ReadOnly="True"
                                    SortExpression="OrderID" />
                                <asp:BoundField DataField="OrderDate" HeaderText="OrderDate" SortExpression="OrderDate" />
                            </Columns>
                        </asp:GridView>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <RowStyle VerticalAlign="Top" />
        </asp:GridView>
    </form>
</body>
</html>
