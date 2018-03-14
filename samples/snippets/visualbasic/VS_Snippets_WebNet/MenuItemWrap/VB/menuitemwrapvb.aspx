<!-- <Snippet1> -->

<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >

  <head runat="server">
    <title>Menu ItemWrap Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>Menu ItemWrap Example</h3>
    
      <!-- Place the Menu control in a table to force text -->
      <!-- wrapping to occur.                              -->
      <table style="border:1; height:100%">
        <tr>
          <td style="width:200px; vertical-align:top">
            <asp:menu id="NavigationMenu"
              staticdisplaylevels="2"
              staticsubmenuindent="10" 
              orientation="Vertical"
              itemwrap="true"
              dynamicverticaloffset="10"    
              runat="server">
              
              <staticmenuitemstyle verticalpadding="10"/> 
            
              <items>
                <asp:menuitem text="How to Add a Menu Control to a Web Form">
                  <asp:menuitem text="Procedure 1">
                    <asp:menuitem text="Step 1"/>
                    <asp:menuitem text="Step 2"/>
                  </asp:menuitem>
                </asp:menuitem>
              </items>
            
            </asp:menu>
          </td>
        </tr>      
      </table>

    </form>
  </body>
</html>

<!-- </Snippet1> -->
