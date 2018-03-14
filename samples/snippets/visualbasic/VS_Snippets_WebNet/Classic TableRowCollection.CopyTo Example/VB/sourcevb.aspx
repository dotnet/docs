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
        For rowNum = 0 To numRows - 1
            Dim rw As New TableRow()
            Dim cellNum As Integer
            For cellNum = 0 To numCells - 1
                Dim cel As New TableCell()
                cel.Text = counter.ToString()
                rw.Cells.Add(cel)
                counter += 1
            Next
            Table1.Rows.Add(rw)
        Next
    End Sub

    Sub Button_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim rowCounter As Integer = 0
        Dim myRowArray(4) As TableRow
        Dim myCellArray(5) As TableCell
        Dim tb As New StringBuilder

        ' Copy the Rows collection to an array.
        Table1.Rows.CopyTo(myRowArray, 0)

        tb.Append("The copied items from the table are: <br />")

        ' Iterate through the TableRows in the array.
        Dim rw As TableRow
        For Each rw In myRowArray
            ' Copy the Cells collection of a row to an array.
            Table1.Rows(rowCounter).Cells.CopyTo(myCellArray, 0)

            ' Iterate through the cell array 
            ' and display its contents.
            Dim cell As TableCell
            For Each cell In myCellArray
                tb.Append(cell.Text & ", ")
            Next
            Label1.Text = tb.ToString()

            rowCounter += 1
        Next
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
