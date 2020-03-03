<!-- <Snippet1> -->
<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.CS.Controls" Assembly="Samples.AspNet.CS" %>
<%@ Page language="c#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>Custom CheckBoxList - Render - C# Example</title>
  </head>
  <body>
    <form id="Form1" method="post" runat="server">
      <h3>Custom CheckBoxList - Render - C# Example</h3>

      <aspSample:CustomCheckBoxListRender
        id="CheckBoxList1" runat="server">
        <asp:ListItem Selected="True">Item 1</asp:ListItem>
        <asp:ListItem>Item 2</asp:ListItem>
        <asp:ListItem>Item 3</asp:ListItem>
        <asp:ListItem>Item 4</asp:ListItem>
        <asp:ListItem>Item 5</asp:ListItem>
        <asp:ListItem>Item 6</asp:ListItem>
      </aspSample:CustomCheckBoxListRender>

    </form>
  </body>
</html>
<!-- </Snippet1> -->
