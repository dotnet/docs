<!-- <Snippet1> -->
<%@ Page Language="C#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    //Protected Sub SqlDataSource1_Filtering(ByVal sender As Object, _
    //    ByVal e As System.Web.UI.WebControls.SqlDataSourceFilteringEventArgs)
    //    Label1.Text = e.ParameterValues(0).ToString()
    //End Sub


    protected void SqlDataSource1_Filtering(object sender, SqlDataSourceFilteringEventArgs e)
    {
        Label1.Text = e.ParameterValues[0].ToString();
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
    <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
        <form id="FORM1" runat="server">

            <p>Show all employees with the following title:
            <asp:DropDownList
                id="DropDownList1"
                runat="server"
                AutoPostBack="True">
                <asp:ListItem>Sales Representative</asp:ListItem>
                <asp:ListItem>Sales Manager</asp:ListItem>
                <asp:ListItem>Vice President, Sales</asp:ListItem>
            </asp:DropDownList></p>

            <asp:SqlDataSource
                id="SqlDataSource1"
                runat="server"
                ConnectionString="<%$ ConnectionStrings:NorthwindConnection %>"
                SelectCommand="SELECT EmployeeID,FirstName,LastName,Title FROM Employees"
                FilterExpression="Title='{0}'" OnFiltering="SqlDataSource1_Filtering">
                <FilterParameters>
                    <asp:ControlParameter Name="Title" ControlId="DropDownList1" PropertyName="SelectedValue"/>
                </FilterParameters>
            </asp:SqlDataSource><br />

            <asp:GridView
                id="GridView1"
                runat="server"
                DataSourceID="SqlDataSource1"
                AutoGenerateColumns="False">
                <columns>
                    <asp:BoundField Visible="False" DataField="EmployeeID" />
                    <asp:BoundField HeaderText="First Name" DataField="FirstName" />
                    <asp:BoundField HeaderText="Last Name" DataField="LastName" />
                </columns>
            </asp:GridView>
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

        </form>
    </body>
</html>
<!-- </Snippet1> -->