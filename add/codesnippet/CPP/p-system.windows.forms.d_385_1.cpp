      // Draw a custom 3D border if the ToolTip is for button1.
      if ( e->AssociatedControl == button1 )
      {
         // Draw the standard background.
         e->DrawBackground();
         
         // Draw the custom border to appear 3-dimensional.
         array<Point>^ temp1 = {Point(0,e->Bounds.Height - 1),Point(0,0),Point(e->Bounds.Width - 1,0)};
         e->Graphics->DrawLines( SystemPens::ControlLightLight, temp1 );
         array<Point>^ temp2 = {Point(0,e->Bounds.Height - 1),Point(e->Bounds.Width - 1,e->Bounds.Height - 1),Point(e->Bounds.Width - 1,0)};
         e->Graphics->DrawLines( SystemPens::ControlDarkDark, temp2 );
         
         // Specify custom text formatting flags.
         TextFormatFlags sf = static_cast<TextFormatFlags>(TextFormatFlags::VerticalCenter | TextFormatFlags::HorizontalCenter | TextFormatFlags::NoFullWidthCharacterBreak);
         
         // Draw the standard text with customized formatting options.
         e->DrawText( sf );
      }