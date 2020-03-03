<%@ Page Language="C#"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">
    <title>Locate the Web Forms Controls on a Page by Walking the Controls Collection</title>
</head>
<script runat="server">
    
    //<Snippet10>
    private void Button1_Click(object sender, System.EventArgs e)
    {
        string allTextBoxValues = "";
        foreach (Control c in Page.Controls)
        {
            foreach (Control childc in c.Controls)
            {
                if (childc is TextBox)
                {
                    allTextBoxValues += ((TextBox)childc).Text + ",";
                }
            }
        }
        if (allTextBoxValues != "")
        {
            Label1.Text = allTextBoxValues;
        }
    }

    //</Snippet10>
    
</script>
    
<body>
    <form id="form1" runat="server">
      <asp:Button id="Button1" runat="server" />
      <asp:Label id="Label1" runat="server" AssociatedControlID="Button1"></asp:Label>
    </form>
</body>
</html>
