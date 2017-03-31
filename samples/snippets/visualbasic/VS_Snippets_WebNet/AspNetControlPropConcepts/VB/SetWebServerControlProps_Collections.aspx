<%@ Page Language="VB"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">
  <title>How to: Set Web Server Control Properties in Collections</title>
</head>

<script runat="server">
    
    Public Sub Page_Load()
        
        '<Snippet5>
        Dim li As ListItem = New ListItem("Item 1")
        ListBox1.Items.Add(li)
        
        ' Create and add the items at the same time
        ListBox1.Items.Add(New ListItem("Apples"))
        ListBox1.Items.Add(New ListItem("Oranges"))
        ListBox1.Items.Add(New ListItem("Lemons"))
        '</Snippet5>
        
    End Sub
    
 </script>
 
<body>
    <form id="form1" runat="server">
      <asp:ListBox Id="ListBox1" runat ="server"></asp:ListBox>
    </form>
</body>
</html>
