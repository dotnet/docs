<!-- <snippet1> -->
<%@ page language="C#" %>
<%@ register TagPrefix="uc1" 
  TagName="DisplayModeMenuCS" 
  Src="DisplayModeMenuCS.ascx" %>
<%@ register tagprefix="aspSample" 
  Namespace="Samples.AspNet.CS.Controls" 
  Assembly="ZoneWebPartsCS"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

</script>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
  <form id="Form1" runat="server">
    <asp:webpartmanager id="WebPartManager1" runat="server" />
    <uc1:DisplayModeMenuCS ID="DisplayModeMenu1" runat="server" />
    <asp:webpartzone
      id="WebPartZone1"
      runat="server"
      title="Zone 1"
      PartChromeType="TitleAndBorder">
        <parttitlestyle font-bold="true" ForeColor="#3300cc"/>
        <partstyle
          borderwidth="1px"   
          borderstyle="Solid"  
          bordercolor="#81AAF2" />
        <ZoneTemplate>
          <aspSample:CalendarWebPart 
            runat="server"   
            id="CalendarWebPart1" 
            Title="Calendar WebPart"
            />         
        </ZoneTemplate>
    </asp:webpartzone>
    <asp:webpartzone
      id="WebPartZone2"
      runat="server"
      title="Zone 2"
      PartChromeType="TitleAndBorder"
      EmptyZoneText="Empty Zone">
        <parttitlestyle font-bold="true" ForeColor="#3300cc"/>
        <partstyle
          borderwidth="1px"   
          borderstyle="Solid"  
          bordercolor="#81AAF2" />
    </asp:webpartzone>
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
    <asp:CatalogZone ID="catalogzone1" Runat="server" >
      <ZoneTemplate>
        <asp:DeclarativeCatalogPart 
          ID="declarativepart1" 
          Runat="server">
          <WebPartsTemplate>
          <aspSample:LinksWebPart 
            runat="server"   
            id="linkswebpart" 
            Title="Favorite Links"
            />  
          </WebPartsTemplate>
        </asp:DeclarativeCatalogPart>
      </ZoneTemplate>
    </asp:CatalogZone>
    <br />
  </form>
</body>
</html>
<!-- </snippet1> -->