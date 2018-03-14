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
        Dim i As Integer
        For i = 0 To 50
            Dim tempRow As New TableRow
            Dim j As Integer
            For j = 0 To 10
                Dim tempCell As New TableCell
                tempCell.Text = "(" & i & "," & j & ")"
                tempRow.Cells.Add(tempCell)
            Next j
            Table1.Rows.Add(tempRow)
        Next i
    End Sub

    Sub ListBox1_SelectedIndexChanged(ByVal sender As Object, _
        ByVal e As EventArgs)

        ' Determine which list item was clicked.
        ' Display the selected scroll bars in the panel.
        Select Case (ListBox1.SelectedIndex)
            Case 0
                Panel1.ScrollBars = ScrollBars.None
            Case 1
                Panel1.ScrollBars = ScrollBars.Horizontal
            Case 2
                Panel1.ScrollBars = ScrollBars.Vertical
            Case 3
                Panel1.ScrollBars = ScrollBars.Both
            Case 4
                Panel1.ScrollBars = ScrollBars.Auto
            Case Else
                Throw New Exception("Select a valid list item.")
        End Select

    End Sub
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head2" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

    <h3>Panel.ScrollBars Property Example</h3>

    <h4>Select the scrollbars to display in the panel.</h4>
    <asp:ListBox ID="ListBox1" runat="Server"
      Rows="5" AutoPostBack="True" SelectionMode="Single"
      OnSelectedIndexChanged="ListBox1_SelectedIndexChanged">
      <asp:ListItem>None</asp:ListItem>
      <asp:ListItem>Horizontal</asp:ListItem> 
      <asp:ListItem>Vertical</asp:ListItem>
      <asp:ListItem>Both</asp:ListItem> 
      <asp:ListItem>Auto</asp:ListItem>              
    </asp:ListBox>

    <hr />              

    <asp:Panel ID="Panel1" runat="Server"
      Height="300px" Width="400px" BackColor="Aqua">
      <asp:Table ID="Table1" runat="Server" />
    </asp:Panel>           
         
    </div>
    </form>
</body>
</html>
<!--</Snippet1>-->
