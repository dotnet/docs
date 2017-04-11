<!-- <snippet5> -->
<!-- The mark-up .ascx file that displays the output of
     the partialcache.cs user control code-behind file. -->
<%@ Control language="C#" inherits="Samples.AspNet.CS.Controls.ctlMine" CodeFile="partialcache.cs.ascx.cs" %>

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
