<!-- <snippet1> -->
<%@ Page Language="VB" 
  Codefile="webpartzonebase_overview.vb"
  Inherits="WebPartZoneBase_overview"  %>
<%@ register TagPrefix="uc1" 
  TagName="DisplayModeMenuVB" 
  Src="DisplayModeMenuVB.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>WebPartZoneBase Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:WebPartManager ID="WebPartManager1" Runat="server" />
      <uc1:DisplayModeMenuVB ID="DisplayModeMenu1" runat="server" />
      <table width="75%">
        <tr>
          <td>
            <!-- <snippet2> -->
            <asp:WebPartZone 
              ID="WebPartZone1" 
              Runat="server"
              LayoutOrientation="Vertical" >
              <EditVerb Text="Edit WebPart" />
              <SelectedPartChromeStyle BackColor="LightBlue" />
              <ZoneTemplate>
                <asp:BulletedList 
                  ID="BulletedList1" 
                  Runat="server"
                  DisplayMode="HyperLink" 
                  Title="Favorite Links" >
                  <asp:ListItem Value="http://msdn.microsoft.com">
                    MSDN
                  </asp:ListItem>
                  <asp:ListItem Value="http://www.asp.net">
                    ASP.NET
                  </asp:ListItem>
                  <asp:ListItem Value="http://www.msn.com">
                    MSN
                  </asp:ListItem>
                </asp:BulletedList>
                <asp:Calendar ID="Calendar1" Runat="server" 
                  Title="My Calendar" />
              </ZoneTemplate>
            </asp:WebPartZone>
            <!-- </snippet2> -->          
          </td>
          <td valign="top" align="right">
            <!-- <snippet3> -->
            <asp:WebPartZone 
              ID="WebPartZone2"
              Runat="server" 
              DragHighlightColor="#00ff00"
              AllowLayoutChange="true"
              EmptyZoneText="Add WebParts to this empty Zone."
              BorderWidth="2"
              BorderColor="DarkBlue"
              BorderStyle="Dashed" 
              MenuLabelText="Verbs Menu" 
              MenuPopupImageUrl="label.gif" >
              <VerbStyle Font-Italic="true" />
              <MenuLabelStyle BackColor="Lime" BorderWidth="1"  />
              <MenuLabelHoverStyle Font-Bold="true" />
              <MenuVerbHoverStyle BackColor="LightGrey" />
              <MenuVerbStyle Font-Italic="true" /> 
              <ZoneTemplate>
                <asp:Label ID="Label1" Runat="server" Title="Date" />
              </ZoneTemplate>
            </asp:WebPartZone>
            <!-- </snippet3> -->         
          </td>
        </tr>
        <tr>
          <td>
            <asp:EditorZone ID="EditorZone1" Runat="server">
              <ZoneTemplate>
                <asp:AppearanceEditorPart ID="AppearanceEditorPart1" 
                  Runat="server" />
                <asp:LayoutEditorPart ID="LayoutEditorPart1" 
                  Runat="server" />
              </ZoneTemplate>
            </asp:EditorZone>      
          </td>
        </tr>
      </table>
    </div>
    <asp:Button ID="Button1" Runat="server" 
      Width="200" Text="Toggle WebPartZone2 Buttons" 
      OnClick="Button1_Click" />
    <br />
    <asp:Button ID="Button2" Runat="server" 
      Width="200"  Text="Toggle Layout Orientation" 
      OnClick="Button2_Click" />
    <br />
    <asp:Button ID="Button3" Runat="server" 
      Width="200" Text="List WebPartZone1 WebParts" 
      OnClick="Button3_Click" />
    <br />
    <asp:Button ID="Button4" Runat="server" 
      Width="200" Text="WebPartZone1 Display Title" 
      OnClick="Button4_Click" />
    <br />
    <asp:Label ID="Label2" Runat="server" Visible="false" />
    </form>
</body>
</html>
<!-- </snippet1> -->