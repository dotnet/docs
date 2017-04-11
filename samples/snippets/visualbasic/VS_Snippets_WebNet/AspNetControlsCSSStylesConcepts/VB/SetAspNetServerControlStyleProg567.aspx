<%@ Page Language="VB"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    Private Sub Page_Load()
        
        '<Snippet5>
        Calendar1.DayStyle.BackColor = System.Drawing.Color.Green
        '</Snippet5>
        
        '<Snippet6>
        Dim s As Style = New Style()
        s.BackColor = System.Drawing.Color.Red
        '</Snippet6>
        
        '<Snippet7>
        ' Apply all values in s, including nulls.
        Calendar1.SelectedDayStyle.CopyFrom(s)
        ' Apply only values in s that are null in HeaderStyle.
        DataGrid1.HeaderStyle.MergeWith(s)
        '</Snippet7>
                
    End Sub
            
</script>
<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">
    <title>How to: Set ASP.NET Server Control Style Properties Programmatically</title>
</head>
<body>
    <form id="form1" runat="server">
      <asp:DataGrid id="DataGrid1" runat="server"></asp:DataGrid>
      <asp:Calendar id="Calendar1" runat="server"></asp:Calendar>
    </form>
</body>
</html>
