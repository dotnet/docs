<!-- <Snippet1> -->
<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.CS.Controls" Assembly="Samples.AspNet.CS" %>
<%@ Page Language="C#" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
    <head>
        <title>Custom ListBox - AddAttributesToRender - C# Example</title>
    <script runat="server">
          private void Page_Load(object sender, System.EventArgs e)
      {
        ListBox1.Items.Add(new ListItem("Item1", "Item1"));
        ListBox1.Items.Add(new ListItem("Item2", "Item2"));
        ListBox1.Items.Add(new ListItem("Item2", "Item2"));
      }
    </script>
    </head>
    <body>
        <form id="Form1" method="post" runat="server">
            <h3>Custom ListBox - AddAttributesToRender - C# Example</h3>
            
            <aspSample:CustomListBoxAddAttributesToRender 
              id="ListBox1" 
              runat="server" />
              
        </form>
    </body>
</html>
<!-- </Snippet1> -->
