<!-- <snippet1> -->
<%@ page language="c#" %>
<%@ register TagPrefix="uc1" 
  TagName="DisplayModeMenu" 
  Src="DisplayModecs.ascx" %>
<%@ register tagprefix="aspSample" 
  Namespace="Samples.AspNet.CS.Controls" 
  Assembly="TextDisplayWebPartCS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head id="Head1" runat="server">
    <title>
      Text Display WebPart with AppearanceEditorPart
    </title>
  </head>
  <body>
    <form id="form1" runat="server">
      <asp:webpartmanager id="WebPartManager1" runat="server" />
      <uc1:DisplayModeMenu ID="DisplayModeMenu1" runat="server" />
      <asp:webpartzone id="zone1" runat="server">
        <zonetemplate>
          <aspSample:TextDisplayWebPart 
            runat="server"   
            id="textwebpart" 
            title = "Text Content WebPart" />          
        </zonetemplate>
      </asp:webpartzone> 
      <!-- <snippet2> -->
      <asp:EditorZone ID="EditorZone1" runat="server">
        <ZoneTemplate>
          <asp:AppearanceEditorPart ID="AppearanceEditorPart1" 
            runat="server" 
            Title="Edit TextDisplayWebPart Properties" />
        </ZoneTemplate>      
      </asp:EditorZone>
      <!-- </snippet2> --> 
    </form>
  </body>
</html>
<!-- </snippet1> -->