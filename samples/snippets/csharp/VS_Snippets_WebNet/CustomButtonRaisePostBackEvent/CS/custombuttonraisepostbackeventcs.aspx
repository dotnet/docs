<!-- <Snippet1> -->
<%@ Page language="c#" %>
<%@ Register TagPrefix="aspSample" Namespace="Samples.AspNet.CS.Controls" Assembly="Samples.AspNet.CS" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head>
    <title>Custom Button - RaisePostBackEvent - C# Example</title>
  </head>
  <body>
    <form id="Form1" method="post" runat="server">
      <h3>Custom Button - RaisePostBackEvent - C# Example</h3>

      <aspSample:CustomButtonRaisePostBackEvent
        id="Button1"
        runat="server"
        Text="Button" />

    </form>
  </body>
</html>
<!-- </Snippet1> -->
