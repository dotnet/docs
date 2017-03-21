private:
   [System::Runtime::InteropServices::DllImportAttribute("user32.dll",CharSet=CharSet::Auto)]
   static bool DestroyIcon( IntPtr handle );

private:
   [SecurityPermission(SecurityAction::Demand, Flags=SecurityPermissionFlag::UnmanagedCode)]
   void GetHicon_Example( PaintEventArgs^ e )
   {
      
      // Create a Bitmap object from an image file.
      Bitmap^ myBitmap = gcnew Bitmap( "c:\\FakePhoto.jpg" );
      
      // Draw myBitmap to the screen.
      e->Graphics->DrawImage( myBitmap, 0, 0 );
      
      // Get an Hicon for myBitmap.
      IntPtr Hicon = myBitmap->GetHicon();
      
      // Create a new icon from the handle. 
      System::Drawing::Icon^ newIcon = ::Icon::FromHandle( Hicon );
      
      // Set the form Icon attribute to the new icon.
      this->Icon = newIcon;
      
      // You can now destroy the Icon, since the form creates
      // its own copy of the icon accesible through the Form.Icon property.
      DestroyIcon( newIcon->Handle );
   }