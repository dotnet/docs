<!--<Snippet1>-->
<%@ Page Language="VB" AutoEventWireup="True" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title> Calendar Caption and Caption Align Example </title>
</head>
<body>

   <form id="form1" runat="server">
  
      <h3> Calendar Caption and Caption Align Example </h3>

      <br /><br /> 
  
      <asp:Calendar id="Calendar1"
           ShowGridLines="True" 
           ShowTitle="True"
            Caption="This calendar is used to demonstrate a calendar caption. It also shows
            how the caption can be aligned to the calendar, in this case to the right edge of
            the calendar."
            CaptionAlign="right"  
           runat="server"/>

      <br /><br />

   </form>

</body>
</html>
 
<!--</Snippet1>-->
