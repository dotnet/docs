<!--<Snippet1>-->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    Private Sub Page_Load(sender As Object, e As EventArgs) 
        ' Generate rows and cells.

        Dim numrows As Integer = 5
        Dim numcells As Integer = 4

        Dim i As Integer
        Dim j As Integer

        For j = 0 to numrows - 1
            Dim r As TableRow = new TableRow()
                
            For i = 0 to numcells - 1
                Dim c As TableCell = new TableCell()
                c.Controls.Add(New LiteralControl("row " & j.ToString() & _ 
                              ", cell " & i.ToString()))
                r.Cells.Add(c)
            Next ' i

            Table1.Rows.Add(r)
        Next ' j
    End Sub

    Private Sub Button_Click(sender As Object, e As EventArgs) 
        Table1.GridLines = CType(DropDown1.SelectedIndex, GridLines)
    End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

    <h3>Table GridLines Example</h3>

    <asp:Table id="Table1" 
        BorderColor="black" 
        BorderWidth="1" 
        GridLines="Both" 
        runat="server" />

    <br />GridLines:

    <asp:DropDownList id="DropDown1" runat="server">
        <asp:ListItem Value="0">None</asp:ListItem>
        <asp:ListItem Value="1">Horizontal</asp:ListItem>
        <asp:ListItem Value="2">Vertical</asp:ListItem>
        <asp:ListItem Value="3">Both</asp:ListItem>
    </asp:DropDownList><br />

    <asp:button id="Button1"
        Text="Display Table"
        OnClick="Button_Click" 
        runat="server" />

    </div>
    </form>
</body>
</html>    
<!--</Snippet1>-->
