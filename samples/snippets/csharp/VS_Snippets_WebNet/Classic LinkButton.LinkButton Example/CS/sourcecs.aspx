<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>LinkButton Example</title>
<script language="C#" runat="server">
 
      void Button_Click(Object Sender, EventArgs e) 
      {
         LinkButton myLinkButton = new LinkButton();
         myLinkButton.Text = "This is a new LinkButton!";
         Page.Form.Controls.Add(myLinkButton);
      }
 
     </script>
 
</head>
<body>
 
   <form id="form1" runat="server">

      <h3>LinkButton Example</h3>
 
      <asp:Button id="Button1" 
           Text="Create and Show a LinkButton" 
           OnClick="Button_Click" 
           runat="server"/>
 
   </form>

</body>
</html>
   
<!--</Snippet1>-->
