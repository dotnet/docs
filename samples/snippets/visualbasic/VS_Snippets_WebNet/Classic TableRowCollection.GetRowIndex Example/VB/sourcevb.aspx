<!--<Snippet1>-->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
        Dim numRows As Integer = 5
        Dim numCells As Integer = 6
        Dim cellNum As Integer
        Dim counter As Integer = 1

        ' Create a table.
        Dim rowNum As Integer
        For rowNum = 0 To numRows - 1
            Dim rw As New TableRow()
            For cellNum = 0 To numCells - 1
                Dim cel As New TableCell()
                cel.Text = counter.ToString()
                If cellNum = List2.SelectedIndex Then
                    cel.BackColor = System.Drawing.Color.Chartreuse
                ElseIf rowNum = List1.SelectedIndex Then
                    cel.BackColor = System.Drawing.Color.CadetBlue
                Else
                    cel.BackColor = System.Drawing.Color.White
                End If
                rw.Cells.Add(cel)
                counter += 1
            Next cellNum
            Table1.Rows.Add(rw)
        Next rowNum
            
        If Not IsPostBack Then
            ' Fill a DropDownList with row numbers
            For rowNum = 0 To numRows - 1
                List1.Items.Add(rowNum.ToString())
            Next rowNum
                
            ' Fill a DropDownList with column numbers
            For cellNum = 0 To numCells - 1
                List2.Items.Add(cellNum.ToString())
            Next cellNum
        End If
    End Sub

    Sub Button_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim rowNum As Integer = List1.SelectedIndex
        Dim rw As TableRow = Table1.Rows(rowNum)
            
        Label1.Text = "The row index of the selected cell is " & _
            Table1.Rows.GetRowIndex(rw).ToString()
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
        Select a cell:
        <br />&nbsp;<br />
        Row: <asp:DropDownList id="List1" runat="server" />
        Column: <asp:DropDownList id="List2" runat="server" />
        <br />&nbsp;<br />
        <asp:Button id="Button1"
           Text="Get Index"
           OnClick="Button_Click"
           runat="server" />
        <br />&nbsp;<br />
        <asp:Label id="Label1" runat="server" />
    </div>
    </form>
</body>
</html>
<!--</Snippet1>-->
