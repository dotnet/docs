<!-- <snippet1> -->
<%@ page language="VB" %>
<%@ register TagPrefix="uc1" 
  TagName="DisplayModeMenuVB" 
  Src="DisplayModeMenuVB.ascx" %>
<%@ register tagprefix="aspSample" 
  Namespace="Samples.AspNet.VB.Controls" 
  Assembly="TextDisplayWebPartVB"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
    "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>ASP.NET Example</title>
</head>
<body>
  <form id="Form1" runat="server">
    <asp:webpartmanager id="WebPartManager1" runat="server" />
    <uc1:DisplayModeMenuVB ID="DisplayModeMenu1" runat="server" />
    <asp:webpartzone
      id="WebPartZone1"
      runat="server"
      title="Zone 1"
      PartChromeType="TitleAndBorder">
        <parttitlestyle font-bold="true" ForeColor="#3300cc" />
        <partstyle
          borderwidth="1px"   
          borderstyle="Solid"  
          bordercolor="#81AAF2" />
        <zonetemplate>
          <asp:Calendar ID="cal1" 
            Runat="server" />
        </zonetemplate>
    </asp:webpartzone>
    <asp:CatalogZone ID="catalogzone1" Runat="server">
      <ZoneTemplate>
        <asp:DeclarativeCatalogPart ID="catalogpart1" Runat="server">
          <WebPartsTemplate>
            <aspSample:TextDisplayWebPart 
              runat="server"   
              id="textwebpart" 
              title = "Text Content WebPart" 
              AllowClose="true" 
              CatalogIconImageUrl="MyFile.gif" /> 
          </WebPartsTemplate>
        </asp:DeclarativeCatalogPart>
      </ZoneTemplate>
    </asp:CatalogZone>
  </form>
</body>
</html>
<!-- </snippet1> -->