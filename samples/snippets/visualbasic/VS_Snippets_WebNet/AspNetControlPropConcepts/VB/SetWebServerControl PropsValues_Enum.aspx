<%@ Page Language="VB"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head runat="server">
    <title>How to: Set Web Server Control Properties Based on Simple Values or Enumerations</title>
</head>

<script  runat="server" >
    
    Sub Page_Load()

        '<Snippet1>
        Label1.Text = "Hello"
        Datagrid1.PageSize = 5
        '</Snippet1>
        
        '<Snippet2>
        'Uses TextBoxMode enumeration
        TextBox1.TextMode = TextBoxMode.SingleLine
        'Uses ImageAlign enumeration
        Image1.ImageAlign = ImageAlign.Middle
        '</Snippet2>

    End Sub
    
</script>

<body>
    <form id="form1" runat="server">
      <asp:Datagrid id="Datagrid1" runat="server"></asp:Datagrid>
      <asp:Label id="Label1" runat="server" AssociatedControlID="TextBox1"></asp:Label>
      <asp:TextBox id ="TextBox1" runat="server"></asp:TextBox>
      <asp:Image Id="Image1" runat="server" AlternateText="Picture description" ></asp:Image>
 </form>
</body>
</html>
