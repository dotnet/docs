      <asp:CatalogZone ID="CatalogZone1" runat="server">
        <ZoneTemplate>
          <asp:ImportCatalogPart ID="ImportCatalogPart1" 
            runat="server" 
            Title="My ImportCatalogPart" 
            OnPreRender="ImportCatalogPart1_PreRender"
            BrowseHelpText="Type a path or browse to find a control's 
              description file." 
            UploadButtonText="Upload Description File" 
            UploadHelpText="Click the button to upload the description 
              file."
            ImportedPartLabelText="My User Information WebPart" 
            PartImportErrorLabelText="An error occurred while trying 
              to import a description file."  />
        </ZoneTemplate>
      </asp:CatalogZone>