<!-- <snippet8> -->
<%@ control language="vb" classname="DisplayModeMenu"%>

<script runat="server">

 ' On initial load, fill the dropdown with display modes.
  Sub DisplayModeDropdown_Load(ByVal sender As Object, _
                               ByVal e As System.EventArgs)
    If Not IsPostBack Then
      Dim mgr As WebPartManager = _
        WebPartManager.GetCurrentWebPartManager(Page)
      Dim browseModeName As String = _
        WebPartManager.BrowseDisplayMode.Name
      ' Use a sorted list so the modes are sorted alphabetically.
      Dim itemArray As New SortedList(mgr.SupportedDisplayModes.Count)
        
      ' Add display modes only if they are supported on the page.
      Dim mode As WebPartDisplayMode
      For Each mode In mgr.SupportedDisplayModes
        Dim modeName As String = mode.Name
        itemArray.Add(modeName, modeName + " Mode")
      Next mode
      ' Fill the dropdown with the display mode names.
      Dim arrayItem As DictionaryEntry
      For Each arrayItem In itemArray
        Dim item As New ListItem(arrayItem.Value.ToString(), _
                                 arrayItem.Key.ToString())
        If item.Value = browseModeName Then
          item.Selected = True
        End If
        DisplayModeDropdown.Items.Add(item)
      Next arrayItem
    End If

  End Sub


' Change the page to the selected display mode.
  Sub DisplayModeDropdown_SelectedIndexChanged(ByVal sender As Object, _
                                               ByVal e As EventArgs)
    Dim mgr As WebPartManager = _
      WebPartManager.GetCurrentWebPartManager(Page)
    Dim selectedMode As String = DisplayModeDropdown.SelectedValue
    
    Dim mode As WebPartDisplayMode
    For Each mode In mgr.SupportedDisplayModes
      If selectedMode = mode.Name Then
        mgr.DisplayMode = mode
        Exit For
      End If
    Next mode

  End Sub

</script>
<div>
  <asp:DropDownList ID="DisplayModeDropdown" 
    runat="server" 
    AutoPostBack="true" 
    OnLoad="DisplayModeDropdown_Load" 
    OnSelectedIndexChanged="DisplayModeDropdown_SelectedIndexChanged" />
</div>
<!-- </snippet8> -->