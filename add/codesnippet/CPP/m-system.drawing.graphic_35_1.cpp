private:
   [SecurityPermission(SecurityAction::Demand, Flags = SecurityPermissionFlag::UnmanagedCode)]            
   void AddMetafileCommentBytes( PaintEventArgs^ e )
   {
      // Create temporary Graphics object for metafile
      //  creation and get handle to its device context.
      Graphics^ newGraphics = this->CreateGraphics();
      IntPtr hdc = newGraphics->GetHdc();

      // Create metafile object to record.
      Metafile^ metaFile1 = gcnew Metafile( "SampMeta.emf",hdc );

      // Create graphics object to record metaFile.
      Graphics^ metaGraphics = Graphics::FromImage( metaFile1 );

      // Draw rectangle in metaFile.
      metaGraphics->DrawRectangle( gcnew Pen( Color::Black,5.0f ), 0, 0, 100, 100 );

      // Create comment and add to metaFile.
      array<Byte>^metaComment = {(Byte)'T',(Byte)'e',(Byte)'s',(Byte)'t'};
      metaGraphics->AddMetafileComment( metaComment );

      // Dispose of graphics object.
      delete metaGraphics;

      // Dispose of metafile.
      delete metaFile1;

      // Release handle to temporary device context.
      newGraphics->ReleaseHdc( hdc );

      // Dispose of scratch graphics object.
      delete newGraphics;

      // Create existing metafile object to draw.
      Metafile^ metaFile2 = gcnew Metafile( "SampMeta.emf" );

      // Draw metaFile to screen.
      e->Graphics->DrawImage( metaFile2, Point(0,0) );

      // Dispose of metafile.
      delete metaFile2;
   }