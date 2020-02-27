<!--<Snippet1>-->
<%@ Page Language="C#" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>HtmlControl TagName Property Example</title>
<script language="C#" runat="server">
 
      void Submit_Clicked(Object sender, EventArgs e) 
      {
         
         Message.InnerHtml = "My TagName is: " + Submit1.TagName;
 
      }        
      
 
   </script>
</head>
 
<body>
   <form id="form1" method="post" runat="server">

      <h3>HtmlControl TagName Property Example</h3>

      <input id="Submit1"        
             type="submit"
             value="Click Me!!"
             onserverclick="Submit_Clicked"
             runat="server"/>
      
      <br /><br />

      <span id="Message" runat="server"/>  
 
   </form>

</body>
</html>

<!--</Snippet1>-->
