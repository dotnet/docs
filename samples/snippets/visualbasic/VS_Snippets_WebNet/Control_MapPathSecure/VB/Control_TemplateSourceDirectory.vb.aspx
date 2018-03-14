<%@ Page language="VB" %>
<%@ Register TagPrefix="CustomControl" Namespace="Control_TemplateSource" Assembly="Control_TemplateSourceDirectory"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
   <head>
    <title>ASP.NET Example</title>
</head>
   <body>
      <form id="Form1" method="post" runat="server">
         <CustomControl:MyControl runat="server" id="MyControl1">
         </CustomControl:MyControl>
      </form>
   </body>
</html>
