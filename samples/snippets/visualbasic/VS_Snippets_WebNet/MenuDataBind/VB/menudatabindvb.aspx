<!-- <Snippet1> -->

<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >

  <!-- For the hover styles of the Menu control to  -->
  <!-- work correctly, you must include this head   -->
  <!-- element.                                     -->
  <head runat="server">
    <title>Menu DataBinding Example</title>
</head>

  <body>
    <form id="form1" runat="server">
    
      <h3>Menu DataBinding Example</h3>
    
      <!-- Bind the Menu control to a SiteMapDataSource control.  -->
      <asp:menu id="NavigationMenu"
        disappearafter="2000"
        staticdisplaylevels="2"
        staticsubmenuindent="10" 
        orientation="Vertical"
        font-names="Arial" 
        target="_blank"
        datasourceid="MenuSource"   
        runat="server">
        
        <staticmenuitemstyle backcolor="LightSteelBlue"
          forecolor="Black"/>
        <statichoverstyle backcolor="LightSkyBlue"/>
        <dynamicmenuitemstyle backcolor="Black"
          forecolor="Silver"/>
        <dynamichoverstyle backcolor="LightSkyBlue"
          forecolor="Black"/>

      </asp:menu>
      
      <asp:SiteMapDataSource id="MenuSource"
        runat="server"/>        

    </form>
  </body>
</html>

<!-- </Snippet1> -->
