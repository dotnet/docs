<%@ Page Language="C#"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">
    <title>How to: Set Web Server Control Properties in Collections</title>
</head>

<script runat="server">
    
    private void Page_Load()
    {
        //<Snippet5>
        // Create the items and then add them to the list.
        ListItem li = new ListItem("Item 1");
        ListBox1.Items.Add(li);
        
        // Create and add the items at the same time.
        ListBox1.Items.Add(new ListItem("Apples"));
        ListBox1.Items.Add(new ListItem("Oranges"));
        ListBox1.Items.Add(new ListItem("Lemons"));
        //</Snippet5>

    }
    
</script>

<body>
    <form id="form1" runat="server">
      <asp:ListBox id="ListBox1" runat="server"></asp:ListBox>
    </form>
</body>
</html>
