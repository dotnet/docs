<!-- <snippet1> -->
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="postbackoptions.aspx.cs" Inherits="postbackoptionscs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>PostBackOptions Example</title>
  </head>
  <body>
    <form id="form1" runat="server">
    <h3>PostBackOptions Example Page</h3>
      Click this button to create client-side script for the 
      Postback hyperlink that causes a postback event to occur.
      <br />
      <asp:Button id="Button1" 
        runat="server" 
        text="Create Script" 
        onclick="Button1_Click" />
      <br /><br />
      <asp:Label id="Label1" 
        runat="server" 
        text="">
      </asp:Label>
      <br />
      <asp:HyperLink id="HyperLink1" 
        runat="server" 
        text="Postback">
      </asp:HyperLink>
    </form>
  </body>
</html>
<!-- </snippet1> -->