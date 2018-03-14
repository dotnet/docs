<%@ Register TagPrefix="ControlSample" Namespace="ControlSample" Assembly="Control_AddParsedSubObject" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
   <head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
      <form id="form1" method="POST" runat="server">
         <ControlSample:MyControl runat="server">
            <myitem Text="One" />
            <myitem Text="Two" />
            <myitem Text="Three" />
            <myitem Text="Four" />
         </ControlSample:MyControl>
      </form>
   </body>
</html>
