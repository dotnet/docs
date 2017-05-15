<!-- <Snippet1> -->

<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >

  <!-- For the hover styles of the Menu control to  -->
  <!-- work correctly, you must include this head   -->
  <!-- element.                                     -->
  <head runat="server">
    <title>MenuItemStyle Example</title>
</head>

  <body>
    <form id="form1" runat="server">
    
      <h3>MenuItemStyle Example</h3>
    
      <!-- Set the style properties of the        -->
      <!-- MenuItemStyle objects contained in the -->
      <!-- StaticMenuItemStyle, StaticHoverStyle, -->
      <!-- DynamicMenuItemStyle, and              -->
      <!-- DynamicHoverStyle properties.          -->
      
      <asp:menu id="NavigationMenu"
        staticdisplaylevels="2"
        staticsubmenuindent="10" 
        orientation="Vertical"
        runat="server">
        
        <staticmenuitemstyle backcolor="LightSteelBlue"
          horizontalpadding="5"
          verticalpadding="2"
          font-names="Arial"   
          forecolor="Black"/>
        <statichoverstyle backcolor="LightSkyBlue"
          font-names="Arial"
          forecolor="Red"/>
        <dynamicmenuitemstyle backcolor="Black"
          horizontalpadding="10"
          verticalpadding="4"
          itemspacing="2"
          font-names="Arial"
          forecolor="Silver"/>
        <dynamichoverstyle backcolor="LightSkyBlue"
          font-names="Arial"
          forecolor="Red"/>
      
        <items>
          <asp:menuitem text="Home"
            tooltip="Home">
            <asp:menuitem text="Music"
              tooltip="Music">
              <asp:menuitem text="Classical"
                tooltip="Classical"/>
              <asp:menuitem text="Rock"
                tooltip="Rock"/>
              <asp:menuitem text="Jazz"
                tooltip="Jazz"/>
            </asp:menuitem>
            <asp:menuitem text="Movies"
              tooltip="Movies">
              <asp:menuitem text="Action"
                tooltip="Action"/>
              <asp:menuitem text="Drama"
                tooltip="Drama"/>
              <asp:menuitem text="Musical"
                tooltip="Musical"/>
            </asp:menuitem>
          </asp:menuitem>
        </items>
      
      </asp:menu>

    </form>
  </body>
</html>

<!-- </Snippet1> -->
