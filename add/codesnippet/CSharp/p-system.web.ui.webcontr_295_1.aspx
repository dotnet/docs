      <asp:EditorZone ID="EditorZone1" runat="server">
        <ZoneTemplate>
          <asp:PropertyGridEditorPart ID="PropertyGridEditorPart1" 
            runat="server" 
            Title="Edit Custom Properties"
            OnPreRender="PropertyGridEditorPart1_PreRender" 
            OnInit="PropertyGridEditorPart1_Init" />   
        </ZoneTemplate>
      </asp:EditorZone>