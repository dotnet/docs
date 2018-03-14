<!-- <Snippet1> -->

<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>Menu Selectable and Enabled properties Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>Menu Selectable and Enabled properties Example</h3>
    Note that Home, set to Selectable=false, is unselectable, but still shows all child items.<br />
    Movies, set to Enabled=false, is unselectable, is greyed out, and does not show child items. <br />
      <asp:menu id="NavigationMenu"
        staticdisplaylevels="1"
        staticsubmenuindent="10" 
        orientation="Vertical"
        target="_blank"  
        runat="server">
        
        <dynamicmenustyle backcolor="LightSkyBlue"
          forecolor="Black"
          borderstyle="Solid"
          borderwidth="1"
          bordercolor="Black" />
      
        <items>
          <asp:menuitem navigateurl="Home.aspx" 
            text="Non-Selectable"
            tooltip="Non-Selectable"
              Selectable="false">
            <asp:menuitem navigateurl="Music.aspx"
              text="Music"
              tooltip="Music">
              <asp:menuitem navigateurl="Classical.aspx" 
                text="Classical"
                tooltip="Classical"/>
              <asp:menuitem navigateurl="Rock.aspx"
                text="Rock"
                tooltip="Rock"/>
              <asp:menuitem navigateurl="Jazz.aspx"
                text="Jazz"
                tooltip="Jazz"/>
            </asp:menuitem>
            <asp:menuitem navigateurl="Movies.aspx"
              text="Disabled"
              tooltip="Disabled"
              Enabled="false">
              <asp:menuitem navigateurl="Action.aspx"
                text="Action"
                tooltip="Action"/>
                 
              <asp:menuitem navigateurl="Drama.aspx"
                text="Drama"
                tooltip="Drama"/>
              <asp:menuitem navigateurl="Musical.aspx"
                text="Musical"
                tooltip="Musical"/>
            </asp:menuitem>
          </asp:menuitem>
        </items>
      
      </asp:menu>

    </form>
  </body>
</html>

<!-- </Snippet1> -->
