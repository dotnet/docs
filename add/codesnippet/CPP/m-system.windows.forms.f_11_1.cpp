private:
   void HorizontallyTileMyWindows( Object^ sender, System::EventArgs^ e )
   {
      // Tile all child forms horizontally.
      this->LayoutMdi( MdiLayout::TileHorizontal );
   }

   void VerticallyTileMyWindows( Object^ sender, System::EventArgs^ e )
   {
      // Tile all child forms vertically.
      this->LayoutMdi( MdiLayout::TileVertical );
   }

   void CascadeMyWindows( Object^ sender, System::EventArgs^ e )
   {
      // Cascade all MDI child windows.
      this->LayoutMdi( MdiLayout::Cascade );
   }