<!-- <snippet1> -->
<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  protected void Page_Init(object sender, EventArgs e)
  {
    foreach (WebPartDisplayMode mode in mgr.SupportedDisplayModes)
    {
      string modeName = mode.Name;
      if (mode.IsEnabled(mgr))
      {
        ListItem item = new ListItem(modeName, modeName);
        DisplayModeDropdown.Items.Add(item);
      }      
    }
  }

  protected void DisplayModeDropdown_SelectedIndexChanged(object 
    sender, EventArgs e)
  {
    String selectedMode = DisplayModeDropdown.SelectedValue;
    WebPartDisplayMode mode = 
      mgr.SupportedDisplayModes[selectedMode];
    if (mode != null)
      mgr.DisplayMode = mode;
  }

  protected void Page_PreRender(object sender, EventArgs e)
  {
    if (mgr.DisplayMode == WebPartManager.CatalogDisplayMode)
      Label1.Visible = true;
    else
      Label1.Visible = false;
  }
  
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <asp:WebPartManager ID="mgr" runat="server">
      </asp:WebPartManager>
      <asp:WebPartZone ID="WebPartZone1" runat="server">
        <ZoneTemplate>
          <asp:BulletedList 
            DisplayMode="HyperLink" 
            ID="BulletedList1" 
            runat="server"
            Title="My Links">
            <asp:ListItem Value="http://www.microsoft.com">
            Microsoft
            </asp:ListItem>
            <asp:ListItem Value="http://www.msn.com">
            MSN
            </asp:ListItem>
            <asp:ListItem Value="http://www.contoso.com">
            Contoso Corp.
            </asp:ListItem>
          </asp:BulletedList> 
        </ZoneTemplate>
      </asp:WebPartZone>
      <asp:WebPartZone ID="WebPartZone2" runat="server" />
      <asp:CatalogZone ID="CatalogZone1" runat="server">
        <ZoneTemplate>
          <asp:DeclarativeCatalogPart 
            ID="DeclarativeCatalogPart1" 
            runat="server">
            <WebPartsTemplate>
              <asp:Calendar ID="Calendar1" runat="server" 
                Title="My Calendar" />             
            </WebPartsTemplate>
          </asp:DeclarativeCatalogPart>
        </ZoneTemplate>
      </asp:CatalogZone>
      <hr />
      <asp:Label ID="Label1" runat="server" 
        Text="Currently in Catalog Mode" 
        Font-Bold="true"
        Font-Size="125%" />
      <br />
      <asp:DropDownList ID="DisplayModeDropdown" 
        runat="server" 
        AutoPostBack="true"
        Width="120"
        OnSelectedIndexChanged=
        "DisplayModeDropdown_SelectedIndexChanged">
      </asp:DropDownList>
    </div>
    </form>
</body>
</html>
<!-- </snippet1> -->