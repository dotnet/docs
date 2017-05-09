<!-- <Snippet1> -->
<%@ Page Language="C#" AutoEventWireup="True" %>
<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.CS.Controls" Assembly="Samples.AspNet.CS" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>Custom RadioButtonList - Render - C# Example</title>
  </head>
  <body>
    <form id="Form1" method="post" runat="server">
      <h3>Custom RadioButtonList - Render - C# Example</h3>

      <aspSample:CustomRadioButtonListRender 
        id="Radiobuttonlist1" 
        runat="server" 
        RepeatColumns="2" 
        RepeatDirection="Horizontal">
        <asp:ListItem Value="Item1">Item1</asp:ListItem>
        <asp:ListItem Value="Item2">Item2</asp:ListItem>
        <asp:ListItem Value="Item3">Item3</asp:ListItem>
        <asp:ListItem Value="Item4">Item4</asp:ListItem>
      </aspSample:CustomRadioButtonListRender>
      
    </form>
  </body>
</html>
<!-- </Snippet1> -->