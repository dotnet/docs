<!--<Snippet1>-->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    Private Sub Page_Load(ByVal sender As Object, _
        ByVal e As System.EventArgs)

        ' Add more rows and columns to the table than can
        ' be displayed in the panel area.
        ' Scroll bars will be required to view all the data.

        ' Add rows and columns to the table.
        Dim rowNum As Integer
        For rowNum = 0 To 50
            Dim tempRow As New TableRow
            Dim cellNum As Integer
            For cellNum = 0 To 10
                Dim tempCell As New TableCell
                tempCell.Text = _
                    String.Format("({0}, {1})", rowNum, cellNum)
                tempRow.Cells.Add(tempCell)
            Next
            Table1.Rows.Add(tempRow)
        Next
    End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head2" runat="server">
    <title>Panel Scrollbars - VB.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

    <h3>Panel.ScrollBars Property Example</h3>        

    <asp:Panel ID="Panel1" runat="Server"
      Height="300px" Width="400px"
      BackColor="Aqua" ScrollBars="Auto">

      <asp:Table ID="Table1" runat="Server"></asp:Table>  

    </asp:Panel>         

    </div>
    </form>
</body>
</html>
<!--</Snippet1>-->
