<!-- <Snippet1> -->

<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>Menu Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>Menu Example</h3>

      <asp:menu id="NavigationMenu"
        staticdisplaylevels="2"
        staticsubmenuindent="10" 
        orientation="Vertical"
        ScrollDownImageUrl="Images\ScrollDownImage.jpg"
        ScrollDownText="Down"
        ScrollUpImageUrl="Images\ScrollUpImage.jpg"
        ScrollUpText="Up" 
        runat="server">
        
        <dynamicmenustyle Height="50"/>
      
        <items>
          <asp:menuitem text="Home">
            <asp:menuitem text="Category 1">
              <asp:menuitem text="Item 1"/>
              <asp:menuitem text="Item 2"/>
              <asp:menuitem text="Item 3"/>
              <asp:menuitem text="Item 4"/>
              <asp:menuitem text="Item 5"/>
              <asp:menuitem text="Item 6"/>
              <asp:menuitem text="Item 7"/>
              <asp:menuitem text="Item 8"/>
              <asp:menuitem text="Item 9"/>
              <asp:menuitem text="Item 10"/>
            </asp:menuitem>
          </asp:menuitem>
        </items>
      
      </asp:menu>

    </form>
  </body>
</html>

<!-- </Snippet1> -->
