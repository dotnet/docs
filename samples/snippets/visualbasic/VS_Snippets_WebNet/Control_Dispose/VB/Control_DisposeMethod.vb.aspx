<%@ Page language="VB"%>
<% @Register TagPrefix="Customcontrol" NameSpace="CustomControlNameSpace" Assembly="Control_DisposeMethod"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
   <head>
    <title>ASP.NET Example</title>
</head>
   <body>
      <form id="Form1" method="post" runat="server">
         <CustomControl:MyCustomControl ID="myControl" runat="server">
         </CustomControl:MyCustomControl>
      </form>
   </body>
</html>
