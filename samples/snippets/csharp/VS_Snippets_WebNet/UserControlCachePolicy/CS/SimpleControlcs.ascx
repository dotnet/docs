<%@ OutputCache Duration="60" VaryByParam="none" %>
<table style="font:10pt verdana;border-width:1;border-style:solid;border-color:black;" cellspacing="15">
<tr>
  <td>
    <b>Simple Control</b>
    <asp:Label ID="Message" runat="server" Text="<%# System.DateTime.Now %>"></asp:Label>
  </td>
</tr>
</table>
