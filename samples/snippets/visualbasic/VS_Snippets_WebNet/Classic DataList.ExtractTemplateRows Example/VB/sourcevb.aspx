<!--<Snippet1>-->
<%@ Page Language="VB" %>
<%@ Import Namespace="System.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    <script runat="server">
        Private Function CreateDataSource() As ICollection
            Dim dt As New DataTable()
            Dim dr As DataRow

            dt.Columns.Add(New DataColumn("StringValue", _
                GetType(String)))
            dt.Columns.Add(New DataColumn("PriceValue", _
                GetType(String)))
            dt.Columns.Add(New DataColumn("DescriptionValue", _
                GetType(String)))

            Dim i As Integer
            For i = 1 To 10
                dr = dt.NewRow()
                dr(0) = "Item " + i.ToString()
                dr(1) = String.Format("{0:C}", (1.23 * (i + 1)))
                dr(2) = "Description for Item " + i.ToString()
                dt.Rows.Add(dr)
            Next

            Dim dv As New DataView(dt)
            Return dv
        End Function

        Private Sub Page_Load(ByVal sender As Object, _
            ByVal e As EventArgs)

            If Not IsPostBack Then
                DataList1.DataSource = CreateDataSource()
                DataList1.DataBind()
            End If
        End Sub
    </script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>
        ExtractTemplateRows Example
    </title>
</head>
<body>
    <form id="form1" runat="server">

    <h3>DataList ExtractTemplateRows Example</h3>

    <asp:DataList id="DataList1" runat="server"
        BorderColor="black"
        CellPadding="3"
        Font-Names="Arial, Helvetica"
        Font-Size="9pt"
        ExtractTemplateRows="true"
        GridLines="Both">

        <HeaderStyle BackColor="#aaaadd" />
        <AlternatingItemStyle BackColor="#efefef" />

        <HeaderTemplate>
        <asp:Table id="Table1" runat="server">
            <asp:TableRow>
                <asp:TableHeaderCell
                    ColumnSpan="2">
                    Items List
                </asp:TableHeaderCell>
            </asp:TableRow>
        </asp:Table>
        </HeaderTemplate>

        <ItemTemplate>
            <asp:Table id="Table2" runat="server">
                <asp:TableRow>
                    <asp:TableCell 
                        Text='<%# Eval("StringValue") %>'>
                    </asp:TableCell>
                    <asp:TableCell 
                        HorizontalAlign="Right"
                        Text='<%# Eval("PriceValue") %>'>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell
                        ColumnSpan="2" 
                        Text='<%# Eval("DescriptionValue") %>'>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </ItemTemplate> 
    </asp:DataList>
 
   </form>
</body>
</html>
<!--</Snippet1>-->
