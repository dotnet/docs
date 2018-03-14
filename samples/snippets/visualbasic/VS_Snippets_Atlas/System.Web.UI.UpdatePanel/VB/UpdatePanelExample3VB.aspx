<!-- <Snippet3> -->

<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    Private Sub ChangeQuantity(ByVal Sender As Button, ByVal delta As Integer)
        Dim quantityLabel As Label = CType(Sender.FindControl("QuantityLabel"), Label)
        Dim currentQuantity As Integer = Int32.Parse(quantityLabel.Text)
        currentQuantity = Math.Max(0, currentQuantity + delta)
        quantityLabel.Text = currentQuantity.ToString(System.Globalization.CultureInfo.InvariantCulture)
    End Sub

    Private Sub OnDecreaseQuantity(ByVal Sender As Object, ByVal E As EventArgs)
        ChangeQuantity(Sender, -1)
    End Sub

    Private Sub OnIncreaseQuantity(ByVal Sender As Object, ByVal E As EventArgs)
        ChangeQuantity(Sender, 1)
    End Sub

    Protected Sub Button1_Click(ByVal Sender As Object, ByVal E As EventArgs)
    
        Dim sb As New StringBuilder()
        sb.Append("Beverage order:<br/>")
        For Each row As GridViewRow In GridView1.Rows
        
            If row.RowType = DataControlRowType.DataRow Then
                Dim quantityLabel As Label = CType(row.FindControl("QuantityLabel"), Label)
                Dim currentQuantity As Int32 = Int32.Parse(quantityLabel.Text)
                sb.Append(row.Cells(0).Text + " : " & currentQuantity & "<br/>")
            End If
        Next
        SummaryLabel.Text = sb.ToString()

    End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>UpdatePanel Inside GridView Template Example </title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" 
                               runat="server" />
            <asp:GridView ID="GridView1" 
                          AutoGenerateColumns="False"
                          DataSourceID="SqlDataSource1"
                          runat="server">
                <Columns>
                    <asp:BoundField DataField="ProductName" 
                                    HeaderText="ProductName" />
                    <asp:BoundField DataField="UnitPrice"
                                    HeaderText="UnitPrice" />
                    <asp:TemplateField HeaderText="Quantity">
                        <ItemTemplate>
                            <asp:UpdatePanel ID="QuantityUpdatePanel"
                                             runat="server" >
                                <ContentTemplate>
                                    <asp:Label ID="QuantityLabel"
                                               Text="0"
                                               runat="server" />
                                    <asp:Button ID="DecreaseQuantity"
                                                Text="-"
                                                OnClick="OnDecreaseQuantity"
                                                runat="server" />
                                    <asp:Button ID="IncreaseQuantity" 
                                                Text="+"
                                                OnClick="OnIncreaseQuantity"
                                                runat="server" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>            
            <asp:UpdatePanel ID="SummaryUpdatePanel" 
                             runat="server">
                <ContentTemplate>
                    <asp:Button ID="Button1"
                                OnClick="Button1_Click"
                                Text="Get Summary"
                                runat="server" />
                    <br />
                    <asp:Label ID="SummaryLabel"
                               runat="server">
                    </asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:SqlDataSource ID="SqlDataSource1"
                               ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>"
                               SelectCommand="SELECT [ProductName], [UnitPrice] FROM 
                               [Alphabetical list of products] WHERE ([CategoryName] 
                               LIKE '%' + @CategoryName + '%')"
                               runat="server">
                <SelectParameters>
                    <asp:Parameter DefaultValue="Beverages"
                                   Name="CategoryName"
                                   Type="String" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
<!-- </Snippet3> -->
