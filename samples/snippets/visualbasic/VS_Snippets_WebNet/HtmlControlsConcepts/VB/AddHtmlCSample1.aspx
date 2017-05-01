<%@ Page Language="VB"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>How to: Add HTML Server Controls to a Web Forms Page using ASP.NET Syntax</title>
</head>

<body>
    <form id="form1" runat="server">
    
      <!--<Snippet1>-->
      <input id="Name" type="text" size="40" runat="server" />
      <input type="submit" id="Enter" value="Enter" runat="server" />
      Click <a id="Anchor1" runat="server" href="more.html">More </a> to see the next page. 
      <!--</Snippet1>-->
    
    </form>
</body>
</html>
