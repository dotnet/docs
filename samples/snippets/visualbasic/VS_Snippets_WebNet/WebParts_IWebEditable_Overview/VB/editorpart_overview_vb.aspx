<!-- <snippet7> -->
<%@ page language="vb" %>
<%@ register TagPrefix="uc1" 
  TagName="DisplayModeUC" 
  Src="DisplayModeUCvb.ascx" %>
<%@ register tagprefix="aspSample" 
  Namespace="Samples.AspNet.VB.Controls" 
  Assembly="TextDisplayWebPartVB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
  <head runat="server">
    <title>
      Text Display WebPart with EditorPart
    </title>
  </head>
  <body>
    <form id="form1" runat="server">
      <asp:webpartmanager id="WebPartManager1" runat="server" />
      <uc1:DisplayModeUC ID="DisplayModeUC1" runat="server" />
      <asp:webpartzone id="zone1" runat="server" 
        CloseVerb-Enabled="false">
        <zonetemplate>
          <aspSample:TextDisplayWebPart 
            runat="server"   
            id="textwebpart" 
            title = "Text Content WebPart" />
        </zonetemplate>
      </asp:webpartzone> 
      <asp:EditorZone ID="EditorZone1" runat="server" /> 
    </form>
  </body>
</html>
<!-- </snippet7> -->