<!-- <Snippet1> -->
<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.VB.Controls" Assembly="Samples.AspNet.VB" %>
<%@ Page Language="VB" AutoEventWireup="True" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
    <head>
        <title>Custom ListBox - AddAttributesToRender -  VB.NET Example</title>
        <script runat="server">
            Sub Page_Load(sender As Object, e As EventArgs)
                ListBox1.Items.Add(New ListItem("Item1", "Item1"))
                ListBox1.Items.Add(New ListItem("Item2", "Item2"))
                ListBox1.Items.Add(New ListItem("Item2", "Item2"))
            End Sub
        </script>
    </head>
    <body>
        <form id="Form1" method="post" runat="server">
            <h3>Custom ListBox - AddAttributesToRender - VB.NET Example</h3>
            
            <aspSample:CustomListBoxAddAttributesToRender id="ListBox1" runat="server" />
        </form>
    </body>
</html>
<!-- </Snippet1> -->
