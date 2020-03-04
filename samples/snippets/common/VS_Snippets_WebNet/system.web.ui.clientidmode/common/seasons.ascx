<%@ Control AutoEventWireup="true" %>

<script type="text/javascript">
  var seasonalSports = new Array("None selected",
                                 "Tennis",
                                 "Volleyball",
                                 "Baseball",
                                 "Skiing");

  function DisplaySport(x) {
      document.getElementById("SelectedSport").innerHTML
      = seasonalSports[x];
  }    
</script>

<asp:DropDownList ID="DropDownList1" runat="server" 
                  onchange="DisplaySport(this.selectedIndex);">
  <asp:ListItem Value="Select a season"></asp:ListItem>
  <asp:ListItem Value="Spring"></asp:ListItem>
  <asp:ListItem Value="Summer"></asp:ListItem>
  <asp:ListItem Value="Autumn"></asp:ListItem>
  <asp:ListItem Value="Winter"></asp:ListItem>
</asp:DropDownList>
<br />
<asp:Label ID="SelectedSport" runat="server" ClientIDMode="Static">
</asp:Label>
