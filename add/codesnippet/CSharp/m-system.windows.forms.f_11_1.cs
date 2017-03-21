private void HorizontallyTileMyWindows (object sender, System.EventArgs e)
 {
    // Tile all child forms horizontally.
    this.LayoutMdi( MdiLayout.TileHorizontal );
 }
 
 private void VerticallyTileMyWindows (object sender, System.EventArgs e)
 {
    // Tile all child forms vertically.
    this.LayoutMdi( MdiLayout.TileVertical );
 }
 
 private void CascadeMyWindows (object sender, System.EventArgs e)
 {
    // Cascade all MDI child windows.
    this.LayoutMdi( MdiLayout.Cascade );
 }
    