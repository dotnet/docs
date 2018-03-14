<!-- <Snippet1> -->

<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>Menu StaticItemFormatString and DynamicItemFormatString Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>Menu StaticItemFormatString and DynamicItemFormatString Example</h3>
    
      <asp:menu id="NavigationMenu"
        staticdisplaylevels="1"
        staticsubmenuindent="10" 
        orientation="Vertical"
        target="_blank"  
        runat="server"
        StaticItemFormatString="To Go to: {0}"
        DynamicItemFormatString="Click here: {0}">
        
        <dynamicmenustyle backcolor="LightSkyBlue"
          forecolor="Black"
          borderstyle="Solid"
          borderwidth="1"
          bordercolor="Black" />
      
        <items>
          <asp:menuitem navigateurl="Home.aspx" 
            text="Home"
            tooltip="Home"
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
              text="Movies"
              tooltip="Movies"
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
