<!-- <Snippet1> -->

<%@ page language="VB" %>

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
        
        <DataBindings>
        
          <asp:menuitembinding datamember="MapHomeNode"
            formatstring="({0})" 
            textfield="Title"
            valuefield="Description"
            imageurlfield="ImageUrl"
            tooltipfield="ToolTip"
            target="_self" />
          <asp:menuitembinding datamember="MapNode" 
            depth="1"
            formatstring="[{0}]" 
            textfield="Title"
            valuefield="Description"
            imageurlfield="ImageUrl"
            tooltipfield="ToolTip"
            target="_blank"/>
          <asp:menuitembinding datamember="MapNode" 
            depth="2"
            formatstring="<{0}>" 
            textfield="Title"
            valuefield="Description"
            imageurlfield="ImageUrl"
            tooltipfield="ToolTip"
            target="_blank"/>
          
        </DataBindings>
        
      </asp:menu>

      <asp:xmldatasource id="MenuSource"
        datafile="Menu.xml"
        runat="server"/> 

    </form>
  </body>
</html>

<!-- </Snippet1> -->