<!-- <Snippet1> -->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        SqlDataSource1.SelectParameters("SearchTerm").DefaultValue = _
            Server.HtmlEncode(TextBox1.Text)
        Label1.Text = "Searching for '" & _
            Server.HtmlEncode(TextBox1.Text) & "'"

    End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AsyncPostBackTrigger Example</title>
</head>
<body>
    <form id="form1" defaultbutton="Button1"
          defaultfocus="TextBox1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server" />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button ID="Button1" Text="Submit" 
                        OnClick="Button1_Click" runat="server"  />
            <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" 
                             runat="server">
                <Triggers>
                  <asp:AsyncPostBackTrigger ControlID="Button1" />
                </Triggers>
                <ContentTemplate>
                    <hr />
                    <asp:Label ID="Label1" runat="server"/>
                    <br />
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True"
                        AllowSorting="True"
                        DataSourceID="SqlDataSource1">
                        <EmptyDataTemplate>
                        Enter a search term.
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
        </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->
