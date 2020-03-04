
<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html  >

  <!-- For the hover styles of the Menu control to  -->
  <!-- work correctly, you must include this head   -->
  <!-- element.                                     -->
  <head id="Head1" runat="server">
    <title>Menu Declarative Example</title>
</head>

  <body>
    <form id="form1" runat="server">

      <h3>Menu Declarative Example</h3>

      <!-- Use declarative syntax to create the   -->
      <!-- menu structure. Submenu items are      -->
      <!-- created by nesting them in parent menu -->
      <!-- items.                                 -->
      <asp:menu id="NavigationMenu"
        disappearafter="2000"
        staticdisplaylevels="2"
        staticsubmenuindent="10" 
        orientation="Vertical"
        font-names="Arial" 
        target="_blank"  
        runat="server">

        <staticmenuitemstyle backcolor="LightSteelBlue"
          forecolor="Black"/>
        <statichoverstyle backcolor="LightSkyBlue"/>
        <dynamicmenuitemstyle backcolor="Black"
          forecolor="Silver"/>
        <dynamichoverstyle backcolor="LightSkyBlue"
          forecolor="Black"/>

        <items>
          <asp:menuitem navigateurl="Home.aspx" 
            text="Home"
            tooltip="Home">
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
              tooltip="Movies">
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