<%@ Page Language="VB"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">
    <title>How to: Set Web Server Control Color Properties
</title>
</head>

<script runat="server">
    
    Public Sub Page_Load()
        
        '<Snippet4>
        Button1.BackColor = System.Drawing.Color.FromName("Red")
        ' White in RGB.
        Button1.BackColor = System.Drawing.Color.FromArgb(255, 255, 255)
        Button1.BackColor = System.Drawing.Color.Red
        ' HTML 4.0 Color
        Button1.BackColor = System.Drawing.Color.MediumSeaGreen
        '</Snippet4>
        
    End Sub
    
</script>
<body>
    <form id="form1" runat="server">
      <asp:Button id="Button1" runat="server" />
    </form>
</body>
</html>
