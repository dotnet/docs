<!-- <snippet12> -->
<%@ page language="vb" %>
<%@ register TagPrefix="uc1" 
  TagName="DisplayModeMenu" 
  Src="DisplayModevb.ascx" %>
<%@ register tagprefix="aspSample" 
  Namespace="Samples.AspNet.VB.Controls" 
  Assembly="TextDisplayWebPartVB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>
      Text Display WebPart with EditorPart
    </title>
  </head>
  <body>
    <form id="form1" runat="server">
      <asp:webpartmanager id="WebPartManager1" runat="server" />
      <uc1:DisplayModeMenu ID="DisplayModeMenu1" runat="server" />
      <asp:webpartzone id="zone1" runat="server" 
        CloseVerb-Enabled="false">
        <zonetemplate>
          <aspSample:TextDisplayWebPart 
            runat="server"   
            id="textwebpart" 
            title = "Text Content WebPart" />          
        </zonetemplate>
      </asp:webpartzone> 
      <!-- <snippet13> -->
      <asp:EditorZone ID="EditorZone1" runat="server">
        <ZoneTemplate>
          <asp:AppearanceEditorPart ID="AppearanceEditorPart1" 
            runat="server" />
          <asp:LayoutEditorPart ID="LayoutEditorPart1" 
            runat="server" />
        </ZoneTemplate>      
      </asp:EditorZone>
      <!-- </snippet13> --> 
    </form>
  </body>
</html>
<!-- </snippet12> -->