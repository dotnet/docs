<!-- <Snippet1> -->
<%@Page  Language="C#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
private void OnDelete(Object sender, EventArgs e) {
    SqlDataSource1.Delete();
}
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
        <form id="form1" runat="server">

            <asp:SqlDataSource
                id="SqlDataSource1"
                runat="server"
                ConnectionString="<%$ ConnectionStrings:MyNorthwind%>"
                SelectCommand="SELECT OrderID FROM Orders"
                DeleteCommand="DELETE FROM [Order Details] WHERE OrderID=@OrderID;DELETE FROM Orders WHERE OrderID=@OrderID;">
                <DeleteParameters>
                    <asp:ControlParameter Name="OrderID" ControlId="DropDownList1" PropertyName="SelectedValue" />
                </DeleteParameters>
            </asp:SqlDataSource>

            <asp:DropDownList
                id="DropDownList1"
                runat="server"
                DataTextField="OrderID"
                DataValueField="OrderID"
                DataSourceID="SqlDataSource1">
            </asp:DropDownList>

            <asp:Button
                id="Button1"
                runat="server"
                Text="Delete Order"
                OnClick="OnDelete">
            </asp:Button>

        </form>
    </body>
</html>
<!-- </Snippet1> -->