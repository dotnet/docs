            <asp:WebPartZone 
              ID="WebPartZone2"
              Runat="server" 
              DragHighlightColor="#00ff00"
              AllowLayoutChange="true"
              EmptyZoneText="Add WebParts to this empty Zone."
              BorderWidth="2"
              BorderColor="DarkBlue"
              BorderStyle="Dashed" 
              MenuLabelText="Verbs Menu" 
              MenuPopupImageUrl="label.gif" >
              <VerbStyle Font-Italic="true" />
              <MenuLabelStyle BackColor="Lime" BorderWidth="1"  />
              <MenuLabelHoverStyle Font-Bold="true" />
              <MenuVerbHoverStyle BackColor="LightGrey" />
              <MenuVerbStyle Font-Italic="true" /> 
              <ZoneTemplate>
                <asp:Label ID="Label1" Runat="server" Title="Date" />
              </ZoneTemplate>
            </asp:WebPartZone>