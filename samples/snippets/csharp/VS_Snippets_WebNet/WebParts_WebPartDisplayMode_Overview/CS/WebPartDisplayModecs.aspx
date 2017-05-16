<!-- <snippet1> -->
<!-- <snippet2> -->
<%@ page language="C#" %>
<%@ register TagPrefix="uc1" 
  TagName="DisplayModeMenuCS" 
  Src="DisplayModeMenuCS.ascx" %>
<%@ register tagprefix="aspSample" 
  Namespace="Samples.AspNet.CS.Controls" 
  Assembly="TextDisplayWebPartCS"%>
<!-- </snippet2> -->
<!-- <snippet3> -->
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
void Button1_Click(object sender, EventArgs e)
{
  WebPartManager1.DisplayMode = WebPartManager.CatalogDisplayMode;
}
</script>
<!-- </snippet3> -->
<!-- <snippet4> -->
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
  <title>Web Parts Display Modes</title>
</head>
<body>
  <form id="Form2" runat="server">
    <asp:webpartmanager id="WebPartManager1" runat="server" />
    <uc1:DisplayModeMenuCS ID="DisplayModeMenu1" runat="server" />
    <asp:webpartzone
      id="WebPartZone1"
      runat="server" BackImageUrl="~/MyImage.gif">
        <zonetemplate>
          <asp:Calendar 
            ID="Calendar1" 
            Runat="server" 
            Title="My Calendar" />
        </zonetemplate>
    </asp:webpartzone>
    <asp:WebPartZone ID="WebPartZone2" Runat="server">
    </asp:WebPartZone>
    <asp:EditorZone ID="editzone1" Runat="server">
      <ZoneTemplate>
        <asp:AppearanceEditorPart 
          ID="appearanceeditor1" 
          Runat="server" />
        <asp:LayoutEditorPart 
          ID="LayoutEditorPart1" 
          Runat="server" />
      </ZoneTemplate>
    </asp:EditorZone>
    <asp:CatalogZone ID="catalogzone1" Runat="server">
      <ZoneTemplate>
        <asp:DeclarativeCatalogPart 
          ID="declarativepart1" 
          Runat="server">
          <WebPartsTemplate>
          <aspSample:TextDisplayWebPart 
            runat="server"   
            id="textwebpart" 
            title = "Text Content WebPart" AllowClose="true"/>  
          </WebPartsTemplate>
        </asp:DeclarativeCatalogPart>
      </ZoneTemplate>
    </asp:CatalogZone>
    <br />
    <asp:button
      id="button1"
      runat="server"
      text="Catalog Mode"
      OnClick="Button1_Click"
    />
  </form>
</body>
</html>
<!-- </snippet4> -->
<!-- </snippet1> -->