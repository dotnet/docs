<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs)
        ' Create a TableStyle
        Dim ts As New TableStyle()
        ts.BackImageUrl = "image1.jpg"
        ts.CellSpacing = 5
        ts.CellPadding = 13
        ts.GridLines = GridLines.Both
        ts.HorizontalAlign = HorizontalAlign.Center

        ' Apply it to Table1
        Table1.ApplyStyle(ts)
        
        ' Fill in the contents so it renders
        Dim i As Integer
        For i = 0 To 9
            Dim tr As New TableRow()
            tr.ID = i.ToString()
            Dim j As Integer
            For j = 0 To 4
                Dim tc As New TableCell()
                tc.ID = j.ToString()
                tc.Text = "Row " & i & ", Cell " & j
                tr.Cells.Add(tc)
            Next
            Table1.Rows.Add(tr)
        Next
    End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>TableStyle Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h3 style="text-align:center">TableStyle Example</h3>
        <asp:Table ID="Table1" runat="server" />
    </div>
    </form>
</body>
</html>
