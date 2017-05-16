<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>HtmlInputRadioButton Sample</title>
<script runat="server">

      void Server_Change(object sender, EventArgs e) 
      {
         if (Radio1.Checked)
            Span1.InnerHtml = "You selected " +
                              Radio1.Value;
         else if (Radio2.Checked)
            Span1.InnerHtml = "You selected " +
                              Radio2.Value;
         else if (Radio3.Checked)
            Span1.InnerHtml = "You selected " +
                              Radio3.Value;
      }
         

   </script>

</head>

<body>

   <form id="form1" runat="server">

      <h3>HtmlInputRadioButton Sample</h3>

      <input type="radio" 
             id="Radio1" 
             name="Mode"
             value="Radio Button 1"
             onserverchange="Server_Change" 
             runat="server"/>
      Option 1
      <br />

      <input type="radio" 
             id="Radio2" 
             name="Mode"
             value="Radio Button 2"
             onserverchange="Server_Change" 
             runat="server"/>
      Option 2
      <br />

      <input type="radio" 
             id="Radio3" 
             name="Mode"
             value="Radio Button 3"
             onserverchange="Server_Change" 
             runat="server"/>
      Option 3

      <br />

      <input type="submit" 
             id="Button1" 
             value="Submit" 
             runat="server"/>

      <br />

      <span id="Span1" 
            runat="server" />

   </form>

</body>
</html>
<!--</Snippet1>-->
