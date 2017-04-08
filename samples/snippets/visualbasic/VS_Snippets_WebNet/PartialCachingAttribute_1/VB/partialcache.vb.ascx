<!-- <snippet5> -->
<!-- The mark-up .ascx file that displays the output of
     the partialcache.vb user control code-behind file. -->
<%@ Control language="vb" inherits="Samples.AspNet.VB.Controls.ctlMine" CodeFile="partialcache.vb.ascx.vb" %>

  <ASP:DataGrid id="MyDataGrid" runat="server"
    Width="900"
    BackColor="#ccccff"
    BorderColor="black"
    ShowFooter="false"
    CellPadding="3"
    CellSpacing="0"
    Font-Names="Verdana"
    Font-Size="8pt"
    HeaderStyle-BackColor="#aaaadd"
    EnableViewState="false"
  />

  <br />

  <i>Control last generated on:</i> <asp:label id="TimeMsg" runat="server" />
<!-- </snippet5> -->
