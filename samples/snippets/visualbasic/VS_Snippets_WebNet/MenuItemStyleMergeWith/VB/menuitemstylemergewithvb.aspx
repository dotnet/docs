<!-- <Snippet1> -->

<%@ Page Language="VB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  Sub SubmitButton_Click(ByVal sender As Object, ByVal e As EventArgs)
  
    ' Use the MergeWith method to merge the 
    ' StaticMenuItemStyle property settings from 
    ' the source Menu control and the target
    ' Menu control.
    Dim sourceMenuStyle As MenuItemStyle = SourceMenu.StaticMenuItemStyle
    TargetMenu.StaticMenuItemStyle.MergeWith(sourceMenuStyle)
  
  End Sub
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>MenuItemStyle MergeWith Example</title>
</head>
<body>
    <form id="form1" runat="server">
    
      <h3>MenuItemStyle MergeWith Example</h3>
      
      <table cellpadding="20"
        border="1">
        <tr>
          <th>          
            Source StaticMenuItemStyle          
          </th> 
          <th>          
            Target StaticMenuItemStyle          
          </th>       
        </tr>
        <tr>
          <td>
          
            <asp:menu id="SourceMenu"
              staticdisplaylevels="2"
              staticsubmenuindent="10" 
              orientation="Vertical"
              runat="server">
              
              <staticmenuitemstyle backcolor="LightSteelBlue"
                horizontalpadding="5"
                verticalpadding="2"/>
            
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

          </td>
          <td>
          
            <asp:menu id="TargetMenu"
              staticdisplaylevels="2"
              staticsubmenuindent="10" 
              orientation="Vertical"
              runat="server">
              
              <staticmenuitemstyle font-names="Arial"   
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

          </td>
        </tr>   
      </table>
      
      <asp:button id="SubmitButton"
        text="Copy Static Menu Item Style"
        onclick="SubmitButton_Click" 
        runat="server"/>
      
    </form>
  </body>
</html>

<!-- </Snippet1> -->
