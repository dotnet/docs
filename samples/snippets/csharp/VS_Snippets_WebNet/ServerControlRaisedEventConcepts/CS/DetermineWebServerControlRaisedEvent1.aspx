<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">
    <title>How to: Determine which Web Server Control Raised an Event</title>
</head>

<script runat= "Server">
    
    //<Snippet1>
    private void Button_Click(object sender, System.EventArgs e)
    {
        Button b;
        b = (Button)sender;
        switch (b.ID)
        {
            case "Button1":
                Label1.Text = "You clicked the first button";
                break;
            case "Button2":
                Label1.Text = "You clicked the second button";
                break;
            case "Button3":
                Label1.Text = "You clicked the third button";
                break;
        }
    }
    //</Snippet1>
    
</script>

<body>
    <form id="form1" runat="server">
      
      <div>
      <asp:Button id="Button1" runat="server" OnClick="Button_Click"></asp:Button>
      <asp:Button id="Button2" runat="server" OnClick="Button_Click"></asp:Button>
      <asp:Button id="Button3" runat="server" OnClick="Button_Click"></asp:Button>
      <asp:Label  id="Label1" runat="server"></asp:Label>
    </div>
     
    </form>
</body>
</html>
