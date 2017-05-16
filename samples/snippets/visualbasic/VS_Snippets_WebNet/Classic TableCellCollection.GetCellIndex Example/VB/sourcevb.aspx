<!-- <Snippet1> -->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        Dim numrows As Integer = 5
        Dim numcells As Integer = 6
        Dim counter As Integer = 1
        Dim a_row As New ArrayList()
        Dim a_column As New ArrayList()

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
            Next
            Table1.Rows.Add(rw)
        Next

        If Not IsPostBack Then
            ' Create a DropDownList for the number of rows.
            For rowNum = 0 To numrows - 1
                a_row.Add(rowNum.ToString())
            Next

            ' Create a DropDownList for the number of columns.
            Dim cellNum As Integer
            For cellNum = 0 To numcells - 1
                a_column.Add(cellNum.ToString())
            Next

            List1.DataSource = a_row
            List2.DataSource = a_column
            List1.DataBind()
            List2.DataBind()
        End If
    End Sub

    Sub Button_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim row As Integer = List1.SelectedIndex
        Dim column As Integer = List2.SelectedIndex
        Dim cell As TableCell = Table1.Rows(row).Cells(column)

        Label1.Text = "The column index of the selected cell is " & _
            Table1.Rows(row).Cells.GetCellIndex(cell).ToString()
    End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <h3>TableCellCollection Example</h3>
    <asp:Table id="Table1" runat="server"/>
    <br /><br />
    <p style="text-align:center">
        Select a cell:
        <br />&nbsp;<br />
        Row: <asp:DropDownList id="List1" runat="server"/>
        Column: <asp:DropDownList id="List2" runat="server"/>
        <br />&nbsp;<br />
        <asp:Button id="Button1"
             Text="Get Index"
             OnClick="Button_Click"
             runat="server"/>
        <br />&nbsp;<br />
        <asp:Label id="Label1" runat="server"/>
    </p>

    </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->
