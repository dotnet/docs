<!-- <Snippet1> -->
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    
    Sub GreetingBtn_Click(ByVal sender As Object, _
                          ByVal e As EventArgs)
   
        ' When the button is clicked,
        ' change the button text, and disable it.
        
        Dim clickedButton As Button = sender
        clickedButton.Text = "...button clicked..."
        clickedButton.Enabled = False
 
        ' Display the greeting label text.
        GreetingLabel.Visible = True
    End Sub

</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Button Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <h3>Simple Button Example</h3>
     
      <asp:Button id="Button1"
           Text="Click here for greeting..."
           OnClick="GreetingBtn_Click" 
           runat="server"/>
      <br />
      <br />
      <asp:Label ID="GreetingLabel" runat="server" 
                 Visible="false" Text="Hello World!" />
    </div>
    </form>
</body>
</html>
<!-- </Snippet1> -->
