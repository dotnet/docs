<%--<Snippet5>--%>
<%@ Page Language="VB"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        GridView1.HeaderRow.TableSection = TableRowSection.TableHeader
    End Sub
</script>
  
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Display Customers</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" 
            AutoGenerateColumns="False"
            RowHeaderColumn="CustomerID"
            Caption="Customers"
            summary="This table shows a list of customers."
            DataKeyNames="CustomerID" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="CustomerID" 
                    HeaderText="Customer ID" 
                    InsertVisible="False" ReadOnly="True" 
                    SortExpression="CustomerID" />
                <asp:BoundField DataField="FirstName" 
                    HeaderText="FirstName" 
                    SortExpression="FirstName" />
                <asp:BoundField DataField="MiddleName" 
                    HeaderText="MiddleName" 
                    SortExpression="MiddleName" />
                <asp:BoundField DataField="LastName" 
                    HeaderText="LastName" 
                    SortExpression="LastName" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:AdventureWorksLTConnectionString %>" 
            SelectCommand="SELECT CustomerID, FirstName, MiddleName, 
                LastName FROM SalesLT.Customer">
        </asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
<%--</Snippet5>--%>
