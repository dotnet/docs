<!-- <snippet4> -->
<%@ control language="C#" classname="DisplayModeMenuCS"%>

<script runat="server">
  
 // Use a field to reference the current WebPartManager.
  WebPartManager _manager;

  void Page_Init(object sender, EventArgs e)
  {
    Page.InitComplete += new EventHandler(InitComplete);
  }  

  void InitComplete(object sender, System.EventArgs e)
  {
    _manager = WebPartManager.GetCurrentWebPartManager(Page);

    String browseModeName = WebPartManager.BrowseDisplayMode.Name;

    // Fill the dropdown with the names of supported display modes.
    foreach (WebPartDisplayMode mode in _manager.SupportedDisplayModes)
    {
      String modeName = mode.Name;
      // Make sure a mode is enabled before adding it.
      if (mode.IsEnabled(_manager))
      {
        ListItem item = new ListItem(modeName, modeName);
        DisplayModeDropdown.Items.Add(item);
      }
    }
  }
 
  // Change the page to the selected display mode.
  void DisplayModeDropdown_SelectedIndexChanged(object sender, 
    EventArgs e)
  {
    String selectedMode = DisplayModeDropdown.SelectedValue;

    WebPartDisplayMode mode = 
      _manager.SupportedDisplayModes[selectedMode];
    if (mode != null)
      _manager.DisplayMode = mode;

  }

  void Page_PreRender(object sender, EventArgs e)
  {
    DisplayModeDropdown.SelectedValue = 
      _manager.DisplayMode.Name;
  }

</script>
<div>
  <asp:Panel ID="Panel1" runat="server" 
    Borderwidth="1" 
    Width="125" 
    BackColor="lightgray"
    Font-Names="Verdana, Arial, Sans Serif" >
  <asp:Label ID="Label1" runat="server" 
    Text="&nbsp;Display Mode" 
    Font-Bold="true"
    Font-Size="8"
    Width="120" 
    AssociatedControlID="DisplayModeDropdown"/>
  <asp:DropDownList ID="DisplayModeDropdown" 
    runat="server"  
    AutoPostBack="true" 
    Width="120"
    OnSelectedIndexChanged="DisplayModeDropdown_SelectedIndexChanged" />
  </asp:Panel>
</div>
<!-- </snippet4> -->