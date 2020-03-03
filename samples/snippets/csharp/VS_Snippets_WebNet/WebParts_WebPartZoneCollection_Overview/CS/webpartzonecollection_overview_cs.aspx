<!-- <snippet1> -->
<%@ Page Language="C#" 
    Codefile="webpartzonecollection_overview.cs" 
    Inherits="webpartzonecollection_overview" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
    
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>WebPartZoneCollection Demo</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:WebPartManager ID="mgr" runat="server" />
    <asp:Table ID="Table1" runat="server">
      <asp:TableRow>
        <asp:TableCell>
          <asp:Label ID="lblZone1" runat="server" 
            Font-Bold="true"
            AssociatedControlID="WebPartZone1">
            WebPartZone1 Contents
          </asp:Label>
          <asp:WebPartZone ID="WebPartZone1" 
            runat="server" Width="230">
            <ZoneTemplate>
              <asp:BulletedList 
                ID="BulletedList1" 
                Runat="server"
                DisplayMode="HyperLink"
                Title="Favorite Links">
                <asp:ListItem 
                  Value="http://msdn.microsoft.com">
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
          <div>
          <asp:Label ID="lblZone2" runat="server" 
            Font-Bold="true"
            AssociatedControlID="WebPartZone2">
            WebPartZone2 Contents
          </asp:Label>
          </div>
          <asp:WebPartZone ID="WebPartZone2" 
            runat="server" Width="230">
            <ZoneTemplate>
              <asp:Calendar ID="Calendar1" 
                runat="server" 
                Title="My Calendar" 
                CatalogIconImageUrl="Mine.gif" />
            </ZoneTemplate>
          </asp:WebPartZone> 
        </asp:TableCell>
        <asp:TableCell VerticalAlign="top"> 
          <asp:Label ID="lblZone3" runat="server" 
            Font-Bold="true" 
            AssociatedControlID="WebPartZone3">
            WebPartZone3 Contents
          </asp:Label>
          <asp:WebPartZone ID="WebPartZone3" runat="server">
            <ZoneTemplate>
              <asp:Table runat="server" ID="table2" 
                Title="Employee Extensions">
                <asp:TableHeaderRow>
                  <asp:TableHeaderCell Scope="Column">
                    Employee Name</asp:TableHeaderCell>
                  <asp:TableHeaderCell Scope="Column">
                    Extension</asp:TableHeaderCell>
                </asp:TableHeaderRow>
                <asp:TableRow>
                  <asp:TableCell>Alberts, Amy</asp:TableCell>
                  <asp:TableCell>x9764</asp:TableCell>
                </asp:TableRow>                
                <asp:TableRow>
                  <asp:TableCell>Hanif, Karim</asp:TableCell>
                  <asp:TableCell>x3240</asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                  <asp:TableCell>Penor, Lori</asp:TableCell>
                  <asp:TableCell>x4165</asp:TableCell>
                </asp:TableRow>
              </asp:Table>
            </ZoneTemplate>
          </asp:WebPartZone>
        </asp:TableCell>
      </asp:TableRow>
    </asp:Table>
    </div>
    <hr />
    <asp:Table ID="Table3" runat="server">
      <asp:TableRow>
        <asp:TableCell>
          <asp:Button ID="Button1" runat="server" 
            Width ="200" OnClick="Button1_Click" 
            Text="Total Zone Count" />
          <br />
          <asp:Button ID="Button2" runat="server" 
            Width ="200" OnClick="Button2_Click"
            Text="Coll. Contains WebPartZone2" />
          <br />
          <asp:Button ID="Button3" runat="server" 
            Width ="200" OnClick="Button3_Click"
            Text="Zone Names from Array" />
          <br />
          <asp:Button ID="Button4" runat="server" 
            Width ="200" OnClick="Button4_Click"
            Text="WebPartZone1 Index" />  
          <br />
          <asp:Button ID="Button5" runat="server" 
            Width ="200" OnClick="Button5_Click"
            Text="Toggle Verb Render Mode" />
        </asp:TableCell>
        <asp:TableCell HorizontalAlign="right" 
          Width="200" VerticalAlign="top">
          <asp:Label ID="Label1" runat="server" 
            Font-Bold="true" />
        </asp:TableCell>  
      </asp:TableRow>
    </asp:Table>
    </form>
</body>
</html>
<!-- </snippet1> -->