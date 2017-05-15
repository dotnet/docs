<!--<Snippet1>-->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

    Private Sub Page_Load(sender As Object, e As EventArgs)
        ' Generate rows and cells.           
        Dim numrows As Integer = 4
        Dim numcells As Integer = 6
        Dim counter As Integer = 1
        Dim rowNum As Integer
        Dim cellNum As Integer
        For rowNum = 0 To numrows - 1
            Dim rw As New TableRow()
            For cellNum = 0 To numcells - 1
                Dim cel As New TableCell()
                cel.Text = counter.ToString()
                counter += 1
                rw.Cells.Add(cel)
            Next
            Table1.Rows.Add(rw)
        Next
    End Sub

    Private Sub Button_Click_Coord(sender As Object, e As EventArgs)            
        Dim rowNum As Integer
        Dim cellNum As Integer
        Dim rowCount As Integer
        For rowCount = 0 To Table1.Rows.Count - 1
            For cellNum = 0 To (Table1.Rows(rowNum).Cells.Count) - 1                    
                Table1.Rows(rowNum).Cells(cellNum).Text = _
                    String.Format("(Row{0}, Cell{1})", rowNum, cellNum)
            Next
        Next
    End Sub

    Private Sub Button_Click_Number(sender As Object, e As EventArgs)
        Dim counter As Integer = 1

        Dim rowNum As Integer
        Dim cellNum As Integer
        For rowNum = 0 To Table1.Rows.Count - 1
            For cellNum = 0 To (Table1.Rows(rowNum).Cells.Count) - 1                    
                Table1.Rows(rowNum).Cells(cellNum).Text = _
                    counter.ToString()
                counter += 1
            Next 
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
            runat="server"/>
       <br />
       <center>
          <asp:Button id="Button1"
               Text="Display Table Coordinates"
               OnClick="Button_Click_Coord"
               runat="server"/>
          <asp:Button id="Button2"
               Text="Display Cell Numbers"
               OnClick="Button_Click_Number"
               runat="server"/>
       </center>
 
    </div>
    </form>
</body>
</html>
<!--</Snippet1>-->
