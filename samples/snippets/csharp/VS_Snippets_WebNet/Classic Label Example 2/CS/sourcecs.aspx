<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>Label Example</title>
<script language="C#" runat="server">

      void Button_Click(Object Sender, EventArgs e) 
      {
         Label1.Text = Server.HtmlEncode(Text1.Text);
      }

   </script>

</head>

<body>

   <form id="Form1" runat="server">

      <h3>Label Example</h3>

      <asp:Label id="Label1" 
                 Text="Label Control" 
                 runat="server"/>

      <p>
        
      <asp:TextBox id="Text1" 
           Text="Copy this text to the label"
           Width="200px"  
           runat="server" />

      <asp:Button id="Button1" 
           Text="Copy" 
           OnClick="Button_Click" 
           runat="server"/>
      </p>

   </form>

</body>
</html>

<!--</Snippet1>-->
