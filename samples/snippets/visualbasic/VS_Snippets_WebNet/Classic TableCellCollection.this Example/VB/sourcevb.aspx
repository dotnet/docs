<!--<Snippet1>-->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    
    Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        Dim numRows As Integer = 5
        Dim numCells As Integer = 6
        Dim counter As Integer = 1
        Dim a_row As New ArrayList()
        Dim a_column As New ArrayList()

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

        If Not IsPostBack Then
            ' Create a DropDownList for the number of columns.
            Dim cellNum As Integer
            For cellNum = 0 To numCells - 1
                a_column.Add(cellNum.ToString())
            Next

            ' Create a DropDownList for the number of rows.
            For rowNum = 0 To numRows - 1
                a_row.Add(rowNum.ToString())
            Next

            List1.DataSource = a_column
            List2.DataSource = a_row
            List1.DataBind()
            List2.DataBind()
        End If
    End Sub

    Sub Button_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim column As Integer = List1.SelectedIndex
        Dim row As Integer = List2.SelectedIndex
        
        Dim spec As String
        spec = "The cell ({0}, {1}) contains the value {2}."
        Label1.Text = String.Format(spec, column, _
            row, Table1.Rows(row).Cells(column).Text)
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
    <asp:Table id="Table1" 
        runat="server"/>
    <br />&nbsp;<br />
    <p>Select a column and row:<br />
        Column: <asp:DropDownList id="List1" 
            runat="server"/>
        Row: <asp:DropDownList id="List2"
            runat="server"/>
        <br />&nbsp;<br />
        <asp:Button id="Button1"
            Text="Display Cell Value"
            OnClick="Button_Click"
            runat="server"/>
        <br />&nbsp;<br />
        <asp:Label id="Label1"
            runat="server"/>
    </p>

    </div>
    </form>
</body>
</html>
<!--</Snippet1>-->
