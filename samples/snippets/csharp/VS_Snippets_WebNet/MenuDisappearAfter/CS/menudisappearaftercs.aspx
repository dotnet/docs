<!-- <Snippet1> -->

<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>Menu DisappearAfter Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>Menu DisappearAfter Example</h3>
    
      <!-- Use the DisappearAfter property to  -->
      <!-- hide the dynamic menu items if the  -->
      <!-- user moves the mouse pointer away   -->
      <!-- from the menu for two seconds.      -->
      <asp:menu id="NavigationMenu"
        disappearafter="2000"
        staticdisplaylevels="1"
        orientation="Vertical"   
        runat="server">
      
        <items>
          <asp:menuitem navigateurl="~\Home.aspx" 
            text="Home"/>
          <asp:menuitem navigateurl="~\Music.aspx"
            text="Music">
            <asp:menuitem navigateurl="~\Classical.aspx" 
              text="Classical"/>
            <asp:menuitem navigateurl="~\Rock.aspx"
              text="Rock"/>
            <asp:menuitem navigateurl="~\Jazz.aspx"
              text="Jazz"/>
          </asp:menuitem>
          <asp:menuitem navigateurl="~\Movies.aspx"
            text="Movies">
            <asp:menuitem navigateurl="~\Action.aspx"
              text="Action"/>
            <asp:menuitem navigateurl="~\Drama.aspx"
              text="Drama"/>
            <asp:menuitem navigateurl="~\SciFi.aspx"
              text="Science Fiction"/>
          </asp:menuitem>
        </items>
      
      </asp:menu>

    </form>
  </body>
</html>

<!-- </Snippet1> -->
