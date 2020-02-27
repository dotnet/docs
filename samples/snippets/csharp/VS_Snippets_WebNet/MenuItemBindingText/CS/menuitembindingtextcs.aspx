<!-- <Snippet1> -->

<%@ page language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>MenuItemBinding Example</title>
</head>
<body>
    <form id="form1" runat="server">

      <h3>MenuItemBinding Example</h3>

      <asp:menu id="NavigationMenu"
        datasourceid="MenuSource"
        runat="server">
        
        <databindings>
        
          <asp:menuitembinding datamember="MapHomeNode"
            textfield="Title"
            valuefield="Description"
            imageurlfield="ImageUrl"
            tooltipfield="ToolTip"/>
          <asp:menuitembinding datamember="MapNode" 
            depth="1"
            textfield="Title"
            valuefield="Description"
            imageurlfield="ImageUrl"
            tooltipfield="ToolTip"/>
          <asp:menuitembinding datamember="MapNode" 
            depth="2"
            text="Static Title"
            value="Static Description"
            imageurl="~\Images\StaticImage.jpg"
            tooltip="Static ToolTip"/>
          
        </databindings>
        
      </asp:menu>

      <asp:xmldatasource id="MenuSource"
        datafile="Menu.xml"
        runat="server"/> 

    </form>
  </body>
</html>

<!-- </Snippet1> -->