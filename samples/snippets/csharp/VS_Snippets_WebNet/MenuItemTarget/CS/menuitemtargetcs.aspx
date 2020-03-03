<!-- <Snippet1> -->

<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>MenuItem Target Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>MenuItem Target Example</h3>
    
      <asp:menu id="NavigationMenu"
        staticdisplaylevels="1"
        staticsubmenuindent="10" 
        orientation="Vertical" 
        target="_blank"  
        runat="server">

        <items>
          <asp:menuitem navigateurl="Home.aspx"
            target="_self" 
            text="Home">
            <asp:menuitem navigateurl="Music.aspx"
              target="_self"
              text="Music">
              <asp:menuitem navigateurl="Classical.aspx"
                target="_blank" 
                text="Classical"/>
              <asp:menuitem navigateurl="Rock.aspx"
                target="_blank"
                text="Rock"/>
              <asp:menuitem navigateurl="Jazz.aspx"
                target="_blank"
                text="Jazz"/>
            </asp:menuitem>
            <asp:menuitem navigateurl="Movies.aspx"
              target="_self"
              text="Movies">
              <asp:menuitem navigateurl="Action.aspx"
                target="_blank"
                text="Action"/>
              <asp:menuitem navigateurl="Drama.aspx"
                target="_blank"
                text="Drama"/>
              <asp:menuitem navigateurl="Musical.aspx"
                target="_blank"
                text="Musical"/>
            </asp:menuitem>
          </asp:menuitem>
        </items>
      
      </asp:menu>

    </form>
  </body>
</html>

<!-- </Snippet1> -->
