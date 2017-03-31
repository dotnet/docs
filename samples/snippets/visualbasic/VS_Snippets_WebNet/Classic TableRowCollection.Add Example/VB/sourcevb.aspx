<!--<Snippet1>-->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        ' Generate rows and cells.           
        Dim numRows As Integer = 5
        Dim numcells As Integer = 6
        Dim rowNum As Integer = 0
        Dim counter As Integer = 1

        For rowNum = 0 To numRows - 1
            Dim rw As New TableRow()
            Dim cellNum As Integer
            For cellNum = 0 To numcells - 1
                Dim cel As New TableCell()
                cel.Text = counter.ToString()
                rw.Cells.Add(cel)
            Next cellNum
            Table1.Rows.Add(rw)
        Next rowNum
        Table1.GridLines = GridLines.Both
        Table1.CellPadding = 4
        Table1.CellSpacing = 0
    End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Programmatic Table</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h3>Table Example, constructed programmatically</h3>
        <asp:Table id="Table1" runat="server"/>
    </div>
    </form>
</body>
</html>
<!--</Snippet1>-->
