<!--<Snippet1>-->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
 
    Sub Page_Load(sender As Object, e As EventArgs)
        Dim numrows As Integer = 5
        Dim numcells As Integer = 6
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
            Next
            Table1.Rows.Add(rw)
        Next

        If Not IsPostBack Then
            ' Create a DropDownList for the number of rows.
            For rowNum = 0 To numrows - 1
                a_row.Add(rowNum.ToString())
            Next

            List1.DataSource = a_row
            List1.DataBind()
        End If 
    End Sub

    Sub Button_Click(sender As Object, e As EventArgs)
        Dim row As Integer = List1.SelectedIndex
        Dim myCellArray(6) As TableCell

        ' Copy the collection to an array.
        Table1.Rows(row).Cells.CopyTo(myCellArray, 0)

        Label1.Text = "The copied items from the selected row are: "

        ' Iterate through the array and display its contents.
        Dim cel As TableCell
        For Each cel In  myCellArray
            Label1.Text = Label1.Text & " " & cel.Text
                
        Next
    End Sub
 
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>TableCellCollection Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

    <h3>TableCellCollection Example</h3>
    <asp:Table id="Table1" 
        GridLines="Both" 
        HorizontalAlign="Center" 
        Font-Names="Verdana" 
        Font-Size="8pt" 
        CellPadding="15" 
        CellSpacing="0" 
        runat="server" />

        <p style="text-align:center">Select a row:
            <br />&nbsp;<br />
            Row: <asp:DropDownList id="List1" 
            runat="server" />
 
            <br /><br />
            <asp:Button id="Button1"
                Text="Copy Row to Array"
                OnClick="Button_Click"
                runat="server" />
            <br /><br />
            <asp:Label id="Label1"
                runat="server" />
       </p>
 
    </div>
    </form>
</body>
</html>
<!--</Snippet1>-->
