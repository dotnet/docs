    <asp:EditorZone ID="EditorZone1" runat="server" >
      <VerbStyle Font-Italic="true" />
      <EditUIStyle BackColor="lightgray" />
      <PartChromeStyle BorderWidth="1" />
      <LabelStyle Font-Bold="true" />
      <CancelVerb Text="Cancel Changes" />
      <ZoneTemplate>
        <asp:AppearanceEditorPart ID="AppearanceEditorPart1" 
          runat="server" />
        <asp:LayoutEditorPart ID="LayoutEditorPart1" 
          runat="server" />
      </ZoneTemplate>
    </asp:EditorZone>