<!--<Snippet1>-->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    Dim numrows As Integer = 5
    Dim numcells As Integer = 6
    Dim counter As Integer = 1

    Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
            
        ' Create a table.
        Dim rowNum As Integer
        For rowNum = 0 To numrows - 1
            Dim rw As New TableRow()
            Dim cellNum As Integer
            For cellNum = 0 To numcells - 1
                Dim cel As New TableCell()
                cel.Text = counter.ToString()
                counter += 1
                rw.Cells.Add(cel)
            Next
            Table1.Rows.Add(rw)
            Table1.GridLines = GridLines.Both
            Table1.CellPadding = 4
            Table1.CellSpacing = 0
        Next
    End Sub

    Sub Button_Click(ByVal sender As Object, ByVal e As EventArgs)
            
        ' Clear the table.
        Table1.Rows.Clear()
            
        ' Create new rows and cells.
        Dim rowNum As Integer
        For rowNum = 0 To numrows - 1
            Dim rw As New TableRow()
            Dim cellNum As Integer
            For cellNum = 0 To numcells - 1
                Dim cel As New TableCell()
                cel.Text = "***"
                rw.Cells.Add(cel)
            Next
            Table1.Rows.Add(rw)
        Next
    End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Programmatic Table</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h3>Programmatic Table Example</h3>
        <asp:Table id="Table1" runat="server"/>

        <asp:Button id="Button1"
            Text="Replace All Rows With ***"
            OnClick="Button_Click"
            runat="server"/>
    </div>
    </form>
</body>
</html>
<!--</Snippet1>-->
