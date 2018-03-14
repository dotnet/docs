<!-- <Snippet1> -->

<%@ page language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>MenuItemBinding Depth Example</title>
</head>
<body>
    <form id="form1" runat="server">

      <h3>MenuItemBinding Depth Example</h3>

      <asp:menu id="NavigationMenu"
        datasourceid="MenuSource"
        runat="server">
        
        <databindings>
        
          <asp:menuitembinding depth="0"
            textfield="Title"
            valuefield="Description"
            imageurlfield="ImageUrl"
            tooltipfield="ToolTip"
            target="_self" />
          <asp:menuitembinding depth="1"
            textfield="Title"
            valuefield="Description"
            imageurlfield="ImageUrl"
            tooltipfield="ToolTip"
            target="_blank"/>
          <asp:menuitembinding depth="2"
            textfield="Title"
            valuefield="Description"
            imageurlfield="ImageUrl"
            tooltipfield="ToolTip"
            target="_blank"/>
          
        </databindings>
        
      </asp:menu>

      <asp:xmldatasource id="MenuSource"
        datafile="MenuDepth.xml"
        runat="server"/> 

    </form>
  </body>
</html>

<!-- </Snippet1> -->