<!-- <Snippet1> -->

<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>MenuItem Declarative Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>MenuItem Declarative Example</h3>
    
      <!-- Use declarative syntax to create the   -->
      <!-- menu structure. Create submenu items   -->
      <!-- by nesting them within parent menu     -->
      <!-- items.                                 -->
      <asp:menu id="NavigationMenu"
        staticdisplaylevels="1"
        staticsubmenuindent="10" 
        orientation="Vertical" 
        target="_blank"  
        runat="server">

        <items>
          <asp:menuitem navigateurl="Home.aspx" 
            text="Home"
            imageurl="Images\Home.gif"
            popoutimageurl="Images\Popout.jpg"   
            tooltip="Home">
            <asp:menuitem navigateurl="Music.aspx"
              text="Music"
              popoutimageurl="Images\Popout.jpg"
              tooltip="Music">
              <asp:menuitem navigateurl="Classical.aspx" 
                text="Classical"
                separatorimageurl="Images\Separator.jpg"
                tooltip="Classical"/>
              <asp:menuitem navigateurl="Rock.aspx"
                text="Rock"
                separatorimageurl="Images\Separator.jpg"
                tooltip="Rock"/>
              <asp:menuitem navigateurl="Jazz.aspx"
                text="Jazz"
                separatorimageurl="Images\Separator.jpg"
                tooltip="Jazz"/>
            </asp:menuitem>
            <asp:menuitem navigateurl="Movies.aspx"
              text="Movies"
              popoutimageurl="Images\Popout.jpg"              
              tooltip="Movies">
              <asp:menuitem navigateurl="Action.aspx"
                text="Action"
                separatorimageurl="Images\Separator.jpg"
                tooltip="Action"/>
              <asp:menuitem navigateurl="Drama.aspx"
                text="Drama"
                separatorimageurl="Images\Separator.jpg"
                tooltip="Drama"/>
              <asp:menuitem navigateurl="Musical.aspx"
                text="Musical"
                separatorimageurl="Images\Separator.jpg"
                tooltip="Musical"/>
            </asp:menuitem>
          </asp:menuitem>
        </items>
      
      </asp:menu>

    </form>
  </body>
</html>

<!-- </Snippet1> -->
