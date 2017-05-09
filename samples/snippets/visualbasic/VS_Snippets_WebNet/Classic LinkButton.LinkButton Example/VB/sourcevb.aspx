<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>LinkButton Example</title>
<script language="VB" runat="server">
 
      Sub Button_Click(Sender As Object, e As EventArgs) 
         Dim myLinkButton As New LinkButton()
         myLinkButton.Text = "This is a new LinkButton!"
         Page.Form.Controls.Add(myLinkButton)
      End Sub
 
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
