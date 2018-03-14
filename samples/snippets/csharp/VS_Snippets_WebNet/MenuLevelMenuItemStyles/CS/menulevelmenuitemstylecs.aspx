<!-- <Snippet1> -->

<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>Menu LevelMenuItemStyles and LevelSelectedStyles Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>Menu LevelMenuItemStyles and LevelSelectedStyles Example</h3>

      <asp:menu id="NavigationMenu"
        staticdisplaylevels="2"
        staticsubmenuindent="10" 
        orientation="Vertical"
        target="_blank"  
        runat="server">
        
        <levelmenuitemstyles>
          <asp:menuitemstyle BackColor="LightSteelBlue"
            forecolor="Black"/>
          <asp:menuitemstyle BackColor="SkyBlue"
            forecolor="Black"/>
          <asp:menuitemstyle BackColor="LightSkyBlue"
            forecolor="Black"/>            
        </levelmenuitemstyles>
        <levelselectedstyles>
          <asp:menuitemstyle BackColor="Cyan"
           forecolor="Gray"/>
          <asp:menuitemstyle BackColor="LightCyan"
           forecolor="Gray"/>
          <asp:menuitemstyle BackColor="PaleTurquoise"
           forecolor="Gray"/>            
        </levelselectedstyles>    
      
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
