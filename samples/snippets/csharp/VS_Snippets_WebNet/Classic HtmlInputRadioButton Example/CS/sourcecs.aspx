<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>HtmlInputRadioButton Sample</title>
<script language="C#" runat="server">

      void Button1_Click(object sender, EventArgs e) 
      {

         if (Radio1.Checked == true)
            Span1.InnerHtml = "Option 1 is selected";
         else if (Radio2.Checked == true)
            Span1.InnerHtml = "Option 2 is selected";
         else if (Radio3.Checked == true)
            Span1.InnerHtml = "Option 3 is selected";
      }

   </script>

</head>
<body>

   <form id="form1" runat="server">

      <h3>HtmlInputRadioButton Sample</h3>

      <input type="radio" 
             id="Radio1" 
             name="Mode" 
             runat="server"/>

      Option 1<br />

      <input type="radio" 
             id="Radio2" 
             name="Mode" 
             runat="server"/>
      
      Option 2<br />

      <input type="radio" 
             id="Radio3" 
             name="Mode" 
             runat="server"/>

      Option 3

      <br />
      <span id="Span1" runat="server" />

      <br />
      <input type="button" 
             id="Button1" 
             value="Enter" 
             onserverclick="Button1_Click" 
             runat="server" />

   </form>

</body>
</html>
   
<!--</Snippet1>-->
