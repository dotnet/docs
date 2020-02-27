<!-- <Snippet2> -->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    Protected Sub Search_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        SqlDataSource1.SelectParameters("SearchTerm").DefaultValue = _
            Server.HtmlEncode(SearchField.Text)
        Label1.Text = "Searching for '" & _
            Server.HtmlEncode(SearchField.Text) & "'"
    End Sub
    
    Protected Sub ExampleProductSearch_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        SqlDataSource1.SelectParameters("SearchTerm").DefaultValue = _
            Server.HtmlEncode(ExampleProductSearch.Text)
        Label1.Text = "Searching for '" & _
            Server.HtmlEncode(ExampleProductSearch.Text) & "'"
        SearchField.Text = ExampleProductSearch.Text
        UpdatePanel2.Update()
    End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head2" runat="server">
    <title>Declarative Trigger Example</title>
    <style type="text/css">
    body {
        font-family: Lucida Sans Unicode;
        font-size: 10pt;
    }
    button {
        font-family: tahoma;
        font-size: 8pt;
    }
    </style>
</head>
<body>
    <form id="form1" runat="server"
          defaultbutton="SearchButton" defaultfocus="SearchField">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server" />
            Search for products in the Northwind database. For example,
            find products with 
            <asp:LinkButton ID="ExampleProductSearch" Text="Louisiana" runat="server" OnClick="ExampleProductSearch_Click">
            </asp:LinkButton> in the title.&nbsp;<br /><br />
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
            <asp:TextBox ID="SearchField" runat="server"></asp:TextBox>
            <asp:Button ID="SearchButton" Text="Submit" OnClick="Search_Click"
                runat="server" />
            </ContentTemplate>
            </asp:UpdatePanel>
            <fieldset>
            <legend>Northwind Products</legend>
            <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" 
                             runat="server">
                <Triggers>
                <asp:AsyncPostBackTrigger ControlID="SearchButton" />
                <asp:AsyncPostBackTrigger ControlID="ExampleProductSearch" />
                </Triggers>
                <ContentTemplate>
                    <asp:Label ID="Label1" runat="server"/>
                    <br />
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True"
                        AllowSorting="True" DataSourceID="SqlDataSource1">
                        <EmptyDataTemplate>
                        No results to display.
                        </EmptyDataTemplate>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                        ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>"
                        SelectCommand="SELECT [ProductName], [UnitsInStock] FROM 
                        [Alphabetical list of products] WHERE ([ProductName] LIKE 
                        '%' + @SearchTerm + '%')">
                        <SelectParameters>
                            <asp:Parameter Name="SearchTerm" Type="String" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </ContentTemplate>
            </asp:UpdatePanel>
            </fieldset>
        </div>
    </form>
</body>
</html>
<!-- </Snippet2> -->
