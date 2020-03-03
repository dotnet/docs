<!--<Snippet2>-->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    Sub Page_Load(sender As Object, e As EventArgs)
        ' Generate rows and cells.           
        Dim numrows As Integer = 3
        Dim numcells As Integer = 2
        Dim j As Integer
        For j = 0 To numrows - 1
            Dim r As New TableRow()
            Dim i As Integer
            For i = 0 To numcells - 1
                Dim c As New TableCell()
                c.Controls.Add(New LiteralControl("row " & j.ToString() & ", cell " & i.ToString()))
                r.Cells.Add(c)
            Next i
            Table1.Rows.Add(r)
        Next j
    End Sub 'Page_Load
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Programmatic Table Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

    <h3>Table Example, constructed programmatically</h3>
    <asp:Table id="Table1" 
        GridLines="Both" 
        HorizontalAlign="Center" 
        Font-Names="Verdana" 
        Font-Size="8pt" 
        CellPadding="15" 
        CellSpacing="0" 
        Runat="server"/>

    </div>
    </form>
</body>
</html>
<!--</Snippet2>-->
