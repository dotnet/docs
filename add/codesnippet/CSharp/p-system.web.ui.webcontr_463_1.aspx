      <asp:CatalogZone ID="CatalogZone1" runat="server">
        <ZoneTemplate>
          <asp:PageCatalogPart ID="PageCatalogPart1" runat="server" 
            Title="My Page Catalog" 
            ChromeType="Titleonly" />
          <asp:DeclarativeCatalogPart ID="DeclarativeCatalogPart1"  
            runat="server" 
            Description="Contains a user control with Web Parts and 
              an ASP.NET Calendar control.">
            <WebPartsTemplate>
              <asp:Calendar ID="Calendar1" runat="server" 
                Title="My Calendar" 
                Description="ASP.NET Calendar control used as a personal calendar." />
              <aspSample:UserInfoWebPart 
                runat="server"   
                id="userinfo1" 
                title = "User Information WebPart"
                Description ="Contains custom, editable user information 
                  for display on a page." />
              <aspSample:TextDisplayWebPart 
                runat="server"   
                id="TextDisplayWebPart1" 
                title = "Text Display WebPart" 
                Description="Contains a label that users can dynamically update." />
            </WebPartsTemplate>              
          </asp:DeclarativeCatalogPart>
        </ZoneTemplate>
      </asp:CatalogZone>