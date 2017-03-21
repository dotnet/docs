      <asp:CatalogZone ID="CatalogZone1" Runat="server">
        <ZoneTemplate>
          <asp:DeclarativeCatalogPart ID="DeclarativeCatalogPart1" 
            Runat="server">
            <WebPartsTemplate>
              <aspSample:TextDisplayWebPart 
                runat="server"   
                id="textwebpart" 
                title = "Text Content WebPart" 
                width="350px" 
                AllowClose="true"
                ExportMode="All"
                HelpMode="Modal"
                HelpUrl="TextWebPartHelp.htm" />            
            </WebPartsTemplate>
          </asp:DeclarativeCatalogPart> 
          <asp:PageCatalogPart ID="PageCatalogPart1" Runat="server" />
        </ZoneTemplate>
      </asp:CatalogZone>