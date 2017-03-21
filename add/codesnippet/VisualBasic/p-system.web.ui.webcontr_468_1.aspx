      <asp:CatalogZone ID="CatalogZone1" runat="server"
        EmptyZoneText="No controls are in the zone."
        HeaderText="My Web Parts Catalog"
        InstructionText="Add Web Parts controls to the zone."
        PartLinkStyle-Font-Italic="true"
        SelectedPartLinkStyle-Font-Bold="true"
        SelectTargetZoneText="Select zone"
        AddVerb-Text="Add Control"
        CloseVerb-Description="Close and return to browse mode." 
        SelectedCatalogPartID="Currently Selected CatalogPart ID.">
        <ZoneTemplate>
          <asp:DeclarativeCatalogPart ID="DeclarativeCatalogPart1" 
            runat="server">
            <WebPartsTemplate>
              <aspSample:TextDisplayWebPart 
                runat="server"   
                id="textwebpart" 
                title = "Text Content WebPart" 
                ExportMode="All"/>  
              <asp:Calendar id="calendar1" runat="server" 
                Title="My Calendar" />               
            </WebPartsTemplate>
          </asp:DeclarativeCatalogPart> 
          <asp:PageCatalogPart ID="PageCatalogPart1" runat="server" />
          <asp:ImportCatalogPart ID="ImportCatalogPart1" runat="server" /> 
        </ZoneTemplate>
      </asp:CatalogZone>
      <hr />
      <asp:CatalogZone ID="CatalogZone2" runat="server"
        BorderWidth="2"
        HeaderText="My Empty CatalogZone"
        EmptyZoneText="No controls are in the zone." />