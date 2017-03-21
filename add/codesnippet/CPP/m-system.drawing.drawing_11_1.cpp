private:
   void DrawVerticalStringFromBottomUp( PaintEventArgs^ e )
   {
      // Create the string to draw on the form.
      String^ text = "Can you read this?";

      // Create a GraphicsPath.
      System::Drawing::Drawing2D::GraphicsPath^ path = gcnew System::Drawing::Drawing2D::GraphicsPath;

      // Add the string to the path; declare the font, font style, size, and
      // vertical format for the string.
      path->AddString( text, this->Font->FontFamily, 1, 15, PointF(0.0F,0.0F), gcnew StringFormat( StringFormatFlags::DirectionVertical ) );

      // Declare a matrix that will be used to rotate the text.
      System::Drawing::Drawing2D::Matrix^ rotateMatrix = gcnew System::Drawing::Drawing2D::Matrix;

      // Set the rotation angle and starting point for the text.
      rotateMatrix->RotateAt( 180.0F, PointF(10.0F,100.0F) );

      // Transform the text with the matrix.
      path->Transform(rotateMatrix);

      // Set the SmoothingMode to high quality for best readability.
      e->Graphics->SmoothingMode = System::Drawing::Drawing2D::SmoothingMode::HighQuality;

      // Fill in the path to draw the string.
      e->Graphics->FillPath( Brushes::Red, path );

      // Dispose of the path.
      delete path;
   }