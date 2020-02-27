<!-- <Snippet1> -->

<%@ Page Language="C#" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>HtmlInputRadioButton ServerChange Example</title>
<script runat="server">

      void Server_Change(object sender, EventArgs e) 
      {
         if (Radio1.Checked)
         {
            Span1.InnerHtml = "You selected " + Radio1.Value;
         }
         else if (Radio2.Checked)
         {
            Span1.InnerHtml = "You selected " + Radio2.Value;
         }
         else if (Radio3.Checked)
         {
            Span1.InnerHtml = "You selected " + Radio3.Value;
         }
      }

      void Page_Load(object sender, EventArgs e)
      {
         // Create an EventHandler delegate for the method you want to
         // handle the event, and then add it to the list of methods
         // called when the event is raised.
         Radio1.ServerChange += new System.EventHandler(this.Server_Change);
         Radio2.ServerChange += new System.EventHandler(this.Server_Change);
         Radio3.ServerChange += new System.EventHandler(this.Server_Change);
      }         

   </script>

</head>

<body>

   <form id="form1" runat="server">

      <h3>HtmlInputRadioButton ServerChange Example</h3>

      <input type="radio" 
             id="Radio1" 
             name="Mode"
             value="Radio Button 1"
             runat="server"/>
      Option 1
      <br />

      <input type="radio" 
             id="Radio2" 
             name="Mode"
             value="Radio Button 2"
             runat="server"/>
      Option 2
      <br />

      <input type="radio" 
             id="Radio3" 
             name="Mode"
             value="Radio Button 3"
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

<!-- </Snippet1> -->   