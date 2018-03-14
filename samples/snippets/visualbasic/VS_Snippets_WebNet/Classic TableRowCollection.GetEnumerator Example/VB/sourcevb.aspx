<!--<Snippet1>-->
<%@ Page Language="VB" %>
<%@ Import Namespace="System.Text" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        Dim numRows As Integer = 5
        Dim numCells As Integer = 6
        Dim counter As Integer = 1
        Dim a_row As New ArrayList()
        
        ' Create a table.
        Dim rowNum As Integer
        For rowNum = 0 To numrows - 1
            Dim rw As New TableRow()
            Dim cellNum As Integer
            For cellNum = 0 To numcells - 1
                Dim cel As New TableCell()
                cel.Text = counter.ToString()
                rw.Cells.Add(cel)
                counter += 1
            Next cellNum
            Table1.Rows.Add(rw)
        Next rowNum
    End Sub

    Sub Button_Click(ByVal sender As Object, ByVal e As EventArgs)
        
        Dim rowCounter As Integer = 0
        Dim currentCell As TableCell
        Dim tb As New StringBuilder
        
        ' Create an IEnumerator for the rows of the table.
        Dim myRowEnum As IEnumerator = Table1.Rows.GetEnumerator()
        
        tb.Append("The copied items from the table are: <br />")
        
        ' Iterate through the IEnumerator and display its contents.
        While myRowEnum.MoveNext()
            
            ' Create an IEnumerator for the cells of a row.
            Dim myCellEnum As IEnumerator = _
                Table1.Rows(rowCounter).Cells.GetEnumerator()
            
            ' Iterate through the IEnumerator and display its contents.
            While myCellEnum.MoveNext()
                currentCell = CType(myCellEnum.Current, TableCell)
                tb.Append(currentCell.Text & ", ")
            End While
            Label1.Text = tb.ToString()
            
            rowCounter += 1
        End While
    End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>TableCellCollection Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h3>TableCellCollection Example</h3>
        <asp:Table id="Table1" runat="server" />
        <br />&nbsp;<br />
        <asp:Button id="Button1"
            Text="Copy Table to Array"
            OnClick="Button_Click"
            runat="server"/>
        <br />&nbsp;<br />
        <asp:Label id="Label1" runat="server" />
    </div>
    </form>
</body>
</html>
<!--</Snippet1>-->
