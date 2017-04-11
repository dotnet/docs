<!-- <Snippet1> -->
<%@ Page Language="C#" AutoEventWireup="True" %>
<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.CS.Controls" Assembly="Samples.AspNet.CS" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>Custom DropDownList - CreateControlCollection - C# Example</title>
    <script runat="server">
      private void Page_Load(object sender, System.EventArgs e)
      {
          DropDownList1.Items.Add(new ListItem("Item1", "Item1"));
          DropDownList1.Items.Add(new ListItem("Item2", "Item2"));
          DropDownList1.Items.Add(new ListItem("Item2", "Item2"));
      }
    </script>
  </head>
  <body>
    <form id="Form1" method="post" runat="server">
      <h3>Custom DropDownList - CreateControlCollection - C# Example</h3>

      <aspSample:CustomDropDownListCreateControlCollection
        id="DropDownList1"
        runat="server" />

    </form>
  </body>
</html>
<!-- </Snippet1> -->