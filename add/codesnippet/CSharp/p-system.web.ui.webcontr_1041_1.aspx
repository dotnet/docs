    <asp:EditorZone ID="EditorZone1" runat="server" 
      style="z-index: 102; left: 340px; position: absolute; top: 90px" 
      Width="170px">
      <ZoneTemplate>
        <asp:BehaviorEditorPart ID="BehaviorEditorPart1" runat="server" 
          Title="My BehaviorEditorPart"  
          OnPreRender="BehaviorEditorPart1_PreRender" />
      </ZoneTemplate>
    </asp:EditorZone>