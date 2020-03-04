<!--<Snippet1>-->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
            
        Dim numRows As Integer = 4
        Dim numCells As Integer = 6
        Dim counter As Integer = 1
        Dim cellNum As Integer

        ' Generate a basic table.         
        Dim rowNum As Integer
        For rowNum = 0 To numRows - 1
            Dim rw As New TableRow()
            For cellNum = 0 To numCells - 1
                Dim cel As New TableCell()
                cel.Text = counter.ToString()
                counter += 1
                rw.Cells.Add(cel)
            Next cellNum
            Table1.Rows.Add(rw)
        Next rowNum
            
        ' Add a row in the middle of the table.
        Dim new_rw As New TableRow()
        Table1.Rows.AddAt(numRows / 2, new_rw)
            
        For cellNum = 0 To numCells - 1
            Dim cel As New TableCell()
            cel.Text = "Mid"
            Table1.Rows((numRows / 2)).Cells.AddAt(cellNum, cel)
            counter += 1
        Next cellNum
    End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Programmatic Table</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h3>Programmatic Table Example</h3>
        <asp:Table id="Table1" runat="server"/>
    </div>
    </form>
</body>
</html>
<!--</Snippet1>-->
