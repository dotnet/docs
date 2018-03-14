<!-- <snippet1> -->
<%@ Page Language="C#" 
  Codefile="genericwebpart.cs" 
  Inherits="genericwebpart_sample" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>GenericWebPart Example</title>
</head>
<body>
    <form id="form1" runat="server">
      <asp:WebPartManager ID="WebPartManager1" runat="server">
      </asp:WebPartManager>
      <!-- <snippet2> -->
      <asp:WebPartZone ID="WebPartZone1" runat="server">
        <ZoneTemplate>
          <asp:Calendar ID="Calendar1" runat="server"
            Title="My Calendar"
            Description="A calendar used as a GenericWebPart control."
            CatalogIconImageUrl="MyCatalogIcon.gif"
            TitleIconimageUrl ="MyTitleIcon.gif"
            TitleUrl="MyInfoUrl.htm" 
            Width="250"/>
        </ZoneTemplate>
      </asp:WebPartZone>
      <!-- </snippet2> -->
      <asp:WebPartZone ID="WebPartZone2" runat="server">
        <ZoneTemplate>
          <asp:BulletedList ID="BulletedList1" 
            Runat="server"
            DisplayMode="HyperLink">
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
        </ZoneTemplate>
      </asp:WebPartZone>
      <hr />
      <asp:Button ID="Button1" width="200"
        runat="server" 
        Text="Display All Property Values" OnClick="Button1_Click" /> 
      <br />
      <asp:Label ID="Label2" runat="server" Text="" />
      <br />   
      <asp:Label ID="Label3" runat="server" Text="" />
    </form>
</body>
</html>
<!-- </snippet1> -->