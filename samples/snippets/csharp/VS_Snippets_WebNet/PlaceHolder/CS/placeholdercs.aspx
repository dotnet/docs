<!--<Snippet1>-->

<%@ Page Language="C#" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>PlaceHolder Example</title>
<script runat="server">

      void Page_Load(Object sender, EventArgs e)
      {
         HtmlButton myButton = new HtmlButton();

         myButton.InnerText = "Button 1";
         PlaceHolder1.Controls.Add(myButton);

         myButton = new HtmlButton();
         myButton.InnerText = "Button 2";
         PlaceHolder1.Controls.Add(myButton);

         myButton = new HtmlButton();
         myButton.InnerText = "Button 3";
         PlaceHolder1.Controls.Add(myButton);

         myButton = new HtmlButton();
         myButton.InnerText = "Button 4";
         PlaceHolder1.Controls.Add(myButton);
      }

   </script>

</head>

<body>
   <form id="form1" runat="server">
      <h3>PlaceHolder Example</h3>

      <asp:PlaceHolder id="PlaceHolder1" 
           runat="server"/>
   </form>
</body>
</html>

<!--</Snippet1>-->