            <asp:WebPartZone 
              ID="WebPartZone1" 
              Runat="server"
              LayoutOrientation="Vertical" >
              <EditVerb Text="Edit WebPart" />
              <SelectedPartChromeStyle BackColor="LightBlue" />
              <ZoneTemplate>
                <asp:BulletedList 
                  ID="BulletedList1" 
                  Runat="server"
                  DisplayMode="HyperLink" 
                  Title="Favorite Links" >
                  <asp:ListItem Value="http://msdn.microsoft.com">
                    MSDN
                  </asp:ListItem>
                  <asp:ListItem Value="http://www.asp.net">
                    ASP.NET
                  </asp:ListItem>
                  <asp:ListItem Value="http://www.msn.com">
                    MSN
                  </asp:ListItem>
                </asp:BulletedList>
                <asp:Calendar ID="Calendar1" Runat="server" 
                  Title="My Calendar" />
              </ZoneTemplate>
            </asp:WebPartZone>