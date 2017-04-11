<!-- <snippet8> -->
<%@ control language="C#" classname="DisplayModeMenu"%>

<script runat="server">

  // On initial load, fill the dropdown with display modes.
  void DisplayModeDropdown_Load(object sender, System.EventArgs e)
  {
    if (!IsPostBack)
    {
      WebPartManager mgr = 
        WebPartManager.GetCurrentWebPartManager(Page);
      String browseModeName = WebPartManager.BrowseDisplayMode.Name;
      // Use a sorted list so the modes are sorted alphabetically.
      SortedList itemArray = 
        new SortedList(mgr.SupportedDisplayModes.Count);

      // Add display modes only if they are supported on the page.
      foreach (WebPartDisplayMode mode in mgr.SupportedDisplayModes)
      {
        String modeName = mode.Name;
        itemArray.Add(modeName, modeName + " Mode");      
      }
      // Fill the dropdown with the display mode names.
      foreach(DictionaryEntry arrayItem in itemArray)
      {
        ListItem item = new ListItem(arrayItem.Value.ToString(), 
          arrayItem.Key.ToString());
        if (item.Value == browseModeName)
          item.Selected = true;
        DisplayModeDropdown.Items.Add(item);
      }
    }
  }

  // Change the page to the selected display mode.
  void DisplayModeDropdown_SelectedIndexChanged(object sender, 
    EventArgs e)
  {
    WebPartManager mgr = WebPartManager.GetCurrentWebPartManager(Page);
    String selectedMode = DisplayModeDropdown.SelectedValue;

    foreach (WebPartDisplayMode mode in mgr.SupportedDisplayModes)
    {
      if (selectedMode == mode.Name)
      {
        mgr.DisplayMode = mode;
        break;
      }
    }
  }

</script>
<div>
  <asp:DropDownList ID="DisplayModeDropdown" 
    runat="server" 
    AutoPostBack="true" 
    OnLoad="DisplayModeDropdown_Load" 
    OnSelectedIndexChanged="DisplayModeDropdown_SelectedIndexChanged" />
</div>
<!-- </snippet8> -->