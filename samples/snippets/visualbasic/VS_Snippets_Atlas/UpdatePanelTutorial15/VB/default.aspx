<!-- <Snippet1> -->

<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    ' <Snippet3> 
    Protected Property ProductInfo() As SortedList
        Get
            If ViewState("ProductInfo") IsNot Nothing Then
                Return CType(ViewState("ProductInfo"), SortedList)
            Else
                Return New SortedList()
            End If
        End Get
        Set(ByVal value As SortedList)
            ViewState("ProductInfo") = value
        End Set
    End Property
    ' </Snippet3>
    
    Protected Sub Category1Button_Click(ByVal sender As Object, ByVal e As EventArgs)
        SqlDataSource1.SelectParameters(0).DefaultValue = "1"        
    End Sub

    Protected Sub Category2Button_Click(ByVal sender As Object, ByVal e As EventArgs)
        SqlDataSource1.SelectParameters(0).DefaultValue = "2"
    End Sub

    ' <Snippet2>
    Protected Sub DataList1_ItemDataBound(ByVal sender As Object, ByVal e As DataListItemEventArgs)
        Dim label As Label = CType(e.Item.FindControl("ProductIDLabel"), Label)
        Dim button As Button = CType(e.Item.FindControl("Button1"), Button)
        Dim textbox As TextBox = CType(e.Item.FindControl("TextBox1"), TextBox)
        button.OnClientClick = "GetQuantity(" & label.Text & ",'" & textbox.ClientID & "','" & _
            label.ClientID + "','" & button.ClientID & "')"
        Dim ProductInfo As SortedList = Me.ProductInfo
        If (ProductInfo.ContainsKey(label.Text)) Then
            textbox.Text = ProductInfo(label.Text).ToString()
        End If
    End Sub
    ' </Snippet2>

    ' <Snippet4>
    Protected Sub Page_Load()
        If (ScriptManager1.IsInAsyncPostBack) Then
            Dim ProductInfo As SortedList = Me.ProductInfo
            For Each d As DataListItem In DataList1.Items
                Dim label As Label = CType(d.FindControl("ProductIDLabel"), Label)
                Dim textbox As TextBox = CType(d.FindControl("TextBox1"), TextBox)
                If (textbox.Text.Length > 0) Then
                    ProductInfo(label.Text) = textbox.Text
                End If
            Next
            Me.ProductInfo = ProductInfo
        End If
    End Sub
    ' </Snippet4>
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Products Display</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
                <Services>
                    <asp:ServiceReference Path="ProductQueryService.asmx" />
                </Services>
                <Scripts>
                    <asp:ScriptReference Path="ProductQueryScript.js" />
                </Scripts>
            </asp:ScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" ChildrenAsTriggers="False" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:Button ID="Category1Button" runat="server" Text="Category 1" OnClick="Category1Button_Click" />
                    <asp:Button ID="Category2Button" runat="server" OnClick="Category2Button_Click" Text="Category 2" />
                    <asp:DataList ID="DataList1" runat="server" DataKeyField="ProductID" DataSourceID="SqlDataSource1"
                        Width="400px" OnItemDataBound="DataList1_ItemDataBound">
                        <ItemTemplate>
                            ProductName:
                            <asp:Label ID="ProductNameLabel" runat="server" Text='<%# Eval("ProductName") %>'>
                            </asp:Label><br />
                            ProductID:
                            <asp:Label ID="ProductIDLabel" runat="server" Text='<%# Eval("ProductID") %>'></asp:Label><br />
                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                            <asp:Button ID="Button1" runat="server" Text="Get Quantity from Web Service" /><br />
                        </ItemTemplate>
                    </asp:DataList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>"
                        SelectCommand="SELECT [ProductName], [ProductID] FROM [Alphabetical list of products] WHERE ([CategoryID] = @CategoryID)">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="1" Name="CategoryID" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="Category1Button" />
                    <asp:AsyncPostBackTrigger ControlID="Category2Button" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->
