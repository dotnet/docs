<!-- <Snippet1> -->

<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>Menu DataBindings Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>Menu DataBindings Example</h3>
    
      <asp:menu id="NavigationMenu"
        staticdisplaylevels="1"
        staticsubmenuindent="10" 
        orientation="Vertical"
        target="_blank"
        datasourceid="MenuSource"
        runat="server">
        
        <DataBindings>
          <asp:menuitembinding datamember="MapHomeNode" 
            depth="0"
            textfield="title" 
            navigateurlfield="url"/>
          <asp:menuitembinding datamember="MapNode" 
            depth="1"
            textfield="title" 
            navigateurlfield="url"/>
          <asp:menuitembinding datamember="MapNode" 
            depth="2"
            textfield="title" 
            navigateurlfield="url"/>
        </DataBindings>
        
      </asp:menu>
      
      <asp:XmlDataSource id="MenuSource"
        datafile="Map.xml"
        runat="server"/>        

    </form>
  </body>
</html>

<!-- </Snippet1> -->
